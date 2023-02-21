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
         List<(DateTime, DateTime)> list = new List<(DateTime, DateTime)>();
        public form1()
        {
            InitializeComponent();
        }
        public static bool HasOverlap(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        {
            return start1 < end2 && end1 > start2;
        }

        public bool HasOverlapListCheck(DateTime date1, DateTime date2)
        {
             bool overlap=false;
            for(int i = 0; i < list.Count; i++){
                if (HasOverlap(list[i].Item1, list[i].Item2, date1, date2) ) {
                    overlap = true;
                }
            }
            return overlap;
        }

        private void addDataToDataGridView() {
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = (n + 1).ToString();
            dataGridView1.Rows[n].Cells[1].Value = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            dataGridView1.Rows[n].Cells[2].Value = dateTimePicker2.Value.ToString("dd-MM-yyyy");
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (list.Count == 0) {

                list.Add((dateTimePicker1.Value, dateTimePicker1.Value));
                addDataToDataGridView();
               
            }
            else if (!HasOverlapListCheck(dateTimePicker1.Value, dateTimePicker2.Value)) {

                list.Add((dateTimePicker1.Value, dateTimePicker1.Value));
                addDataToDataGridView();
            }
            else {
                MessageBox.Show("Átfedés!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
