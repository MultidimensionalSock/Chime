using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Chime
{

    public class Game : GameWindow
    {
        public static void Main(String[] args)
        {

            Console.WriteLine("Main Method");
            using (Game game = new Game(800, 600, "Chime"))
            {
                game.Run();
            }
        }

        public Game(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) { }
    }

}

