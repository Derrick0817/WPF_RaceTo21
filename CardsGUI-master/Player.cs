using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace CardsGUI
{
	/// <summary>
	/// Class representing individual player:
	/// name, cards in hand, score (sum of current card values), status (from enum PlayerStatus)
	/// </summary>
	public class Player
	{
		public string name;
		public List<Card> cards = new List<Card>();
		public PlayerStatus status = PlayerStatus.active;
		public int score;
		public ObservableCollection<Card> cardImages { get; set; } //failed attempt to use view model

		public Player(string n)
		{
			name = n;
			cardImages = new ObservableCollection<Card>();
		}

		/// <summary>
		/// Introduces player by name. Called by CardTable object.
		/// </summary>
		/// <param name="playerNum"></param>
		public void Introduce(int playerNum)
		{
			Console.WriteLine("Hello, my name is " + name + " and I am player #" + playerNum);
		}
	}
}