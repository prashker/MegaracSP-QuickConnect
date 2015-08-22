using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaracSP_QuickConnect
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Server value provided (silent execution)
            if (args.Length == 1)
            {
                // Silently fail if invalid server provided
                // Array is 0-indexed but user provided values
                // are probably 1-indexed
                // So subtract 1
                // Also this is naive parsing
                // We're only expecting a single number!
                // Someone want to make a proper parser?
                ServerManager sm = ServerManager.Instance;
                int i = Convert.ToInt32(args[0]);
                MegaracKVM.DownloadAndRunKVM(sm.servers[i - 1]);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}
