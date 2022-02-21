using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static YAML_Creator.YAMLNameWindow;
using static YAML_Creator.RPHubLoad;

namespace YAML_Creator
{
    public partial class YAMLCreator : Form
    {
        List<Area> FullAreaList = YAMLNameWindow.FullAreaList;
        public static int AreaCounter = 0;
        public static string RPHubName = "";
        public static string YAMLPath = YAMLNameWindow.YAMLPath;
        public static bool DefClicked = false;
        public static int areaClicked = -1;
        public static bool delayOver = false;

        public YAMLCreator()
        {
            InitializeComponent();

            if(FullAreaList != null)
            {
                RPHubName = RPHub.AreaNameList;
                foreach(Area a in FullAreaList)
                {
                    AllAreasView.Items.Add(a.AreaNameList);
                    AreaListReachable.Items.Add(a.AreaNameList);
                    AreaCounter++;
                }
            } 
            else
            {
                FullAreaList = new List<Area>();
            }
        }

        private void CreateArea_Click(object sender, EventArgs e)
        {
            if (AreaName.Text == "")
            {
                return;
            }
            Area a = new Area();
            AllAreasView.Items.Add(AreaName.Text);
            AreaListReachable.Items.Add(AreaName.Text);
            a.AreaNameList = AreaName.Text;
            a.BackgroundFolderList = Background.Text;
            a.DescriptionList = Description.Text;
            if (RPHubName != "")
            {
                a.ReachableAreaList.Add(RPHubName);
            }
            
            AreaCounter++;
            AreaName.Text = "";
            Background.Text = "";
            Description.Text = "";
            AreaNumber.Text = "Number of Areas: " + AreaCounter;
            FullAreaList.Add(a);
        }
        private void CreateCHub_Click(object sender, EventArgs e)
        {
            if (AreaName.Text == "")
            {
                return;
            }
            Area a = new Area();
            AllAreasView.Items.Add(AreaName.Text);
            AreaListReachable.Items.Add(AreaName.Text); ;
            a.AreaNameList = AreaName.Text;
            a.BackgroundFolderList = Background.Text;
            a.DescriptionList = Description.Text;
            a.Lock = false;
            a.GetAreas = true;
            a.RPArea = false;
            a.BGLock = false;
            a.Bullet = true;
            a.Iniswap = true;
            a.Lobby = false;
            a.SongSwitch = true;
            a.RollP = true;
            RPHubName = AreaName.Text;
            AreaCounter++;
            AreaName.Text = "";
            Background.Text = "";
            Description.Text = "";
            AreaNumber.Text = "Number of Areas: " + AreaCounter;
            FullAreaList.Add(a);
        }

        private void CreateDHub_Click(object sender, EventArgs e)
        {
            if (DefClicked)
            {
                return;
            }
            DefClicked = true;
            Area a = new Area();
            AllAreasView.Items.Add("Main RP Hub");
            AreaListReachable.Items.Add("Main RP Hub");
            a.AreaNameList = "Main RP Hub";
            a.BackgroundFolderList = "Class Trial Debate Room V3-1_HD";
            a.DescriptionList = "";
            a.Lock = false;
            a.GetAreas = true;
            a.RPArea = false;
            a.BGLock = false;
            a.Bullet = true;
            a.Iniswap = true;
            a.Lobby = false;
            a.SongSwitch = true;
            a.RollP = true;
            RPHubName = "Main RP Hub";
            AreaCounter++;
            AreaName.Text = "";
            Background.Text = "";
            Description.Text = "";
            AreaNumber.Text = "Number of Areas: " + AreaCounter;
            FullAreaList.Add(a);
        }

