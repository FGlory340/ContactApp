using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManagement.Forms
{
    public partial class Edit : Form
    {
        protected Contact Contactcontact;
        public Edit( Contact contact)
        {
            InitializeComponent();
            Contactcontact = contact;
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            name.Text = Contactcontact.Contact_name;
            phno.Text = Contactcontact.Phoneno;
            address.Text = Contactcontact.Contact_address;
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            await   DataAccess.UpdateContact(name.Text, address.Text, phno.Text,Contactcontact.Id);
        }
    }
}
