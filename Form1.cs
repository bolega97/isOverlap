using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddDate
{
    public partial class form1 : Form
    {
        List<(string, string)> list = new List<(string, string)>();
        public form1()
        {
            InitializeComponent();
        }
        public static bool HasOverlap(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        {
            return start1 < end2 && end1 > start2;
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            
            
         
            if (!HasOverlap(dateTimePicker1.Value, dateTimePicker2.Value, dateTimePicker3.Value, dateTimePicker4.Value))
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = (n + 1).ToString();
                dataGridView1.Rows[n].Cells[1].Value = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                dataGridView1.Rows[n].Cells[2].Value = dateTimePicker2.Value.ToString("dd-MM-yyyy");
                dataGridView1.Rows[n].Cells[3].Value = dateTimePicker3.Value.ToString("dd-MM-yyyy");
                dataGridView1.Rows[n].Cells[4].Value = dateTimePicker4.Value.ToString("dd-MM-yyyy");

            }
            else {
                MessageBox.Show("Átfedés!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            

        }
    }
}
