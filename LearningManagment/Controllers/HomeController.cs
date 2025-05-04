using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace LearningManagment.Controllers
{
    public class HomeController : Controller
    {
        // write code here to connect your database

        // GET: Home
        public ActionResult Index()
        {
            string query = "select * from tbl_batch order by Sr desc";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            ViewBag.table1 = dt;
            return View();
        }

        [HttpPost]
        public ActionResult SaveStdData(string name, long? mobile, string email, string passwd, string branch, string year, HttpPostedFileBase profile, int batch) 
        {
            string query = $"insert into tbl_student values ('{name}', '{mobile}', '{email}', '{passwd}', '{branch}', '{year}', '{profile.FileName}', {batch}, 0, '{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open(); 
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result > 0)
            {
                profile.SaveAs(Server.MapPath("/content/stddatapic/" + profile.FileName));
                return Content("<script>alert('Data Added Succesfully !'); location.href = '/home/index/#register'</script>");
            }
            else
            {
                return Content("<script>alert('Data Not Added !'); location.href = '/home/index/#register'</script>");
            }
        }

        [HttpGet]
        public ActionResult SaveContact(string txt_name, long num_mobile, string txt_email, string txt_topic, string txt_message) 
        {
            string query = $"insert into tbl1_contact values ('{txt_name}', {num_mobile}, '{txt_email}', '{txt_topic}', '{txt_message}', '2020-09-09')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();

            if (result > 0)
            {
                return Content("<script>alert('Message Added Succesfully !'); location.href = '/home/index/#contact'</script>");
            }
            else
            {
                return Content("<script>alert('Message Not Added !'); location.href = '/home/index/#contact'</script>");
            }
        }

        [HttpPost]
        public ActionResult Login(string email, string passwd) 
        {
            string query = $"select * from tbl_student where EmailId = '{email}' and Password = '{passwd}'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt1 = new DataTable();
            adapter.Fill(dt1);

            if (dt1.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt1.Rows[0]["Status"]) == 1)
                {
                    Session["Name"] = dt1.Rows[0]["Name"];
                    Session["Email"] = dt1.Rows[0]["EmailId"];
                    Session["batch"] = dt1.Rows[0]["Batch"];
                    Session["Picture"] = dt1.Rows[0]["Picture"];

                    return Content("<script>alert('Welcome!'); location.href = '/student/dashboard'</script>");
                }
                else
                {
                    return Content("<script>alert('You are not authorize by admin.'); location.href = '/home/index'</script>");
                }
            }
           else
            {
                return Content("<script>alert('Invalid Id and Password!'); location.href = '/student/dashboard'</script>");
            }
        
                
        }
        public ActionResult Adminlogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult adminsignin(string email, string password)
        {
            if(email.Equals("admin") && password.Equals("123"))
            {
                Session["admin"] = email;
                return Content("<script>alert('Welcome!'); location.href = '/admin/dashboard'</script>");
            }
            else
            {
                return Content("<script>alert('Invalid Id and Password!'); location.href = '/home/adminlogin'</script>");
            }
        }
    }
}