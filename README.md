# API C# .NET N-Tier

## 🧱 Structure du projet

Le projet suit une architecture **N-Tier (multi-couches)** claire et découplée :

```
API → BLL → DAL → Domain
```

### 📂 Couches

| Projet | Références autorisées | Rôle |
|--------|------------------------|------|
| **N_Tier.API** | → `N_Tier.BLL`<br>→ `N_Tier.Domain` *(optionnel, pour modèles simples)* | Expose les endpoints, gère les contrôleurs, la configuration et l’injection de dépendances. |
| **N_Tier.BLL** | → `N_Tier.DAL`<br>→ `N_Tier.Domain` | Contient la logique métier, les services, les DTOs et les managers. |
| **N_Tier.DAL** | → `N_Tier.Domain` | Gère la persistance des données (Entity Framework Core, repositories, migrations, `ApplicationDbContext`). |
| **N_Tier.Domain** | *(aucune référence)* | Contient les entités, enums et interfaces abstraites de base. |

### ⚠️ Interdictions

- ❌ `API ↛ DAL` (sauf pour l’injection de dépendances EF Core)  
- ❌ `DAL ↛ BLL`  
- ❌ `Domain ↛ autre`

Cette structure garantit un découplage fort et une maintenabilité optimale.


---

## 🚀 Démarrage rapide

### 1️⃣ Prérequis

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [Entity Framework Core Tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)

Vérifie les installations :
```bash
dotnet --version
docker --version
```

---

### 2️⃣ Installation du projet

Cloner le dépôt :
```bash
git clone https://github.com/GastonDeSade/N-Tier.git
cd N-Tier
```

Restaurer les dépendances :
```bash
dotnet restore
```

---

### 3️⃣ Configuration de la base de données

Assure-toi que le projet de démarrage est bien **N_Tier.API**, car il contient la configuration de connexion et le contexte EF Core.

Créer une migration initiale :
```bash
dotnet ef migrations add Init --startup-project ../N_Tier.API
```

Appliquer la migration à la base de données :
```bash
dotnet ef database update --startup-project ../N_Tier.API
```

🧩 Ces deux commandes permettent de :
- **Créer la structure initiale de la base de données** selon les entités du projet Domain.  
- **Appliquer les migrations** via EF Core en pointant sur le projet de démarrage (`N_Tier.API`).

---

### 4️⃣ Lancement du projet

Lancer l’API localement :
```bash
dotnet run --project N_Tier.API
```

L’API sera accessible à :
```
https://localhost:5001
```
ou  
```
http://localhost:5000
```

---

### 5️⃣ Lancement via Docker

Démarrer les conteneurs Docker (API + Base de données, selon le `docker-compose.yml`) :
```bash
docker compose up -d
```

🧱 Cette commande :
- Lance tous les services définis dans le fichier `docker-compose.yml`.  
- Met en place l’environnement complet (API, base de données, dépendances externes).  
- Permet de tester la solution sans installation locale spécifique.

---

## ✅ Résumé de la structure

```
/N_Tier.API      → Contrôleurs, configuration, DI, endpoints REST
/N_Tier.BLL      → Logique métier, services, DTOs
/N_Tier.DAL      → Repositories, DbContext, migrations EF Core
/N_Tier.Domain   → Entités, enums, interfaces
```
