using Ultraviolet;
using UvGame.Shared;

namespace UvGame.NETCore
{
    public class Program : UltravioletApplication
    {
        public Program() : base("DEVELOPER_PLACEHOLDER", "APPLICATION_PLACEHOLDER")
        {
        }

        public static void Main(string[] args)
        {
            using (var app = new Program())
            {
                app.Run();
            }
        }

        protected override UltravioletApplicationAdapter OnCreatingApplicationAdapter()
        {
            return new Game(this);
        }

        protected override void OnInitialized()
        {
            UsePlatformSpecificFileSource();
            base.OnInitialized();
        }
    }
}