using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;

namespace Textie.Games.Audio
{
    public enum DelayType
    {
        WaitBeginning,
        WaitEnd
    }
    public class DelayedAudioTrack : IAudioTrack
    {
        public DelayedAudioTrack()
        {
            DelayType = DelayType.WaitEnd;
            WaitInMilliseconds = 0;
        }
        public DelayedAudioTrack(Stream stream)
            : this()
        {
            OpenStream(stream);
        }

        public SoundPlayer Player { get; set; }

        public void OpenStream(Stream stream)
        {
            Player = new System.Media.SoundPlayer(stream);
        }

        public DelayType DelayType { get; set; }

        public int WaitInMilliseconds { get; set; }

        public void Play()
        {
            Player.Play();
            Thread.Sleep(WaitInMilliseconds);
        }

        public void Pause()
        {
            Player.Stop();
        }
    }
}
