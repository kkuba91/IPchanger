using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace IPchanger
{
    public partial class StartForm : Form
    {
        /* Dynamic Libraries include */
        /* void ReleaseCapture() and void SendMessage() Ex. used for drag the window on the screen (custom topbars/AppHolders)
         */
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        /* 
         * PUBLIC DECLARATIONS 
         */
        public List<Adapter> Adaptery;                              //List of Ethernet adapters controls
        public Dictionary<int, string> typyAdapterow;               // Adapters types
        public static Dictionary<int, string> static_typyAdapterow; // Adapters types (static)
        public static NetworkInterface thisAdapter;                 // One/selected adapter object (NIC)
        public Lang lang;
        public ChLang LangForm;

        /* StartForm - First Opening form Constructor function
         * Icludes: Dictionary of Ethernet adapter types
         */
        public StartForm()
        {
            this.Visible = false;
            InitializeComponent();
            Adaptery = new List<Adapter>();
            lang = new Lang();

            static_typyAdapterow = new Dictionary<int, string>();
            static_typyAdapterow.Add(1, "Unknown");
            static_typyAdapterow.Add(6, "Ethernet");
            static_typyAdapterow.Add(9, "Token Ring");
            static_typyAdapterow.Add(15, "Fddi");
            static_typyAdapterow.Add(20, "Basic ISDN");
            static_typyAdapterow.Add(21, "Primary ISDN");
            static_typyAdapterow.Add(23, "Ppp");
            static_typyAdapterow.Add(24, "Loopback");
            static_typyAdapterow.Add(26, "Ethernet 3 Megabit");
            static_typyAdapterow.Add(28, "Slip");
            static_typyAdapterow.Add(37, "Atm");
            static_typyAdapterow.Add(48, "Generic Modem");
            static_typyAdapterow.Add(62, "Fast Ethernet T");
            static_typyAdapterow.Add(63, "ISDN");
            static_typyAdapterow.Add(69, "Fast Ethernet Fx");
            static_typyAdapterow.Add(71, "WiFi");
            static_typyAdapterow.Add(94, "Asymetric DSL");
            static_typyAdapterow.Add(95, "Rate Adapt DSL");
            static_typyAdapterow.Add(96, "Symetric DSL");
            static_typyAdapterow.Add(97, "Very High Speed DSL");
            static_typyAdapterow.Add(114, "IP Over Atm");
            static_typyAdapterow.Add(117, "Gigabit Ethernet");
            static_typyAdapterow.Add(131, "Tunnel");
            static_typyAdapterow.Add(143, "Multi Rate Symmetric DSL");
            static_typyAdapterow.Add(144, "High Performance Serial Bus");
            static_typyAdapterow.Add(237, "Wman");
            static_typyAdapterow.Add(243, "Wwanpp");
            static_typyAdapterow.Add(244, "Wwanpp 2");

            typyAdapterow = static_typyAdapterow;
            refreshAdaptersData();
            translate();
            this.Visible = true;
        }

        /* WinForms GUI Action Functions (self-generated from properties toolbox)
         */

        /**
         * \brief           Close Application Action triggered by right up corner Close Button
         * \return          Sum of input values
         */
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /**
         * \brief           Minimize Application Action triggered by right up corner Minimize Button
         */
        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /**
         * \brief           Drag Application form on the screen Actions
         * \note            Depending which graphical object is pressed by mouse cursor there are 3 functions for:
         *                  - TopBar
         *                  - label located in TopBar
         *                  - logo (pictureBox) located in TopBar on the Left
         */
        private void TopBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xF012, 0);
        }

        private void labelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xF012, 0);
        }

        private void pictureBoxLogo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xF012, 0);
        }

        /**
         * \brief           Check Network Interfaces properties data - triggered from button in StartForm form
         */
        private void buttonNetworkCheck_Click(object sender, EventArgs e)
        {
            refreshAdaptersData();
        }


        /* Other functions
         */

        /**
         * \brief           Refresh data about Network Interfaces properties
         *                  must be public, because triggered also from other forms
         */
        public void refreshAdaptersData()
        {
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel1.Controls.Clear();

            List<string> ips = GetLocalIPAddress();
            List<string> adapts = GetLocalAdapters();
            List<bool> stats = GetLocalStatuses();
            List<string> descr = GetLocalDescr();
            List<string> masks = GetLocalIPMasks();
            List<string> ids = GetLocalIds();
            List<string> types = GetLocalTypes();

            Adapter ada;

            Adaptery.Clear();

            for (int i = 0; i < ips.Count; i++)
            {

                if (stats[i])
                {
                    ada = new Adapter(this, adapts[i], descr[i], ips[i], masks[i], stats[i], ids[i], types[i]);
                    Adaptery.Add(ada);
                }
            }
            for (int i = 0; i < ips.Count; i++)
            {
                if (!stats[i])
                {
                    ada = new Adapter(this, adapts[i], descr[i], ips[i], masks[i], stats[i], ids[i], types[i]);
                    Adaptery.Add(ada);
                }
            }
            for (int i = 0; i < ips.Count; i++)
            {
                Adaptery[i].translate();
                flowLayoutPanel1.Controls.Add(Adaptery[i]);
            }
            flowLayoutPanel1.Visible = true;
        }

        /**
         * \brief           Collect NIC IDs into the indyvidual List
         * \return          List of string type IDs
         */
        public static List<string> GetLocalIds()
        {
            var host = NetworkInterface.GetAllNetworkInterfaces();
            var ids = new List<string>();
            foreach (NetworkInterface nic in host)
            {
                ids.Add(nic.Id.ToString());
            }
            return ids;
            throw new Exception("!");
        }

        /**
         * \brief           Collect NIC IPv4 Addresses into the indyvidual List
         * \return          List of string type IPv4 addresses for each adapter
         */
        public static List<string> GetLocalIPAddress()
        {
            var host = NetworkInterface.GetAllNetworkInterfaces();
            var stats = new List<string>();
            foreach (NetworkInterface nic in host)
            {
                try
                {
                    stats.Add(nic.GetIPProperties().UnicastAddresses[1].Address.ToString());
                }
                catch(Exception)
                {
                    stats.Add(nic.GetIPProperties().UnicastAddresses[0].Address.ToString());
                }
            }
            return stats;
            throw new Exception("!");
        }

        /**
         * \brief           Collect NIC Subnet masks Addresses into the indyvidual List
         * \return          List of string type Subnet masks for each adapter
         */
        public static List<string> GetLocalIPMasks()
        {
            var host = NetworkInterface.GetAllNetworkInterfaces();
            var masks = new List<string>();
            foreach (NetworkInterface nic in host)
            {
                try
                {
                    masks.Add(nic.GetIPProperties().UnicastAddresses[1].IPv4Mask.ToString());
                }
                catch(Exception ex)
                {
                    masks.Add(nic.GetIPProperties().UnicastAddresses[0].IPv4Mask.ToString());
                }
            }
            return masks;
            throw new Exception("!");
        }

        /**
         * \brief           Collect NIC Operating Statuses into the indyvidual List
         * \note            true := it is ON
         *                  false := it is OFF
         * \return          List of string type status for each adapter
         */
        public static List<bool> GetLocalStatuses()
        {
            var host = NetworkInterface.GetAllNetworkInterfaces();
            var stats = new List<bool>();
            foreach (NetworkInterface nic in host)
            {
                if (nic.OperationalStatus.ToString() == "Up") stats.Add(true); else stats.Add(false);
            }
            return stats;
        }

        /**
         * \brief           Collect NIC Adapter Desriptions into the indyvidual List
         *                  mostly name or type or manufacturer included
         * \return          List of string type Descriptions for each adapter
         */
        public static List<string> GetLocalDescr()
        {
            var host = NetworkInterface.GetAllNetworkInterfaces();
            var descr = new List<string>();
            foreach (NetworkInterface nic in host)
            {
                descr.Add(nic.Description.ToString());
            }
            return descr;
        }

        /**
         * \brief           Collect NIC Adapter MAC Addresses into the indyvidual List
         * \return          List of string type MACs for each adapter
         */
        public static List<string> GetLocalPHAddresses()
        {
            var host = NetworkInterface.GetAllNetworkInterfaces();
            var PHAs = new List<string>();
            foreach (NetworkInterface nic in host)
            {
                PHAs.Add(nic.GetPhysicalAddress().ToString());
            }
            return PHAs;
        }

        /**
         * \brief           Collect NIC Adapter Name into the indyvidual List
         * \return          List of string type Names for each adapter
         */
        public static List<string> GetLocalAdapters()
        {
            var host = NetworkInterface.GetAllNetworkInterfaces();
            var adapters = new List<string>();
            foreach (NetworkInterface nic in host)
                {
                    adapters.Add(nic.Name);
                }
            return adapters;
        }

        /**
         * \brief           Collect NIC Adapter Type into the indyvidual List
         * \return          List of string type Types for each adapter
         */
        public static List<string> GetLocalTypes()
        {
            var host = NetworkInterface.GetAllNetworkInterfaces();
            var adapters = new List<string>();
            foreach (NetworkInterface nic in host)
            {
                adapters.Add(static_typyAdapterow[(int)nic.NetworkInterfaceType]);
            }
            return adapters;
        }

        /**
         * \brief           Open Properties SubForm  Function with selected NIC
         * \param[1]        object type - Form required here (for Properties Form)
         */
        private void PanelProperties(object formularz)
        {
            Form fh = formularz as Form;    //Properties (Właściwości) Form
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;       // Properties shown/docked in the Panel inside
            
            panelContent.Controls.Add(fh);
            panelContent.Tag = fh;
            fh.Show();

            /* Unnecessary controls from left subform goes invisible */
            button1.Visible = false;
            flowLayoutPanel1.Visible = false;
            button_cmd_IPs.Visible = false;
            button_cmd_IPsAll.Visible = false;
            button_Languages.Visible = false;

        }

        /**
         * \brief           Select proper Network Interface and trigger PanelProprties function with chosen one
         * \param[1]        string type - Selected adapter Name
         */
        public void OpenProperties(string adapt)
        {
            var host = NetworkInterface.GetAllNetworkInterfaces();
            var adapters = new List<string>();
            int id = 0;
            int id_ok = 0;
            foreach (NetworkInterface nic in host)
            {
                adapters.Add(nic.Name);
                if (nic.Name == adapt) id_ok = id;
                id++;
            }
            thisAdapter = host[id_ok];
            PanelProperties(new Settings(this, thisAdapter));
        }

        /**
         * \brief           Check how many adapters are active on the host
         */
        private void button_cmd_IPs_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/K netsh interface show interface";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = false;
            process.StartInfo.RedirectStandardError = false;
            process.Start();
            process.WaitForExit();
        }

        /**
         * \brief           Check IP configuration for all adapters created on host
         */
        private void button_cmd_IPsAll_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/K ipconfig /all";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = false;
            process.StartInfo.RedirectStandardError = false;
            process.Start();
            process.WaitForExit();
        }

        /**
         * \brief           Open "Change Language" Form
         */
        private void button_Languages_Click(object sender, EventArgs e)
        {
            LangForm = new ChLang(this);
            LangForm.Visible = true;
            this.Visible = false;
        }

        /**
         * \brief           Translate function
         */
        public void translate()
        {
            button1.Text = lang.transl("Search");
        }
    }
}
