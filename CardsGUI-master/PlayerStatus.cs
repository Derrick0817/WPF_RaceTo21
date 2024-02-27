using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGUI
{
	/// <summary>
	/// Player's current participation in game.
	/// "active" allows player to continue taking cards.
	/// All others skip this player until game end.
	/// </summary>
	public enum PlayerStatus
	{
		active,
		stay,
		bust,
		win
	}
}
