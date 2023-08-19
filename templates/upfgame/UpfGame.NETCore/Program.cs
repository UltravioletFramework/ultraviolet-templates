using System.Linq;
using Ultraviolet;
using UpfGame.Shared;

namespace UpfGame.NETCore
{
    public class Program : UltravioletApplication
    {
        private static GameFlags sFlags = GameFlags.None;
        public Program() : base("DEVELOPER_PLACEHOLDER", "APPLICATION_PLACEHOLDER")
        {
        }

        public static void Main(string[] args)
        {
            if (args.Contains("-compile:expressions"))
                sFlags |= GameFlags.CompileExpressions;

            using (var app = new Program())
            {
                app.Run();
            }
        }

        protected override UltravioletApplicationAdapter OnCreatingApplicationAdapter()
        {
            return new Game(this, sFlags);
        }

        protected override void OnInitialized()
        {
            UsePlatformSpecificFileSource();
            base.OnInitialized();
        }
    }
}