﻿using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Textie.Games.Primitives;

namespace Textie.Games
{
    public class Stage
    {

        public static bool DO_LOG = false;

        public Stage(IScintillaGateway editor, Logger logger, Size size)
        {
            Editor = editor;
            Logger = logger;
            Sprites = new List<Sprite>();
            Size = size;
            InitializeData();
        }

        public Size Size { get; set; }
        private IScintillaGateway Editor { get; set; }
        private Logger Logger { get; set; }


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

        private void ClampSprite(Sprite sprite)
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

        private void ProcessTrajectorySprite(Sprite sprite)
        {
            if (null != sprite.TrajectoryController)
                sprite.TrajectoryController.HandleSprite(sprite);
        }
        private void ProcessCollisionSprite(Sprite sprite, IEnumerable<Sprite> collidables)
        {
            if (sprite is ICollider && null != sprite.CollisionController)
                sprite.CollisionController.HandleSprite(sprite, collidables);
        }

        private void DrawSprites()
        {
            var collidables = Sprites.Where(x => x is ICollider);
            foreach (var sprite in Sprites.OrderBy(x => x.LayerOrder))
            {
                ProcessTrajectorySprite(sprite);
                if (sprite.MarkDelete)
                    continue;

                ProcessCollisionSprite(sprite, collidables);
                if (sprite.MarkDelete)
                    continue;

                sprite.Update();
                // clamp the sprite's position so that it doesn't go out of bounds
                ClampSprite(sprite);
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

            Sprites.RemoveAll(x => x.MarkDelete);

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
