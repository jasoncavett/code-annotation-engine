using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CAE.src.gui.component
{
    public class FSTree : TreeView
    {
        /// <summary>
        /// A simple File System treeview component populates each level on view and destroys the nodes after the level is closed.
        /// 
        /// By rlemon @ http://codingforums.com/showthread.php?t=98085.
        /// </summary>
        public FSTree()
        {
            this.BeforeExpand += new TreeViewCancelEventHandler(FSTree_BeforeExpand);
            this.AfterCollapse += new TreeViewEventHandler(FSTree_AfterCollapse);
        }

        /// <summary>
        /// After a collapse has happened, remove the nodes underneath the one that was collapsed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FSTree_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.Nodes.Clear();
            e.Node.Nodes.Add("."); // need a node in there to spark the expand.
        }

        /// <summary>
        /// Before the expansion happens, populate with the nodes under the expanded node.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FSTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                e.Node.Nodes.Clear();
                string needle = (string)e.Node.Tag;
                string[] folders = Directory.GetDirectories(needle);
                string[] files = Directory.GetFiles(needle);

                foreach (string folder in folders)
                {
                    try
                    {
                        string[] s_folders = Directory.GetDirectories(folder);
                        string[] s_files = Directory.GetFiles(folder);

                        TreeNode t_folder = getNode(folder);
                        foreach (string s_folder in s_folders)
                        {
                            t_folder.Nodes.Add(getNode(s_folder));
                        }
                        foreach (string s_file in s_files)
                        {
                            t_folder.Nodes.Add(getNode(s_file));
                        }
                        e.Node.Nodes.Add(t_folder);
                    }
                    catch (IOException)
                    {
                    }
                    catch (UnauthorizedAccessException)
                    {
                    }
                }

                foreach (string file in files)
                {
                    e.Node.Nodes.Add(getNode(file));
                }
            }
            catch (IOException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }
        }

        /// <summary>
        /// Load the tree.
        /// </summary>
        /// <param name="root">The root path.</param>
        public void Load(string root)
        {
            this.Nodes.Clear();
            TreeNode nNode = getNode(root);
            nNode.Nodes.Add("."); // need a node in there to spark the expand.
            this.Nodes.Add(nNode);
            this.Nodes[0].Expand();
        }

        /// <summary>
        /// Return a tree node underneath a specific path.
        /// </summary>
        /// <param name="path">The path to search for a node.</param>
        /// <returns>The node at the specific path.</returns>
        private TreeNode getNode(string path)
        {
            TreeNode rNode = new TreeNode();
            int limit = path.LastIndexOf('\\') + 1;
            string name = path.Substring(limit, (path.Length - limit));
            if (name.Length < 1)
            {
                name = path.Substring(0, (path.Length - 1));
            }
            rNode.Text = name;
            rNode.Tag = path;
            return rNode;
        }
    }
}
