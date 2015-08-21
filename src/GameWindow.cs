using System;
using amulware.Graphics;
using OpenTK;
using OpenTK.Graphics;

namespace Game
{
    sealed class GameWindow : amulware.Graphics.Program
    {
        private GameRenderer renderer;
        private GameState game;

        public GameWindow()
            : base(1280, 720, GraphicsMode.Default, "The Game", GameWindowFlags.Default, DisplayDevice.Default, 3, 2, GraphicsContextFlags.Default)
        {
            
        }

        protected override void OnLoad(EventArgs e)
        {
            this.renderer = new GameRenderer();

            this.game = new GameState();
        }

        protected override void OnUpdate(UpdateEventArgs e)
        {
            this.game.Update(e);
        }

        protected override void OnRender(UpdateEventArgs e)
        {
            this.renderer.PrepareFrame(this.Width, this.Height);

            this.renderer.Draw(this.game);
            this.renderer.FinaliseFrame();

            this.SwapBuffers();
        }
    }
}