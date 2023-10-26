using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDA_CaracMoto.ViewModels
{
    public class MusicItemViewModel : BaseViewModel
    {
        public MusicItemViewModel(string title, string artist, string filename)
        {
            Title = title;
            Artist = artist;
            Filename = filename;
        }

        public string Title { get; }
        public string Artist { get; }
        public string Filename { get; }
    }
}
