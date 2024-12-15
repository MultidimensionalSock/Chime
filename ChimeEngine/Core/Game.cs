using OpenTK.Graphics.OpenGL4; 
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System.Drawing;
using ChimeEngine.Graphics;
using OpenTK.Mathematics;

namespace ChimeEngine.Core
{
    
    public class Game : GameWindow
    {
        private static void Main()
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                ClientSize = new OpenTK.Mathematics.Vector2i(800, 600),
                Title = "Chime",
                // This is needed to run on macos
                Flags = ContextFlags.ForwardCompatible,
            };

            using (var window = new Game(GameWindowSettings.Default, nativeWindowSettings))
            {
                window.Run();
            }
        }
        Mesh test;
        public Game(GameWindowSettings settings, NativeWindowSettings windowSettings) : base(settings, windowSettings)
        {
            Vertex[] vert =
            {
                new Vertex(
                    new Vector3(-0.5f, -0.5f, 0.0f),
                    new Vector3(1f, 0f, 0f),
                    Vector2.Zero),
                new Vertex(
                    new Vector3(0.5f, -0.5f, 0.0f),
                    new Vector3(0f, 1f, 0f),
                    Vector2.Zero),
                new Vertex(
                    new Vector3(0.0f, 0.5f, 0.0f),
                    new Vector3(0f, 0f, 1f),
                    Vector2.Zero)
            };
            uint[] indices = { 0, 1, 3 };
            Texture[] textures = null;
            test = new Mesh(vert, indices, textures);

    }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(Color.CornflowerBlue);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            test.Draw();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

        }

        protected override void OnUnload()
        {
        }
    }

    
}