        private void AllAreasView_SelectedIndexChanged(object sender, EventArgs e)
        {
            delayOver = false;
            if (AllAreasView.SelectedIndex >= 0)
            {
                var selectedArea = FullAreaList[AllAreasView.SelectedIndex];
                if (selectedArea != null) {
                    AreaListReachableView.Items.Clear();
                    AreaListScreamView.Items.Clear();
                    AreaNameDisplay.Text = selectedArea.AreaNameList;
                    BackgroundDisplay.Text = selectedArea.BackgroundFolderList;
                    DescriptionDisplay.Text = selectedArea.DescriptionList;
                    LockAllowed.Checked = selectedArea.Lock;
                    UseGetareas.Checked = selectedArea.GetAreas;
                    RPArea.Checked = selectedArea.RPArea;
                    BGLock.Checked = selectedArea.BGLock;
                    Bullet.Checked = selectedArea.Bullet;
                    Ini.Checked = selectedArea.Iniswap;
                    Lobby.Checked = selectedArea.Lobby;
                    SongSwitch.Checked = selectedArea.SongSwitch;
                    RollP.Checked = selectedArea.RollP;
                    foreach (string element in selectedArea.ReachableAreaList)
                    {
                        AreaListReachableView.Items.Add(element);
                    }
                    foreach (string element in selectedArea.ScreamAreaList)
                    {
                        AreaListScreamView.Items.Add(element);
                    }
                    areaClicked = AllAreasView.SelectedIndex;
                }
            }
            delayOver = true;
        }

        private void AreaRemove_Click(object sender, EventArgs e)
        {
            if (AllAreasView.SelectedIndex == -1)
            {
                return;
            }
            for(int i = 0; i < FullAreaList.Count; i++)
            {
                FullAreaList[i].ReachableAreaList.Remove(AllAreasView.GetItemText(AllAreasView.SelectedItem));
                FullAreaList[i].ScreamAreaList.Remove(AllAreasView.GetItemText(AllAreasView.SelectedItem));
            }
            FullAreaList.RemoveAt(AllAreasView.SelectedIndex);
            AreaListReachable.Items.RemoveAt(AllAreasView.SelectedIndex);
            AllAreasView.Items.RemoveAt(AllAreasView.SelectedIndex);
            AreaCounter--;
            AreaNumber.Text = "Number of Areas: " + AreaCounter;
        }

        private void RemoveReachableArea_Click(object sender, EventArgs e)
        {
            if (AreaListReachableView.SelectedIndex == -1)
            {
                return;
            }
            FullAreaList[AllAreasView.SelectedIndex].ReachableAreaList.RemoveAt(AreaListReachableView.SelectedIndex);
            AreaListReachableView.Items.RemoveAt(AreaListReachableView.SelectedIndex);
        }

        private void RemoveScreamArea_Click(object sender, EventArgs e)
        {
            if (AreaListScreamView.SelectedIndex == -1)
            {
                return;
            }
            FullAreaList[AllAreasView.SelectedIndex].ScreamAreaList.RemoveAt(AreaListScreamView.SelectedIndex);
            AreaListScreamView.Items.RemoveAt(AreaListScreamView.SelectedIndex);
        }

        private void ReachableAreaAdd_Click(object sender, EventArgs e)
        {
            if (AreaListReachable.SelectedIndex == -1 || AreaListReachable.SelectedItem == AllAreasView.SelectedItem)
            {
                return;
            }
            ListBox.ObjectCollection list = AreaListReachableView.Items;
            foreach(string item in list)
            {
                if (item == AreaListReachable.GetItemText(AreaListReachable.SelectedItem))
                {
                    return;
                }
            }

            ListBox.SelectedObjectCollection objects = AreaListReachable.SelectedItems;
            foreach (string item in objects)
            {
                if (item == AllAreasView.GetItemText(AllAreasView.SelectedItem))
                {
                    return;
                }
                else
                {
                    int itemIndex = 0;
                    FullAreaList[AllAreasView.SelectedIndex].ReachableAreaList.Add(item);
                    AreaListReachableView.Items.Add(item);
                    foreach (Area a in FullAreaList)
                    {
                        if(a.AreaNameList == item)
                        {
                            break;
                        }
                        itemIndex++;
                    }
                    FullAreaList[itemIndex].ReachableAreaList.Add(FullAreaList[AllAreasView.SelectedIndex].AreaNameList);
                }
            }
            
        }

