using ChimeEngine.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics; 

namespace Chime.Graphics
{
    public struct Vertex
    {
        public Vector3 Position;
        public Vector3 Normal;
        public Vector2 TexCoords;
    }

    public struct Texture
    {
        uint id;
        string type;
    }

    public class Mesh
    {
        List<Vertex> Vertices;
        List<uint> Indices;
        List<Texture> Textures;

        public Mesh(List<Vertex> vertices, List<uint> indices, List<Texture> textures)
        {
            Vertices = vertices;
            Indices = indices;
            Textures = textures;
        }
        //void Draw(Shader shader);
    }
}
