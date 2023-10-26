using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDA_CaracMoto.ViewModels
{
    public class MyLibraryPageViewModel : BaseViewModel
    {
        MusicItemViewModel selectedMusicItem;
        public ObservableCollection<MusicItemViewModel> Music { get; }


        public MyLibraryPageViewModel()
        {
            Music = new ObservableCollection<MusicItemViewModel>
        {
            new MusicItemViewModel("The Happy Ukelele Song", "Stanislav Fomin", "ukelele.mp3")
        };
        }

        public MusicItemViewModel SelectedMusicItem
        {
            get => selectedMusicItem;
            set
            {
                selectedMusicItem = value;
                NotifyPropertyChanged();

                OnMusicItemSelected();
            }
        }

        async void OnMusicItemSelected()
        {
            await Shell.Current.GoToAsync(
                Routes.MusicPlayer.RouteName,
                new Dictionary<string, object>
                {
                    [Routes.MusicPlayer.Arguments.Music] = SelectedMusicItem
                });
        }
    }
}
