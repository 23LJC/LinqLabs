using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starter
{
    public partial class FrmLINQ架構介紹_InsideLINQ : Form
    {
        public FrmLINQ架構介紹_InsideLINQ()
        {
            InitializeComponent();
            this.productsTableAdapter1.Fill(this.nwDataSet11.Products);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            ArrayList arrList = new ArrayList();
            arrList.Add(2);
            arrList.Add(4);

            var q = from n in arrList.Cast<int>()  //Cast轉型
                    select new { N = n };
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            

            var q = (from p in this.nwDataSet11.Products
                     orderby p.UnitsInStock descending
                     select p).Take(5);

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //When Linq execute quert ??
            //foreach(...in q)
            //q.ToXXX()
            //Aggregation  q.sum(0



            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            this.listBox1.Items.Add("sum" + nums.Sum());
            this.listBox1.Items.Add("sum" + nums.Max());
            this.listBox1.Items.Add("sum" + nums.Min());
            this.listBox1.Items.Add("sum" + nums.Average());
            this.listBox1.Items.Add("sum" + nums.Count());

            this.listBox1.Items.Add("Avg UnitPrice=" + this.nwDataSet11.Products.Average(p => p.UnitPrice));
            this.listBox1.Items.Add("Max UnitslnStock=" + this.nwDataSet11.Products.Max(p => p.UnitsInStock));
        }
    }
}