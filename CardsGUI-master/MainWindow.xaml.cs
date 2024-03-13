using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CardsGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int numberOfPlayers; // number of players in current game
        List<Player> players = new List<Player>(); // list of objects containing player data
        CardTable cardTable = new CardTable(); // object in charge of displaying game information
        Deck deck = new Deck(); // deck of cards
        int currentPlayer = 0; // current player on list
        public Task nextTask; // keeps track of game state
        private bool cheating = false; // lets you cheat for testing purposes if true
        List<string> names = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            deck.Shuffle();
            nextTask = Task.GetNumberOfPlayers;
        }
        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void Cheat_Click(object sender, RoutedEventArgs e)
        {
            return;
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
             //while (nextTask != Task.GameOver)
             //{
                 DoNextTask();
             //}
        }

        private void TextEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (nextTask == Task.GetNumberOfPlayers)
            {
                if (e.Key == System.Windows.Input.Key.Return)
                {
                    if (int.TryParse(TextEntry.Text, out numberOfPlayers) == false)
                    {
                        Instruction.Text = "Please enter a valid number!";
                    }
                    else
                    {
                        numberOfPlayers = int.Parse(TextEntry.Text);
                        if(numberOfPlayers < 2 || numberOfPlayers >4)
                        {
                            Instruction.Text = "Please enter a valid number!";
                            numberOfPlayers = 0;
                        }
                        else
                        {
                            numberOfPlayers = int.Parse(TextEntry.Text);
                            TextEntry.Text = "";
                            nextTask = Task.GetNames;
                            DoNextTask();
                        }
                    }
                }
            }
            if (nextTask == Task.GetNames)
            {             
                if (e.Key == System.Windows.Input.Key.Return)
                {

                    if (TextEntry.Text != "")
                    {
                        AddPlayer(TextEntry.Text);
                        switch (currentPlayer)
                        {
                            case 0:
                                Player1.Text = players[currentPlayer].name;
                                Player1.Visibility = Visibility.Visible;
                                break;

                            case 1:
                                Player2.Text = players[currentPlayer].name;
                                Player2.Visibility = Visibility.Visible;
                                break;

                            case 2:
                                Player3.Text = players[currentPlayer].name;
                                Player3.Visibility = Visibility.Visible;
                                break;

                            case 3:
                                Player4.Text = players[currentPlayer].name;
                                Player4.Visibility = Visibility.Visible;
                                break;

                        }
                        Console.WriteLine(currentPlayer + players[currentPlayer].name);
                        currentPlayer++;
                        GameState.Text = "Player " + (currentPlayer + 1) + ", What is your name?";
                        TextEntry.Text = "";
                        if (currentPlayer >= numberOfPlayers)
                        {
                            currentPlayer = 0;
                            nextTask = Task.PlayerTurn;
                            DoNextTask();
                        }
                    }
                    else
                    {
                        Instruction.Text = "Please enter a valid name!";
                    }
                    

                }
            }
         }

        private void Hit1_Click(object sender, RoutedEventArgs e)
        {
            Player player = players[currentPlayer];
            if (player.status == PlayerStatus.active)
            {
                Card card = deck.DealTopCard();
                player.cards.Add(card);
                player.score = ScoreHand(player);
                if (player.score > 21)
                {
                    player.status = PlayerStatus.bust;
                    switch (currentPlayer)
                    {
                        case 0:
                            Busted_1.Visibility = Visibility.Visible;
                            Busted_1_Text.Visibility = Visibility.Visible;
                            break;
                        case 1:
                            Busted_2.Visibility = Visibility.Visible;
                            Busted_2_Text.Visibility = Visibility.Visible;
                            break;
                        case 2:
                            Busted_2.Visibility = Visibility.Visible;
                            Busted_2_Text.Visibility = Visibility.Visible;
                            break;
                        case 3:
                            Busted_2.Visibility = Visibility.Visible;
                            Busted_2_Text.Visibility = Visibility.Visible;
                            break;
                    }
                    
                }
                else if (player.score == 21)
                {
                    player.status = PlayerStatus.win;
                }
            }
            nextTask = Task.CheckForEnd;
            DoNextTask();
        }

        private void Hit2_Click(object sender, RoutedEventArgs e)
        {
            Player player = players[currentPlayer];
            if (player.status == PlayerStatus.active)
            {
                Card card = deck.DealTopCard();
                player.cards.Add(card);
                player.cards.Add(card);
                player.score = ScoreHand(player);
                if (player.score > 21)
                {
                    player.status = PlayerStatus.bust;
                    switch (currentPlayer)
                    {
                        case 0:
                            Busted_1.Visibility = Visibility.Visible;
                            Busted_1_Text.Visibility = Visibility.Visible;
                            break;
                        case 1:
                            Busted_2.Visibility = Visibility.Visible;
                            Busted_2_Text.Visibility = Visibility.Visible;
                            break;
                        case 2:
                            Busted_2.Visibility = Visibility.Visible;
                            Busted_2_Text.Visibility = Visibility.Visible;
                            break;
                        case 3:
                            Busted_2.Visibility = Visibility.Visible;
                            Busted_2_Text.Visibility = Visibility.Visible;
                            break;
                    }

                }
                else if (player.score == 21)
                {
                    player.status = PlayerStatus.win;
                }
            }
            nextTask = Task.CheckForEnd;
            DoNextTask();
        }

        private void Hit3_Click(object sender, RoutedEventArgs e)
        {
            Player player = players[currentPlayer];
            if (player.status == PlayerStatus.active)
            {
                Card card = deck.DealTopCard();
                player.cards.Add(card);
                player.cards.Add(card);
                player.cards.Add(card);
                player.score = ScoreHand(player);
                if (player.score > 21)
                {
                    player.status = PlayerStatus.bust;
                    switch (currentPlayer)
                    {
                        case 0:
                            Busted_1.Visibility = Visibility.Visible;
                            Busted_1_Text.Visibility = Visibility.Visible;
                            break;
                        case 1:
                            Busted_2.Visibility = Visibility.Visible;
                            Busted_2_Text.Visibility = Visibility.Visible;
                            break;
                        case 2:
                            Busted_2.Visibility = Visibility.Visible;
                            Busted_2_Text.Visibility = Visibility.Visible;
                            break;
                        case 3:
                            Busted_2.Visibility = Visibility.Visible;
                            Busted_2_Text.Visibility = Visibility.Visible;
                            break;
                    }

                }
                else if (player.score == 21)
                {
                    player.status = PlayerStatus.win;
                }
            }
            nextTask = Task.CheckForEnd;
            DoNextTask();
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            Player player = players[currentPlayer];
            currentPlayer++;
            if (currentPlayer > players.Count - 1)
            {
                nextTask = Task.PlayerTurn;
                currentPlayer = 0;
                DoNextTask();
            }else
            {
                nextTask = Task.CheckForNextTurn;
                DoNextTask();
            }
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            Player player = players[currentPlayer];
            players.Remove(player);
            if (players.Count == 1)
            {
                AnnounceWinner(players[0]);
                nextTask = Task.GameOver;
                DoNextTask();
            }
            else
            {
                nextTask = Task.CheckForNextTurn;
                DoNextTask();
            }
        }

        private void Stand_Click(object sender, RoutedEventArgs e)
        {
            Player player = players[currentPlayer];
            if (player.status == PlayerStatus.active)
            {
                player.status = PlayerStatus.stay;
            }
            nextTask = Task.CheckForEnd;
            DoNextTask();
        }

        private void Fold_Click(object sender, RoutedEventArgs e)
        {
            Player player = players[currentPlayer];
            players.Remove(player);
            if (players.Count == 1)
            {
                AnnounceWinner(players[0]);
                nextTask = Task.GameOver;
                DoNextTask();
            }
            else
            {
                nextTask = Task.CheckForEnd;
                DoNextTask();
            }
        }

        public void AddPlayer(string n)
        {
            players.Add(new Player(n));
        }
        public void DoNextTask()
        {
            if (nextTask == Task.GetNumberOfPlayers)
            {
                Start_Button.Visibility = Visibility.Hidden;
                GameState.Visibility = Visibility.Visible;
                Instruction.Visibility = Visibility.Visible;
                TextEntry.Visibility = Visibility.Visible;
            }
            else if (nextTask == Task.GetNames)
            {
                GameState.Text = "Player " + (currentPlayer+1) + ", What is your name?";
                Instruction.Text = "Enter the name.";

            }
            else if (nextTask == Task.PlayerTurn)
            {
                Instruction.Visibility = Visibility.Hidden;
                TextEntry.Visibility = Visibility.Hidden;
                Yes.Visibility = Visibility.Hidden;
                No.Visibility = Visibility.Hidden;
                Hit1.Visibility = Visibility.Visible;
                Hit2.Visibility = Visibility.Visible;
                Hit3.Visibility = Visibility.Visible;
                Stand.Visibility = Visibility.Visible;
                Fold.Visibility = Visibility.Visible;
                GameState.Text = players[currentPlayer].name + ", choose your action.";
                //cardTable.ShowHand(player);
            }
            else if (nextTask == Task.CheckForEnd)
            {
                if (!CheckActivePlayers())
                {
                    Player winner = DoFinalScoring();
                    AnnounceWinner(winner);
                    nextTask = Task.GameOver;
                }
                else
                {
                    currentPlayer++;
                    Console.WriteLine(currentPlayer);
                    Console.WriteLine(players.Count - 1);
                    if (currentPlayer > players.Count - 1)
                    {
                        currentPlayer = 0; // back to the first player...
                        nextTask = Task.CheckForNextTurn; //Ask if continue after checking for end
                        DoNextTask();
                    }
                    else
                    {
                        nextTask = Task.PlayerTurn;
                        DoNextTask();
                    }
                }
            }
            else if (nextTask == Task.CheckForNextTurn)
            {
                Hit1.Visibility = Visibility.Hidden;
                Hit2.Visibility = Visibility.Hidden;
                Hit3.Visibility = Visibility.Hidden;
                Stand.Visibility = Visibility.Hidden;
                Fold.Visibility = Visibility.Hidden;
                Yes.Visibility = Visibility.Visible;
                No.Visibility = Visibility.Visible;
                Console.WriteLine("check for next turn");
                GameState.Text = players[currentPlayer].name + ", Do you want to continue.";                
            }
        }

        public int ScoreHand(Player player)
        {
            int score = 0;
            if (cheating == true && player.status == PlayerStatus.active)
            {
                string response = null;
                while (int.TryParse(response, out score) == false)
                {
                    Console.Write("OK, what should player " + player.name + "'s score be?");
                    response = Console.ReadLine();
                }
                return score;
            }
            else
            {
                foreach (Card card in player.cards)
                {
                    string faceValue = card.ID.Remove(card.ID.Length - 1);
                    switch (faceValue)
                    {
                        case "K":
                        case "Q":
                        case "J":
                            score = score + 10;
                            break;
                        case "A":
                            score = score + 1;
                            break;
                        default:
                            score = score + int.Parse(faceValue);
                            break;
                    }
                }
            }
            return score;
        }

        public bool CheckActivePlayers()
        {         
            foreach (var player in players)
            {
                if (player.status == PlayerStatus.active)
                {
                    return true; // at least one player is still going!
                }
            }
            return false; // everyone has stayed or busted, or someone won!
        }

        /// <summary>
        /// Check win conditions from best to worst:
        /// player hit 21, player scored highest, player didn't bust
        /// </summary>
        /// <returns>winning player or null if everyone busted</returns>
        public Player DoFinalScoring()
        {
            int highScore = 0;
            foreach (var player in players)
            {
                cardTable.ShowHand(player);
                if (player.status == PlayerStatus.win) // someone hit 21
                {
                    return player;
                }
                if (player.status == PlayerStatus.stay) // still could win...
                {
                    if (player.score > highScore)
                    {
                        highScore = player.score;
                    }
                }
                // if busted don't bother checking!
            }
            if (highScore > 0) // someone scored, anyway!
            {
                // find the FIRST player in list who meets win condition
                return players.Find(player => player.score == highScore);
            }
            return null; // everyone must have busted because nobody won!
        }

        public void AnnounceWinner(Player player)
        {
            if (player != null)
            {
                GameState.Text = (player.name + " wins!");
            }
            else
            {
                GameState.Text = ("Everyone busted!");
            }
            Hit1.Visibility = Visibility.Hidden;
            Hit2.Visibility = Visibility.Hidden;
            Hit3.Visibility = Visibility.Hidden;
            Stand.Visibility = Visibility.Hidden;
            Fold.Visibility = Visibility.Hidden;
            Instruction.Text = ("Exit or start a new game.");
        }
    }
}
