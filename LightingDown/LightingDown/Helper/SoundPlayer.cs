using System;
using System.Runtime.InteropServices;

namespace LightingDown
{
    public static class SoundPlayer
    {
        [DllImport("winmm.dll",EntryPoint="PlaySound")]
        private static extern bool PlaySound(string pszSound, IntPtr hmod, uint fdwSound); 

        public static void PlayCompleteSound()
        {
            PlaySound(Environment.CurrentDirectory + "\\complete.wav", IntPtr.Zero, 0);
        }
    }
}
