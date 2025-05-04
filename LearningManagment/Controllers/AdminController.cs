using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.Data;
using System.Web.Mvc.Ajax;
using System.Web.WebPages;
using System.Web.UI.WebControls;

namespace LearningManagment.Controllers
{
    public class AdminController : Controller
    {
        // write code here to connect your database

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard() 
        {
            return View();
        }

        // PAGE TO ADD & MANAGE BATCHS 
        public ActionResult AddBatch()
        {
            // Select all data from tbl_batch
            string query = "select * from tbl_batch order by Sr desc";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            // transfer data to ViewBag to view page
            ViewBag.batchtable = dt;
            return View();
        }

        // Enter batch in database
        [HttpPost]
        public ActionResult SaveBatch(string txt_class)
        {
            string query = $"insert into tbl_batch values('{txt_class}', 1)";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();

            if (result > 0) 
            {
                return Content("<script>alert('Batch Added Succesfully !'); location.href = '/admin/addbatch'</script>");
            }
            else
            {
                return Content("<script>alert('Batch Not Added !'); location.href = '/admin/addbatch'</script>");
            }
        }

        // page to add & manage video category
        public ActionResult AddVideoCategory()
        {
            // Select all data from tbl_video_category
            string query = "select * from tbl_video_cetegory order by sr desc";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            // transfer data to ViewBag to view page
            ViewBag.videocattable = dt;
            return View();
        }

        // Enetr video category in database
        [HttpPost]
        public ActionResult SaveVideoCategory(string txt_category, HttpPostedFileBase file_thumbNail)
        {
            string query = $"insert into tbl_video_cetegory values('{txt_category}', '{file_thumbNail.FileName}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();

            if (result > 0)
            {
                file_thumbNail.SaveAs(Server.MapPath("/Content/categorypic/" + file_thumbNail.FileName));
                return Content("<script>alert('Video Category Added Succesfully !'); location.href = '/admin/addvideocategory'</script>");
            }
            else
            {
                return Content("<script>alert('Video Category Not Added !'); location.href = '/admin/addvideocategory'</script>");
            }
        }

        // page to add video
        public ActionResult AddVideo()
        {
            // Select data from batch onload event
            string query = "select * from tbl_batch order by Sr desc";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            // select data from video category
            string command = "select * from tbl_video_cetegory order by Sr desc";
            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable table2 = new DataTable();
            adapter.Fill(table2);

            // select data from video
            string command1 = "select * from tbl_video left join tbl_batch on tbl_video.Batch = tbl_batch.Sr left join tbl_video_cetegory on tbl_video.Cetegory = tbl_video_cetegory.Sr";
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1, con);
            DataTable table3 = new DataTable();
            adapter1.Fill(table3);

            ViewBag.table1 = dt;
            ViewBag.table2 = table2;
            ViewBag.table3 = table3;

            return View();
        }

        // enter video in database
        [HttpPost]
        public ActionResult SaveVideo(string txt_title, int ddl_batch, int ddl_category, string txt_link, HttpPostedFileBase file_thumbnail, string txt_desc) 
        {
            string query = $"insert into tbl_video values('{txt_title}', {ddl_batch}, {ddl_category},  '{txt_desc}','{txt_link}', '{file_thumbnail.FileName}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            
            if (result > 0)
            {
                file_thumbnail.SaveAs(Server.MapPath("/Content/videopic/" + file_thumbnail.FileName));
                return Content("<script>alert('Video Added Succesfully !'); location.href = '/admin/addvideo'</script>");
            }
            else
            {
                return Content("<script>alert('Video Not Added !'); location.href = '/admin/addvideo'</script>");
            }
        }

