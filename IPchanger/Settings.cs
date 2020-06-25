using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;

namespace IPchanger
{
    public partial class Settings : Form
    {
        /// <summary>
        /// PRIVATE DECLARATIONS
        /// </summary>
        private StartForm Parent;
        private NetworkInterface Adapter;
        private long BytesSent, BytesRead;
        private string Nazwa, Opis, Typ, Speed, PHY;
        private bool Active, Tx, Rx, Offline, Enabled;
        private bool SettingsActive;

        /**
         * \brief           Constructor function
         * \note            Settings object is SubForm with data for adapter properties
         * \param[1]        StartForm type to give this object parent
         * \param[2]        NetworkInterface type of selected adapter
         */
        public Settings(StartForm parent, NetworkInterface thisAdapter)
        {
            string subs1, subs2, subs3, subs4, subs5, subs6; /* for MAC address */

            /* Rewrite values to private variables */
            Parent = parent;
            Adapter = thisAdapter;
            InitializeComponent();
            Nazwa = thisAdapter.Name;
            Opis = thisAdapter.Description;
            Typ = Parent.typyAdapterow[(int)thisAdapter.NetworkInterfaceType];

            /* Settings for IP change small panel not visible by default */
            SettingsActive = false;

            /* Rewrite values to labels contents */
            label_nazwa.Text = Nazwa;
            label_opis.Text = Opis;
            label_ipv4.Text = thisAdapter.GetIPProperties().UnicastAddresses[1].Address.ToString();
            label_maska.Text = thisAdapter.GetIPProperties().UnicastAddresses[1].IPv4Mask.ToString();

            /* Style for ComboBox for Addressing - without selection, just a list */
            comboBoxAddressing.DropDownStyle = ComboBoxStyle.DropDownList;

            /* Check if adapter is switched Off */
            Enabled = checkEnabled(Nazwa);

            /* Get IP version 4 address value and write into label content */
            try
            {
                label_gateway.Text = thisAdapter.GetIPProperties().GatewayAddresses[0].Address.ToString();
            }
            catch (Exception e)
            {
                label_gateway.Text = Parent.lang.transl("none");
            }

            /* Get type of addressing value and write into label content */
            try
            {
                if (thisAdapter.GetIPProperties().GetIPv4Properties().IsDhcpEnabled) label_addressing.Text = Parent.lang.transl("DHCP");
                else label_addressing.Text = Parent.lang.transl("Static");
            }
            catch (Exception e)
            {
                label_addressing.Text = Parent.lang.transl("none");
            }

            /* Get MAC address value and write into label content */
            PHY = thisAdapter.GetPhysicalAddress().ToString();
            try
            {
                /* Separate each byte by '-' sign */
                subs1 = PHY.Substring(0, 2);
                subs2 = PHY.Substring(2, 2);
                subs3 = PHY.Substring(4, 2);
                subs4 = PHY.Substring(6, 2);
                subs5 = PHY.Substring(8, 2);
                subs6 = PHY.Substring(10, 2);
                label_PHY.Text = subs1 + "-" + subs2 + "-" + subs3 + "-" + subs4 + "-" + subs5 + "-" + subs6;
            }
            catch (Exception e)
            {
                label_PHY.Text = Parent.lang.transl("none");
            }

            /* Write connection type value and write into label content */
            label_Type.Text = Typ;

            /* Write connection speed value and write into label content */
            refreshSpeed(thisAdapter);

            /* Get DHCP server IP ver.4 value and write into label content - may have importance when DHCP used*/
            try
            {
                label_dhcpServer.Text = thisAdapter.GetIPProperties().DhcpServerAddresses[0].MapToIPv4().ToString();
            }
            catch (Exception e)
            {
                label_dhcpServer.Text = Parent.lang.transl("none");
            }

            translate();                /* Translate all labels in subform */
            this.Visible = true;        /* Make window visible */
        }

        /// <summary>
        /// ACTION FUNCTIONS BELOW
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        /**
         * \brief           Action function: Mose Hover
         * \note            Used for highlight settings button
         */
        private void pictureBox_Settings_MouseHover(object sender, EventArgs e)
        {
            pictureBox_Settings.BackColor = Color.DarkGray;
        }