        private void ScreamAreaAdd_Click(object sender, EventArgs e)
        {
            if (AreaListReachable.SelectedIndex == -1 || AreaListReachable.SelectedItem == AllAreasView.SelectedItem)
            {
                return;
            }

            ListBox.ObjectCollection list = AreaListScreamView.Items;
            foreach (string item in list)
            {
                if (item == AreaListReachable.GetItemText(AreaListReachable.SelectedItem))
                {
                    return;
                }
            }

            ListBox.SelectedObjectCollection objects = AreaListReachable.SelectedItems;
            foreach (string item in objects)
            {
                if (item == AllAreasView.GetItemText(AllAreasView.SelectedItem))
                {
                    return;
                }
                else
                {
                    int itemIndex = 0;
                    FullAreaList[AllAreasView.SelectedIndex].ScreamAreaList.Add(item);
                    AreaListScreamView.Items.Add(item);
                    foreach (Area a in FullAreaList)
                    {
                        if (a.AreaNameList == item)
                        {
                            break;
                        }
                        itemIndex++;
                    }
                    FullAreaList[itemIndex].ScreamAreaList.Add(FullAreaList[AllAreasView.SelectedIndex].AreaNameList);
                }
            }
        }

        private void BothAdd_Click(object sender, EventArgs e)
        {
            if (AreaListReachable.SelectedIndex == -1 || AreaListReachable.SelectedItem == AllAreasView.SelectedItem)
            {
                return;
            }

            ListBox.ObjectCollection list = AreaListScreamView.Items;
            foreach (string item in list)
            {
                if (item == AreaListReachable.GetItemText(AreaListReachable.SelectedItem))
                {
                    return;
                }
            }

            ListBox.ObjectCollection slist = AreaListReachableView.Items;
            foreach (string sitem in slist)
            {
                if (sitem == AreaListReachable.GetItemText(AreaListReachable.SelectedItem))
                {
                    return;
                }
            }


            ListBox.SelectedObjectCollection objects = AreaListReachable.SelectedItems;
            foreach (string item in objects)
            {
                if (item == AllAreasView.GetItemText(AllAreasView.SelectedItem))
                {
                    return;
                }
                else
                {
                    int itemIndexS = 0;
                    FullAreaList[AllAreasView.SelectedIndex].ScreamAreaList.Add(item);
                    AreaListScreamView.Items.Add(item);
                    foreach (Area a in FullAreaList)
                    {
                        if (a.AreaNameList == item)
                        {
                            break;
                        }
                        itemIndexS++;
                    }
                    FullAreaList[itemIndexS].ScreamAreaList.Add(FullAreaList[AllAreasView.SelectedIndex].AreaNameList);

                    int itemIndexR = 0;
                    FullAreaList[AllAreasView.SelectedIndex].ReachableAreaList.Add(item);
                    AreaListReachableView.Items.Add(item);
                    foreach (Area a in FullAreaList)
                    {
                        if (a.AreaNameList == item)
                        {
                            break;
                        }
                        itemIndexR++;
                    }
                    FullAreaList[itemIndexR].ReachableAreaList.Add(FullAreaList[AllAreasView.SelectedIndex].AreaNameList);
                }
            }
        }

