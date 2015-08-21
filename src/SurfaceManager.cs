using amulware.Graphics;
using amulware.Graphics.ShaderManagement;

namespace Game
{
    sealed class SurfaceManager
    {
        public Matrix4Uniform ProjectionMatrix { get; private set; }
        public Matrix4Uniform ModelviewMatrix { get; private set; }

        public IndexedSurface<PrimitiveVertexData> Primitives { get; private set; }

        public SurfaceManager(ShaderManager shaderMan)
        {
            // matrices
            this.ProjectionMatrix = new Matrix4Uniform("projectionMatrix");
            this.ModelviewMatrix = new Matrix4Uniform("modelviewMatrix");

            // create shaders
            shaderMan.MakeShaderProgram("primitives");

            // surfaces
            this.Primitives = new IndexedSurface<PrimitiveVertexData>();
            this.Primitives.AddSettings(this.ProjectionMatrix, this.ModelviewMatrix);
            shaderMan["primitives"].UseOnSurface(this.Primitives);

        }

    }
}