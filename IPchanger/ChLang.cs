using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace IPchanger
{
    public partial class ChLang : Form
    {
        private StartForm Parent;

        /* Dynamic Libraries include */
        /* void ReleaseCapture() and void SendMessage() Ex. used for drag the window on the screen (custom topbars/AppHolders)
         */
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        /**
         * \brief           Constructor function for translation object
         * \param[1]        StartForm object which is parent object in this application 
         */
        public ChLang(StartForm sf)
        {
            Parent = sf;
            InitializeComponent();
            this.Location = new Point(Parent.Left + 80, Parent.Top + 100);
            refresh();
        }

        /**
         * \brief           Action function: Click
         * \note            Close this Form (language form) and back to StartForm 
         */
        private void button_CloseSettings_Click(object sender, EventArgs e)
        {
            Parent.translate();
            Parent.refreshAdaptersData();
            this.Close();
            this.DestroyHandle();
            Parent.Visible = true;
        }

        /**
         * \brief           Action function: Mouse Down
         * \note            Dragging on TobBar objects to grag whole form
         *                  In summary thease are three functions
         */
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xF012, 0);
        }

        private void panelTopBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xF012, 0);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xF012, 0);
        }

        /**
         * \brief           Action function: Click
         * \note            Change to English translation
         */
        private void button_Eng_Click(object sender, EventArgs e)
        {
            Parent.lang.SelectedLang = "Eng";
            Parent.lang.WriteSelect("Eng");
            refresh();
        }

        /**
         * \brief           Action function: Click
         * \note            Change to German translation
         */
        private void button_Ger_Click(object sender, EventArgs e)
        {
            Parent.lang.SelectedLang = "Ger";
            Parent.lang.WriteSelect("Ger");
            refresh();
        }

        /**
         * \brief           Action function: Click
         * \note            Change to French translation
         */
        private void button_Fra_Click(object sender, EventArgs e)
        {
            Parent.lang.SelectedLang = "Fra";
            Parent.lang.WriteSelect("Fra");
            refresh();
        }

        /**
         * \brief           Action function: Click
         * \note            Change to Spanish translation
         */
        private void button_Esp_Click(object sender, EventArgs e)
        {
            Parent.lang.SelectedLang = "Esp";
            Parent.lang.WriteSelect("Esp");
            refresh();
        }

        /**
         * \brief           Action function: Click
         * \note            Change to Russian translation
         */
        private void button_Rus_Click(object sender, EventArgs e)
        {
            Parent.lang.SelectedLang = "Rus";
            Parent.lang.WriteSelect("Rus");
            refresh();
        }

        /**
         * \brief           Action function: Click
         * \note            Change to Polish translation
         */
        private void button_Pol_Click(object sender, EventArgs e)
        {
            Parent.lang.SelectedLang = "Pol";
            Parent.lang.WriteSelect("Pol");
            refresh();
        }

        /**
         * \brief           Function for refresh all subjects in the form (with translations)
         */
        private void refresh()
        {
            string lang = Parent.lang.SelectedLang;
            Color back = Color.FromArgb(0, 56, 90);
            if (lang == "Eng") pictureBox_eng.BackColor = Color.LightSkyBlue; else pictureBox_eng.BackColor = back;
            if (lang == "Ger") pictureBox_ger.BackColor = Color.LightSkyBlue; else pictureBox_ger.BackColor = back;
            if (lang == "Fra") pictureBox_fra.BackColor = Color.LightSkyBlue; else pictureBox_fra.BackColor = back;
            if (lang == "Esp") pictureBox_esp.BackColor = Color.LightSkyBlue; else pictureBox_esp.BackColor = back;
            if (lang == "Rus") pictureBox_rus.BackColor = Color.LightSkyBlue; else pictureBox_rus.BackColor = back;
            if (lang == "Pol") pictureBox_pol.BackColor = Color.LightSkyBlue; else pictureBox_pol.BackColor = back;
            translate();
        }

        /**
         * \brief           Translate function
         */
        private void translate()
        {
            label1.Text = Parent.lang.transl("Select language");
        }
    }
}