        private void CreateYAML_Click(object sender, EventArgs e)
        {
            File.WriteAllText(YAMLPath, "");
            for (var i = 0; i < FullAreaList.Count; i++)
            {
                Area a = FullAreaList[i];
                File.AppendAllText(YAMLPath, "- area: " + a.AreaNameList + Environment.NewLine);
                File.AppendAllText(YAMLPath, "  background: " + a.BackgroundFolderList + Environment.NewLine);
                File.AppendAllText(YAMLPath, "  bglock: " + a.BGLock + Environment.NewLine);
                File.AppendAllText(YAMLPath, "  locking_allowed: " + a.Lock + Environment.NewLine);
                File.AppendAllText(YAMLPath, "  rp_getareas_allowed: " + a.GetAreas + Environment.NewLine);
                File.AppendAllText(YAMLPath, "  rp_area: " + a.RPArea + Environment.NewLine);
                File.AppendAllText(YAMLPath, "  bullet: " + a.Bullet + Environment.NewLine);
                File.AppendAllText(YAMLPath, "  iniswap_allowed: " + a.Iniswap + Environment.NewLine);
                File.AppendAllText(YAMLPath, "  lobby_area: " + a.Lobby + Environment.NewLine);
                File.AppendAllText(YAMLPath, "  song_switch_allowed: " + a.SongSwitch + Environment.NewLine);
                File.AppendAllText(YAMLPath, "  rollp_allowed: " + a.RollP + Environment.NewLine);


                if (a.DescriptionList != "" && a.DescriptionList != " " && i != 0)
                {
                    File.AppendAllText(YAMLPath, "  default_description: " + a.DescriptionList + Environment.NewLine);
                }
                if (a.ReachableAreaList.Count != 0)
                {
                    File.AppendAllText(YAMLPath, "  reachable_areas: ");
                    for (int ind = 0; ind < a.ReachableAreaList.Count; ind++)
                    {
                        File.AppendAllText(YAMLPath, a.ReachableAreaList[ind]);
                        if (ind != a.ReachableAreaList.Count - 1)
                        {
                            File.AppendAllText(YAMLPath, ", ");
                        }
                    }
                    File.AppendAllText(YAMLPath, Environment.NewLine);
                }
                if (a.ScreamAreaList.Count != 0)
                {
                    File.AppendAllText(YAMLPath, "  scream_range: ");
                    for (int ind = 0; ind < a.ScreamAreaList.Count; ind++)
                    {
                        File.AppendAllText(YAMLPath, a.ScreamAreaList[ind]);
                        if (ind != a.ScreamAreaList.Count - 1)
                        {
                            File.AppendAllText(YAMLPath, ", ");
                        }
                    }
                    File.AppendAllText(YAMLPath, Environment.NewLine);
                }
                MessageBox.Show("YAML Created successfully at " + YAMLPath + ".");
                Close();
                Close();
            }
        }

        private void DROSafe_Click(object sender, EventArgs e)
        {
            File.WriteAllText(YAMLPath, "");
            AppendDefaultAreas();
            for (var i = 0; i < FullAreaList.Count; i++)
            {
                Area a = FullAreaList[i];
                File.AppendAllText(YAMLPath, "- area: " + a.AreaNameList + Environment.NewLine);
                File.AppendAllText(YAMLPath, "  background: " + a.BackgroundFolderList + Environment.NewLine);
                File.AppendAllText(YAMLPath, "  bglock: " + a.BGLock + Environment.NewLine);
                File.AppendAllText(YAMLPath, "  locking_allowed: " + a.Lock + Environment.NewLine);
                File.AppendAllText(YAMLPath, "  rp_getareas_allowed: " + a.GetAreas + Environment.NewLine);
                File.AppendAllText(YAMLPath, "  rp_area: " + a.RPArea + Environment.NewLine);
                File.AppendAllText(YAMLPath, "  bullet: " + a.Bullet + Environment.NewLine);
                File.AppendAllText(YAMLPath, "  iniswap_allowed: " + a.Iniswap + Environment.NewLine);
                File.AppendAllText(YAMLPath, "  lobby_area: " + a.Lobby + Environment.NewLine);
                File.AppendAllText(YAMLPath, "  song_switch_allowed: " + a.SongSwitch + Environment.NewLine);
                File.AppendAllText(YAMLPath, "  rollp_allowed: " + a.RollP + Environment.NewLine);
                File.AppendAllText(YAMLPath, "  default_description: " + a.DescriptionList + Environment.NewLine);
                File.AppendAllText(YAMLPath, "  reachable_areas: ");
                for (int ind = 0; ind < a.ReachableAreaList.Count; ind++)
                {
                    File.AppendAllText(YAMLPath, a.ReachableAreaList[ind]);
                    if (ind != a.ReachableAreaList.Count - 1)
                    {
                        File.AppendAllText(YAMLPath, ", ");
                    }
                }
                File.AppendAllText(YAMLPath, Environment.NewLine);
                File.AppendAllText(YAMLPath, "  scream_range: ");
                for(int ind = 0; ind < a.ScreamAreaList.Count; ind++)
                {
                    File.AppendAllText(YAMLPath, a.ScreamAreaList[ind]);
                    if(ind != a.ScreamAreaList.Count-1)
                    {
                        File.AppendAllText(YAMLPath, ", ");
                    }
                }
                File.AppendAllText(YAMLPath, Environment.NewLine);
                MessageBox.Show("YAML Created successfully at " + YAMLPath + ".");
                Close();
            }
        }

