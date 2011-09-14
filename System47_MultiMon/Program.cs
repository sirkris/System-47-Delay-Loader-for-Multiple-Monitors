/*
 * System 47 Delay Loader for Multiple Monitors
 * Written by Kris Craig.  09.14.2011.
 * 
 * This loader is designed to improve the performance 
 * of the System 47 screensaver on multiple monitors by 
 * loading each instance with a random delay.  This will 
 * cause System 47 to generate a different random seed in 
 * each instance, which in turn will allow each monitor to 
 * display a different LCARS sequence instead of them all 
 * displaying the exact same one.  This adds some awesome 
 * realism to the effect.
 * 
 * See the included WTFPLv3.txt file for license information.  
 * Since System 47 itself does not have a permissive open 
 * source license, you will have to download and install 
 * it separately.
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace System47_MultiMon
{
    public static class Delay
    {
        public static int rand(int low, int high)
        {
            Random random = new Random();
            return random.Next(low, high);
        }

        public static void wait(int low, int high)
        {
            int sec = rand(low, high);
            Thread.Sleep((sec * 1000));
        }
    }

    public static class Screensaver
    {
        [DllImport("user32.dll", EntryPoint = "LockWorkStation")]
        private static extern IntPtr LockWorkStation();

        public static void runScreenSaver()
        {
            Delay.wait(1, 10);
            Process.Start("System47.scr /s");
            LockWorkStation();
        }

        public static void Main()
        {
            runScreenSaver();
        }
    }
}
