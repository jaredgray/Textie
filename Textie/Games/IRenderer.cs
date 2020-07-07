using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Textie.Games.Primitives;

namespace Textie.Games
{
    public interface IRenderer
    {
        /// <summary>
        /// initializes the renderer so that it is in a state ready to render to it's output
        /// </summary>
        void Initialize(Size screenSize);

        /// <summary>
        /// renderes a frame to the output (screen, file etc)
        /// </summary>
        void RenderFrame(IEnumerable<byte> buffer);

        /// <summary>
        /// called before render frame 
        /// </summary>
        void PreRenderFrame();

        /// <summary>
        /// resizes the renderers view
        /// </summary>
        /// <param name="newSize"></param>
        void OnScreenResize(Size newSize);
    }
}
