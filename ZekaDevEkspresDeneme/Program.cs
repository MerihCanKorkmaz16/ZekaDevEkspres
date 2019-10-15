using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
//using DevExpress.UserSkins;
//using DevExpress.Skins;
//using DevExpress.LookAndFeel;
using System.Threading;


namespace ZekaDevEkspresDeneme
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool kontrol;

            Mutex mutex = new Mutex(true, "Program", out kontrol);
            if (kontrol == false)
            {
                MessageBox.Show("Bu program zaten çalışıyor.");
                return;
            }
            Control.CheckForIllegalCrossThreadCalls = false;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            System.Threading.Thread.Sleep(200);
            Application.Run(new SatınAlmaFormu());
            GC.KeepAlive(mutex);
            
        }
    }
}
