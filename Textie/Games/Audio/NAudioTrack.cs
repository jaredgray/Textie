﻿using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Textie.Games.Audio
{
    public class NAudioTrack: IAudioTrack
    {
        public NAudioTrack()
        {
        }
        public NAudioTrack(Stream stream)
            : this()
        {
            //BufferedWaveProvider provider = new BufferedWaveProvider(new WaveFormat(4400, 16, 1));

           
            //using (var audioFile = new AudioFileReader(stream))
            //using (var outputDevice = new WaveOutEvent())
            //{
            //    outputDevice.Init(audioFile);
            //    outputDevice.Play();
            //    while (outputDevice.PlaybackState == PlaybackState.Playing)
            //    {
            //        Thread.Sleep(1000);
            //    }
            //}
        }
        public void OpenStream(Stream stream)
        {
           //Player = new System.Media.SoundPlayer(stream);
        }

        public virtual void Play()
        {
            //Player.Play();
        }

        public virtual void Pause()
        {
            //Player.Stop();
        }
    }
}
