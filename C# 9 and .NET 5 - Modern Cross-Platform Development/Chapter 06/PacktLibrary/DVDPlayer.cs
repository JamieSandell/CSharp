using static System.Console;

namespace Packt.Shared
{
    public class DVDPlayer : IPlayable
    {
        public void Pause()
        {
            WriteLine("DVD paused.");
        }

        public void Play()
        {
            WriteLine("DVD player is playing.");
        }
    }
}