        /**
         * \brief           Action function: Mouse Enter
         * \note            Used for highlight settings button
         */
        private void pictureBox_Settings_MouseEnter(object sender, EventArgs e)
        {
            pictureBox_Settings.BackColor = Color.DarkGray;
        }

        /**
         * \brief           Action function: Mose Leave
         * \note            Used for unhighlight settings button
         */
        private void pictureBox_Settings_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_Settings.BackColor = Color.Transparent;
        }

        /**
         * \brief           Action function: Click
         * \note            Used for toggle visibility of IP settings panel 
         */
        private void pictureBox_Settings_Click(object sender, EventArgs e)
        {
            SettingsActive = !SettingsActive;
            if(SettingsActive)
            {
                refreshSettings(true);
            }
        }

        /**
         * \brief           Action function: Click
         * \note            Used for switch off visibility of IP settings panel 
         */
        private void button1_Click(object sender, EventArgs e)
        {
            SettingsActive = false;
        }

        /**
         * \brief           Action function: Selected Value Changed
         * \note            Used for refresh controls visibility inside IPv4 configuration panel
         */
        private void comboBoxAddressing_SelectedValueChanged(object sender, EventArgs e)
        {
            refreshSettings(false);
        }

        /**
         * \brief           Action function: Text Changed
         * \note            Used for refresh TextBox control and optionally add dot as autocomplete feature
         *                  Also used for animate OK/NOK icons next to TextBox field
         *                  IPv4 TextBox field
         */
        private void textBox_IP_TextChanged(object sender, EventArgs e)
        {
            string txt = textBox_IP.Text;
            if(textBox_IP.Text == "")
            {
                pictureBox_IPOK.Visible = false;
                pictureBox_IPNOK.Visible = false;
            }
            else
            {
                IPAddress adres;
                string[] splitValues = txt.Split('.');
                bool is255 = false;

                /* Animation of OK/NOK icons */
                try
                {
                    if (splitValues[0] == "255" || splitValues[1] == "255" || splitValues[2] == "255" || splitValues[3] == "255") is255 = true;
                    if (IPAddress.TryParse(txt, out adres) && splitValues.Length == 4 && is255 == false)
                    {
                        pictureBox_IPOK.Visible = true;
                        pictureBox_IPNOK.Visible = false;
                    }
                    else
                    {
                        pictureBox_IPOK.Visible = false;
                        pictureBox_IPNOK.Visible = true;
                    }
                }
                catch(Exception ee)
                {
                    pictureBox_IPOK.Visible = false;
                    pictureBox_IPNOK.Visible = true;
                }
            }

            /* Autocomplete with dots */
            dot_octet(textBox_IP);
        }

        /**
         * \brief           Action function: Text Changed
         * \note            Used for refresh TextBox control and optionally add dot as autocomplete feature
         *                  Also used for animate OK/NOK icons next to TextBox field
         *                  Subnet Mask TextBox field
         */
        private void textBox_Maska_TextChanged(object sender, EventArgs e)
        {
            string txt = textBox_Maska.Text;
            List<string> ones = new List<string>(){ "128", "192", "224", "240", "248", "252", "254", "255" };

            /* Animation of OK/NOK icons */
            if (txt == "")
            {
                pictureBox_MaskOK.Visible = false;
                pictureBox_MaskNOK.Visible = false;
            }
            else
            {
                string[] splitValues = txt.Split('.');
                if (splitValues.Length == 4)
                {

                    if (ones.Contains(splitValues[0]) && splitValues[1] == "0" && splitValues[2] == "0" && splitValues[3] == "0")
                    {
                        pictureBox_MaskOK.Visible = true;
                        pictureBox_MaskNOK.Visible = false;
                    }
                    else if(splitValues[0] == "255" && ones.Contains(splitValues[1]) && splitValues[2] == "0" && splitValues[3] == "0")
                    {
                        pictureBox_MaskOK.Visible = true;
                        pictureBox_MaskNOK.Visible = false;
                    }
                    else if (splitValues[0] == "255" && splitValues[1] == "255" && ones.Contains(splitValues[2]) && splitValues[3] == "0")
                    {
                        pictureBox_MaskOK.Visible = true;
                        pictureBox_MaskNOK.Visible = false;
                    }
                    else if (splitValues[0] == "255" && splitValues[1] == "255" && splitValues[2] == "255" && ones.Contains(splitValues[3]))
                    {
                        pictureBox_MaskOK.Visible = true;
                        pictureBox_MaskNOK.Visible = false;
                    }
                    else
                    {
                        pictureBox_MaskOK.Visible = false;
                        pictureBox_MaskNOK.Visible = true;
                    }
                }
                else
                {
                    pictureBox_MaskOK.Visible = false;
                    pictureBox_MaskNOK.Visible = true;
                }
            }

            /* Autocomplete with dots */
            dot_octet(textBox_Maska);
        }

