using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_API
{
    public class CharactersSound
    {
        private static WaveOutEvent outputDevice;

        public static void PlayCharactersSound()
        {
            string audioFilePath = @"C:\Users\Scooo\Downloads\TP_Midna_Yawn2.wav";

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
