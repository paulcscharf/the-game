using amulware.Graphics;
using Bearded.Utilities;

namespace Game
{
    sealed class GeometryManager : Singleton<GeometryManager>
    {
        public PrimitiveGeometry Primitives { get; private set; }

        public GeometryManager(SurfaceManager surfaces)
        {
            this.Primitives = new PrimitiveGeometry(surfaces.Primitives);
        }

    }
}