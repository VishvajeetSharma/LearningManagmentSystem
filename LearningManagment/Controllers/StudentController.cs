using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningManagment.Controllers
{
    public class StudentController : Controller
    {
        // write code here to connect your database

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Course()
        {
            string query = "select * from tbl_video_cetegory order by Sr desc";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            ViewBag.cat = dt;
            return View();
        }

        public ActionResult SoftwareKit()
        {
            return View();
        }

        public ActionResult Task()
        {
            // select data from tbl_assignment
            int batchid = Convert.ToInt32(Session["batch"]);
            string query = $"select * from tbl_assignment left join tbl_submittedtask on tbl_assignment.sr=taskno where batch={batchid} order by tbl_assignment.sr desc";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            ViewBag.task = dt;
            return View();
        }

        public ActionResult Notes()
        {
            // Select data from tbl_notes
            string query = "select * from tbl_notes order by Sr desc";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            ViewBag.notes = dt;
            return View();
        }

        public ActionResult VideoLecture(int? catid)
        {
            if (catid.HasValue)
            {
                int batchid = Convert.ToInt32(Session["batch"]);
                string query = $"select * from tbl_video where batch={batchid} and cetegory={catid} order by sr";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                ViewBag.video = dt;
                return View();
            }
            else
            {
                return Content("<script>alert('Please select video category'); location.href = '/student/course'</script>");
            }
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            Session.RemoveAll();
            return Content("<script>location.href = '/home/index'</script>");
        }

        [HttpPost]
        public ActionResult submittask(int? taskno, string email, HttpPostedFileBase taskfile)
        {
            string query = $"insert into tbl_submittedtask values({taskno},'{email}','{taskfile.FileName}','{DateTime.Now.ToString("yyyy-MM-dd")}',0,'')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result > 0)
            {
                taskfile.SaveAs(Server.MapPath("/content/answerfile/" + taskfile.FileName));
                return Content("<script>alert('File Uploaded Successfully!'); location.href = '/student/task'</script>");
            }
            else
            {
                return Content("<script>alert('File not submitted!'); location.href = '/student/task'</script>");
            }
        }
        [HttpPost]
        public ActionResult changepass(string opasswd, string npasswd, string cpasswd)
        {
            if(npasswd.Equals(cpasswd))
            {
                string email = Session["email"].ToString();
                string query = $"update tbl_student set password='{npasswd}' where emailid='{email}' and password='{opasswd}'";
                SqlCommand cmd = new SqlCommand(query,con);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if(result>0)
                {
                    Session.RemoveAll();
                    return Content("<script>alert('Password updated'); location.href = '/home/index'</script>");
                }
                else
                {
                    return Content("<script>alert('Not changed. Old password not matched.'); location.href = '/student/changepassword'</script>");
                }
            }
            else
            {
                return Content("<script>alert('New password and confirm password should match'); location.href = '/student/changepassword'</script>");
            }
        }
    }
}