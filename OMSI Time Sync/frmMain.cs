﻿using System;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace OMSI_Time_Sync
{
    public partial class frmMain : Form
    {
        public DateTime omsiTime = DateTime.MinValue;
        public DateTime systemTime;

        // Is OMSI loaded into a map?
        public bool omsiLoaded = false;

        // Is OMSI running and this tool has been successfully attached to it?
        public bool processAttached = false;

        // For accessing or writing to OMSI's memory
        public Mem m;

        // For hotkey support
        globalKeyboardHook gkhManualSyncHotkey = new globalKeyboardHook();

        public frmMain()
        {
            InitializeComponent();
        }

        // Get the current date and time in OMSI
        private bool getOmsiTime()
        {
            if (processAttached)
            {
                string dateStr = m.ReadInt(OmsiAddresses.day).ToString("D2") + "/" + m.ReadInt(OmsiAddresses.month).ToString("D2") + "/" + m.ReadInt(OmsiAddresses.year).ToString("D4") + " " + m.ReadByte(OmsiAddresses.hour).ToString("D2") + ":" + m.ReadByte(OmsiAddresses.minute).ToString("D2") + ":" + ((int)Math.Max(0, Math.Min(59, Math.Ceiling(m.ReadFloat(OmsiAddresses.second))))).ToString("D2");

                return DateTime.TryParse(dateStr, out omsiTime);
            }

            return false;
        }

        // Set the date and time in OMSI
        private bool syncOmsiTime()
        {
            try
            {
                // Is OMSI's process attached to this tool AND is OMSI loaded into a map?
                if (processAttached && omsiLoaded)
                {
                    // Get the time difference in seconds between the actual date and time and OMSI's date and time
                    double timeDifference = (systemTime - omsiTime).TotalSeconds;

                    // If either:
                    // - Only resync OMSI time if behind actual time is disabled
                    // * OR *
                    // - Only resync OMSI time if behind actual time is enabled AND the time difference is greater than 1.0 seconds
                    if (
                        (!AppConfig.onlyResyncOmsiTimeIfBehindActualTime) ||
                        (AppConfig.onlyResyncOmsiTimeIfBehindActualTime && timeDifference > 1.0)
                       )
                    {
                        // Auto Sync Mode:
                        // 0  - Always
                        // 1  - Only when bus is moving
                        // 2  - Only when bus is not moving
                        // 3  - Only when bus has a timetable
                        // 4  - Only when bus has no timetable
                        if (
                            AppConfig.autoSyncModeIndex == 0 ||
                            (
                             AppConfig.autoSyncModeIndex == 1 &&
                             OmsiTelemetry.pluginActive &&
                             OmsiTelemetry.busSpeedKph > 0.0
                            ) ||
                            (
                             AppConfig.autoSyncModeIndex == 2 &&
                             OmsiTelemetry.pluginActive &&
                             OmsiTelemetry.busSpeedKph == 0.0
                            ) ||
                            (
                             AppConfig.autoSyncModeIndex == 3 &&
                             OmsiTelemetry.pluginActive &&
                             OmsiTelemetry.scheduleActive == 1
                            ) ||
                            (
                             AppConfig.autoSyncModeIndex == 4 &&
                             OmsiTelemetry.pluginActive &&
                             OmsiTelemetry.scheduleActive == 0
                            )
                           )
                        {
                            // Get current system date and time
                            DateTime newSystemTime = systemTime;

                            // This should prevent a rare scenario where BCS thinks the time has been set in the past
                            if (AppConfig.onlyResyncOmsiTimeIfBehindActualTime)
                            {
                                // If only resync OMSI time if behind actual time is enabled then:
                                // - Add two seconds to the system time retrieved a moment ago
                                newSystemTime = newSystemTime.AddSeconds(2.0);
                            }

                            // Apply the new date and time in OMSI by modifying some of the addresses in memory
                            m.WriteMemory(OmsiAddresses.hour, "int", newSystemTime.Hour.ToString());
                            m.WriteMemory(OmsiAddresses.minute, "int", newSystemTime.Minute.ToString());
                            m.WriteMemory(OmsiAddresses.second, "float", newSystemTime.Second.ToString());

                            m.WriteMemory(OmsiAddresses.day, "int", newSystemTime.Day.ToString());
                            m.WriteMemory(OmsiAddresses.month, "int", newSystemTime.Month.ToString());
                            m.WriteMemory(OmsiAddresses.year, "int", newSystemTime.Year.ToString());
                        }
                    }

                    // Get the latest date and time in OMSI again
                    return getOmsiTime();
                }
            }
            catch { }

            return false;
        }

        // Load the app config
        private bool loadConfig()
        {
            try
            {
                TextReader txtRdr = new StreamReader("config.txt");

                AppConfig.alwaysOnTop = Convert.ToBoolean(txtRdr.ReadLine());
                AppConfig.autoSyncOmsiTime = Convert.ToBoolean(txtRdr.ReadLine());
                AppConfig.onlyResyncOmsiTimeIfBehindActualTime = Convert.ToBoolean(txtRdr.ReadLine());
                AppConfig.offsetHour = Math.Max(-23, Math.Min(23, Convert.ToInt32(txtRdr.ReadLine())));
                AppConfig.offsetHourIndex = Convert.ToInt32(txtRdr.ReadLine());
                AppConfig.windowPositionLeft = Convert.ToInt32(txtRdr.ReadLine());
                AppConfig.windowPositionTop = Convert.ToInt32(txtRdr.ReadLine());
                AppConfig.manualSyncHotkeyIndex = Convert.ToInt32(txtRdr.ReadLine());
                AppConfig.autoSyncModeIndex = Convert.ToInt32(txtRdr.ReadLine());

                return true;
            }
            catch
            {
                // If something goes wrong then use the default settings
                AppConfig.alwaysOnTop = AppConfigDefaults.alwaysOnTop;
                AppConfig.autoSyncOmsiTime = AppConfigDefaults.autoSyncOmsiTime;
                AppConfig.onlyResyncOmsiTimeIfBehindActualTime = AppConfigDefaults.onlyResyncOmsiTimeIfBehindActualTime;
                AppConfig.offsetHour = AppConfigDefaults.offsetHour;
                AppConfig.offsetHourIndex = AppConfigDefaults.offsetHourIndex;
                AppConfig.windowPositionLeft = AppConfigDefaults.windowPositionLeft;
                AppConfig.windowPositionTop = AppConfigDefaults.windowPositionTop;
                AppConfig.manualSyncHotkeyIndex = AppConfigDefaults.manualSyncHotkeyIndex;
                AppConfig.autoSyncModeIndex = AppConfigDefaults.autoSyncModeIndex;

                return false; 
            }
        }

        // SAve the app config
        private bool saveConfig()
        {
            try
            {
                TextWriter txtWtr = new StreamWriter("config.txt");

                txtWtr.WriteLine(AppConfig.alwaysOnTop.ToString());
                txtWtr.WriteLine(AppConfig.autoSyncOmsiTime.ToString());
                txtWtr.WriteLine(AppConfig.onlyResyncOmsiTimeIfBehindActualTime.ToString());
                txtWtr.WriteLine(AppConfig.offsetHour.ToString());
                txtWtr.WriteLine(AppConfig.offsetHourIndex.ToString());
                txtWtr.WriteLine(AppConfig.windowPositionLeft.ToString());
                txtWtr.WriteLine(AppConfig.windowPositionTop.ToString());
                txtWtr.WriteLine(AppConfig.manualSyncHotkeyIndex.ToString());
                txtWtr.WriteLine(AppConfig.autoSyncModeIndex.ToString());

                txtWtr.Close();

                return true;
            }
            catch { return false; }
        }

        // Run the named pipe client for communication with the optional telemetry plugin for OMSI
        void RunClient()
        {
            // Loop to keep this thread active
            while (true)
            {
                try
                {
                    // Setup a new named pipe client
                    using (var pipeClient = new NamedPipeClientStream(".", "OmsiTimeSyncTelemetryPlugin", PipeDirection.InOut))
                    {
                        // If named pipe client is connected then pluginActive will be true
                        OmsiTelemetry.pluginActive = pipeClient.IsConnected;

                        // If named pipe client isn't connected then try making a connection indefinitely until one is established
                        if (!pipeClient.IsConnected)
                        {
                            // Connect the named pipe client indefinitely until a connection is established
                            pipeClient.Connect();
                        }

                        // If named pipe client is connected then pluginActive will be true
                        OmsiTelemetry.pluginActive = pipeClient.IsConnected;

                        // Stream reader and writer for communication in and out
                        using (var reader = new StreamReader(pipeClient))
                        {
                            using (var writer = new StreamWriter(pipeClient))
                            {
                                // Another loop to keep this section active
                                while (true)
                                {
                                    // Request telemetry from the OMSI plugin
                                    writer.WriteLine("telemetry");
                                    writer.Flush();

                                    pipeClient.WaitForPipeDrain();

                                    // Wait for a response from the OMSI plugin
                                    var message = reader.ReadLine();

                                    // If message isn't empty, pretty much
                                    if (message != null)
                                    {
                                        try
                                        {
                                            // We're only expecting a telemetry response, so try to split the response accordingly
                                            string[] telemetryData = message.Split(new char[] { '*' });

                                            // Try to parse the following:
                                            float.TryParse(telemetryData[0], out OmsiTelemetry.busSpeedKph);
                                            byte.TryParse(telemetryData[1], out OmsiTelemetry.scheduleActive);
                                        }
                                        catch { }
                                    };

                                    // Wait 1 second before requesting new telemetry
                                    System.Threading.Thread.Sleep(1000);
                                }
                            }
                        }
                    }
                }
                catch { }
            }
        }

        // Timer that runs every 1 second
        private void tmrOMSI_Tick(object sender, EventArgs e)
        {
            // If the plugin is active or not then indicate this on the UI
            if (OmsiTelemetry.pluginActive)
            {
                this.lblOmsiTelemetryPluginStatus.Text = "Active";
            }
            else
            {
                this.lblOmsiTelemetryPluginStatus.Text = "Not Detected";
            }

            // Adjust the actual time by the number of 'offset hours' that is set in the UI
            systemTime = DateTime.Now.AddHours(AppConfig.offsetHour);

            // Display the actual time in the UI
            lblSystemTime.Text = systemTime.ToString();

            // Search for Omsi.exe process
            int processID = m.GetProcIdFromName("omsi");

            // If process isn't already attached
            if (!processAttached)
            {
                // If a process was found
                if (processID > 0)
                {
                    // Attach to the process
                    processAttached = m.OpenProcess(processID);
                }
            }

            // If a process can't be found and one is attached
            if (processID <= 0 && processAttached)
            {
                // De-attach process
                processAttached = false;

                m.CloseProcess();
            }
            
            // If a process is attached
            if (processAttached)
            {
                // If getOmsiTime() is true then OMSI is loaded into a map with a valid date and time
                omsiLoaded = getOmsiTime();

                // If OMSI isn't loaded into a map
                if (!omsiLoaded)
                {
                    // Indicate that OMSI is running but isn't loaded into a map yet
                    lblOmsiTime.Text = "OMSI is running, waiting for a map to load!";

                    // Don't execute any further code yet
                    return;
                }

                // If auto sync OMSI time is enabled
                if (AppConfig.autoSyncOmsiTime)
                {
                    // Go ahead with syncing OMSI time
                    syncOmsiTime();
                }

                // State the current date and time of OMSI in the UI
                lblOmsiTime.Text = omsiTime.ToString();
            }
            else
            {
                // State that 'OMSI is not running' in the UI
                lblOmsiTime.Text = "OMSI is not running!";
            }
        }

        // For handling the state of auto syncing OMSI time
        private void chkAutoSyncOmsiTime_CheckedChanged(object sender, EventArgs e)
        {
            AppConfig.autoSyncOmsiTime = chkAutoSyncOmsiTime.Checked;

            btnManualSyncOmsiTime.Enabled = !chkAutoSyncOmsiTime.Checked;
        }

        // For handling the state of only resyncing OMSI time if it's behind the actual time
        private void chkOnlyResyncOmsiTimeIfBehindActualTime_CheckedChanged(object sender, EventArgs e)
        {
            AppConfig.onlyResyncOmsiTimeIfBehindActualTime = chkOnlyResyncOmsiTimeIfBehindActualTime.Checked;
        }

        // For handling the 'offset hours' setting
        private void cmbOffsetHours_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppConfig.offsetHour = Convert.ToInt32(cmbOffsetHours.SelectedItem);
            AppConfig.offsetHourIndex = cmbOffsetHours.SelectedIndex;
        }

        // For handling the state of 'always on top'
        private void chkAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            AppConfig.alwaysOnTop = chkAlwaysOnTop.Checked;
            TopMost = chkAlwaysOnTop.Checked;
        }


        // For manually syncing OMSI's time when pressing the button on the UI
        private void btnManualSyncOmsiTime_Click(object sender, EventArgs e)
        {
            // Attempt to sync OMSI's time with the actual time, but if it fails...
            if (!syncOmsiTime())
            {
                // Show an error message stating that it failed for some reason
                MessageBox.Show("ERROR: Unable to sync OMSI time. Please check that OMSI is running and a map has been loaded.", "OMSI Time Sync - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // For handling the manual sync hotkey setting
        private void cmbManualSyncHotkey_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If there are already hotkeys being monitored
            if (gkhManualSyncHotkey.HookedKeys.Count > 0)
            {
                // Clear them
                gkhManualSyncHotkey.HookedKeys.Clear();
            }

            // If the hotkey preference isn't 'none'
            if ((Keys)cmbManualSyncHotkey.SelectedItem != Keys.None)
            {
                // Add the hotkey to be monitored
                gkhManualSyncHotkey.HookedKeys.Add((Keys)cmbManualSyncHotkey.SelectedItem);
            }

            // If the dropdown list is visible then apply the current choice from the dropdown list to the app's config
            if (cmbManualSyncHotkey.Visible) AppConfig.manualSyncHotkeyIndex = cmbManualSyncHotkey.SelectedIndex;
        }

        // For when the manual sync hotkey is pressed (well, released)
        private void manualSyncHotkey_KeyUp(object sender, KeyEventArgs e)
        {
            // Sync OMSI time with actual time, if possible
            syncOmsiTime();
        }

        // For handling the auto sync mode setting
        private void cmbAutoSyncMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppConfig.autoSyncModeIndex = cmbAutoSyncMode.SelectedIndex;
        }

        // Github link
        private void lnkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://github.com/Ixe1/OMSI-Time-Sync");
        }

        // Donate link
        private void lnkDonate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://paypal.me/ixe1");
        }

        // Form loading event
        private void frmMain_Load(object sender, EventArgs e)
        {
            // Load app config
            loadConfig();

            // If app config has a previous window position then apply it to the UI
            if (AppConfig.windowPositionTop != -1 && AppConfig.windowPositionLeft != -1)
            {
                StartPosition = FormStartPosition.Manual;

                Top = AppConfig.windowPositionTop;
                Left = AppConfig.windowPositionLeft;
            }

            // Get a list of potential hotkeys to choose from for the manual sync hotkey
            cmbManualSyncHotkey.DataSource = Enum.GetValues(typeof(Keys));

            // Setup the dropdown lists so they are configured based on the app's config
            cmbOffsetHours.SelectedIndex = AppConfig.offsetHourIndex;
            cmbManualSyncHotkey.SelectedIndex = AppConfig.manualSyncHotkeyIndex;
            cmbAutoSyncMode.SelectedIndex = AppConfig.autoSyncModeIndex;

            // Same with checkboxes
            chkAlwaysOnTop.Checked = AppConfig.alwaysOnTop;
            chkAutoSyncOmsiTime.Checked = AppConfig.autoSyncOmsiTime;
            chkOnlyResyncOmsiTimeIfBehindActualTime.Checked = AppConfig.onlyResyncOmsiTimeIfBehindActualTime;

            // Add 'key released' event for manual sync hotkey
            gkhManualSyncHotkey.KeyUp += new KeyEventHandler(manualSyncHotkey_KeyUp);

            // Show manual sync hotkey dropdown menu
            cmbManualSyncHotkey.Visible = true;

            // If config.txt doesn't exist
            if (!File.Exists("config.txt"))
            {
                // Show initial message box dialog (yes/no)
                if (MessageBox.Show(
                    "Thanks for downloading and running OMSI Time Sync.\n" +
                    "\n" +
                    "It's important that you close any games that have anti-cheat protection before pressing 'Yes'! This program performs memory editing which might be falsely flagged as a hack.\n" +
                    "\n" +
                    "This notice will not be shown again unless the 'config.txt' file is deleted. The author of this program will not be liable.\n" +
                    "\n" +
                    "While this is a free program, a donation is highly appreciated if you like this program.\n" +
                    "\n" +
                    "Do you acknowledge the above notice and agree?",
                    "OMSI Time Sync", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    // If 'no' is chosen then close the app
                    this.Close();
                    Application.Exit();

                    // Don't execute further code
                    return;
                }
            }

            // For accessing and writing to OMSI's memory later on
            m = new Mem();

            // Enable the timer which does various stuff
            tmrOMSI.Enabled = true;

            // For the named pipe client, which will communicate with the OMSI telemetry plugin (optional)
            var client = Task.Factory.StartNew(() => RunClient());
        }

        // Form closing event
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Set current window position in app's config
            AppConfig.windowPositionTop = Top;
            AppConfig.windowPositionLeft = Left;

            // If the timer is enabled
            if (tmrOMSI.Enabled)
            {
                // Save app config
                saveConfig();
            }
        }
    }

    // Important addresses in memory for the OMSI process
    static class OmsiAddresses
    {
        public const string hour = "base+0x0046176C";     // int (h)
        public const string minute = "base+0x0046176D";   // int (m)
        public const string second = "base+0x00461770";   // float (second.millisecond)
        public const string year = "base+0x00461790";     // int (yyyy)
        public const string month = "base+0x0046178C";    // int (m)
        public const string day = "base+0x00461778";      // int (d)
    }

    // For use with the OMSI telemetry plugin (optional)
    static class OmsiTelemetry
    {
        public static bool pluginActive = false;
        public static float busSpeedKph = 0.0f;
        public static byte scheduleActive = 0;
    }

    // This app's config
    static class AppConfig
    {
        public static bool alwaysOnTop = AppConfigDefaults.alwaysOnTop;
        public static bool autoSyncOmsiTime = AppConfigDefaults.autoSyncOmsiTime;
        public static bool onlyResyncOmsiTimeIfBehindActualTime = AppConfigDefaults.onlyResyncOmsiTimeIfBehindActualTime;
        public static int offsetHour = AppConfigDefaults.offsetHour;
        public static int offsetHourIndex = AppConfigDefaults.offsetHourIndex;
        public static int windowPositionLeft = AppConfigDefaults.windowPositionLeft;
        public static int windowPositionTop = AppConfigDefaults.windowPositionTop;
        public static int manualSyncHotkeyIndex = AppConfigDefaults.manualSyncHotkeyIndex;
        public static int autoSyncModeIndex = AppConfigDefaults.autoSyncModeIndex;
    }

    // This app's default config
    static class AppConfigDefaults
    {
        public static bool alwaysOnTop = false;
        public static bool autoSyncOmsiTime = true;
        public static bool onlyResyncOmsiTimeIfBehindActualTime = true;
        public static int offsetHour = 0;
        public static int offsetHourIndex = 23;
        public static int windowPositionLeft = -1;
        public static int windowPositionTop = -1;
        public static int manualSyncHotkeyIndex = 0;
        public static int autoSyncModeIndex = 0;
    }
}
