using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaracSP_QuickConnect
{
    public partial class Form1 : Form
    {

        ServerManager sm;

        public Form1()
        {
            InitializeComponent();

            sm = ServerManager.Instance;

            serverBindingSource.DataSource = sm.servers;
            deleteCheck();

            sm.saveToSettings();
        }

        

        private void serverListGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            //Console.WriteLine("Selected Row:" + r);
            deleteCheck();
            populateForm(sm.servers[r]);
        }

        private void serverListGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            MegaracKVM.DownloadAndRunKVM(sm.servers[r]); 
        }

        // Helpers for ServerManager
        // Delete from Settings
        private void deleteServer(int idx)
        {
            // Remove from the binding to update List<> and Grid
            // http://stackoverflow.com/questions/1435479/refreshing-datagridview-bindings-to-a-list-when-a-row-is-deleted
            serverBindingSource.RemoveAt(idx);
            sm.saveToSettings();
        }

        // Add to Settings
        private void addServer(Server s)
        {
            serverBindingSource.Add(s);
            sm.saveToSettings();
        }

        // Given a server, populate form fields
        private void populateForm(Server s)
        {
            txtHost.Text = s.host;
            txtUsername.Text = s.username;
            txtPassword.Text = s.password;
        }

        private void txtHost_TextChanged(object sender, EventArgs e)
        {
            connectAndSaveCheck();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            connectAndSaveCheck();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            connectAndSaveCheck();
        }

        // See if delete button is clickable
        // and enable/disable accordingly
        public void deleteCheck()
        {
            deleteButton.Enabled = serverListGrid.CurrentRow != null;
        }

        public void connectAndSaveCheck()
        {
            bool form = filledOutForm();
            connectButton.Enabled = form;
            saveButton.Enabled = form;
        }

        // Return True if minimal values required were filled in
        private bool filledOutForm()
        {
            return txtHost.Text.Length != 0 && txtUsername.Text.Length != 0;
        }

        // Delete server button
        private void deleteButton_Click(object sender, EventArgs e)
        {
            int r = serverListGrid.CurrentRow.Index;
            deleteServer(r);
        }

        // Add server to list
        private void saveButton_Click(object sender, EventArgs e)
        {
            Server s = new Server(txtHost.Text, txtUsername.Text, txtPassword.Text);
            addServer(s);
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            Server s = new Server(txtHost.Text, txtUsername.Text, txtPassword.Text);
            MegaracKVM.DownloadAndRunKVM(s);
        }

        private void lblHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Navigate to a URL.
            System.Diagnostics.Process.Start("http://prashker.net");
        }
    }
}
