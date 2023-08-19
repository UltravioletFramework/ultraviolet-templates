using System;
using Ultraviolet;
using Ultraviolet.BASS;
using Ultraviolet.Content;
using Ultraviolet.FreeType2;
using Ultraviolet.Graphics;
using Ultraviolet.Graphics.Graphics2D;
using Ultraviolet.Input;
using Ultraviolet.OpenGL;

namespace UvGame.Shared
{
    public class Game : UltravioletApplicationAdapter
    {
        public Game(IUltravioletApplicationAdapterHost host)
            : base(host)
        { }

        protected override void OnConfiguring(UltravioletConfiguration configuration)
        {
            configuration.Plugins.Add(new OpenGLGraphicsPlugin());
            configuration.Plugins.Add(new BASSAudioPlugin());
            configuration.Plugins.Add(new FreeTypeFontPlugin());

//-:cnd:noEmit
#if DEBUG
            configuration.Debug = true;
            configuration.DebugLevels = DebugLevels.Error | DebugLevels.Warning;
            configuration.DebugCallback = (uv, level, message) =>
            {
                System.Diagnostics.Debug.WriteLine(message);
            };
#endif
//+:cnd:noEmit
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override void OnLoadingContent()
        {
            this.contentManager = ContentManager.Create("Content");
            this.spriteBatch = SpriteBatch.Create();
            this.texture = this.contentManager.Load<Texture2D>("desktop_uv256");

            base.OnLoadingContent();
        }

        protected override void OnUpdating(UltravioletTime time)
        {
            if (Ultraviolet.GetInput().GetKeyboard().IsKeyPressed(Key.Escape))
            {
                Host.Exit();
            }
            base.OnUpdating(time);
        }

        protected override void OnDrawing(UltravioletTime time)
        {
            var window = Ultraviolet.GetPlatform().Windows.GetCurrent();
            var position = new Vector2(window.ClientSize.Width / 2f, window.ClientSize.Height / 2f);
            var origin = new Vector2(texture.Width / 2f, texture.Height / 2f);

            this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            this.spriteBatch.Draw(texture, position, null, Color.White, 0f, origin, 1f, SpriteEffects.None, 0f);
            this.spriteBatch.End();

            base.OnDrawing(time);
        }

        protected override void Dispose(Boolean disposing)
        {
            if (disposing)
            {
                if (this.contentManager != null)
                    this.contentManager.Dispose();

                if (this.spriteBatch != null)
                    this.spriteBatch.Dispose();
            }
            base.Dispose(disposing);
        }

        private ContentManager contentManager;
        private SpriteBatch spriteBatch;
        private Texture2D texture;
    }
}
