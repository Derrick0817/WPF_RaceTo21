using System.Collections.ObjectModel;

namespace CardsGUI
{
    public class MainViewModel
    {
        public ObservableCollection<Card> cardImages { get; set; } //Obsservable list of cards
        public ObservableCollection<Player> playerHand { get; set; } //Obsservable list of players, this is used to get different card list in each player's hand
        public Deck deck;

        public MainViewModel()
        {
            deck = new Deck();
            cardImages = new ObservableCollection<Card>(deck.Cards);
            playerHand = new ObservableCollection<Player>();
            //{ // initalizing images
            //cardImages.Add(new Card {ID= ImagePath = "pack://application:,,,/images/card_clubs_02.png"},
            //new ImageItem { ImagePath = "pack://application:,,,/images/card_clubs_03.png"},
            //new ImageItem { ImagePath = "pack://application:,,,/images/card_clubs_04.png"},
            //};

        }

        /*
         Implement methods in deck so they can be called by a mainviewmodel
         */
        public Card DealTop()
        {
            return deck.DealTopCard();
        }

        public void ShuffleDeck()
        {
            deck.Shuffle();
        }
    }
}