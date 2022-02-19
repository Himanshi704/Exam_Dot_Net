using ProductApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductApplication.Controllers
{
    public class Product1Controller : Controller
    {
        // GET: Product1
        public ActionResult Index()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Product;Integrated Security=True";
            cn.Open();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "select * from Products";
            List<Product> list = new List<Product>();
            
            try
            {
                
                SqlDataReader dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                {
                    Product p = new Product();
                    p.ProductId = (int)dr["ProductId"];
                    p.ProductName = (string)dr["ProductName"];
                    p.Rate = (decimal)dr["Rate"];
                    p.Description = (string)dr["Description"];
                    p.CategoryName = (string)dr["CategoryName"];
                    list.Add(p);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return View(list);
        }

        // GET: Product1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product1/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product1/Edit/5
        public ActionResult Edit(int id=0)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Product;Integrated Security=True";
            cn.Open();
            SqlCommand cmdEdit = new SqlCommand();
            cmdEdit.Connection = cn;
            cmdEdit.CommandType = System.Data.CommandType.Text;
            cmdEdit.CommandText = "select * from Products where ProductId = @ProductId";
            cmdEdit.Parameters.AddWithValue("@ProductId", id);
            Product p = null;
            try
            {
                SqlDataReader dr = cmdEdit.ExecuteReader();
                if (dr.Read())
                {
                    p = new Product { ProductId = id, ProductName = dr.GetString(1) ,Rate = dr.GetDecimal(2),Description=dr.GetString(3),CategoryName=dr.GetString(4)};
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

            return View(p);
        }

        // POST: Product1/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product p)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Product;Integrated Security=True";
            cn.Open();
            SqlCommand cmdEdit = new SqlCommand();
            cmdEdit.Connection = cn;
            cmdEdit.CommandType = System.Data.CommandType.Text;
            cmdEdit.CommandText = "update Products set ProductName=@ProductName,Rate=@Rate,Description=@Description,CategoryName=@CategoryName";
            cmdEdit.Parameters.AddWithValue("@ProductId", p.ProductId);
            cmdEdit.Parameters.AddWithValue("@ProductName", p.ProductName);
            cmdEdit.Parameters.AddWithValue("@Rate", p.Rate);
            cmdEdit.Parameters.AddWithValue("@Description", p.Description);
            cmdEdit.Parameters.AddWithValue("@CategoryName", p.CategoryName);


            try
            {
                // TODO: Add update logic here
                cmdEdit.ExecuteNonQuery();
                //if (ModelState.IsValid)
                
                    return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Product1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product1/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
