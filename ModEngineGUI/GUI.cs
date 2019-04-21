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
using SoulsFormats;

namespace ModEngineGUI
{
    public partial class GUI : Form
    {
        public Configure CFG;

        public GUI()
        {
            InitializeComponent();
            CFG = new Configure(this);
            LoadModList();
        }

        public void LoadModList()
        {
            string dir = CFG.ModFolder;
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            if (!File.Exists("loadorder.ini"))
            {
                StringBuilder sb = new StringBuilder();
                foreach (var mod in Directory.GetDirectories(dir))
                {
                    string name = Path.GetFileName(mod);
                    if (name != "_main")
                    {
                        modListbox.Items.Add(name);
                        sb.AppendLine(name);
                    }
                }
                File.WriteAllText("loadorder.ini", sb.ToString().Trim());
            } else
            {
                var lines = File.ReadAllLines("loadorder.ini").ToList();
                var mods = Directory.GetDirectories(dir).Select(d => Path.GetFileName(d));
                foreach (var line in lines.ToList())
                {
                    if (mods.Contains(line))
                    {
                        modListbox.Items.Add(line);
                    } else
                    {
                        lines.Remove(line);
                    }
                }
                File.WriteAllLines("loadorder.ini", lines.ToArray());
            }
        }

        public void WriteLog(string text)
        {
            ThreadHelperClass.SetText(this, consoleBox, text.Replace("\n", Environment.NewLine));
        }

        private async void installBtn_ClickAsync(object sender, EventArgs e)
        {
            consoleBox.Clear();
            var task = new Task(() => Install());
            task.Start();
            await task;
        }

        private void Install()
        {

            if (modListbox.CheckedItems.Count == 0)
            {
                WriteLog("ERROR: No mods selected.");
                return;
            }

            var d = new DirectoryInfo(CFG.ModFolder + @"\_main");
            d.Delete(true);
            d.Create();
            d.Attributes |= FileAttributes.Hidden;

            var megaMod = new GameMod(CFG.ModFolder, "_main");
            foreach (var item in modListbox.CheckedItems)
            {
                string name = item.ToString();
                WriteLog("INSTALLING: " + name + "...");
                megaMod.Combine(new GameMod(CFG.ModFolder, name));
            }

            WriteLog("\nComplete!");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CFG.ShowDialog();
        }

        public void LogException(string message, Exception ex)
        {
            var sb = new StringBuilder();
            sb.AppendLine("* " + message + " *" + Environment.NewLine + ex.Message);
            var trace = ex.StackTrace.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i < Math.Min(trace.Count(), 6); i++)
            {
                var line = trace[i];
                int sfIndex = line.LastIndexOf("SoulsFormats");
                int edIndex = line.LastIndexOf("ModEngineGUI");
                if (sfIndex > -1) sb.AppendLine("  at " + line.Substring(sfIndex));
                else if (edIndex > -1) sb.AppendLine("  at " + line.Substring(edIndex));
                else sb.AppendLine("  " + line.Trim());
            }
            WriteLog(sb.ToString());
        }

        private void upBtn_Click(object sender, EventArgs e)
        {
            MoveItem(-1);
        }

        private void dnBtn_Click(object sender, EventArgs e)
        {
            MoveItem(1);
        }

        private void MoveItem(int direction)
        {
            if (modListbox.SelectedItem == null || modListbox.SelectedIndex < 0) return;
            int newIndex = modListbox.SelectedIndex + direction;
            if (newIndex < 0 || newIndex >= modListbox.Items.Count) return;
            object selected = modListbox.SelectedItem;

            modListbox.Items.Remove(selected);
            modListbox.Items.Insert(newIndex, selected);
            modListbox.SetSelected(newIndex, true);
        }

        private void saveOrderBtn_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            foreach (var obj in modListbox.Items)
                sb.AppendLine(obj.ToString());
            File.WriteAllText("loadorder.ini", sb.ToString());
        }
    }

    public static class ThreadHelperClass
    {
        delegate void SetTextCallback(Form f, Control ctrl, string text);

        public static void SetText(Form form, Control ctrl, string text)
        {
            if (ctrl.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                form.Invoke(d, new object[] { form, ctrl, text });
            }
            else
            {
                ctrl.Text += text + Environment.NewLine;
            }
        }
    }

    public class GameMod
    {
        public string Name { get; set; }
        public string FullModPath { get; set; }
        public List<string> FilePaths = new List<string>();

        public GameMod(string topFolder, string modName)
        {
            Name = modName;
            FullModPath = Path.GetFullPath(topFolder);

            void searchDirectory(DirectoryInfo dir)
            {
                var relativeFiles = dir.GetFiles().Select(f => f.FullName.Replace(FullModPath, "\""));
                FilePaths.AddRange(relativeFiles);
                foreach (var subdir in dir.GetDirectories())
                    searchDirectory(subdir);
            }

            searchDirectory(new DirectoryInfo(topFolder + @"\" + modName));
        }

        public FileInfo GetFile(string relativePath) => new FileInfo(FullModPath + @"\" + relativePath);

        public void Combine(GameMod mod)
        {
            var modA = this;
            var modB = mod;

            foreach (string filePath in modB.FilePaths)
            {
                bool hasFile = modA.FilePaths.Contains(filePath);
                if (!hasFile || Path.GetFileName(filePath) != "gameparam.parambnd.dcx")
                {
                    string pathA = modA.FullModPath + @"\" + filePath;
                    string pathB = modB.FullModPath + @"\" + filePath;
                    Directory.CreateDirectory(pathA);
                    File.Copy(pathA, pathB, true);
                } else if (Path.GetFileName(filePath) == "gameparam.parambnd.dcx")
                {
                    var paramA = BND4.Read(modA.FullModPath + @"\" + filePath);
                    var paramB = BND4.Read(modB.FullModPath + @"\" + filePath);

                    //compare them and stuff
                }
            }
        }
    }
}
