using Assimp;
using ChimeEngine.Core;
using OpenTK.Graphics.ES30;
using OpenTK.Mathematics;
using System.Runtime.InteropServices;

namespace ChimeEngine.Graphics
{
    public struct Vertex
    {
        public Vector3 Position;
        public Vector3 Normal;
        public Vector2 TextureCoordinates;

        public Vertex(Vector3 position, Vector3 normal, Vector2 textureCoordinates)
        {
            Position = position;
            Normal = normal;
            TextureCoordinates = textureCoordinates;
        }

        public static int Size()
        {
            unsafe
            {
                return sizeof(Vertex);
            }
        }
    }

    public struct Texture
    {
        public uint Id;
        public TextureType TexType;
    }

    public class Mesh
    {
        public Transform transform;

        private Vertex[] _vertices;
        private uint[] _indices;
        private Texture[] _textures;

        public int VAO, VBO, EBO;

        public Shader shader;

        public Mesh(Vertex[] vertices, uint[] indices, Texture[] textures)
        {
            _vertices = vertices;
            _indices = indices;
            _textures = textures;

            SetupMesh();
        }

        ~Mesh()
        {

        }


        private void SetupMesh() 
        {
            VAO = GL.GenVertexArray();
            VBO = GL.GenBuffer();
            EBO = GL.GenBuffer();

            GL.BindVertexArray(VAO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);

            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * Vertex.Size(), _vertices, BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ArrayBuffer, EBO);
            GL.BufferData(BufferTarget.ArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);


            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, Vertex.Size(), Marshal.OffsetOf(typeof(Vertex), "Position"));

            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, Vertex.Size(), Marshal.OffsetOf(typeof(Vertex), "Normal"));

            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 2, VertexAttribPointerType.Float, false, Vertex.Size(), Marshal.OffsetOf(typeof(Vertex), "TextureCoordinates"));

            GL.BindVertexArray(0);

            shader = new Shader("D:\\Git\\Chime\\ChimeEngine\\Shaders\\VertexShader.glsl", 
                "D:\\Git\\Chime\\ChimeEngine\\Shaders\\FragmentShader.glsl"
                );
        }

        public void Draw() 
        {
            if (_textures != null)
            {
                for (int i = 0; i < _textures.Length; i++)
                {
                    GL.ActiveTexture((TextureUnit)i);
                    shader.SetInt("material" + _textures[i].TexType, i);
                    GL.BindTexture(TextureTarget.Texture2D, _textures[i].Id);
                }
            }
            GL.ActiveTexture(0);

            shader.Use();

            GL.BindVertexArray(VAO);
            GL.DrawElements(OpenTK.Graphics.ES30.PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, _indices);
            GL.BindVertexArray(0);
        }
    }
}
