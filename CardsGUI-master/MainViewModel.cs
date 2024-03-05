using System.Collections.ObjectModel;

namespace CardsGUI
{
    public class MainViewModel
    {
        public ObservableCollection<ImageItem> Images { get; set; }
        public int PlayerCount;

        public MainViewModel()
        {   
            Images = new ObservableCollection<ImageItem> { // initalizing images
            new ImageItem { ImagePath = "pack://application:,,,/images/card_clubs_02.png"},
            new ImageItem { ImagePath = "pack://application:,,,/images/card_clubs_03.png"},
            new ImageItem { ImagePath = "pack://application:,,,/images/card_clubs_04.png"},
            };

        }
    }
}