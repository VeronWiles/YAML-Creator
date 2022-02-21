using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static YAML_Creator.YAMLNameWindow;

namespace YAML_Creator
{
    public partial class RPHubLoad : Form
    {
        readonly List<Area> FullAreaList = YAMLNameWindow.FullAreaList;
        public static Area RPHub;

        public RPHubLoad()
        {
            InitializeComponent();

            foreach(Area item in FullAreaList)
            {
                AreaList.Items.Add(item.AreaNameList);
            }
        }

        void RPHubLoad_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void RPHubConfirm_Click(object sender, EventArgs e)
        {
            if (AreaList.SelectedIndex != -1)
            {
                RPHub = FullAreaList[AreaList.SelectedIndex];
                YAMLCreator window = new YAMLCreator();
                window.Show();
                window.FormClosed += new FormClosedEventHandler(RPHubLoad_FormClosed);
                Hide();
            }
        }
    }
}
