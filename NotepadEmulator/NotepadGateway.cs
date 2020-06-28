using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotepadEmulator
{
    public class NotepadGateway : INotepadPPGateway
    {
        public void FileNew()
        {

        }

        public string GetCurrentFilePath()
        {
            throw new NotImplementedException();
        }

        public string GetFilePath(int bufferId)
        {
            throw new NotImplementedException();
        }

        public void SetCurrentLanguage(LangType language)
        {
            throw new NotImplementedException();
        }
    }
}
