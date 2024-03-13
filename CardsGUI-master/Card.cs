using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGUI
{
    /// <summary>
    /// Represents an individual card in deck two ways: 
    /// ID string is two-character short name and name is full card name written out
    /// </summary>
    public class Card
    {
        public string ID;
        public string name; // store the name for each card alongside the ID
        public string ImagePath;//{ get; set; }, store image path
        
    }
}