        public void AppendDefaultAreas()
        {
            File.AppendAllText(YAMLPath, "- area: Lobby" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  background: Class Trial Debate Room DR2-1_HD" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  bglock: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  evidence_mod: FFA" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  locking_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  iniswap_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  rollp_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  tl_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  change_reachability_allowed: false" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  lobby_area: true" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  gm_ic_allowed: false" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  song_switch_allowed: true" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  bullet: false" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "- area: Jail" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  background: Headmaster's Office_HD" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  bglock: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  evidence_mod: CM" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  locking_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  iniswap_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  rollp_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  tl_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  change_reachability_allowed: false" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  lobby_area: true" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  gm_ic_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "- area: Class Trial Room" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  background: Class Trial Debate Room DR2-3_HD" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  bglock: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  evidence_mod: CM" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  locking_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  iniswap_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  rollp_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  tl_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  change_reachability_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "- area: Class Trial Room 2" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  background: Class Trial Debate Room DR2-5_HD" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  bglock: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  evidence_mod: CM" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  locking_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  iniswap_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  rollp_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  tl_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  change_reachability_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "- area: Mock Trial Room" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  background: Class Trial Debate Room DR1-3_HD" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  bglock: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  evidence_mod: CM" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  locking_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  iniswap_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  rollp_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  tl_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  song_switch_allowed: true" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  change_reachability_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "- area: Parlor" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  background: Principal's Room_HD" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  bglock: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  evidence_mod: CM" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  locking_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  iniswap_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  rollp_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  tl_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  change_reachability_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  lobby_area: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  gm_ic_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  bullet: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "- area: OOC Game Room" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  background: Game Room_HD" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  bglock: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  evidence_mod: FFA" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  locking_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  iniswap_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  rollp_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  tl_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  change_reachability_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  lobby_area: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  gm_ic_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  song_switch_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "- area: Testing Labs" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  background: Bio Lab_HD" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  bglock: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  evidence_mod: CM" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  locking_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  iniswap_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  rollp_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  tl_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  change_reachability_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  lobby_area: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  gm_ic_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  song_switch_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  cbg_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  bullet: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "- area: OOC Meeting Room" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  background: Headmaster's Office_HD" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  bglock: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  evidence_mod: FFA" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  locking_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  iniswap_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  rollp_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  tl_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  change_reachability_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  lobby_area: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  gm_ic_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  song_switch_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "- area: OOC Venting Room" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  background: VLR Biotope Vents_HD" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  bglock: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  evidence_mod: FFA" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  locking_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  iniswap_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  rollp_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  tl_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  change_reachability_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  lobby_area: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  gm_ic_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  song_switch_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "- area: The Stained Thinkery" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  background: Class Trial Debate Room DR2-1_HD" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  bglock: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  evidence_mod: CM" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  locking_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  iniswap_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  rollp_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  tl_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  change_reachability_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  lobby_area: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  gm_ic_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  song_switch_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "- area: Less Stained Thinkery" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  background: Class Trial Debate Room DR2-6_HD" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  bglock: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  evidence_mod: CM" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  locking_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  iniswap_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  rollp_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  tl_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  change_reachability_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  lobby_area: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  gm_ic_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  song_switch_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "- area: Love Hotel" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  background: V3 Love Hotel_HD" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  bglock: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  evidence_mod: CM" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  locking_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  iniswap_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  rollp_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  tl_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  change_reachability_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  lobby_area: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  gm_ic_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  song_switch_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "- area: Love Hotel 2" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  background: V3 Love Hotel_HD" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  bglock: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  evidence_mod: CM" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  locking_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  iniswap_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  rollp_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  tl_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  change_reachability_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  lobby_area: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  gm_ic_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  song_switch_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "- area: Love Hotel 3" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  background: V3 Love Hotel_HD" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  bglock: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  evidence_mod: CM" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  locking_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  iniswap_allowed: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  rollp_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  tl_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  change_reachability_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  lobby_area: True" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  gm_ic_allowed: False" + Environment.NewLine);
            File.AppendAllText(YAMLPath, "  song_switch_allowed: True" + Environment.NewLine);
        }

