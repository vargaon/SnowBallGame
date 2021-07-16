# SnowBall Game

## Anotace
SnowBall Game je hra inspirovaná hrou "*Gun and Mayhem 2*".

Hru hraje 2 až 4 hráčů proti sobě a snaží se protihráče trefit sněhovou koulí a shodit je tak z platformy, na které stojí.

Na herní ploše se během hry náhodně objevují různé bonusy, které hráči mohou sebrat a stát se tak silnějšími nebo naopak slabšími.

Hráči během hry sbírají body za trefení hráče nebo sebrání bonusu. O body přichází, když spadnou z platformy.

Cílem hry je zůstat jako poslední a nasbírat přitom co nejvíce bodů.

## Přesné zadání
Jedná se okenní aplikaci psanou v jazyce C# s architekturou .NET Framework 4.8.

Aplikace zahrnuje učivo probírané v obou částích předmětu jako je objektový návrh, delegáti, LINQ, generické metody a třídy.

Hra spadá do kategorie arkádové skákací hry.

Hráči hrají proti sobě na jednom PC a jedné klávesnici. Hráči si na začátku hry zvolí ovládací klávesy, jméno a barvu své postavy (avatara). Hráč ovládá svého avatara pomocí zvolených kláves a snaží se pomocí hozených koulí shodit protihráče. Poté co hráč spadne z platforem, ubere se mu jeden život a pokud mu nějaké zbývají dopadne náhodně na nějakou platformu, jinak ve hře končí. Vyhrává ten, kdo zůstane poslední.

## Hra
### Nastavení
Hru můžou hrát **2 až 4** hráči. Počet hráčů je možné měnit pomocí tlačítek `Add Player` a `Remove`.

Hráči si na začátku hry nastaví své ovládací klávesy, jméno a barvu svého avatara.

**Ovládací klávesy** si hráč navolí pomocí kliknutí do textového pole vedle názvu typu pohybu nebo hodu a stiskne danou klávesu. Daný pohyb lze ovládat pouze jednou klávesou. 

Možné pohyby jsou :
- skok (`Jump`) 
- doleva (`Left`)
- doprava (`Right`)
- dolů (`Down`) 

A poté ještě klávesa pro házení koulí (`Throw`). 

**Barvu** svého avatara si lze zvolit kliknutím na barevný čtverec na kartě hráče. Po kliknutí se zobrazí dialogové okno, kde si hráč může zvolit z nabízených barev. Nejsou povolené vlastní barvy a barva černá z důvodu černého pozadí herní plochy.

**Jméno** hráče si lze zvolit opět v textovém poli v horní části karty hráče.

### Pravidla
Hráči se na platformách pohybují pomocí zvolených kláves. Ve hře působí gravitace a pokud hráč pod sebou nemá pevnou platformu tak padá. Hráči se mezi platformami pohybují pomocí skoků. Skočit lze pouze jednou a další skok je možný až když hráč stojí na nějaké z platforem. Skoku není nijak bráněno, je možné provést skok pod platformou a dostat se tak výše.

Každý hráč začíná hru se třemi životy a základní koulí nazvanou `snowball`.

Hráči během hry mohou sbírat bonusy, které se vždy objevují náhodně na nějaké platformě. Bonusy hráči umožňují například házet jinými typy koulí, pohybovat se rychleji nebo skákat rychleji. Bonusy se dělí na dva typy `PlayerBonus` a `BallBonus`. BallBonus je omezen počtem koulí které hráč hodí, po **8** hozených koulích lepšího typu se hráči nastaví opět základní koule snowball. PlayerBonus je omezen časem **6 sekund**. Pokud hráč ztratí život, přijde o všechny bonusy. Když má hráč aktivní bonus a sebere bonus stejného typu, bonus se přepíše na nový a obnoví se trvání bonusu.

Hráči během hry sbírají body za trefení proti hráče **(+5)** nebo sebrání bonusu **(+2)**. Body ztrácejí, pokud spadnou z platforem a ztratí život **(-4)**. 

Počet životů, bodů a informace o sebraných bonusech je možné vidět ve spodní části herního panelu. Každý hráč zde má svůj profil, který zmizí, pokud již hráč nemá životy.

## Bonusy

### GiantSize

### DwarfSize

### JumpBoost

### Protection

### ExtraLive

### ReverseGravity

### JellyBall

### SpeedBall

## Průběh práce

## Co nebylo doděláno

## Závěr
