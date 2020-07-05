using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Textie.Games.Primitives;

namespace Textie.Games.SpaceInvaders.Scenes
{
    public class SIScene : Scene
    {
        public SIScene(IScintillaGateway editor, Logger logger, Size size, GameData gameData) : base(editor, logger, size, gameData)
        {
            
        }

        public event EventHandler SceneComplete;
        protected void EndScene()
        {
            SceneComplete?.Invoke(this, EventArgs.Empty);
        }

        public virtual void OnLeftKeyDown() { }
        public virtual void OnUpKeyDown() { }
        public virtual void OnRightKeyDown() { }
        public virtual void OnDownKeyDown() { }
        public virtual void OnSpaceKeyDown() { }
    }
}
