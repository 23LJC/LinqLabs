using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLabs.作業
{
    public partial class Frm作業_4 : Form
    {
        public Frm作業_4()
        {
            InitializeComponent();
            this.categoriesTableAdapter1.Fill(this.nwDataSet11.Categories);
            this.productsTableAdapter1.Fill(this.nwDataSet11.Products);
        }
        NorthwindEntities dbContext = new NorthwindEntities();

        private void button4_Click(object sender, EventArgs e)
        {
            int[] nums1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] nums2 = { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            int[] nums3 = { 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };


            IEnumerable<IGrouping<string, int>> q = from n in nums1
                                                        //group n by (n % 2);
                                                    group n by n % 2 == 0 ? "偶數" : "奇數";

            this.dataGridView1.DataSource = q.ToList();
            foreach (var group in q)
            {
                TreeNode x = this.treeView1.Nodes.Add(group.Key.ToString());

                foreach (var item in group)
                {
                    x.Nodes.Add(item.ToString());
                }
            }

        }
        private object MyKey(int n)
        {
            if (n < 5)
                return "小";
            else if (n > 10)
                return "中";
            else
                return "大";
        }

        private void button38_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            var q = from p in files
                    where p.Length > 0
                    orderby p.Length descending
                    select p;

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            this.ordersTableAdapter1.Fill(this.nwDataSet11.Orders);

            var q = from o in this.nwDataSet11.Orders
                    group o by o.OrderDate.Year into g
                    select new { g.Key, Count = g.Count() };

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //NW Products 低中高 價產品 
            var q = from p in nwDataSet11.Products
                    group p by MyP((int)p.UnitPrice) into g
                    select new { Price = g.Key, Count = g.Count(), Group = g };
            dataGridView1.DataSource = q.ToList();
            foreach (var group in q)
            {
                TreeNode tn = treeView1.Nodes.Add(group.Price.ToString());

                foreach (var item in group.Group)
                {
                    tn.Nodes.Add(item.ProductName.ToString());
                }
            }









        }
        private object MyP(int n)
        {

            if (n < 50)
                return "小";
            else if (n > 50)
                return "中";
            else
                return "大";

        }

        private void button2_Click(object sender, EventArgs e)
        {




        }

        private void button15_Click(object sender, EventArgs e)
        {
            var q = from o in nwDataSet11.Orders
                    group o by o.OrderDate.Year into g
                    select new { Year = g.Key, Count = g.Count(), Group = g };

            dataGridView1.DataSource = q.ToList();
            foreach (var group in q)
            {
                TreeNode tn = treeView1.Nodes.Add(group.Year.ToString());

                foreach (var item in group.Group)
                {
                    tn.Nodes.Add(item.OrderID.ToString());
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            var q = (from u in this.dbContext.Products
                     orderby u.UnitPrice descending
                     select u).Take(5);
            this.dataGridView1.DataSource = q.ToList();
        }
    }
}

