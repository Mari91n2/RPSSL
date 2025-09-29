// See https://aka.ms/new-console-template for more information

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Velkommen til RPSSL (Rock, Paper, Scissors, Spock, Lizard)!");
        
        int playerScore = 0;
        int computerScore = 0;
        int winningScore = 3;

        string[] choices = { "rock", "paper", "scissors", "spock", "lizard" };
        Random random = new Random();

        while (playerScore < winningScore && computerScore < winningScore)
        {
            Console.WriteLine("Vælg: rock, paper, scissors, spock eller lizard");
            string playerChoice = Console.ReadLine().ToLower();

            string computerChoice = choices[random.Next(choices.Length)];
            Console.WriteLine($"Computeren valgte: {computerChoice}");

            if (playerChoice == computerChoice)
            {
                Console.WriteLine("Uafgjort! Ingen point.");
            }
            else if (
                (playerChoice == "rock" && (computerChoice == "scissors" || computerChoice == "lizard")) ||
                (playerChoice == "paper" && (computerChoice == "rock" || computerChoice == "spock")) ||
                (playerChoice == "scissors" && (computerChoice == "paper" || computerChoice == "lizard")) ||
                (playerChoice == "spock" && (computerChoice == "rock" || computerChoice == "scissors")) ||
                (playerChoice == "lizard" && (computerChoice == "spock" || computerChoice == "paper"))
            )
            {
                Console.WriteLine("Du vinder runden!");
                playerScore++;
            }
            else
            {
                Console.WriteLine("Computeren vinder runden!");
                computerScore++;
            }

            Console.WriteLine($"Stilling: Spiller {playerScore} - Computer {computerScore}\n");
        }

        if (playerScore == winningScore)
            Console.WriteLine("Tillykke! Du har vundet spillet!");
        else
            Console.WriteLine("Computeren har vundet spillet!");
    }
}