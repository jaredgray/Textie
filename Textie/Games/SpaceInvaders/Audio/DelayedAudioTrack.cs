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
    public class DelayedAudioTrack : AudioTrack
    {
        public DelayedAudioTrack()
            : base()
        {
            DelayType = DelayType.WaitEnd;
            WaitInMilliseconds = 0;
        }
        public DelayedAudioTrack(Stream stream)
            : base(stream)
        {
            DelayType = DelayType.WaitEnd;
            WaitInMilliseconds = 0;
        }

        public DelayType DelayType { get; set; }

        public int WaitInMilliseconds { get; set; }

        public override void Play()
        {
            base.Play();
            Thread.Sleep(WaitInMilliseconds);
        }
    }
}
