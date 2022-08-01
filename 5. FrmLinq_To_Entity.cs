using LinqLabs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Starter
{
    public partial class FrmLinq_To_Entity : Form
    {
        public FrmLinq_To_Entity()
        {
            InitializeComponent();
            dbContext.Database.Log = Console.WriteLine;
        }
        //in memory DB context
        NorthwindEntities dbContext = new NorthwindEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            var q = from p in dbContext.Products
                    where p.UnitPrice > 30
                    select p;
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = this.dbContext.Categories.First().Products.ToList();
            MessageBox.Show(this.dbContext.Products.First().Category.CategoryName);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            var q = from p in this.dbContext.Products
                    orderby p.UnitsInStock ascending, p.ProductID descending
                    select p;
            this.dataGridView1.DataSource = q.ToList();
            //OrderByDescending ThenBy
            var q2 = from n in dbContext.Products.OrderByDescending(p => p.UnitsInStock).ThenBy(n => n.ProductID)
                     select n;
            this.dataGridView2.DataSource = q.ToList();
            ////自訂compare logic
            //var q3 = dbContext.Products.AsEnumerable().OrderBy(p => p, new MyCompare()).ToList();
        }
        //class Mycompare
private void button11_Click(object sender, EventArgs e)
        {
            var q = from p in this.dbContext.Products
                    group p by p.Category.CategoryName into g
                    select new { CategoryName = g.Key, AvgUnitPrice = $"{ g.Average(p => p.UnitPrice):c2}" };
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bool? b;
            b = true;
            b = false;
            b = null;
            //b.Value
            var q = from o in this.dbContext.Orders
                    group o by o.OrderDate.Value.Year into g
                    select new { g.Key, count = g.Count() };

        }

        private void button55_Click(object sender, EventArgs e)
        {
            Product prod = new Product { ProductName = "XXX", Discontinued = false };
            this.dbContext.Products.Add(prod);

            this.dbContext.SaveChanges();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }
    }
}
