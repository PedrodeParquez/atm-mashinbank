using System;
using System.IO.Packaging;
using System.Windows.Media;

namespace atm_mashinbank.Model {
  public class CustomSoundPlayer {
    private MediaPlayer mediaPlayer;

    public CustomSoundPlayer(string musicFilePath) {
      InitializeMediaPlayer(musicFilePath);
    }

    private void InitializeMediaPlayer(string musicFilePath) {
      mediaPlayer = new MediaPlayer();
      mediaPlayer.Open(new Uri(musicFilePath));
      mediaPlayer.MediaEnded += MediaEndedHandler;
      mediaPlayer.Play();
    }

    private void MediaEndedHandler(object sender, EventArgs e) {
      mediaPlayer.Position = TimeSpan.Zero;
      mediaPlayer.Play();
    }

    public void Stop() {
      mediaPlayer.Stop();
    }
  }
}
