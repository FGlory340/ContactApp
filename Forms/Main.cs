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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private async void saveBtn_Click(object sender, EventArgs e)
        {
            string name=  contactname.Text;
            string phno = phoneno.Text;
            string address =    addresstext.Text;
            int selectedIndex = groupbox.SelectedIndex;
            groupbox.SelectedItem.ToString();
            string group =(string) groupbox.Items[selectedIndex];

           var row=await DataAccess.CreateContact(name,phno,address, group);

            if (Math.Abs(row) == 1)
            {
                MessageBox.Show("Contact Created");
                contactname.Text = "";
                phoneno.Text = "";
                addresstext.Text = "";
            }
            else
            {
                MessageBox.Show("Couldn't Add Contact");
            }
            
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            dataview.DataSource = await DataAccess.FetchContacts();
        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataview.SelectedRows;
            int Id = 0;

            foreach (DataGridViewRow row in rows)
            {
               Id = int.Parse(row.Cells["Id"].Value.ToString());
            }

            Contact contact = new Contact();

            contact = await DataAccess.FetchContact(Id);

            if(contact != null)
            {
                new Forms.Edit(contact).Show();
            }
                 
        }

        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataview.SelectedRows;
            int Id = 0;

            foreach (DataGridViewRow row in rows)
            {
                Id = int.Parse(row.Cells["Id"].Value.ToString());
            }

            int change =   await DataAccess.DeleteContact(Id);

            if (Math.Abs(change) == 1)
            {
                MessageBox.Show("Contact Delete");
            }
            else
            {
                MessageBox.Show("Couldn't Delete Contact");
            }
        }
    }
}
