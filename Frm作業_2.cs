using System;
using System.Linq;
using System.Windows.Forms;

namespace Starter
{
    public partial class Frm作業_2 : Form
    {
        public Frm作業_2()
        {
            InitializeComponent();
            this.productPhotoTableAdapter1.Fill(this.awDataset1.ProductPhoto);
        }

        private void button11_Click(object sender, System.EventArgs e)
        {

            var q = from p in this.awDataset1.ProductPhoto

                    select p;
            this.dataGridView1.DataSource = q.ToList();


        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            var d = awDataset1.ProductPhoto.OrderBy(n => n.ModifiedDate).Where(n => n.ModifiedDate > dateTimePicker1.Value && n.ModifiedDate < dateTimePicker2.Value);
            this.dataGridView1.DataSource = d.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ("".Equals(comboBox3.Text))
                return;
            int i = int.Parse(comboBox3.Text);

            var DataTime = from s in this.awDataset1.ProductPhoto
                           where s.ModifiedDate.Year == i
                           select s;
            this.dataGridView1.DataSource = DataTime.ToList();
                
        }

    }
}
  