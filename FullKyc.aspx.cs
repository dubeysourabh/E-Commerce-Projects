using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Reflection.Emit;

public partial class Agent_FullKyc : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    string logId, mob;
    SqlDataAdapter adptCart = new SqlDataAdapter();
    DataSet dsCart = new DataSet();
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["ALog"] == null)
        {
            lblmsg.Text = "Session Expired!!! Please login again...";
        }
        else
        {
            logId = Convert.ToString(Request.Cookies["ALog"].Value);
            if (!Page.IsPostBack)
            {
                //btnSubmit_Click();
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Ensure file uploads
        if (txtFrontAadharImg.HasFile && txtBackAadharImg.HasFile && txtFrontPanImg.HasFile)
        {
            // Define file paths for saving
            string folderPath = Server.MapPath("~/CompanyImg/");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath); // Create directory if it doesn't exist
            }

            // Save the images
            string frontAadharPath = Path.Combine(folderPath, txtFrontAadharImg.FileName);
            txtFrontAadharImg.SaveAs(frontAadharPath);

            string backAadharPath = Path.Combine(folderPath, txtBackAadharImg.FileName);
            txtBackAadharImg.SaveAs(backAadharPath);

            string frontPanPath = Path.Combine(folderPath, txtFrontPanImg.FileName);
            txtFrontPanImg.SaveAs(frontPanPath);

            // Insert the data into the database

            cmd = new SqlCommand("INSERT INTO tblKyc(FullName, AadharCardNo, PanCardNo, FrontAadharCardImg, BackAadharCardImg, FrontPanCardImg,Status) " +
                                            "VALUES (@FullName, @AadharCardNo, @PanCardNo, @FrontAadharCardImg, @BackAadharCardImg, @FrontPanCardImg,@Status)", con);
            cmd.Parameters.AddWithValue("@FullName", txtName.Text.Trim());
            cmd.Parameters.AddWithValue("@AadharCardNo", txtAadhar.Text.Trim());
            cmd.Parameters.AddWithValue("@PanCardNo", TxtPan.Text.Trim());
            cmd.Parameters.AddWithValue("@FrontAadharCardImg", "~/CompanyImg/" + txtFrontAadharImg.FileName);
            cmd.Parameters.AddWithValue("@BackAadharCardImg", "~/CompanyImg/" + txtBackAadharImg.FileName);
            cmd.Parameters.AddWithValue("@FrontPanCardImg", "~/CompanyImg/" + txtFrontPanImg.FileName);
            cmd.Parameters.AddWithValue("@Status", "Pending");


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        else
        {
            Label1.Text = "Please upload all required images.";
        }
    }
}