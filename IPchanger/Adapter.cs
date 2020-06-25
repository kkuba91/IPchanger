using System;
using System.Drawing;
using System.Windows.Forms;

namespace IPchanger
{
    public partial class Adapter : UserControl
    {
        /// <summary>
        /// PRIVATE DECLARATIONS
        /// </summary>
        private string Nazwa, Opis, IPv4, Maska, Id, Typ;
        private StartForm Parent;
        private bool Status;

        /**
         * \brief           Constructor function
         * \note            Adapter object is UserControl with data for adapter properties
         * \param[1]        StartForm type to give this object parent
         * \param[2]        String type name of selected adapter
         * \param[3]        String type description of selected adapter
         * \param[4]        String type IP version 4 address
         * \param[5]        String type Subnet mask
         * \param[6]        String type state (Up/Down)
         * \param[7]        String type ID for identyfication parameters for selected adapter
         * \param[8]        String type Type for identyfication physical layer of adapter (Ex. Wifi, DSL..)
         */
        public Adapter(StartForm parent, string name, string desc, string ipv4, string mask, bool state, string id, string type)
        {
            InitializeComponent();

            /* Point if WiFi layer by switching on/off picture control */
            if (type == "WiFi")
            {
                pictureWifi.Visible = true;
            }
            else
            {
                pictureWifi.Visible = false;
            }

            Parent = parent;

            /* Rewtite property values to private variables */
            Nazwa = name;
            Opis = desc;
            IPv4 = ipv4;
            Maska = mask;
            Status = state;
            Id = id;
            Typ = type;

            /* Rewtite property values to label contents */
            label_nazwa.Text = Nazwa;
            label_opis.Text = Opis;
            label_ipv4.Text = IPv4;
            label_maska.Text = Maska;

            /* Indicate if adapter is running/plugged to a net */
            if (state)
                control_Active.BackColor = System.Drawing.Color.Green;
            else
                control_Active.BackColor = System.Drawing.Color.Red;

            /* Translate labels in the form */
            translate();
        }

        /**
         * \brief           Function used by many action functions
         * \note            Trigger to open properties SubForm
         */
        private void control_Click()
        {
            Parent.OpenProperties(this.Nazwa);
        }

        /**
         * \brief           Action function: Click
         * \note            Used control_Click()
         *                  Used by many objects on the controls
         */
        private void label1_Click(object sender, EventArgs e)
        {
            control_Click();
        }

        private void label_nazwa_Click(object sender, EventArgs e)
        {
            control_Click();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            control_Click();
        }

        private void label_opis_Click(object sender, EventArgs e)
        {
            control_Click();
        }

        private void pictureBox_NetworkIcon_Click(object sender, EventArgs e)
        {
            control_Click();
        }

        private void label_ipv4_Click(object sender, EventArgs e)
        {
            control_Click();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            control_Click();
        }

        private void label_maska_Click(object sender, EventArgs e)
        {
            control_Click();
        }

        private void panelBack_Click(object sender, EventArgs e)
        {
            control_Click();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            control_Click();
        }

        private void control_Active_Click(object sender, EventArgs e)
        {
            control_Click();
        }

        /**
         * \brief           Action function: Mose Hover
         * \note            Used for highlight UserControl
         */
        private void panelBack_MouseHover(object sender, EventArgs e)
        {
            panelBack.BackColor = Color.White;
        }

        /**
         * \brief           Action function: Mose Leave
         * \note            Used for unhighlight UserControl
         */
        private void panelBack_MouseLeave(object sender, EventArgs e)
        {
            panelBack.BackColor = Color.FromArgb(164, 193, 249);
        }

        /**
         * \brief           Translate function
         */
        public void translate()
        {
            label1.Text = Parent.lang.transl("Name:");
            label2.Text = Parent.lang.transl("Description:");
            label4.Text = Parent.lang.transl("SubnetMask:");
        }
    }
}