        // page to add assignment
        public ActionResult AddAssignment()
        {
            string query = "select * from tbl_batch order by Sr desc";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            // select data from tbl assignment
            string command = "select * from tbl_assignment left join tbl_batch on tbl_assignment.Batch = tbl_batch.Sr";
            SqlDataAdapter adapter1 = new SqlDataAdapter(command, con);
            DataTable dt2 = new DataTable();
            adapter1.Fill(dt2);

            ViewBag.table1 = dt;
            ViewBag.table2 = dt2;
            return View();
        }
        // enter assignment in database
        public ActionResult SaveAssignment(string ddl_batch, string txt_subject, string txt_title, string txt_desc, HttpPostedFileBase file_assignment, string txt_teacher, DateTime date_lastdate)
        {
            string query = $"insert into tbl_assignment values ('{ddl_batch}', '{txt_subject}', '{txt_title}', '{txt_desc}', '{file_assignment.FileName}', '{txt_teacher}', '{date_lastdate.ToString("yyyy-MM-dd")}', '{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}', 1)";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();

            if (result > 0)
            {
                file_assignment.SaveAs(Server.MapPath("/content/assignments/" + file_assignment.FileName));
                return Content("<script>alert('Assignment Added Succesfully !'); location.href = '/admin/addassignment'</script>");
            }
            else
            {
                return Content("<script>alert('Assignment Not Added !'); location.href = '/admin/addassignment'</script>");
            }
        }

        public ActionResult ManageStudent()
        {
            // Select data from tbl student
            string query = "select * from tbl_student left join tbl_batch on tbl_student.Batch = tbl_batch.Sr order by RegDate desc";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt1 = new DataTable();
            sda.Fill(dt1);

            ViewBag.table = dt1;
            return View();
        }

        public ActionResult UpdateStatus(string EmailId, int? Status) 
        { 
            if(!EmailId.IsEmpty() && Status.HasValue)
            {
                int s = Status == 0 ? 1 : 0;
                string query = $"update tbl_student set Status={s} where EmailId = '{EmailId}'";
                SqlCommand cmd = new SqlCommand (query, con);
                con.Open();
                int r = cmd.ExecuteNonQuery();
                con.Close();

                return Content("<script>alert('Status Updated.'); location.href = '/admin/managestudent'</script>");
            }
            else
            {
                return Content("<script>alert('Try again !'); location.href = '/admin/managestudent'</script>");
            }
        }

        public ActionResult DeleteBatch(string Batch)
        {
            if (!Batch.IsEmpty())
            {
                string query = $"delete from tbl_batch where Batch = '{Batch}'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int r = cmd.ExecuteNonQuery();
                con.Close();

                return Content("<script>alert('Batch Deleted.'); location.href = '/admin/addbatch'</script>");
            }
            else
            {
                return Content("<script>alert('Try Again.'); location.href = '/admin/addbatch'</script>");
            }
        }

        public ActionResult DeleteCat(string Category)
        {
            if (!Category.IsEmpty())
            {
                string query = $"delete from tbl_video_cetegory where CetegoryName = '{Category}'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int r = cmd.ExecuteNonQuery();
                con.Close();

                return Content("<script>alert('Category Deleted.'); location.href = '/admin/addvideocategory'</script>");
            }
            else
            {

                return Content("<script>alert('Try Again.'); location.href = '/admin/addvideocategory'</script>");
            }
        }

        public ActionResult ManageEnquiry()
        {
            // Select data from tbl1_contact
            string query = "select * from tbl1_contact order by Sr desc";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            ViewBag.table = dt;
            return View();
        }

        public ActionResult logout()
        {
            Session.Remove("admin");
            return Content("<script>alert('Logged out'); location.href = '/home/adminlogin'</script>");
        }

        public ActionResult ManageAssignment()
        {
            string query = "select * from tbl_submittedtask left join tbl_assignment on taskno = tbl_assignment.Sr  left join tbl_student on tbl_submittedtask.userid = tbl_student.emailid order by tbl_submittedtask.Sr desc;";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            ViewBag.assignmgmt = dt;
            return View();
        }

        public ActionResult Notes()
        {
            // Select data from tbl-batch
            string query = "select * from tbl_batch order by Sr desc";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            ViewBag.table1 = dt;
            return View();
        }


        [HttpPost]
        public ActionResult SaveNotes(string txt_title, string txt_desc, string txt_teacher, int ddl_batch, HttpPostedFileBase file_notes)
        {
            string query = $"insert into tbl_notes values ('{txt_title}', '{txt_desc}', '{txt_teacher}', '{file_notes.FileName}', {ddl_batch}, '{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();

            if (result > 0)
            {
                file_notes.SaveAs(Server.MapPath("/Content/notes/" + file_notes.FileName));
                return Content("<script>alert('Notes Added Succesfully !'); location.href = '/admin/notes'</script>");
            }
            else
            {
                return Content("<script>alert('Notes Not Added !'); location.href = '/admin/notes'</script>");
            }
        }
    }
}