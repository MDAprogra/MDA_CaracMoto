using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Maui.Dispatching;
using Plugin.Maui.Audio;

namespace MDA_CaracMoto.ViewModels
{
    public class MusicPlayerPageViewModel : BaseViewModel, IQueryAttributable
    {
        readonly IAudioManager audioManager;
        readonly IDispatcher dispatcher;
        IAudioPlayer audioPlayer;
        TimeSpan animationProgress;
        MusicItemViewModel musicItemViewModel;
        bool isPositionChangeSystemDriven;
        bool isDisposed;

        public MusicPlayerPageViewModel(
            IAudioManager audioManager,
            IDispatcher dispatcher)
        {
            this.audioManager = audioManager;
            this.dispatcher = dispatcher;

            PlayCommand = new Command(Play);
            PauseCommand = new Command(Pause);
            StopCommand = new Command(Stop);
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue(Routes.MusicPlayer.Arguments.Music, out object musicObject) &&
                musicObject is MusicItemViewModel musicItem)
            {
                MusicItemViewModel = musicItem;

                audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(musicItem.Filename));

                NotifyPropertyChanged(nameof(HasAudioSource));
            }
        }

        public MusicItemViewModel MusicItemViewModel
        {
            get => musicItemViewModel;
            set
            {
                musicItemViewModel = value;
                NotifyPropertyChanged();
            }
        }

        public bool HasAudioSource => audioPlayer is not null;

        public bool IsPlaying => audioPlayer?.IsPlaying ?? false;

        public Command PlayCommand { get; }
        public Command PauseCommand { get; }
        public Command StopCommand { get; }
        void Play()
        {
            audioPlayer.Play();
            NotifyPropertyChanged(nameof(IsPlaying));
        }

        void Pause()
        {
            if (audioPlayer.IsPlaying)
            {
                audioPlayer.Pause();
            }
            else
            {
                audioPlayer.Play();
            }
            NotifyPropertyChanged(nameof(IsPlaying));
        }

        void Stop()
        {
            if (audioPlayer.IsPlaying)
            {
                audioPlayer.Stop();
                NotifyPropertyChanged(nameof(IsPlaying));
            }
        }
    }
}
