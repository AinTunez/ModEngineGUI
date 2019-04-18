using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ModEngineGUI
{
    public partial class Configure : Form
    {
        private GUI UI;

        public bool SkipLogos
        {
            get => skipLogosBox.Checked;
            set => skipLogosBox.Checked = value;
        }

        public bool LoadUxmFiles
        {
            get => loadUxmBox.Checked;
            set => loadUxmBox.Checked = value;
        }

        public bool UseModOverrideDirectory
        {
            get => useModOverrideBox.Checked;
            set => useModOverrideBox.Checked = value;
        }

        public string ModFolder
        {
            get => modFolderBox.Text;
            set => modFolderBox.Text = value;
        }

        public bool CacheFilePaths
        {
            get => cacheFilePathBox.Checked;
            set => cacheFilePathBox.Checked = value;
        }

        public bool ShowDebugLog
        {
            get => showDebugLogBox.Checked;
            set => showDebugLogBox.Checked = value;
        }

        public string ChainDInput8DLLPath
        {
            get => chainDllBox.Text;
            set => chainDllBox.Text = value;
        }

        public Configure(GUI g)
        {
            InitializeComponent();
            UI = g;
            LoadFromINI();
        }

        public void LoadFromINI ()
        {
            if (!File.Exists("modengine.ini"))
            {
                SkipLogos = false;
                LoadUxmFiles = false;
                UseModOverrideDirectory = true;
                ModFolder = @".\mods";
                ShowDebugLog = false;
                CacheFilePaths = true;
                ChainDInput8DLLPath = "";
                return;
            }

            string[] lines = File.ReadAllLines("modengine.ini");
            foreach (var line in lines)
            {
                var lin = line.Trim();
                if (lin.Trim().StartsWith(";") || lin.StartsWith("[")) continue;

                var data = lin.Split(new char[] { '=' });
                var key = data[0];
                var val = data[1];

                if (key == "skipLogos") SkipLogos = val == "1";
                else if (key == "loadUXMFiles") LoadUxmFiles = val == "1";
                else if (key == "useModOverrideDirectory") UseModOverrideDirectory = val == "1";
                else if (key == "modOverrideDirectory") ModFolder = Path.GetDirectoryName(val.Replace("\"", ""));
                else if (key == "showDebugLog") ShowDebugLog = val == "1";
                else if (key == "cacheFilePaths") CacheFilePaths = val == "1";
                else if (key == "chainDInput8DLLPath") ChainDInput8DLLPath = val.Replace("\"", "");
            }
        }

        private string WriteBool(bool input) => input ? "1" : "0";

        public void WriteToINI()
        {
            var sb = new StringBuilder();
            sb.AppendLine("skipLogos=" + WriteBool(SkipLogos));
            sb.AppendLine("loadUXMFiles=" + WriteBool(LoadUxmFiles));
            sb.AppendLine("useModOverrideDirectory=" + WriteBool(UseModOverrideDirectory));
            sb.AppendLine("modOverrideDirectory=\"" + ModFolder + @"\_main""");
            sb.AppendLine("showDebugLog=" + WriteBool(ShowDebugLog));
            sb.AppendLine("chainDInput8DLLPath=\"" + ChainDInput8DLLPath + "\"");
            sb.AppendLine("cacheFilePaths=" + CacheFilePaths);
            File.WriteAllText("modengine.ini", sb.ToString());
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            WriteToINI();
            UI.LoadModList();
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            UI.LoadModList();
            Close();
        }

        private void chainBtn_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "DLL Files (*.dll)|*.dll";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ChainDInput8DLLPath = ofd.FileName;
            }
        }

        private void selectDirBtn_Click(object sender, EventArgs e)
        {
            var folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                ModFolder = "\\" + folderBrowser.SelectedPath.Replace(Environment.CurrentDirectory, "");
            }
        }

        private string GetRelativePath(string filespec, string folder)
        {
            Uri pathUri = new Uri(filespec);
            // Folders must end in a slash
            if (!folder.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                folder += Path.DirectorySeparatorChar;
            }
            Uri folderUri = new Uri(folder);
            return Uri.UnescapeDataString(folderUri.MakeRelativeUri(pathUri).ToString().Replace('/', Path.DirectorySeparatorChar));
        }
    }
}
