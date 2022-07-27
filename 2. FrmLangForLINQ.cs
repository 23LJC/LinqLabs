﻿using LinqLabs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starter
{
    public partial class FrmLangForLINQ : Form
    {
        public FrmLangForLINQ()
        {
            InitializeComponent();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //100.200
            int n1, n2;
            n1 = 100;
            n2 = 200;
            MessageBox.Show(n1 + "," + n2);
            ClsMyUtility.Swap(ref n1, ref n2);
            MessageBox.Show(n1 + "," + n2);

            //aaa.bbb
            string s1, s2;
            s1 = "aaa";
            s2 = "bbb";
            MessageBox.Show(s1 + "," + s2);
            ClsMyUtility.Swap(ref s1, ref s2);
            MessageBox.Show(s1 + "," + s2);

            MessageBox.Show(SystemInformation.ComputerName);
        }

        //泛用型別
        private void button7_Click(object sender, EventArgs e)
        {
            //100.200
            int n1, n2;
            n1 = 100;
            n2 = 200;
            MessageBox.Show(n1 + "," + n2);
            ClsMyUtility.SwapAnyType(ref n1, ref n2);
            //ClsMyUtility.SwapAnyType<int>(ref n1, ref n2); int可給可不給
            MessageBox.Show(n1 + "," + n2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.buttonX.Click += ButtonX_Click;

            //this.buttonX.Click += aaa;
            this.buttonX.Click += new EventHandler(aaa);

            //2.0匿名方法
            this.buttonX.Click += delegate (object sender1, EventArgs e1) { MessageBox.Show("匿名方法"); };
            //---------------------------------------------------------------------------------------------------------------
            //c#3.0匿名方法 簡潔版 Lamgba

            this.buttonX.Click += (object sender1, EventArgs e1) => { MessageBox.Show("c#3.0匿名方法 簡潔版 Lamgba"); };

        }

        private void ButtonX_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ButtonX click");
        }
        private void aaa(object sender, EventArgs e)
        {
            MessageBox.Show("aaa");
        }

        bool test(int n)
        {
            return n > 5;
        }


        //step1 create delegate class
        delegate bool Mydelegate(int n);


        //step1 create delegate class
        //step2 create delegate object
        //step3 call method
        private void button9_Click(object sender, EventArgs e)
        {
            bool result = test(10);
            MessageBox.Show("result = " + result);

            //step1 create delegate class
            Mydelegate delegateObj = new Mydelegate(test);

            //step2 create delegate object
            result = delegateObj(2);

            //step3 call method
            MessageBox.Show("result = " + result);


            //2.0
            delegateObj = delegate (int a) { return a % 2 == 0; };

            result = delegateObj(10);

            MessageBox.Show("result = " + result);

            //3.0
            delegateObj = n => n % 2 == 0;
            result = delegateObj(100);
            MessageBox.Show("result = " + result);

        }

        List<int> MyWhere (int[] nums, Mydelegate delegateObj)
        {
            List<int>  list = new List<int>();
            
            foreach (int n in  nums)
            {
                if (delegateObj(n))
                {
                    list.Add(n);
                }
            }
            return list;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30};
            List<int> result =MyWhere(nums, test);

            List<int> odd = MyWhere(nums, n => n%2 == 1) ;
            List<int> even = MyWhere(nums, n => n % 2 == 0);

            foreach(int n in odd)
            {
                this.listBox1.Items.Add(n);
            }


            foreach (int n in even)
            {
                this.listBox2.Items.Add(n);
            }

        }

        IEnumerable<int>  Mylterator(int[] nums, Mydelegate delegateObj)
        {
            List<int> list = new List<int>();

            foreach (int n in nums)
            {
                if (delegateObj(n))
                {
                    yield return(n);
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
            IEnumerable<int> q = Mylterator(nums, n => n % 2 == 0);

            foreach (int n in q)
            {
                this.listBox1.Items.Add(n);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
            IEnumerable<int> q = Mylterator(nums, n => n>5 );

            foreach (int n in q)
            {
                this.listBox1.Items.Add(n);
            }
        }
    }
}