using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MSD
{
    public partial class InsertBox : Form
    {
        public string name;
        public int quantity;


        public InsertBox()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            quantity = (int)numericUpDown1.Value;

            this.Close();
        }       
    }
}
