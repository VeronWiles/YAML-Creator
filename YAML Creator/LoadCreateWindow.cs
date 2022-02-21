using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YAML_Creator
{
    public partial class YAMLNameWindow : Form
    {
        public class Area
        {
            public string AreaNameList { get; set; }
            public string BackgroundFolderList { get; set; }
            public string DescriptionList { get; set; }

            public List<string> ReachableAreaList = new List<string>();

            public List<string> ScreamAreaList = new List<string>();

            public bool Lock { get; set; } = true;

            public bool GetAreas { get; set; } = false;

            public bool RPArea { get; set; } = true;

            public bool BGLock { get; set; } = false;

            public bool Bullet { get; set; } = false;

            public bool Iniswap { get; set; } = true;

            public bool Lobby { get; set; } = false;

            public bool SongSwitch { get; set; } = true;

            public bool RollP { get; set; } = true;

        }

        public YAMLNameWindow()
        {
            InitializeComponent();
        }
        public static string YAMLNameInput = "";
        public static string YAMLPath = "";
        public static List<Area> FullAreaList = null;
        private void YAMLNameConfirm_Click(object sender, EventArgs e)
        {
            YAMLNameInput = YAMLName.Text;
            if (YAMLNameInput != "")
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    YAMLPath = fbd.SelectedPath + "/" + YAMLNameInput + ".yaml";
                    if (!File.Exists(YAMLPath)) {
                        File.WriteAllText(YAMLPath, "");

                        YAMLCreator window = new YAMLCreator();
                        window.Show();
                        window.FormClosed += new FormClosedEventHandler(YAMLNameWindow_FormClosed);
                        Hide();
                    }
                    else
                    {
                        if (MessageBox.Show("This file already exists, would you like to replace it?", "Replace File", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            File.WriteAllText(YAMLPath, "");

                            YAMLCreator window = new YAMLCreator();
                            window.Show();
                            window.FormClosed += new FormClosedEventHandler(YAMLNameWindow_FormClosed);
                            Hide();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a location to save your YAML to, to continue.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a name for your YAML.");
            }
        }

        void YAMLNameWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            FullAreaList = new List<Area>();
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = "c://",
                Filter = "yaml files (*.yaml)|*.yaml",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                YAMLPath = ofd.FileName;

                AssignToArea(YAMLPath);
                RPHubLoad window = new RPHubLoad();
                window.Show();
                window.FormClosed += new FormClosedEventHandler(YAMLNameWindow_FormClosed);
                Hide();
            }
            else
            {
                MessageBox.Show("Please select a location to save your YAML to continue.");
            }
        }

        private void AssignToArea(string path)
        {
            int count = 0;
            foreach (string line in System.IO.File.ReadLines(path))
            {
                if (line.Contains("- area:"))
                {
                    Area newA = new Area();
                    FullAreaList.Add(newA);
                    count++;
                }
            }

            if (count == 0)
            { 
                FullAreaList = null;
                return;
            }

            int index = 0;
            Area a = FullAreaList[0];

            foreach (string line in System.IO.File.ReadLines(path))
            {
                if (line.Contains("- area:"))
                {
                    a = FullAreaList[index];
                    index++;
                    string newLine = line.Remove(0, 7);
                    if (newLine.IndexOf(" ") == 0)
                    {
                        newLine = newLine.Remove(0, 1);
                    }
                    a.AreaNameList = newLine;
                }
                if (line.Contains("  background:"))
                {
                    string newLine = line.Remove(0, 13);
                    if (newLine.IndexOf(" ") == 0)
                    {
                        newLine = newLine.Remove(0, 1);
                    }
                    a.BackgroundFolderList = newLine;
                }
                if (line.Contains("  default_description:"))
                {
                    string newLine = line.Remove(0, 22);
                    if (newLine.IndexOf(" ") == 0)
                    {
                        newLine = newLine.Remove(0, 1);
                    }
                    a.DescriptionList = newLine;
                }

                if (line.Contains("  bglock:"))
                {
                    string newLine = line.Remove(0, 9);
                    if (newLine.IndexOf(" ") == 0)
                    {
                        newLine = newLine.Remove(0, 1);
                    }
                    if (newLine.ToLower() == "true")
                    {
                        a.BGLock = true;
                    }
                    else
                    {
                        a.BGLock = false;
                    }
                }
                if (line.Contains("  locking_allowed:"))
                {
                    string newLine = line.Remove(0, 18);
                    if (newLine.IndexOf(" ") == 0)
                    {
                        newLine = newLine.Remove(0, 1);
                    }
                    if (newLine.ToLower() == "true")
                    {
                        a.Lock = true;
                    }
                    else
                    {
                        a.Lock = false;
                    }
                }
                if (line.Contains("  rp_getareas_allowed:"))
                {
                    string newLine = line.Remove(0, 22);
                    if (newLine.IndexOf(" ") == 0)
                    {
                        newLine = newLine.Remove(0, 1);
                    }
                    if (newLine.ToLower() == "true")
                    {
                        a.GetAreas = true;
                    }
                    else
                    {
                        a.GetAreas = false;
                    }
                }
                if (line.Contains("  rp_area:"))
                {
                    string newLine = line.Remove(0, 10);
                    if (newLine.IndexOf(" ") == 0)
                    {
                        newLine = newLine = newLine.Remove(0, 1);
                    }
                    if (newLine.ToLower() == "true")
                    {
                        a.RPArea = true;
                    }
                    else
                    {
                        a.RPArea = false;
                    }
                }
                if (line.Contains("  bullet:"))
                {
                    string newLine = line.Remove(0, 9);
                    if (newLine.IndexOf(" ") == 0)
                    {
                        newLine = newLine.Remove(0, 1);
                    }
                    if (newLine.ToLower() == "true")
                    {
                        a.Bullet = true;
                    }
                    else
                    {
                        a.Bullet = false;
                    }
                }
                if (line.Contains("  iniswap_allowed:"))
                {
                    string newLine = line.Remove(0, 18);
                    if (newLine.IndexOf(" ") == 0)
                    {
                        newLine = newLine.Remove(0, 1);
                    }
                    if (newLine.ToLower() == "true")
                    {
                        a.Iniswap = true;
                    }
                    else
                    {
                        a.Iniswap = false;
                    }
                }
                if (line.Contains("  lobby_area:"))
                {
                    string newLine = line.Remove(0, 13);
                    if (newLine.IndexOf(" ") == 0)
                    {
                        newLine = newLine.Remove(0, 1);
                    }
                    if (newLine.ToLower() == "true")
                    {
                        a.Lobby = true;
                    }
                    else
                    {
                        a.Lobby = false;
                    }
                }
                if (line.Contains("  song_switch_allowed:"))
                {
                    string newLine = line.Remove(0, 22);
                    if (newLine.IndexOf(" ") == 0)
                    {
                        newLine = newLine.Remove(0, 1);
                    }
                    if (newLine.ToLower() == "true")
                    {
                        a.SongSwitch = true;
                    }
                    else
                    {
                        a.SongSwitch = false;
                    }
                }
                if (line.Contains("  rollp_allowed:"))
                {
                    string newLine = line.Remove(0, 16);
                    if (newLine.IndexOf(" ") == 0)
                    {
                        newLine = newLine.Remove(0, 1);
                    }
                    if (newLine.ToLower() == "true")
                    {
                        a.RollP = true;
                    }
                    else
                    {
                        a.RollP = false;
                    }
                }

                if (line.Contains("  reachable_areas:"))
                {
                    string newLine = line.Remove(0, 18);
                    if (newLine.IndexOf(" ") == 0)
                    {
                        newLine = newLine.Remove(0, 1);
                    }
                    while (true)
                    {
                        int commaIndex = newLine.IndexOf(",");
                        int endIndex = newLine.Count();
                        if (commaIndex >= 0)
                        {
                            string areaName = newLine.Substring(0, commaIndex);
                            a.ReachableAreaList.Add(areaName);
                            newLine = newLine.Remove(0, commaIndex + 1);
                        }
                        else if (endIndex > 0)
                        {
                            string areaName = newLine.Substring(0, endIndex);
                            a.ReachableAreaList.Add(areaName);
                            newLine = newLine.Remove(0, endIndex);
                        }
                        else
                        {
                            break;
                        }
                        if (newLine.IndexOf(" ") == 0)
                        {
                            newLine = newLine.Remove(0, 1);
                        }
                    }
                }
                if (line.Contains("  scream_range:"))
                {
                    string newLine = line.Remove(0, 15);
                    if (newLine.IndexOf(" ") == 0)
                    {
                        newLine = newLine.Remove(0, 1);
                    }
                    while (true)
                    {
                        int commaIndex = newLine.IndexOf(",");
                        int endIndex = newLine.Count();
                        if (commaIndex >= 0)
                        {
                            string areaName = newLine.Substring(0, commaIndex);
                            a.ScreamAreaList.Add(areaName);
                            newLine = newLine.Remove(0, commaIndex + 1);
                        }
                        else if (endIndex > 0)
                        {
                            string areaName = newLine.Substring(0, endIndex);
                            a.ScreamAreaList.Add(areaName);
                            newLine = newLine.Remove(0, endIndex);
                        }
                        else
                        {
                            break;
                        }
                        if (newLine.IndexOf(" ") == 0)
                        {
                            newLine = newLine.Remove(0, 1);
                        }
                    }
                }
            }
        }
    }
}
