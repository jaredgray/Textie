using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Textie.Games.Primitives;

namespace Textie.Games
{
    public class Sprite
    {
        public Sprite(int width, int height)
        {
            this.Bounds = new Bounds()
            {
                Position = new Vector2D()
                {
                    X = 0,
                    Y = 0
                },
                Size = new Size()
                {
                    Width = width,
                    Height = height
                }
            };
        }

        public bool MarkDelete { get; set; }

        public virtual Bounds Bounds { get; private set; }

        public int LayerOrder { get; set; }

        public void SetData(string data)
        {
            Data = new List<char>(Bounds.Size.Width * Bounds.Size.Height);
            using (StringReader sr = new StringReader(data))
            {
                var line = "";
                while(null != (line = sr.ReadLine()))
                {
                    if (string.IsNullOrEmpty(line))
                        continue;
                    for (int i = 0; i < line.Length; i++)
                    {
                        Data.Add(line[i]);
                    }
                }
            }

            if(Bounds.Size.Width * Bounds.Size.Height != Data.Count - 1)
            {
                // something is wrong here
            }
        }

        protected List<char> Data { get; set; }

        public char GetCharAt(int index)
        {
            if(index < Data.Count)
            {
                return Data[index];
            }
            else
            {

            }
            return ' ';
        }

        public virtual void Update() { }

        public TrajectoryController TrajectoryController { get; set; }
    }
}
