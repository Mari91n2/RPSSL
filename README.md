Dette projekt er en simpel implementering af spillet **Rock, Paper, Scissors, Spock, Lizard (RPSSL)** i C#.  
Formålet er at vise, hvordan man kan oversætte et flowchart til C#-kode og forstå de vigtigste sprogelementer.

---
Spillet følger denne logik:

1. Start spillet  
2. Spiller vælger et tegn (rock, paper, scissors, spock, lizard)  
3. Computeren vælger et tilfældigt tegn  
4. Tegnene sammenlignes efter RPSSL-reglerne  
5. Vinderen af runden får 1 point  
6. Tjek: har en spiller nået **winningScore**?  
   - Ja → afslut og sig hvem der har vundet  
   - Nej → gå tilbage til trin 2  
---

1. Åbn projektet i **Rider** eller Visual Studio  
2. Sørg for, at `Program.cs` indeholder koden  
3. Tryk **Run**´
4. Følg instruktionerne i konsollen og spil mod computeren  

---
Spillets regler
- Rock slår Scissors og Lizard  
- Paper slår Rock og Spock  
- Scissors slår Paper og Lizard  
- Spock slår Rock og Scissors  
- Lizard slår Spock og Paper  
