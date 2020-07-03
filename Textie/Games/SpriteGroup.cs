using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Textie.Games.Primitives;

namespace Textie.Games
{
    public class SpriteGroup<T> : Sprite, IList<T>
        where T : Sprite
    {
        public SpriteGroup() : base(0, 0)
        {
            _sprites = new List<T>();
        }

        public override void Update()
        {
            base.Update();
        }

        public bool PauseRebuild { get; set; }

        private void ClearData()
        {
            Data = new List<char>(Bounds.Size.Width * Bounds.Size.Height);
            for (int i = 0; i < (Bounds.Size.Width * Bounds.Size.Height); i++)
            {
                Data.Add(' ');
            }
        }

        public void RebuildData()
        {
            var maxX = _sprites.Max(x => x.Bounds.Position.X + x.Bounds.Size.Width);
            var maxY = _sprites.Max(x => x.Bounds.Position.Y + x.Bounds.Size.Height);
            this.Bounds.Size = new Size()
            {
                Height = maxY,
                Width = maxX
            };
            ClearData();
            foreach (var sprite in _sprites.OrderBy(x => x.LayerOrder))
            {
                //ClampSprite(sprite);
                for (int y = 0; y < sprite.Bounds.Size.Height; y++)
                {
                    for (int x = 0; x < sprite.Bounds.Size.Width; x++)
                    {
                        var c = sprite.GetCharAt((y * sprite.Bounds.Size.Width) + x);
                        var ypos = (y * Bounds.Size.Width) + (sprite.Bounds.Position.Y * Bounds.Size.Width);
                        var xpos = x + sprite.Bounds.Position.X;
                        Data[ypos + xpos] = c;
                    }
                }
            }
        }

        private List<T> _sprites;

        #region IList implementation

        public int Count => _sprites.Count;

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get
            {
                return _sprites[index];
            }
            set
            {
                _sprites[index] = value;
                RebuildData();
            }
        }

        public int IndexOf(T item)
        {
            return _sprites.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _sprites.Insert(index, item);
            RebuildData();
        }

        public void RemoveAt(int index)
        {
            _sprites.RemoveAt(index);
            RebuildData();
        }

        public void Add(T item)
        {
            _sprites.Add(item);
            RebuildData();
        }

        public void Clear()
        {
            _sprites.Clear();
            RebuildData();
        }

        public bool Contains(T item)
        {
            return _sprites.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _sprites.CopyTo(array, arrayIndex);
            RebuildData();
        }

        public bool Remove(T item)
        {
            var removal = _sprites.Remove(item);
            RebuildData();
            return removal;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _sprites.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
