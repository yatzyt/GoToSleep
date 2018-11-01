using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace GoToSleep
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        [DllImport("user32.dll")]
        private static extern void LockWorkStation();

        private void sleepBtn_Click(object sender, EventArgs e)
        {
            Application.SetSuspendState(PowerState.Suspend, true, true);
            Application.Exit();
        }

        private void Hibernate()
        {
            Application.SetSuspendState(PowerState.Hibernate, true, true);
            Application.Exit();
        }
    }
}