        private void AreaNameDisplay_TextChanged(object sender, EventArgs e)
        {
            if (areaClicked >= 0 && delayOver)
            {
                var selectedArea = FullAreaList[areaClicked];

                selectedArea.AreaNameList = AreaNameDisplay.Text;
                AreaListReachable.Items[areaClicked] = AreaNameDisplay.Text;
                AllAreasView.Items[areaClicked] = AreaNameDisplay.Text;
            }
        }

        private void BackgroundDisplay_TextChanged(object sender, EventArgs e)
        {
            if (areaClicked >= 0 && delayOver)
            {
                var selectedArea = FullAreaList[areaClicked];

                selectedArea.BackgroundFolderList = BackgroundDisplay.Text;
            }
        }

        private void DescriptionDisplay_TextChanged(object sender, EventArgs e)
        {
            if (areaClicked >= 0 && delayOver)
            {
                var selectedArea = FullAreaList[areaClicked];

                selectedArea.DescriptionList = DescriptionDisplay.Text;
            }
        }

        private void LockAllowed_CheckedChanged(object sender, EventArgs e)
        {
            if (areaClicked >= 0 && delayOver)
            {
                var selectedArea = FullAreaList[areaClicked];

                selectedArea.Lock = LockAllowed.Checked;
            }
        }

        private void UseGetareas_CheckedChanged(object sender, EventArgs e)
        {
            if (areaClicked >= 0 && delayOver)
            {
                var selectedArea = FullAreaList[areaClicked];

                selectedArea.GetAreas = UseGetareas.Checked;
            }
        }

        private void RPArea_CheckedChanged(object sender, EventArgs e)
        {
            if (areaClicked >= 0 && delayOver)
            {
                var selectedArea = FullAreaList[areaClicked];

                selectedArea.RPArea = RPArea.Checked;
            }
        }

        private void BGLock_CheckedChanged(object sender, EventArgs e)
        {
            if (areaClicked >= 0 && delayOver)
            {
                var selectedArea = FullAreaList[areaClicked];

                selectedArea.BGLock = BGLock.Checked;
            }
        }

        private void Bullet_CheckedChanged(object sender, EventArgs e)
        {
            if (areaClicked >= 0 && delayOver)
            {
                var selectedArea = FullAreaList[areaClicked];

                selectedArea.Bullet = Bullet.Checked;
            }
        }

        private void Ini_CheckedChanged(object sender, EventArgs e)
        {
            if (areaClicked >= 0 && delayOver)
            {
                var selectedArea = FullAreaList[areaClicked];

                selectedArea.Iniswap = Ini.Checked;
            }
        }

        private void Lobby_CheckedChanged(object sender, EventArgs e)
        {
            if (areaClicked >= 0 && delayOver)
            {
                var selectedArea = FullAreaList[areaClicked];

                selectedArea.Lobby = Lobby.Checked;
            }
        }

        private void SongSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (areaClicked >= 0 && delayOver)
            {
                var selectedArea = FullAreaList[areaClicked];

                selectedArea.SongSwitch = SongSwitch.Checked;
            }
        }

        private void RollP_CheckedChanged(object sender, EventArgs e)
        {
            if (areaClicked >= 0 && delayOver)
            {
                var selectedArea = FullAreaList[areaClicked];

                selectedArea.RollP = RollP.Checked;
            }
        }
    }
}
