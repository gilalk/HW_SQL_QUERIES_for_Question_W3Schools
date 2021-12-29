using HW_SQL_QUERIES_for_Question_W3Schools.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_SQL_QUERIES_for_Question_W3Schools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void execBtn_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Q1":
                    using(var db = new NorthwindContext())
                    {
                        var query1 = (from p in db.Products
                                     select (new { p.ProductName, p.QuantityPerUnit })).ToList();
                        dataGridView1.DataSource = query1;
                    }
                    break;
                case "Q2":
                    using (var db = new NorthwindContext())
                    {
                        var query2 = (from p in db.Products
                                      where(p.Discontinued == false)
                                      select (new { p.ProductId, p.ProductName })).ToList();
                        dataGridView1.DataSource = query2;
                    }
                    break;
                case "Q3":
                    using (var db = new NorthwindContext())
                    {
                        var query3 = (from p in db.Products
                                      where (p.Discontinued == true)
                                      select (new { p.ProductId, p.ProductName })).ToList();
                        dataGridView1.DataSource = query3;
                    }
                    break;
                case "Q4":
                    using (var db = new NorthwindContext())
                    {
                        var query4 = (db.Products.OrderBy(p => p.UnitPrice).Select(p => new { p.ProductName , p.UnitPrice})).ToList();
                        query4.RemoveRange(1, query4.Count - 2);
                        dataGridView1.DataSource = query4;
                    }
                    break;
                case "Q5":
                    using (var db = new NorthwindContext())
                    {
                        var query5 = (from p in db.Products
                                      where (p.Discontinued == false && p.UnitPrice < 20)
                                      select (new { p.ProductId, p.ProductName, p.UnitPrice })).ToList();
                        dataGridView1.DataSource = query5;
                    }
                    break;
                case "Q6":
                    using (var db = new NorthwindContext())
                    {
                        var query6 = (from p in db.Products
                                      where (p.UnitPrice >= 15 && p.UnitPrice <= 25)
                                      orderby p.UnitPrice
                                      select (new { p.ProductId, p.ProductName, p.UnitPrice })).ToList();
                        dataGridView1.DataSource = query6;
                    }
                    break;
                case "Q7":
                    using (var db = new NorthwindContext())
                    {
                        var avg = db.Products.Average(p => p.UnitPrice);
                        var query7 = db.Products.Where(p => p.UnitPrice > avg).Select(p => new { p.ProductName, p.UnitPrice}).ToList();
                        dataGridView1.DataSource = query7;
                    }
                    break;
                case "Q8":
                    using (var db = new NorthwindContext())
                    {
                        var query8 = db.Products.OrderByDescending(p => p.UnitPrice).Select(p => new { p.ProductName, p.UnitPrice }).ToList();
                        query8.RemoveRange(10, query8.Count - 10);
                        dataGridView1.DataSource = query8;
                    }
                    break;
                case "Q9":
                    using (var db = new NorthwindContext())
                    {
                        var discontinued = db.Products.Where(p => p.Discontinued == true).Select(p => p.Discontinued).ToList().Count;
                        var current = db.Products.Where(p => p.Discontinued == false).Select(p => p.Discontinued).ToList().Count;
                        
                        DataTable query9 = new DataTable();

                        query9.Columns.Add("Discontinued", typeof(int));
                        query9.Columns.Add("Current", typeof(int));

                        query9.Rows.Add(discontinued, current);
                        dataGridView1.DataSource = query9;
                    }
                        break;
                case "Q10":
                    using (var db = new NorthwindContext())
                    {
                        var query10 = db.Products.Where(p => p.UnitsOnOrder > p.UnitsInStock).Select(p => new { p.ProductName, p.UnitsOnOrder, p.UnitsInStock }).ToList();
                        dataGridView1.DataSource = query10;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
