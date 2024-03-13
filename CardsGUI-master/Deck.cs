using System;
using System.Collections.Generic;
using System.Linq; 

namespace CardsGUI
{
    /// <summary>
    /// Manages a standard deck of 52 cards, represented as a list of Card instances.
    /// </summary>
    public class Deck
    {
        List<Card> cards = new List<Card>();

        public List<Card> Cards
        {
            get { return cards; }
        }

        /// <summary>
        /// Constructor for an ordered deck of cards.
        /// </summary>
        public Deck()
        {
            Console.WriteLine("*********** Building deck...");
            string[] suits = { "S", "H", "C", "D" };
            string basePath = "pack://application:,,,/images/";

            for (int cardVal = 1; cardVal <= 13; cardVal++)
            {
                foreach (string cardSuit in suits)
                {
                    string cardName;
                    string cardLongName;
                    string imageName;


                    switch (cardVal)
                    {
                        case 1:
                            cardName = "A";
                            cardLongName = "Ace of ";
                            break;
                        case 11:
                            cardName = "J";
                            cardLongName = "Jack of ";
                            break;
                        case 12:
                            cardName = "Q";
                            cardLongName = "Queen of ";
                            break;
                        case 13:
                            cardName = "K";
                            cardLongName = "King of ";
                            break;
                        default:
                            cardName = cardVal.ToString();
                            cardLongName = cardVal.ToString() + " of ";
                            break;
                    }

                    switch (cardSuit)
                    {
                        case "S":
                            cardLongName += "Spades";
                            break;
                        case "H":
                            cardLongName += "Hearts";
                            break;
                        case "C":
                            cardLongName += "Clubs";
                            break;
                        case "D":
                            cardLongName += "Diamonds";
                            break;
                    }

                    imageName = basePath + cardSuit + cardName + ".png";
                    cards.Add(new Card { ID = cardName + cardSuit, name = cardLongName, ImagePath = imageName });
                }
            }
        }

        /// <summary>
        /// Randomly swap cards to shuffle the deck.
        /// </summary>
        public void Shuffle()
        {
            Console.WriteLine("Shuffling Cards...");

            Random rng = new Random(); 

            for (int i = 0; i < cards.Count; i++)
            {
                Card tmp = cards[i];
                int swapindex = rng.Next(cards.Count);
                cards[i] = cards[swapindex];
                cards[swapindex] = tmp;
            }
        }


        /// <summary>
        /// Shows all cards. Kinda hacky. See comment below.
        /// </summary>
        public void ShowAllCards()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                Console.Write(i + ":" + cards[i].ID); 
                if (i < cards.Count - 1)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.WriteLine("");
                }
            }
        }
        /// <summary>
        /// Remove top card (defined here as last card in the list), an instance of Card
        /// </summary>
        /// <returns>the removed instance of Card, representing one of the 52 cards in the deck</returns>
        public Card DealTopCard()
        {
            Card card = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);       
            return card;
        }

    }
}