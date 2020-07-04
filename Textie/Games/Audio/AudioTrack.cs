using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Textie.Games.Audio
{
    public class AudioTrack : IAudioTrack
    {
        public AudioTrack()
        {
        }
        public AudioTrack(Stream stream)
            : this()
        {
            OpenStream(stream);
        }
        public SoundPlayer Player { get; set; }

        public void OpenStream(Stream stream)
        {
            Player = new System.Media.SoundPlayer(stream);
        }

        public virtual void Play()
        {
            Player.Play();
        }

        public virtual void Pause()
        {
            Player.Stop();
        }
    }
}
