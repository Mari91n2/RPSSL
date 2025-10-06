using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace RPSLSGame;

public partial class MainWindow : Window
{
    private enum Symbol { Rock, Paper, Scissors, Lizard, Spock }
    private enum RoundResult { Draw, PlayerWins, ComputerWins }

    private readonly Random _rng = new();
    private int _playerPoints = 0;
    private int _computerPoints = 0;
    private const int PointsToWin = 3;

    private TextBlock? _txtStatus;
    private TextBlock? _txtSummary;
    private TextBlock? _txtScore;

    public MainWindow()
    {
        InitializeComponent();

        // Hent de relevante UI-elementer
        _txtStatus = this.FindControl<TextBlock>("TxtInfo");
        _txtSummary = this.FindControl<TextBlock>("TxtChoices");
        _txtScore = this.FindControl<TextBlock>("TxtScore");

        // Tilknyt knapper
        HookUpButtons();

        // Første visning
        ShowWelcomeMessage();
    }

    private void HookUpButtons()
    {
        // Spilknapper
        foreach (var name in new[] { "BtnRock", "BtnPaper", "BtnScissors", "BtnLizard", "BtnSpock" })
        {
            this.FindControl<Button>(name).Click += PlayerMadeChoice;
        }

        // Kontrolknapper
        this.FindControl<Button>("BtnRestart").Click += RestartGame;
        this.FindControl<Button>("BtnExit").Click += (_, _) => Close();
    }

    private void PlayerMadeChoice(object? sender, RoutedEventArgs e)
    {
        if (GameIsFinished()) return;

        var playerBtn = (Button)sender!;
        var playerChoice = ConvertToSymbol(playerBtn.Content!.ToString()!);
        var computerChoice = (Symbol)_rng.Next(Enum.GetValues(typeof(Symbol)).Length);

        var outcome = DecideRoundWinner(playerChoice, computerChoice);
        HandleRoundResult(playerChoice, computerChoice, outcome);
    }

    private static Symbol ConvertToSymbol(string text) => text.ToLower() switch
    {
        "rock" => Symbol.Rock,
        "paper" => Symbol.Paper,
        "scissors" => Symbol.Scissors,
        "lizard" => Symbol.Lizard,
        "spock" => Symbol.Spock,
        _ => throw new InvalidOperationException("Ugyldigt valg fra knap.")
    };

    private RoundResult DecideRoundWinner(Symbol player, Symbol computer)
    {
        if (player == computer)
            return RoundResult.Draw;

        bool playerWins =
            (player == Symbol.Rock && (computer == Symbol.Scissors || computer == Symbol.Lizard)) ||
            (player == Symbol.Paper && (computer == Symbol.Rock || computer == Symbol.Spock)) ||
            (player == Symbol.Scissors && (computer == Symbol.Paper || computer == Symbol.Lizard)) ||
            (player == Symbol.Lizard && (computer == Symbol.Spock || computer == Symbol.Paper)) ||
            (player == Symbol.Spock && (computer == Symbol.Rock || computer == Symbol.Scissors));

        return playerWins ? RoundResult.PlayerWins : RoundResult.ComputerWins;
    }

    private void HandleRoundResult(Symbol player, Symbol computer, RoundResult result)
    {
        string message;

        switch (result)
        {
            case RoundResult.PlayerWins:
                _playerPoints++;
                message = $"Du vandt runden!  {player} besejrer {computer}.";
                break;

            case RoundResult.ComputerWins:
                _computerPoints++;
                message = $"Computeren vinder runden  – {computer} slår {player}.";
                break;

            default:
                message = $"Lige runde! Begge valgte {player}.";
                break;
        }

        _txtStatus!.Text = message;
        _txtSummary!.Text = $"Du: {player}  |  Computer: {computer}";
        _txtScore!.Text = $"Stillingen: Du {_playerPoints} - {_computerPoints} Computer";

        if (GameIsFinished())
        {
            _txtStatus.Text = _playerPoints > _computerPoints
                ? "Tillykke, du vandt hele spillet! 🏆"
                : "Computeren tog sejren denne gang. Prøv igen!";
        }
    }

    private bool GameIsFinished() => _playerPoints >= PointsToWin || _computerPoints >= PointsToWin;

    private void RestartGame(object? sender, RoutedEventArgs e)
    {
        _playerPoints = 0;
        _computerPoints = 0;
        ShowWelcomeMessage();
    }

    private void ShowWelcomeMessage()
    {
        _txtStatus!.Text = "Vælg et symbol for at begynde spillet.";
        _txtSummary!.Text = "Du: -  |  Computer: -";
        _txtScore!.Text = $"Stillingen: Du {_playerPoints} - {_computerPoints} Computer";
    }
}
