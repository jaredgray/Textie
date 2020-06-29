using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Textie.Games.Primitives;

namespace Textie.Games
{
    public class Stage
    {

        const bool DO_LOG = false;

        public Stage(IScintillaGateway editor, Logger logger, TrajectoryController trajectoryController, Size size)
        {
            Editor = editor;
            Logger = logger;
            TrajectoryController = trajectoryController;
            Sprites = new List<Sprite>();
            Size = size;
            InitializeData();
        }

        public Size Size { get; set; }
        private IScintillaGateway Editor { get; set; }
        private Logger Logger { get; set; }
        private TrajectoryController TrajectoryController { get; set; }


        private List<char> Data { get; set; }
        private List<Sprite> Sprites { get; set; }

        public void AddSprite(Sprite sprite)
        {
            this.Sprites.Add(sprite);
        }

        public void RemoveSprite(Sprite sprite)
        {
            this.Sprites.Remove(sprite);
        }

        private void InitializeData()
        {
            Data = new List<char>(Size.Width * Size.Height);
            for (int i = 0; i < (Size.Width * Size.Height); i++)
            {
                Data.Add(' ');
            }
        }

        private void ClearData()
        {
            for (int i = 0; i < (Size.Width * Size.Height); i++)
            {
                Data[i] = ' ';
            }
        }

        private void ClampSprrite(Sprite sprite)
        {
            if (sprite.Bounds.Position.X < 0)
                sprite.Bounds.Position.X = 0;
            if (sprite.Bounds.Position.X + sprite.Bounds.Size.Width > Size.Width)
                sprite.Bounds.Position.X = Size.Width - sprite.Bounds.Size.Width;
            if (sprite.Bounds.Position.Y < 0)
                sprite.Bounds.Position.Y = 0;
            if (sprite.Bounds.Position.Y + sprite.Bounds.Size.Height > Size.Height)
                sprite.Bounds.Position.Y = Size.Height - sprite.Bounds.Size.Height;
        }

        private void ProcessTrajectorySprites()
        {
            TrajectoryController.HandleSprites(Sprites);
            var deleted = Sprites.Where(x => x.MarkDelete).ToList();
            // TODO: GC should? cleanup these?? maybe
            foreach (var victim in deleted)
            {
                Sprites.Remove(victim);
            }
        }

        private void DrawSprites()
        {
            ProcessTrajectorySprites();
            foreach (var sprite in Sprites.OrderBy(x => x.LayerOrder))
            {
                // clamp the sprite's position so that it doesn't go out of bounds
                ClampSprrite(sprite);
                for (int y = 0; y < sprite.Bounds.Size.Height; y++)
                {
                    for (int x = 0; x < sprite.Bounds.Size.Width; x++)
                    {
                        var c = sprite.GetCharAt((y * sprite.Bounds.Size.Width) + x);
                        var ypos = (y * Size.Width) + (sprite.Bounds.Position.Y * Size.Width);
                        var xpos = x + sprite.Bounds.Position.X;
                        Data[ypos + xpos] = c;
                    }
                }
            }
        }

        public void Draw()
        {
            ClearData();
            DrawSprites();
            Editor.ClearAll();
            StringBuilder linebuilder = new StringBuilder();
            for (int y = 0; y < Size.Height; y++)
            {
                for (int x = 0; x < Size.Width; x++)
                {
                    linebuilder.Append(Data[(y * Size.Width) + x]);
                }
                linebuilder.AppendLine();
            }
            AddTextToEditor(linebuilder.ToString());
        }

        private void AddTextToEditor(string text)
        {
            Editor.AddText(text.Length, text);
            Editor.NewLine();
            if (DO_LOG)
            {
                if (null != Logger)
                {
                    Logger.WriteLine(text);
                }
            }
        }
    }
}
