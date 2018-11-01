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

        private void Shutdown()
        {
            ManagementBaseObject mboShutdown = null;
            ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
            mcWin32.Get();

            mcWin32.Scope.Options.EnablePrivileges = true;
            ManagementBaseObject mboShutdownParams =
                mcWin32.GetMethodParameters("Win32Shutdown");

            mboShutdownParams["Flags"] = "1";
            mboShutdownParams["Reserved"] = "0";
            foreach (ManagementObject manObj in mcWin32.GetInstances())
            {
                mboShutdown = manObj.InvokeMethod("Win32Shutdown", mboShutdownParams, null);
            }

        }
    }
}
