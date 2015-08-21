using amulware.Graphics;
using amulware.Graphics.ShaderManagement;
using Bearded.Utilities.Math;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Game
{
    sealed class GameRenderer
    {
        private readonly ShaderManager shaderMan;
        private readonly SurfaceManager surfaces;

        private int width;
        private int height;

        public GameRenderer()
        {
            this.shaderMan = new ShaderManager();
            var shaderLoader = ShaderFileLoader.CreateDefault("data/shaders");
            this.shaderMan.Add(shaderLoader.Load(""));

            this.surfaces = new SurfaceManager(this.shaderMan);

            new GeometryManager(this.surfaces);
        }


        public void PrepareFrame(int width, int height)
        {
            if (width != this.width || height != this.height)
            {
                this.resize(width, height);
            }

            GL.ClearColor(0.2f, 0.2f, 0.2f, 0);
            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        private void resize(int width, int height)
        {
            GL.Viewport(0, 0, width, height);

            this.surfaces.ProjectionMatrix.Matrix = this.createProjectionMatrix(width, height);

            this.width = width;
            this.height = height;
        }

        private Matrix4 createProjectionMatrix(int width, int height)
        {
            const float zNear = 0.1f;
            const float zFar = 256f;
            const float fovy = GameMath.PiOver4;

            var ratio = (float)width / height;

            var yMax = zNear * GameMath.Tan(0.5f * fovy);
            var yMin = -yMax;
            var xMin = yMin * ratio;
            var xMax = yMax * ratio;

            var matrix = Matrix4.CreatePerspectiveOffCenter(xMin, xMax, yMin, yMax, zNear, zFar);

            return matrix;
        }

        public void Draw(GameState game)
        {
            this.surfaces.ModelviewMatrix.Matrix = Matrix4.LookAt(
                new Vector3(0, 0, 50), new Vector3(0, 0, 0), new Vector3(0, 1, 0)
                );

            game.Render();
        }

        public void FinaliseFrame()
        {
            SurfaceDepthMaskSetting.DontMask.Set(null);
            SurfaceBlendSetting.PremultipliedAlpha.Set(null);

            this.surfaces.Primitives.Render();
            this.surfaces.Text.Render();
        }
    }
}