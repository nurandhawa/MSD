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
    public partial class Form1 : Form
    {
        SQLiteDatabase SQLDatabase;

        public Form1()
        {
            InitializeComponent();
            SQLDatabase = new SQLiteDatabase("MSD.s3db");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (InsertBox IB = new InsertBox())
            {
                IB.ShowDialog();
                
                // On close
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("Name", IB.name);
                data.Add("Quantity", IB.quantity.ToString());
                SQLDatabase.Insert("Medicine", data);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Dictionary<string, string> data = new Dictionary<string, string>();
            //data.Add("Name", "varchar(30)");
            //data.Add("Quantity", "number(5)");
            //SQLDatabase.CreateTable("Medicine", data);

            //List<string> headers = new List<string>();
            //headers.Add("Name");
            //headers.Add("Quantity");
            //List<List<object>> list = SQLDatabase.Query("Test", headers);
            //resultsView.View = View.Details;
            //// Add a column with width 20 and left alignment.
            //for (int i = 0; i < headers.Count; i++)
            //{
            //    resultsView.Columns.Add(headers[i], 200, HorizontalAlignment.Left);
            //}


            resultsView.Clear();
            // Adding ListView Columns
            resultsView.GridLines = true;
            resultsView.View = View.Details;
            resultsView.Columns.Add("Name", 245, HorizontalAlignment.Left);
            resultsView.Columns.Add("Quantity", 241, HorizontalAlignment.Left);
            DataTable dt = SQLDatabase.GetDataTable("select Name, Quantity from Medicine;");

            string[] Str = new string[2];
            ListViewItem newItem;
            foreach (DataRow dataRow in dt.Rows)
            {
                Str[0] = dataRow["Name"].ToString();
                Str[1] = dataRow["Quantity"].ToString();
                newItem = new ListViewItem(Str);
                resultsView.Items.Add(newItem);
            }
        }
    }
}
