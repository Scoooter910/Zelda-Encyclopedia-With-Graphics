using NAudio.Wave;
using System;

public static class ItemsSound
{
    private static WaveOutEvent outputDevice;

    public static void PlayItemsSound()
    {
        string audioFilePath = @"C:\Users\Scooo\OneDrive\Desktop\OOT_Fanfare_Item.wav";

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