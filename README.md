# 🏰 3D Tower Defense

Egy stratégiai 3D tower defense játék Unity-ben, ahol védd meg a bázisod az egyre erősebb ellenséges hullámok ellen!

---

## 🎮 Játékmenet

### Cél
Állítsd meg az ellenséges egységeket mielőtt elérik a bázisod! Építs tornyokat, gyűjts coinokat és maradj életben minél tovább.

### Csapatok
| Csapat | Szín | Viselkedés |
|--------|------|------------|
| Játékos | 🔵 Kék | Tornyok építése |
| Ellenség | 🔴 Piros | Automatikus útvonalakon halad |

---

## ⚔️ Ellenségek

Az ellenségek **3 különböző útvonalon** közelítenek (Path A, B, C) és egyre erősebbek spawnolnak.

| Egység | Élet (HP) | Sebzés | Jutalom | Sebesség |
|--------|-----------|--------|---------|----------|
| 🗡️ Knight | 4 | 1 | 10 coin | Gyors |
| 🧙 Wizard | 8 | 2 | 20 coin | Közepes |
| 👹 Grunt | 15 | 3 | 35 coin | Lassú |
| 🪨 Golem | 30 | 5 | 50 coin | Nagyon lassú |

### Feloldási rendszer
- **Kezdetben:** Csak Knight spawnol
- **10 Knight megölése után:** Wizard is spawnol
- **10 Wizard megölése után:** Grunt is spawnol
- **10 Grunt megölése után:** Golem is spawnol

Minden ellenségnek **Health Bar** jelzi az életerejét!

---

## 🗼 Tornyok

| Torony | Sebzés | Ár |
|--------|--------|-----|
| 🏹 Alap torony | 3 | 50 coin |

A tornyokat előre meghatározott **TurretPlace** helyekre lehet építeni.

---

## 💎 Treasure Chest rendszer

A pályán **véletlenszerűen** megjelenik egy kincsesláda:

| Tulajdonság | Érték |
|-------------|-------|
| Spawn idő | 10-30 másodperc között |
| Életidő | 30 másodperc |
| Jutalom | **+100 coin** |

- A chest **random ChestPlace** pozíción jelenik meg
- Ha **rákattintasz** időben: +100 coin
- Ha **nem kattintasz** 30 másodpercen belül: eltűnik

---

## 💰 Coin rendszer

### Kezdő coin: 100

### Bevétel
| Forrás | Coin |
|--------|------|
| Knight megölése | +10 |
| Wizard megölése | +20 |
| Grunt megölése | +35 |
| Golem megölése | +50 |
| Treasure Chest | +100 |

### Kiadások
| Építmény | Ár |
|----------|-----|
| Torony | 50 coin |

---

## ❤️ Játékos élet

- Az ellenségek **sebzik a játékost** ha elérik az útvonal végét
- Minden egységnek más a sebzése (Knight: 1, Wizard: 2, Grunt: 3, Golem: 5)
- Ha az élet **0-ra csökken**: Game Over

---

## 🗺️ Pálya felépítés

- **3 útvonal** (Path A, B, C) - az ellenségek random választanak
- **TurretPlace-ek** - ide építhetsz tornyokat
- **ChestPlace-ek** - itt jelenhet meg a kincsesláda

---

## 🏆 Győzelmi/Vesztési feltételek

| Eredmény | Feltétel |
|----------|----------|
| ❌ **Game Over** | A játékos élete 0-ra csökken |
| 🔄 **Try Again** | Újrakezdheted a pályát |

---

## 🎨 Vizuális jellemzők

- **3D grafika** Unity engine-nel
- **Health Bar** minden ellenségen
- **Színkódolás** - piros ellenségek, kék játékos tornyok
- **Gizmos** - Scene nézetben látható spawn helyek (sárga)

---

## 🛠️ Technológiák

- **Game Engine:** Unity 6
- **Render Pipeline:** Universal Render Pipeline (URP)
- **Programozási nyelv:** C#
- **UI:** TextMeshPro

---

## 📁 Script struktúra

| Script | Funkció |
|--------|---------|
| `GameManager.cs` | Coin kezelés, Game Over |
| `Spawner.cs` | Ellenség spawnolás, unlock rendszer |
| `EnemyMovement.cs` | Ellenség mozgás, HP, halál |
| `Turret.cs` | Torony célzás, lövés |
| `Bullet.cs` | Lövedék mozgás, sebzés |
| `BuildManager.cs` | Torony építés |
| `TurretPlace.cs` | Torony helyek |
| `ChestSpawner.cs` | Chest spawnolás |
| `ChestPlace.cs` | Chest helyek |
| `TreasureChest.cs` | Chest felvétel |
| `PlayerHealth.cs` | Játékos élet |

---

## 👥 Készítők

- André Lili
- Mariotti Lili
- Góga Dávid
- Istvanovszki Zsombor

---

## 📄 Licenc

Ez a projekt tanulmányi célokra készült.
