using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Management;


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

        /// <summary>
        /// Shuts down or reboots the system
        /// </summary>
        /// <param name="flag"> 1 is shut down, 2 is reboot. </param>
        private void DieFirst(int flag)
        {
            ManagementBaseObject mboShutdown = null;
            ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
            mcWin32.Get();

            mcWin32.Scope.Options.EnablePrivileges = true;
            ManagementBaseObject mboShutdownParams =
                mcWin32.GetMethodParameters("Win32Shutdown");

            mboShutdownParams["Flags"] = flag.ToString();
            mboShutdownParams["Reserved"] = "0";
            foreach (ManagementObject manObj in mcWin32.GetInstances())
            {
                mboShutdown = manObj.InvokeMethod("Win32Shutdown", mboShutdownParams, null);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Hibernate();
            MessageBox.Show("test");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //DieFirst(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //DieFirst(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Hide();
        }
    }
}
