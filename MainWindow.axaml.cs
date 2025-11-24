using Avalonia.Controls;
using System;

namespace AvaloniaApplication3
{
    public partial class MainWindow : Window
    {
        // enum med figurerne (krav fra opgaven på lærerens hjemmeside)
        // her laver jeg de 5 shapes som man kan vælge i RPSSL
        private enum Shape
        {
            Rock,
            Paper,
            Scissors,
            Lizard,
            Spock
        }

        // enum til  resultat
        private enum RoundResult
        {
            Win,
            Lose,
            Tie
        }

        // variabler
        private Random rnd = new Random();
        private int humanScore = 0;
        private int agentScore = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        // når man klikker på en af knapperne
        private void OnPlayerClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            // knap-teksten er figuren
            string valg = (sender as Button)!.Content!.ToString()!;
            Shape human = Enum.Parse<Shape>(valg);

            // agent vælger random
            Shape agent = (Shape)rnd.Next(0, 5);
            AgentValgText.Text = $"Agent valg: {agent}";

            // jeg kalder resolve som afgør hvem der vinder
            RoundResult res = Resolve(human, agent);

            if (res == RoundResult.Win)
            {
                ResultatText.Text = "Resultat: Du vandt!";
                humanScore++;
            }
            else if (res == RoundResult.Lose)
            {
                ResultatText.Text = "Resultat: Du tabte!";
                agentScore++;
            }
            else
            {
                ResultatText.Text = "Resultat: Uafgjort.";
            }

            ScoreText.Text = $"Stilling: Dig {humanScore} - Agent {agentScore}";
        }
        // funktion der afgør hvem der vinder runden
        // logikken her kommer FRA lærerens hjemmeside:
        // han giver tabellen: p2 - p1 = (-4, -2, 1, 3) betyder p1 vinder
        // resten betyder p1 taber
        //
        // selve opsætningen af funktionen har jeg lavet, men
        // tabel-logikken kommer fra undervisningsmaterialet
        private RoundResult Resolve(Shape p1, Shape p2)
        {
            if (p1 == p2)
                return RoundResult.Tie;
            
            // regner forskel mellem figurer (fra lærerens RPSSL tabel)


            int diff = (int)p2 - (int)p1;
 
            // her bruger jeg tabelværdierne
            // dette er det eneste sted der var lidt svært, så dette lavede jeg med hjælp fra ChatGPT
            switch (diff)
            {
                case -4:
                case -2:
                case 1:
                case 3:
                    return RoundResult.Win;

                default:
                    return RoundResult.Lose;
            }
        }
    }
}

