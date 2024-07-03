﻿using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_API
{
    public class BossesSound
    {
        private static WaveOutEvent outputDevice;
        public static void PlayBossesSound()
        {
            string audioFilePath = @"C:\Users\Scooo\Downloads\OOT_PhantomGanon_Laugh.wav";

            try
            {
                // Stop any currently playing sound
                if (outputDevice != null && outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    outputDevice.Stop();
                    outputDevice.Dispose();
                }

                // Initialize new output device and play the sound
                outputDevice = new WaveOutEvent();
                var audioFile = new AudioFileReader(audioFilePath);
                outputDevice.Init(audioFile);
                outputDevice.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to play audio: {ex.Message}");
            }
        }
    }
}