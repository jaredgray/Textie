using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Textie;
using Textie.Games;
using Textie.Games.Primitives;
using static NotepadEmulator.Win32Console;

namespace NotepadEmulator
{
    public class ConsoleRenderer : IRenderer
    {
        public static bool DO_LOG = false;
        public ConsoleRenderer(Logger logger)
        {
            Logger = logger;
        }

        private Logger Logger { get; set; }

        IntPtr ConsoleWindowHandle { get; set; }

        public Size SceneSize { get; set; }
        IntPtr ScreenBufferHandle { get; set; }
        SafeFileHandle SafeScreenBufferHandle { get; set; }
        public CharInfo[] CharInfoOutputBuffer { get; set; }
        public SmallRect ViewportSize;
        //public SmallRect ConsoleWindowSize;

        public void Initialize(Size sceneSize)
        {
            this.SceneSize = sceneSize;
            ScreenBufferHandle = Win32Console.CreateConsoleScreenBuffer(Win32Console.GENERIC_READ | Win32Console.GENERIC_WRITE, 0, IntPtr.Zero, Win32Console.CONSOLE_TEXTMODE_BUFFER, IntPtr.Zero);
            Win32Console.SetConsoleActiveScreenBuffer(ScreenBufferHandle);
            SafeScreenBufferHandle = new SafeFileHandle(ScreenBufferHandle, true);
            Console.ForegroundColor = ConsoleColor.Green;
            CharInfoOutputBuffer = new CharInfo[SceneSize.Width * SceneSize.Height];
            ViewportSize = new SmallRect() { Left = 0, Top = 0, Right = (short)SceneSize.Width, Bottom = (short)SceneSize.Height };
            ConsoleWindowHandle = GetConsoleWindow();
            //Console.SetWindowSize(SceneSize.Width, SceneSize.Height);
            //Console.WindowHeight = SceneSize.Height + 23;
            //Console.WindowWidth = SceneSize.Width + 60;
            ShowWindow(ConsoleWindowHandle, MAXIMIZE);
            //ConsoleWindowSize = new SmallRect() { Left = 0, Top = 0, Right = (short)SceneSize.Width, Bottom = (short)(SceneSize.Height + 100) };
            //SetConsoleWindowInfo(ConsoleWindowHandle, true, ref ConsoleWindowSize);

            Logger.WriteLine($"Console Handle: {ConsoleWindowHandle}");
            Logger.WriteLine($"Screen Buffer Handle: {ScreenBufferHandle}");
        }

        public void InitializeFrameBuffer()
        {
        }

        public void RenderFrame(IEnumerable<byte> buffer)
        {
            for (int y = 0; y < SceneSize.Height; y++)
            {
                for (int x = 0; x < SceneSize.Width; x++)
                {
                    var index = (y * SceneSize.Width) + x;
                    CharInfoOutputBuffer[index].Attributes = (short)ConsoleColor.Green;
                    CharInfoOutputBuffer[index].Char.AsciiChar = buffer.ElementAt(index);
                }
            }
            WriteConsoleOutput(SafeScreenBufferHandle, CharInfoOutputBuffer,
              new Coord() { X = (short)SceneSize.Width, Y = (short)SceneSize.Height },
              new Coord() { X = 0, Y = 0 },
              ref ViewportSize);
        }

        public void PreRenderFrame()
        {
            // Clear the console
            Console.Clear();
        }

        public void OnScreenResize(Size newSize)
        {
            if (SceneSize != newSize)
                this.SceneSize = newSize;
        }

    }
}
