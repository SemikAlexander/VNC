using System;
using System.Windows.Forms;
using VncSharp;

namespace VncClient
{
    public partial class VncClientForm : System.Windows.Forms.Form
    {
        public VncClientForm()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            string remoteHost = hostTextBox.Text;
            int port = Convert.ToInt32(portTextBox.Text);
            try
            {
                remoteDesktop1.VncPort = port;
                remoteDesktop1.Connect(remoteHost, false, true);
            }
            catch (VncProtocolException ex)
            {
                MessageBox.Show(string.Format("Невозможно установить соединение: {0}", ex.Message));
            }
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                remoteDesktop1.Disconnect();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(string.Format("Невозможно отключитья от сервера: {0}", ex.Message));
            }
        }

        private void VncClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                remoteDesktop1.Disconnect();
            }
            catch (InvalidOperationException ex) { }
        }
    }
}
