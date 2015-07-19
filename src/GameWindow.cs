using System;
using amulware.Graphics;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Game
{
    sealed class GameWindow : amulware.Graphics.Program
    {
        public GameWindow()
            : base(1280, 720, GraphicsMode.Default, "The Game", GameWindowFlags.Default, DisplayDevice.Default, 3, 2, GraphicsContextFlags.Default)
        {
            
        }

        protected override void OnLoad(EventArgs e)
        {
        }

        protected override void OnUpdate(UpdateEventArgs e)
        {
        }

        protected override void OnRender(UpdateEventArgs e)
        {
            GL.ClearColor(0.2f, 0.2f, 0.2f, 0);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            this.SwapBuffers();
        }
    }
}