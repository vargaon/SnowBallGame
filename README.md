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
Barva: fialová.

Zvětší velikost hráče a zmeší jeho rychlost pohybu.

### DwarfSize
Barva: fialová.

Zmenší velikost hráče a zvětší jeho rychlost pohybu.

### JumpBoost
Barva: modrá.

Zvětší výšku a rychlost hráčova skoku.

### Protection
Barva: zelená.

Zvětší hráčovu obranu vůči protihráčovým koulím. Odražení je menší.

### ExtraLive
Barva: červená.

Přidá hráči jeden život.

### ReverseGravity
Barva: bílá.

Obrátí hráčovu gravitaci. Ovládání zůstane stejné. Hráč padá směrem nahoru a skáče směrem dolů. Pokud se hráč dostane mimo hrací plochu jinak než pádem přes dolní okraj, bonus je odebrát a hráčovi se navrátí původní gravitace.

### JellyBall
Barva: žlutá.

Hráč hází vetší a pomalejší koule, které mají sníženou odrazovost.

### SpeedBall
Barva: žlutá.

Hráč hazí menší a rychlejší koule, které mají zvetšenou odrazovost.

## Průběh práce
Na začátku jsem si sepsal základní osnovu toho, co budu dělat. Vytvořil jsem si jednoduchý herní panel s pár platformami a jedním hráčem v návrháři formulářové aplikace.
 
Poté jsem začal řešit způsob ovládání hráčů. Vytvořil jsem si slovník kláves ovládání s hodnotou `true` nebo `false` pokud byla klávesa zmáčknutá. Slovník se aktualizuje pomocí vhodně přepsaných metod formuláře. Dále jsem si vytvořil základní třídu `Game`, která má odkaz na tento slovník a třídu `Player`, která představuje hráče. 

Třída game pracuje s instancí třídy `PlayerMovementEngine` která pohybuje s hráčem. Pohyby jsou prováděny sekvenčně pomocí interního timeru, který má nastavený interval na 20ms. Engine udává způsob pohybu hráče, avšak vlastnosti pohybu má u sebe uložený hráč. Dlouho jsem přemýšlel, jakým způsobem udělat pohyb hráče a gravitaci ve hře, nakonec využívám pomocné čítače, kteří mění svoji hodnotu podle délky trvání daného pohybu.

Další na řadě bylo házení koulí. Koule mají svůj vlastní `BallMovementEngine` který jimi pohybuje. Koule jsou opět prvky formuláře, jenž mění svojí pozici v závislosti na čase. Pro identifikaci, jestli koule narazila do hráče používám vhodnou metodu na prvku formuláře.

Po vyřešení základní fyziky hry jsem konečně začal přidávat zábavnější prvky. Více hráčů, komplikovanější hrací pole a bonusy. Poté jsem začal pracovat na začátečním nastavení hráče. Navrhl jsem vhodný design a umístil všechny potřebné ovládací prvky ve formulářovém návrháři. Myslím si, že nastavení hráče je snadné a funguje dobře.

Kompozici mého kódu jsem v průběhu práce několikrát změnil, tak aby byla co nejintuitivnější a aby byly splněny všechny požadavky. Snažil jsem se co nejvíce využít principu delegátů a lambda funkcí pro zpřehlednění a zefektivnění kódu. Využil jsem i princip generických metod a typů při práci s pohyblivými prvky nebo vytváření různých typů koulí. Vzhledem k členitosti mého kódu jsem využil i abstraktních tříd pro to abych se v kódu moc neopakoval a také `factory design patern`, který mi pomáhá s tvoření různorodých instancí koulí, hráčů nebo bonusů.

Nakonec jsem zdokumentoval veškeré veřejné metody a vlastnosti a vytvořil finální design hry.

## Co nebylo doděláno
Během vytváření této hry mě napadlo spoustu nápadů, jak hru udělat ještě zábavnější a hratelnější. Mezi ty hlavní určitě patří online komunikace, aby hráči mohli hrát proti sobě na různých počítačích a nemuseli se dělit o jednu klávesnici a také jednoduchá umělá inteligence, která by hrála proti vám a snažila se vás shodit.

Co se týče větší různorodosti ve hře. Nestihl jsem přidat více typů koulí nebo jejich speciální způsob pohybu. Například že by hozené koule podléhali také gravitaci. Dále jsem chtěl přidat bonus s dvojitým skokem a také ukazatele počtu hozených koulí a dobu trvání bonusu v profilu hráče. 

S některými nedostatky jsem se však nemohl smířit a důkazem toho je i bonus změny gravitace, který jsem přidal v průběhu psaní dokumentace a hru to velice ozvláštnilo.

## Závěr
Práce na hře mě velice bavila a díky tomuto projektu jsem si mohl vyzkoušet spoustu nových věcí a více si osvojit jazyk C#.  Doufám, že budu mít v budoucnu ještě příležitost se k projektu vrátit a dodělat věci které jsem nestihl.
