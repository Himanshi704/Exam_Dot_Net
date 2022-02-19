using PartialViewMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartialViewMVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Product;Integrated Security=True";
            cn.Open();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "select * from PartialView";
            List<Class1> list = new List<Class1>();

            try
            {

                SqlDataReader dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                {
                    Class1 c = new Class1();
                    c.Id = (int)dr["Id"];
                   c.Name = (string)dr["Name"];
                    c.Center = (string)dr["Center"];
                    c.RollNo = (int)dr["RollNo"];
                    list.Add(c);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return View(list);
            
        }
    }
}