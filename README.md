# 🏰 3D Tower Defense

Egy stratégiai 3D tower defense játék Unity-ben, ahol a cél a pálya közepén található kincsesláda megszerzése az ellenség előtt.

---

## 🎮 Játékmenet

### Cél
A pálya közepén található **kincsesláda** elérése az ellenség előtt. Aki előbb kinyitja a ládát, az nyer!

### Csapatok
| Csapat | Szín | Irányítás |
|--------|------|-----------|
| Játékos | 🔵 Kék | Manuális |
| Ellenség | 🔴 Piros | Automatikus (AI) |

---

## ⚔️ Egységek

### Katonák

| Egység | Élet (HP) | Sebzés | Ár |
|--------|-----------|--------|-----|
| 🗡️ Sima katona | 4 | 1 | 10 coin |
| 🧙 Varázsló | 8 | 2 | 15 coin |

### Katapultok (Tornyok)

| Katapult | Sebzés | Ár |
|----------|--------|-----|
| 🪨 Sima katapult | 3 | 20 coin |
| 🔥 Tüzes katapult | 5 | 25 coin |

---

## 💰 Coin rendszer

### Bevétel
- Ellenséges **sima katona** megölése: **+5 coin**
- Ellenséges **varázsló** megölése: **+10 coin**

### Kiadások
- Egységek és katapultok vásárlása a fent megadott árakon

---

## 📈 Nehézségi rendszer

A játék **dinamikusan nehezedik** a játékos katapultjainak függvényében:

| Játékos katapultjai | Ellenség spawnja |
|---------------------|------------------|
| Nincs katapult | Csak sima katonák |
| 1 sima katapult | Több sima katona |
| 2 katapult (vegyes) | Sima katonák + néha varázslók |
| 1 sima + 1 tüzes | Több varázsló, kevesebb sima katona |
| 2 tüzes katapult | Csak varázslók |

Az ellenség AI szintén **erősíti saját katapultjait** a játék előrehaladtával.

---

## 🗺️ Pálya felépítés

```
[Ellenség spawn]
        |
   [Katapult hely 1] [Katapult hely 2]  ← Ellenség oldal
        |
        |
   [💎 KINCSESLÁDA 💎]  ← Pálya közepe
        |
        |
   [Katapult hely 3] [Katapult hely 4]  ← Játékos oldal
        |
 [Játékos spawn]
```

- **4 katapult hely** összesen
- **2 hely** az ellenség oldalán
- **2 hely** a játékos oldalán
- Az egységek **fix vonalon** mozognak a kincsesláda felé

---

## 🏆 Győzelmi/Vesztési feltételek

| Eredmény | Feltétel |
|----------|----------|
| ✅ **Győzelem** | A játékos egysége elsőként éri el és nyitja ki a kincsesládát |
| ❌ **Vereség** | Az ellenség egysége elsőként éri el és nyitja ki a kincsesládát |

---

## 🎨 Vizuális jellemzők

- **3D grafika** Unity engine-nel
- **Animált egységek** - a katonák és varázslók mozgása animált
- **Fix útvonal** - az egységek előre meghatározott útvonalon haladnak
- **Színkódolás** - kék (játékos) vs piros (ellenség) megkülönböztetés

---

## 🛠️ Technológiák

- **Game Engine:** Unity
- **Render Pipeline:** Universal Render Pipeline (URP)
- **Programozási nyelv:** C#

---

## 👥 Készítők

- André Lili
- Mariotti Lili
- Góga Dávid
- Istvanovszki Zsombor

---

## 📄 Licenc

Ez a projekt tanulmányi célokra készült.
