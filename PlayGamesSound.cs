using NAudio.Wave;

namespace Final_Project_API
{
    public class PlayGamesSound
    {
        private static WaveOutEvent outputDevice;

        public static void PlayGamesSound1()
        {
            string audioFilePath = @"C:\Users\Scooo\OneDrive\Desktop\MM_SkullKid_OcarinaLaugh1.wav";

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

