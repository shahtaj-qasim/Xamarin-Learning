using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Add("People");
            treeView1.Nodes.Add("Animals");
            treeView1.Nodes[0].Nodes.Add("Adam");
            treeView1.Nodes[0].Nodes.Add("Joe");
            treeView1.Nodes[0].Nodes.Add("Bob");
            treeView1.Nodes[1].Nodes.Add("Cat");
            treeView1.Nodes[1].Nodes.Add("Dog");
            treeView1.Nodes[1].Nodes[0].Nodes.Add("Puppy");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Remove();
            //treeview.Nodes.Clear(); removes all nodes inside the
            //treeview
            //treeview property checkbox=true;
            removeChecked(treeView1.Nodes);
        }
        List<TreeNode> tnList = new List<TreeNode>();
        void removeChecked(TreeNodeCollection tnc)
        {
            foreach (TreeNode tn in tnc)
            {
                if (tn.Checked) tnList.Add(tn);
                else if (tn.Nodes.Count != 0) removeChecked(tn.Nodes);

            }
            foreach (TreeNode tn in tnList)
                {
                    treeView1.Nodes.Remove(tn);
                }
            
        }
        
    }
}
