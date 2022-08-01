using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Starter
{
    public partial class FrmLINQ_To_XXX : Form
    {
        public FrmLINQ_To_XXX()
        {
            InitializeComponent();
            this.categoriesTableAdapter1.Fill(this.nwDataSet11.Categories);
            this.productsTableAdapter1.Fill(this.nwDataSet11.Products);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //樹狀圖,group
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            IEnumerable<IGrouping<string, int>> q = from n in nums
                                                     //group n by (n % 2);
                                                 group n by n % 2 == 0 ? "偶數" : "奇數";

            this.dataGridView1.DataSource = q.ToList();
            //======================================

            foreach (var group in q)
            {
                TreeNode x = this.treeView1.Nodes.Add(group.Key.ToString());

                foreach (var item in group)
                {
                    x.Nodes.Add(item.ToString());
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11,12,13,14,15,16};

            var q = from n in nums
                        //group n by (n % 2);
                    group n by n % 2 == 0 ? "偶數" : "奇數" into g
                    select new { MyKey = g.Key, MyCount = g.Count(), MyAvg = g.Average() ,MyGroup = g};

            this.dataGridView1.DataSource = q.ToList();
            //======================================

            foreach (var group in q)
            {
                string s = $"{group.MyKey}({group.MyCount})";
                TreeNode x = this.treeView1.Nodes.Add(s);  //(group.Key.ToString());

                foreach (var item in group.MyGroup)
                {
                    x.Nodes.Add(item.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

            var q = from n in nums
                        //group n by (n % 2);
                    group n by  MyKey(n) into g
                    select new { MyKey = g.Key, MyCount = g.Count(), MyAvg = g.Average(), MyGroup = g };
            
            this.dataGridView1.DataSource = q.ToList();

            //======================================
            this.treeView1.Nodes.Clear();
            foreach (var group in q)
            {
                string s = $"{group.MyKey}({group.MyCount})";
                TreeNode x = this.treeView1.Nodes.Add(s);  //(group.Key.ToString());

                foreach (var item in group.MyGroup)
                {
                    x.Nodes.Add(item.ToString());
                }
            }
            //======================================
            this.chart1.DataSource = q.ToList();
            this.chart1.Series[0].XValueMember = "MyKey";
            this.chart1.Series[0].YValueMembers = "MyCount";
            this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            this.chart1.DataSource = q.ToList();
            this.chart1.Series[1].XValueMember = "MyKey";
            this.chart1.Series[1].YValueMembers = "MyAvg";
            this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

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

            this.dataGridView1.DataSource = files;

            var q = from f in files
                    group f by f.Extension into g
                    orderby g.Count() descending
                    select new { g.Key, MyCount = g.Count() };

            this.dataGridView1.DataSource = q.ToList();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.ordersTableAdapter1.Fill(this.nwDataSet11.Orders);

            var q = from o in this.nwDataSet11.Orders
                    group o by o.OrderDate.Year into g
                    select new { g.Key, Count = g.Count() };

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            var q = from f in files
                    let s = f.Extension
                    where s == ".exe"
                    select f;

            MessageBox.Show("count" + q.Count());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int[] nums1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] nums2 = { 11,12, 13, 14, 15, 16, 17, 18, 19, 20 };

            //集合運算子Distinct/Union/Intersect/Except
            IEnumerable<int> q = nums1.Intersect(nums2);
            q = nums2.Distinct();
            //==========
            //數量詞作業Any/All/Contains
            //==========
            //切割運算子Take/Take While/Skip/Skip While
            //==========
            //產生作業Gemeration-Range/Repeat/Empty DefaultEmpty

        }

        private void button10_Click(object sender, EventArgs e)
        {
            //join

            var q = from p in this.nwDataSet11.Products
                    group p by p.CategoryID into g
                    orderby g.Key
                    select new { CategoryID = g.Key, AvgUnitPrice = g.Average(p => p.UnitPrice) };
            this.dataGridView1.DataSource = q.ToList();

            var q2 = from c in this.nwDataSet11.Categories join p in this.nwDataSet11.Products on c.CategoryID equals p.CategoryID
                group p  by c.CategoryName into g
                     select new { CategoryID = g.Key, AvgUnitPrice = g.Average(p => p.UnitPrice) };
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button31_Click(object sender, EventArgs e)
        {

        }

        private void FrmLINQ_To_XXX_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