        /**
         * \brief           Action function: Mouse Enter
         * \note            Used for highlight save settings button
         */
        private void pictureBox_SaveButton_MouseEnter(object sender, EventArgs e)
        {
            pictureBox_SaveButton.BackColor = Color.Gray;
        }

        /**
         * \brief           Action function: Mouse Leave
         * \note            Used for unhighlight save settings button
         */
        private void pictureBox_SaveButton_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_SaveButton.BackColor = Color.Transparent;
        }

        /**
         * \brief           Action function: Click
         * \note            Used for set new IP configuration fo IPv4 properties in selected adapter
         */
        private void pictureBox_SaveButton_Click(object sender, EventArgs e)
        {
            setIPandMASK(textBox_IP.Text, textBox_Maska.Text);
        }

        /**
         * \brief           Action function: Click
         * \note            Used for switch ON selected adapter
         *                  Using process of system cmd.exe file
         */
        private void button_Enable_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/c netsh interface set interface "+ this.Nazwa +" enable";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            //* Read the output (or the error)
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            int i = 0;
            while(!Enabled && i<5)
            {
                Thread.Sleep(500);
                Enabled = checkEnabled(Nazwa);
                i++;
            }
        }

        /**
         * \brief           Action function: Click
         * \note            Used for switch OFF selected adapter
         *                  Using process of system cmd.exe file
         */
        private void button_Disable_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/c netsh interface set interface " + this.Nazwa + " disable";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            //* Read the output (or the error)
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            int i = 0;
            while (Enabled && i < 5)
            {
                Thread.Sleep(500);
                Enabled = checkEnabled(Nazwa);
                i++;
            }
        }

        /**
         * \brief           Action function: TextChanged
         * \note            Used for refresh adapter settings in Configuration Panel
         */
        private void comboBoxAddressing_TextChanged(object sender, EventArgs e)
        {
            refreshSettings(false);
        }

        /**
         * \brief           Action function: Click
         * \note            Used for check if andy net device uses already typed IP addres
         *                  just in case of making IP conflict in the net
         *                  Using process of system cmd.exe file
         */
        private void button_IPconflict_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/c ping -t " + textBox_IP.Text;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = false;
            process.StartInfo.RedirectStandardError = false;
            process.Start();
        }

        /**
         * \brief           Action function: Click
         * \note            Used for closing Properties SubForm and switching ON StartPanel SubForm controls
         */
        private void buttonClose_Click_1(object sender, EventArgs e)
        {
            Parent.button1.Visible = true;
            Parent.flowLayoutPanel1.Visible = true;
            Parent.button_cmd_IPs.Visible = true;
            Parent.button_cmd_IPsAll.Visible = true;
            Parent.button_Languages.Visible = true;
            this.Close();
        }

        /// <summary>
        /// USER DEFINED PRIVATE FUNCTIONS
        /// </summary>

        /**
         * \brief           Function for making autocomplete with dots (for address octets or subnet mask octets)
         */
        private void dot_octet(TextBox tb)
        {
            if (tb.Text.Length == 3 && !tb.Text.Contains(".")) { tb.Text += "."; tb.SelectionStart = tb.Text.Length; }
            else if (tb.Text.Length > 2 && tb.Text.Contains("."))
            {
                string[] splitValues = tb.Text.Split('.');
                int count = splitValues.Length;
                if (count < 4 && splitValues[count - 1].Length == 3) { tb.Text += "."; tb.SelectionStart = tb.Text.Length; }
            }
        }

        /**
         * \brief           Function for refreshing data when Addressing changed
         * param[1]         Bool type. 
         *                  read:=0 means read from Settings SubForm label context (switching on Configuration Panel)
         *                  read:=1 means addressing changed from configuration panel by User
         */
        private void refreshSettings(bool read)
        {
            bool dhcp = false;
            bool statical = false;
            if (read)
            {
                if (label_addressing.Text == "DHCP") { comboBoxAddressing.SelectedIndex = 1; dhcp = true; statical = false; }
                if (label_addressing.Text == "Statycznie") { comboBoxAddressing.SelectedIndex = 0; dhcp = false; statical = true; }
            }
            else
            {
                /* DHCP */
                if (comboBoxAddressing.SelectedIndex == 1)
                {
                    dhcp = true; statical = false;
                    pictureBox_IPOK.Visible = false;
                    pictureBox_IPNOK.Visible = false;
                    pictureBox_MaskOK.Visible = false;
                    pictureBox_MaskNOK.Visible = false;
                }
                /* Static */
                if (comboBoxAddressing.SelectedIndex == 0) { dhcp = false; statical = true; }
            }
            
            if (dhcp)                       /* DHCP */
            {
                label11.Visible = false;
                label12.Visible = false;
                textBox_IP.Visible = false;
                textBox_Maska.Visible = false;
            }
            else if (statical)              /* Static */
            {
                label11.Visible = true;
                label12.Visible = true;
                textBox_IP.Visible = true;
                textBox_Maska.Visible = true;
            }
        }

        /**
         * \brief           Function for set IPv4 configuration to selected adapter
         * \note            Using process of system cmd.exe file
         * \param[1]        String type new IPv4 address
         * \param[2]        String type new Subnet Mask
         */
        private void setIPandMASK(string IPaddress, string Mask)
        {
            string arg = "";
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
                psi.UseShellExecute = true;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.Verb = "runas";

                if (comboBoxAddressing.SelectedIndex == 0)
                    //netsh interface ipv4 set address \"Ethernet\" static "+hostname+" 255.255.255.0
                    arg = "/c netsh interface ipv4 set address \"" + Nazwa + "\" static " + IPaddress + " " + Mask;
                else if (comboBoxAddressing.SelectedIndex == 1)
                    //netsh interface ipv4 set address \"Ethernet\" source=dhcp
                    arg = "/c netsh interface ipv4 set address \"" + Nazwa + "\" source=dhcp";

                psi.Arguments = arg;
                Process.Start(psi);

                /* Wait 1s500ms after switch triggered */
                Thread.Sleep(1500);
                Parent.button1.Visible = true;
                Parent.flowLayoutPanel1.Visible = true;
                Parent.button_cmd_IPs.Visible = true;
                Parent.button_cmd_IPsAll.Visible = true;
                Parent.button_Languages.Visible = true;
                Parent.refreshAdaptersData();           /* Refresh data */
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /**
         * \brief           Function for trimm many blank spaces from cmd stream
         * \note            It is replacing last blank in blank isle to ';'
         *                  Rest of them it is trimming
         * \param[1]        String type text with many blank spaces
         * \return          String type text with words separated only by ';'
         */
        private string cmdAdapters(string startText)
        {
            string output;
            char[] a;
            int length = startText.Length;
            a = startText.ToCharArray();
            for(int i=0; i<length-1; i++)
            {
                if (a[i] == ' ' && a[i+1] != ' ') a[i] = ';';
            }
            output = new string(a);
            output = output.Replace(" ", "");
            return output;
        }

        /**
         * \brief           Function for checking in selected adapter if it is switched On/Off
         *                  It is using cmd.exe stream out to decide of adapter state
         * \param[1]        String type of Adapter name
         * \return          (bool) 1:= Enabled
         *                  (bool) 0:= Disabled
         */
        private bool checkEnabled(string AdName)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/c netsh interface show interface";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            //* Read the output (or the error)
            string[] output = process.StandardOutput.ReadToEnd().Split('\n');

            int count = output.Length - 5;
            string[] txt = cmdAdapters(output[3]).Split(';');

            bool AdapterEnabled = false;
            if(count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    txt = cmdAdapters(output[3 + i]).Split(';');
                    if (txt[3] == AdName)
                        break;
                }
                if (txt[0] == "Enabled") AdapterEnabled = true; else AdapterEnabled = false;
            }
            return AdapterEnabled;
        }

        /**
         * \brief           Function checking connection speed range and select correct speed range into label
         * \param[1]        NetworkInterface of selected adapter
         */
        private void refreshSpeed(NetworkInterface a)
        {
            long speed = a.Speed;
            if (speed >= 1000000000) Speed = (speed / 1000000000).ToString() + " Gb/s";
            else if (speed >= 1000000) Speed = (speed / 1000000).ToString() + " Mb/s";
            else if (speed >= 1000) Speed = (speed / 1000).ToString() + " kb/s";
            else if (speed >= 1) Speed = (speed).ToString() + " b/s";
            label_speed.Text = Speed;
        }


        /** SYNCHRONOUS TIMER Function for refreshing some data 
         * \brief                   Action function: time period
         */
        private void timerProperties_Tick(object sender, EventArgs e)
        {
            /* OK / NoOK states (icons) for IPv4 input and Subnet Mask input */
            if (Active)
            {
                pictureBox_Ikona.Visible = true;
                pictureBox_IkonaOffline.Visible = false;
                pictureBox_IkonaRx.Visible = false;
                pictureBox_IkonaTx.Visible = false;
            }
            if (Offline)
            {
                pictureBox_Ikona.Visible = false;
                pictureBox_IkonaOffline.Visible = true;
                pictureBox_IkonaRx.Visible = false;
                pictureBox_IkonaTx.Visible = false;
            }
            if (Tx)
            {
                pictureBox_Ikona.Visible = false;
                pictureBox_IkonaOffline.Visible = false;
                pictureBox_IkonaRx.Visible = false;
                pictureBox_IkonaTx.Visible = true;
            }
            if (Rx)
            {
                pictureBox_Ikona.Visible = false;
                pictureBox_IkonaOffline.Visible = false;
                pictureBox_IkonaRx.Visible = true;
                pictureBox_IkonaTx.Visible = false;
            }

            /* Connection (Computers) Icon animation for current state */
            if (Adapter.OperationalStatus.ToString() == "Down") { Offline = true; Tx = false; Rx = false; Active = false; }
            else if (Adapter.GetIPv4Statistics().BytesReceived != BytesRead) { Offline = false; Tx = false; Rx = true; Active = false; }
            else if (Adapter.GetIPv4Statistics().BytesSent != BytesSent) { Offline = false; Tx = true; Rx = false; Active = false; }
            else { Offline = false; Tx = false; Rx = false; Active = true; }

            BytesRead = Adapter.GetIPv4Statistics().BytesReceived;
            BytesSent = Adapter.GetIPv4Statistics().BytesSent;

            /* Toggle IP address configuration panel */
            if (SettingsActive) panel_Settings.Visible = true; else panel_Settings.Visible = false;

            /* Adapter switched On/Off button animation */
            if (Enabled) 
            { 
                button_Enable.Visible = false; button_Disable.Visible = true; 
            }
            else
            {
                button_Enable.Visible = true; button_Disable.Visible = false;
            }

            /* Buttons: ChechIPconflict / SaveSetting visibility dependancies */
            if (pictureBox_IPOK.Visible) 
                button_IPconflict.Visible = true; 
            else
                button_IPconflict.Visible = false;

            if ((pictureBox_IPOK.Visible && pictureBox_MaskOK.Visible && comboBoxAddressing.SelectedIndex == 0) || comboBoxAddressing.SelectedIndex == 1)
                pictureBox_SaveButton.Enabled = true;
            else
                pictureBox_SaveButton.Enabled = false;

        }

        /**
         * \brief           Translate function
         */
        private void translate()
        {
            label1.Text = Parent.lang.transl("Address:");
            label4.Text = Parent.lang.transl("SubnetMask:");
            label7.Text = Parent.lang.transl("Addressing:");
            label6.Text = Parent.lang.transl("MAC address:");
            label3.Text = Parent.lang.transl("Type:");
            label2.Text = Parent.lang.transl("Speed:");
            label8.Text = Parent.lang.transl("DHCP:");

            label9.Text = Parent.lang.transl("Settings");
            label10.Text = Parent.lang.transl("Addressing:");
            label11.Text = Parent.lang.transl("IP address:");
            label12.Text = Parent.lang.transl("SubnetMask:");

            comboBoxAddressing.Items[0] = Parent.lang.transl("Static");
            comboBoxAddressing.Items[1] = Parent.lang.transl("Dynamic");
        }
    }
}
