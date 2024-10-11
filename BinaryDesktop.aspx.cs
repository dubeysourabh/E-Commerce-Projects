using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

public partial class Agent_BinaryDesktop : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    string loginid, loginid1 = "";
    string cmdsel, sts;
    string uid;
    string str, curr = "", prev = "", status;
    DateTime datefr;
    SqlCommand sqlupdate = new SqlCommand();
    decimal amt, bonus, pamt, pinamt;
    double tds, admin, tdsamt, adminamt, tdsamt1, adminamt1;
    DateTime sdate, edate, currd;
    int weeks, no = 0, HisWeek, payno, weeks1 = 0, cnt = 0;
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter adpt = new SqlDataAdapter();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        //string userId = Session["userid"].ToString();

        //if (Request.Cookies["Log1"] == null)
        //{
        //    ScriptManager.RegisterStartupScript(this, typeof(string), "Validation", "var res1=alert('Session Expired!!! Please Login...'); (res1==true)?(window.location='../loginp.aspx') :(window.location='../loginp.aspx');", true);
        //    //Panel1.Visible = false;
        //}
        //else if (Session["userid"] == null)
        //{

        //    ScriptManager.RegisterStartupScript(this, typeof(string), "Validation", "var res1=alert('Session Expired!!! Please Login...'); (res1==true)?(window.location='../loginp.aspx') :(window.location='../loginp.aspx');", true);

        //}
        //else
        //{
        //loginid1 = Request.Cookies["Log1"].Value;
        //if (Session["user_id"] == null)
        //{
        //    Response.Write("<script language='java script'>alert('Your session Timeout Please Re-login')</script>");
        //    //ScriptManager.RegisterStartupScript(this, typeof(string), "Validation", "var res1=alert('Session Expired!!! Please Login...'); (res1==true)?(window.location='../loginp.aspx') :(window.location='../loginp.aspx');", true);
        //}
        //else
        //{
        //    loginid = Session["user_id"].ToString();
        //    // bindTopup();
        //    bindData();
        //    bindDirect();
        //    bindProduct();
        //}

        if (Request.Cookies["ALog"] != null)
        {
            loginid = Convert.ToString(Request.Cookies["ALog"].Value);
            if (!Page.IsPostBack)
            {
                bindData();
                bindDirect();
                //bindclubincome();
                bindProduct();
                double leftDisValueNumber = 0;
                double rightDisValueNumber = 0;
                double leftDisValueNumber1 = 0;
                double rightDisValueNumber1 = 0;
                double leftDisValueNumber2 = 0;
                double rightDisValueNumber2 = 0;
                double leftDisValueNumber3 = 0;
                double rightDisValueNumber3 = 0;
                double leftDisValueNumber4 = 0;
                double rightDisValueNumber4 = 0;
                double leftDisValueNumber5 = 0;
                double rightDisValueNumber5 = 0;
                double leftDisValueNumber6 = 0;
                double rightDisValueNumber6 = 0;
                double leftDisValueNumber7 = 0;
                double rightDisValueNumber7 = 0;
                double leftDisValueNumber8 = 0;
                double rightDisValueNumber8 = 0;
                double leftDisValueNumber9 = 0;
                double rightDisValueNumber9 = 0;
                double leftDisValueNumber10 = 0;
                double rightDisValueNumber10 = 0;
                double leftDisValueNumber11 = 0;
                double rightDisValueNumber11 = 0;
                double leftDisValueNumber12 = 0;
                double rightDisValueNumber12 = 0;
                double leftDisValueNumber13 = 0;
                double rightDisValueNumber13 = 0;
                double leftDisValueNumber14 = 0;
                double rightDisValueNumber14 = 0;
                double leftDisValueNumber15 = 0;
                double rightDisValueNumber15 = 0;
                double leftDisValueNumber16 = 0;
                double rightDisValueNumber16 = 0;
                double leftDisValueNumber17 = 0;
                double rightDisValueNumber17 = 0;


                bool isLeftDisValueNumeric = double.TryParse(LeftDisValue.Text, out leftDisValueNumber);
                bool isRightDisValueNumeric = double.TryParse(RightDisValue.Text, out rightDisValueNumber);

                bool isLeftDisValueNumeric1 = double.TryParse(trtSilver.Text, out leftDisValueNumber1);
                bool isRightDisValueNumeric1 = double.TryParse(Label8.Text, out rightDisValueNumber1);

                bool isLeftDisValueNumeric2 = double.TryParse(Label7.Text, out leftDisValueNumber2);
                bool isRightDisValueNumeric2 = double.TryParse(Label9.Text, out rightDisValueNumber2);

                bool isLeftDisValueNumeric3 = double.TryParse(Label23.Text, out leftDisValueNumber3);
                bool isRightDisValueNumeric3 = double.TryParse(Label24.Text, out rightDisValueNumber3);

                bool isLeftDisValueNumeric4 = double.TryParse(Label25.Text, out leftDisValueNumber4);
                bool isRightDisValueNumeric4 = double.TryParse(Label44.Text, out rightDisValueNumber4);

                bool isLeftDisValueNumeric5 = double.TryParse(Label47.Text, out leftDisValueNumber5);
                bool isRightDisValueNumeric5 = double.TryParse(Label48.Text, out rightDisValueNumber5);

                bool isLeftDisValueNumeric6 = double.TryParse(Label49.Text, out leftDisValueNumber6);
                bool isRightDisValueNumeric6 = double.TryParse(Label50.Text, out rightDisValueNumber6);

                bool isLeftDisValueNumeric7 = double.TryParse(Label51.Text, out leftDisValueNumber7);
                bool isRightDisValueNumeric7 = double.TryParse(Label52.Text, out rightDisValueNumber7);

                bool isLeftDisValueNumeric8 = double.TryParse(Label53.Text, out leftDisValueNumber8);
                bool isRightDisValueNumeric8 = double.TryParse(Label54.Text, out rightDisValueNumber8);

                bool isLeftDisValueNumeric9 = double.TryParse(Label55.Text, out leftDisValueNumber9);
                bool isRightDisValueNumeric9 = double.TryParse(Label56.Text, out rightDisValueNumber9);

                bool isLeftDisValueNumeric10 = double.TryParse(Label57.Text, out leftDisValueNumber10);
                bool isRightDisValueNumeric10 = double.TryParse(Label58.Text, out rightDisValueNumber10);

                bool isLeftDisValueNumeric11 = double.TryParse(Label59.Text, out leftDisValueNumber11);
                bool isRightDisValueNumeric11 = double.TryParse(Label60.Text, out rightDisValueNumber11);

                bool isLeftDisValueNumeric12 = double.TryParse(Label61.Text, out leftDisValueNumber12);
                bool isRightDisValueNumeric12 = double.TryParse(Label62.Text, out rightDisValueNumber12);

                bool isLeftDisValueNumeric13 = double.TryParse(Label63.Text, out leftDisValueNumber13);
                bool isRightDisValueNumeric13 = double.TryParse(Label64.Text, out rightDisValueNumber13);

                bool isLeftDisValueNumeric14 = double.TryParse(Label65.Text, out leftDisValueNumber14);
                bool isRightDisValueNumeric14 = double.TryParse(Label66.Text, out rightDisValueNumber14);

                bool isLeftDisValueNumeric15 = double.TryParse(Label67.Text, out leftDisValueNumber15);
                bool isRightDisValueNumeric15 = double.TryParse(Label68.Text, out rightDisValueNumber15);

                bool isLeftDisValueNumeric16 = double.TryParse(Label69.Text, out leftDisValueNumber16);
                bool isRightDisValueNumeric16 = double.TryParse(Label70.Text, out rightDisValueNumber16);

                bool isLeftDisValueNumeric17 = double.TryParse(Label71.Text, out leftDisValueNumber17);
                bool isRightDisValueNumeric17 = double.TryParse(Label72.Text, out rightDisValueNumber17);


                if (leftDisValueNumber >= 200 && rightDisValueNumber >= 100)
                {
                    
                    First_td_Status.Text = "Active";
                }
                else
                {                  
                    First_td_Status.Text = "Inactive";
                }

                if (leftDisValueNumber1 >= 600 && rightDisValueNumber1 >= 300)
                {
                    // Second set is valid -> Mark as Active
                    Second_td_Status.Text = "Active";
                }
                else
                {
                    // Second set is invalid -> Mark as Inactive
                    Second_td_Status.Text = "Inactive";
                }
                if (leftDisValueNumber2 >= 1200 && rightDisValueNumber2 >= 600)
                {
                    // Second set is valid -> Mark as Active
                    Third_td_Status.Text = "Active";
                }
                else
                {
                    // Second set is invalid -> Mark as Inactive
                    Third_td_Status.Text = "Inactive";
                }
                if (leftDisValueNumber3 >= 2400 && rightDisValueNumber3 >= 1200)
                {
                    // Second set is valid -> Mark as Active
                    Fourth_td_Status.Text = "Active";
                }
                else
                {
                    // Second set is invalid -> Mark as Inactive
                    Fourth_td_Status.Text = "Inactive";
                }
                if (leftDisValueNumber4 >= 4800 && rightDisValueNumber4 >= 2400)
                {
                    // Second set is valid -> Mark as Active
                    Fifth_td_Status.Text = "Active";
                }
                else
                {
                    // Second set is invalid -> Mark as Inactive
                    Fifth_td_Status.Text = "Inactive";
                }
                if (leftDisValueNumber5 >= 12000 && rightDisValueNumber5 >= 6000)
                {
                    // Second set is valid -> Mark as Active
                    Sixth_td_Status.Text = "Active";
                }
                else
                {
                    // Second set is invalid -> Mark as Inactive
                    Sixth_td_Status.Text = "Inactive";
                }
                if (leftDisValueNumber6 >= 24000 && rightDisValueNumber6 >= 12000)
                {
                    // Second set is valid -> Mark as Active
                    Label10.Text = "Active";
                }
                else
                {
                    // Second set is invalid -> Mark as Inactive
                    Label10.Text = "Inactive";
                }
                if (leftDisValueNumber7 >= 48000 && rightDisValueNumber7 >= 24000)
                {
                    // Second set is valid -> Mark as Active
                    Label11.Text = "Active";
                }
                else
                {
                    // Second set is invalid -> Mark as Inactive
                    Label11.Text = "Inactive";
                }
                if (leftDisValueNumber8 >= 96000 && rightDisValueNumber8 >= 48000)
                {
                    // Second set is valid -> Mark as Active
                    Label3.Text = "Active";
                }
                else
                {
                    // Second set is invalid -> Mark as Inactive
                    Label3.Text = "Inactive";
                }
                if (leftDisValueNumber9 >= 192000 && rightDisValueNumber9 >= 96000)
                {
                    // Second set is valid -> Mark as Active
                    Label13.Text = "Active";
                }
                else
                {
                    // Second set is invalid -> Mark as Inactive
                    Label13.Text = "Inactive";
                }
                if (leftDisValueNumber10 >= 384000 && rightDisValueNumber10 >= 192000)
                {
                    // Second set is valid -> Mark as Active
                    Label14.Text = "Active";
                }
                else
                {
                    // Second set is invalid -> Mark as Inactive
                    Label14.Text = "Inactive";
                }
                if (leftDisValueNumber11 >= 768000 && rightDisValueNumber11 >= 384000)
                {
                    // Second set is valid -> Mark as Active
                    Label6.Text = "Active";
                }
                else
                {
                    // Second set is invalid -> Mark as Inactive
                    Label6.Text = "Inactive";
                }
                if (leftDisValueNumber12 >= 1536000 && rightDisValueNumber12 >= 768000)
                {
                    // Second set is valid -> Mark as Active
                    Label16.Text = "Active";
                }
                else
                {
                    // Second set is invalid -> Mark as Inactive
                    Label16.Text = "Inactive";
                }
                if (leftDisValueNumber13 >= 3072000 && rightDisValueNumber13 >= 1536000)
                {
                    // Second set is valid -> Mark as Active
                    Label17.Text = "Active";
                }
                else
                {
                    // Second set is invalid -> Mark as Inactive
                    Label17.Text = "Inactive";
                }
                if (leftDisValueNumber14 >= 6133000 && rightDisValueNumber3 >= 3072000)
                {
                    // Second set is valid -> Mark as Active
                    Label18.Text = "Active";
                }
                else
                {
                    // Second set is invalid -> Mark as Inactive
                    Label18.Text = "Inactive";
                }
                if (leftDisValueNumber15 >= 12288000 && rightDisValueNumber15 >= 6133000)
                {
                    // Second set is valid -> Mark as Active
                    Label19.Text = "Active";
                }
                else
                {
                    // Second set is invalid -> Mark as Inactive
                    Label19.Text = "Inactive";
                }
                if (leftDisValueNumber16 >= 24276000 && rightDisValueNumber16 >= 12288000)
                {
                    // Second set is valid -> Mark as Active
                    Label20.Text = "Active";
                }
                else
                {
                    // Second set is invalid -> Mark as Inactive
                    Label20.Text = "Inactive";
                }
                if (leftDisValueNumber17 >= 49152000 && rightDisValueNumber17 >= 24276000)
                {
                    // Second set is valid -> Mark as Active
                    Label21.Text = "Active";
                }
                else
                {
                    // Second set is invalid -> Mark as Inactive
                    Label21.Text = "Inactive";
                }
            }
        }
    }

    protected void btnChangePhoto_Click(object sender, EventArgs e)
    {
        if (FileUpload1.PostedFile != null)
        {

            //logId = Request.Cookies["Log"].Value;
            Stream imgStream = FileUpload1.PostedFile.InputStream;
            int imgLen = FileUpload1.PostedFile.ContentLength;
            byte[] imgBinaryData = new byte[imgLen];
            int n = imgStream.Read(imgBinaryData, 0, imgLen);

            SqlCommand cmd = new SqlCommand("Update membermaster set photo=@img_data Where loginid='" + loginid + "'", con);
            con.Open();

            SqlParameter param1 = new SqlParameter("@img_data", SqlDbType.Image);
            param1.Value = imgBinaryData;
            cmd.Parameters.Add(param1);

            cmd.ExecuteNonQuery();
            SelfImg.ImageUrl = "ImageUploadHandler.ashx?loginid=" + loginid;
            //Image1.ImageUrl=~/Agent/ImaHandler2.ashx?Loginid"=+logId;
            con.Close();
            bindData();

        }
    }

    protected void bindData()
    {

        //if (Request.Cookies["curr"] == null || Request.Cookies["curr"].Value == "")
        //{
        //    curr = Request.Cookies["curr"].Value;
        //    prev = Request.Cookies["prev"].Value;
        SqlCommand cmdcurr = new SqlCommand("select lastlogin from loginsession where loginid='" + loginid + "'", con);
        con.Open();
        SqlDataReader readcurr = cmdcurr.ExecuteReader();
        if (readcurr.HasRows)
        {
            readcurr.Read();
            prev = Convert.ToString(readcurr[0]);
        }
        con.Close();
        curr = Convert.ToString(DateTime.Now);

        con.Open();
        sqlupdate = new SqlCommand("update LoginSession set lastLogin=@gdate  where loginid='" + loginid + "'", con);
        sqlupdate.Parameters.AddWithValue("@gdate", Convert.ToDateTime(curr));
        sqlupdate.ExecuteNonQuery();
        con.Close();

        //lblCurrent.Text = curr;
        //lblLast.Text = prev;
        //}


        SqlDataAdapter adpt = new SqlDataAdapter();
        if (loginid == "ww1111")
        {
            adpt = new SqlDataAdapter("SELECT ISNULL(membername, N'---') AS membername, ISNULL(Spillby, N'---') AS spillby, photo,'---' as sname from  membermaster where loginid='" + loginid + "'", con);


            //adpt = new SqlDataAdapter("select isnull(membername,'---') as membername, isnull(spillby,'---') as spillby from membermaster where (loginid=spillby) ,photo from membermaster where loginid='" + loginid + "'", con);
        }
        else
        {
            adpt = new SqlDataAdapter("select isnull(membermaster.membername,'---') as membername, isnull(membermaster.spillby,'---') as spillby, isnull(membermaster1.membername,'---') as sname,membermaster.photo from membermaster inner join membermaster as membermaster1 on membermaster1.loginid=membermaster.spillby where membermaster.loginid='" + loginid + "'", con);
        }

        DataSet dsd = new DataSet();
        adpt.Fill(dsd);
        if (dsd.Tables[0].Rows.Count > 0)
        {
            lblLogin.Text = Convert.ToString(loginid);
            lblName.Text = Convert.ToString(dsd.Tables[0].Rows[0]["membername"]);
            //lblsid.Text = Convert.ToString(dsd.Tables[0].Rows[0]["spillby"]);
            /// if (lblsid.Text == "admin")
            //{
            //    SqlCommand cmd111 = new SqlCommand("select membername from membermaster Where loginid='shree'", con);
            //    con.Open();
            //    lblsname.Text = Convert.ToString(cmd111.ExecuteScalar());
            //    con.Close();
            //}
            // else
            //{
            //    lblsname.Text = Convert.ToString(dsd.Tables[0].Rows[0]["sname"]);
            //}

            //if (lblsname.Text == "")
            //{
            //    lblsname.Text = "---";
            //}
            if (Convert.ToString(dsd.Tables[0].Rows[0]["photo"]) == "")
            {
                SelfImg.ImageUrl = "../CompanyImg/emp.png";
            }
            else
            {
                SelfImg.ImageUrl = "../Agent/ImageUploadHandler.ashx?loginid=" + loginid;
            }
        }
    }

    //    SqlDataAdapter adptB = new SqlDataAdapter("select sum isnull(TOtRV,0) as amount,convert(varchar,doj,3)  from repurchase_members where loginid='" + loginid + "'", con);
    //    DataSet dsB = new DataSet();
    //    adptB.Fill(dsB);
    //    if (dsB.Tables[0].Rows.Count > 0)
    //    {
    //        iblpv.Text = Convert.ToString(dsB.Tables[0].Rows[0]["amount"]);
    //        //lblDate.Text = Convert.ToString(dsB.Tables[0].Rows[0]["doj"]);
    //    }
    //    else
    //    {
    //        iblpv.Text = "0";
    //        //lblDate.Text = "---";
    //    }

    //}

    protected void bindDirect()
    {
        try
        {
            //============================================All Directs==========================================================================

            cmd = new SqlCommand("select count(*) from directcur where loginid='" + loginid + "' and pinvalue>0", con);
            con.Open();
            ADLeftP.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            cmd = new SqlCommand("select count(*) from directcur where loginid='" + loginid + "' and pinvalue=0", con);
            con.Open();
            ADLeftU.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            ADLeftT.Text = Convert.ToString(Convert.ToInt32(ADLeftP.Text) + Convert.ToInt32(ADLeftU.Text));

            //=================================================Today's Directs=====================================================================

            cmd = new SqlCommand("select count(*) from directcur where loginid='" + loginid + "' and pinvalue>0 and (DATEDIFF(d, date, GETDATE()) = 0)", con);
            con.Open();
            TDLeftP.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            cmd = new SqlCommand("select count(*) from directcur where loginid='" + loginid + "' and pinvalue=0 and (DATEDIFF(d, date, GETDATE()) = 0)", con);
            con.Open();
            TDLeftU.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            TDLeftT.Text = Convert.ToString(Convert.ToInt32(TDLeftP.Text) + Convert.ToInt32(TDLeftU.Text));

            cmd = new SqlCommand("select count(*) from directcur where loginid='" + loginid + "'", con);
            con.Open();
            ibldirect.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            cmd = new SqlCommand("select count(*) from directcur where side='Leftside'and pinvalue>0  and loginid='" + loginid + "'", con);
            con.Open();
            leftdirectpv.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            cmd = new SqlCommand("select count(*) from directcur where side='Leftside' and  loginid='" + loginid + "'", con);
            con.Open();
            iblleftdirect.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            cmd = new SqlCommand("select count(*) from directcur where side='Rightside' and  loginid='" + loginid + "'", con);
            con.Open();
            iblrightdirect.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            cmd = new SqlCommand("select count(*) from directcur where side='Rightside'and pinvalue>0  and loginid='" + loginid + "'", con);
            con.Open();
            rightdirectpv.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            cmd = new SqlCommand("select count(*) from printview where intro='" + loginid + "'", con);
            con.Open();
            ibltotal.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            //==================================================Repurchase details====================================================================
            cmd = new SqlCommand("select Leftcount from repbinarypurf where loginid='" + loginid + "'", con);
            con.Open();
            IblLeftcount.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            cmd = new SqlCommand("select LeftPoint from repbinarypurf where loginid='" + loginid + "'", con);
            con.Open();
            Iblleftpv.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            cmd = new SqlCommand("select Rightcount from repbinarypurf where loginid='" + loginid + "'", con);
            con.Open();
            Iblrightcount.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            cmd = new SqlCommand("select RightPoint from repbinarypurf where loginid='" + loginid + "'", con);
            con.Open();
            IblRightpv.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();


            cmd = new SqlCommand("select Leftpoint from repbinarycur where loginid='" + loginid + "'", con);
            con.Open();
            caryleftrv.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            cmd = new SqlCommand("select RightPoint from repbinarycur where loginid='" + loginid + "'", con);
            con.Open();
            caryrightrv.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            //==================================================matching details====================================================================
            cmd = new SqlCommand("select Leftcount from BinaryPurf where loginid='" + loginid + "'", con);
            con.Open();
            leftcount.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            cmd = new SqlCommand("select Rightcount from BinaryPurf where loginid='" + loginid + "'", con);
            con.Open();
            leftpv.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            cmd = new SqlCommand("select LeftPoint from BinaryPurf where loginid='" + loginid + "'", con);
            con.Open();
            rightcount.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            cmd = new SqlCommand("select RightPoint from BinaryPurf where loginid='" + loginid + "'", con);
            con.Open();
            rightpv.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            cmd = new SqlCommand("select LeftPoint from binarycur where loginid='" + loginid + "'", con);
            con.Open();
            caryleftpv.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            cmd = new SqlCommand("select RightPoint from binarycur where loginid='" + loginid + "'", con);
            con.Open();
            caryrightpv.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            //==================================================All Registrations====================================================================

            cmd = new SqlCommand("select status from findamaster where loginid='" + loginid + "'", con);
            con.Open();
            iblrank.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            cmd = new SqlCommand("select pinval from repfindamaster where loginid=@loginid", con);
            cmd.Parameters.AddWithValue("@loginid", loginid); // Use parameterized query to prevent SQL injection

            con.Open();
            object result = cmd.ExecuteScalar();
            con.Close();

            if (result != null && Convert.ToInt32(result) > 0)
            {
                iblshop.Text = "Active";
                iblshop.ForeColor = System.Drawing.Color.Green;  // Set text color to green for Active
            }
            else
            {
                iblshop.Text = "Inactive";
                iblshop.ForeColor = System.Drawing.Color.Red;    // Set text color to red for Inactive
            }

            cmd = new SqlCommand("select isnull(Grandtotal,0)  from ewallet where loginid='" + loginid + "'", con);
            con.Open();
            Iblmatch.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            cmd = new SqlCommand("select isnull(Grandtotal,0)  from ewallet where loginid='" + loginid + "'", con);
            con.Open();
            IblMPI.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            cmd = new SqlCommand("select isnull(Grandtotal,0)  from ewallet where loginid='" + loginid + "'", con);
            con.Open();
            Iblrep.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            cmd = new SqlCommand("select SUM(TotRV) from repurchase_members where status='Shipped' and loginid='" + loginid + "'", con);
            con.Open();
            iblTolPv.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            //cmd = new SqlCommand("select isnull(LeftPoint,0) as LeftPoint from binarypurf where loginid='" + loginid + "'", con);
            //con.Open();
            //ARLeftTP.Text = Convert.ToString(cmd.ExecuteScalar());
            //con.Close();

            //cmd = new SqlCommand("select isnull(RightPoint,0) as RightPoint from binarypurf where loginid='" + loginid + "'", con);
            //con.Open();
            //ARRightTP.Text = Convert.ToString(cmd.ExecuteScalar());
            //con.Close();


            cmd = new SqlCommand("select isnull(LeftCount,0) as LeftCount from binarypurf where loginid='" + loginid + "'", con);
            con.Open();
            //ARLeftTC.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            cmd = new SqlCommand("select isnull(RightCount,0) as RightCount from binarypurf where loginid='" + loginid + "'", con);
            con.Open();
            //ARRightTC.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            //===================================================Todays Registrations===================================================================

            cmd = new SqlCommand("select count(*) as LeftC from printview where intro='" + loginid + "' and pinval>0 and side like 'leftside%' and (DATEDIFF(d, date, GETDATE()) = 0)", con);
            con.Open();
            TRLeftPC.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            cmd = new SqlCommand("select count(*) as LeftC from printview where intro='" + loginid + "' and pinval=0 and side like 'leftside%' and (DATEDIFF(d, date, GETDATE()) = 0)", con);
            con.Open();
            TRLeftUC.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            //TRLeftTC.Text = Convert.ToString(Convert.ToInt32(TRLeftPC.Text) + Convert.ToInt32(TRLeftUC.Text));

            cmd = new SqlCommand("select count(*) as RightC from printview where intro='" + loginid + "' and pinval>0 and side like 'rightside%' and (DATEDIFF(d, date, GETDATE()) = 0)", con);
            con.Open();
            TRRightPC.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            cmd = new SqlCommand("select count(*) as RightC from printview where intro='" + loginid + "' and pinval=0 and side like 'rightside%' and (DATEDIFF(d, date, GETDATE()) = 0)", con);
            con.Open();
            TRRightUC.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            // TRRightTC.Text = Convert.ToString(Convert.ToInt32(TRRightPC.Text) + Convert.ToInt32(TRRightUC.Text));

            //===========================================================================today paid/unpaid reg========================================================

            //cmd = new SqlCommand("select ISNULL(MAX(finalpin),0) from (select tt.directid,isnull(SUM(tt.dpin + tt.newidsum),0) as finalpin from (SELECT d.directid, sum(d.pinvalue) as dpin, sum(l.pinvalue) AS newidsum from DirectCur d left JOIN LevelSponcer l ON d.directid = l.loginid where d.loginid='" + loginid + "' and d.status='pending' and l.status='Unpaid' and CAST(l.date as date)=CAST(GETDATE() as date) group by d.directid ) as tt group by tt.directid) as t ", con);
            cmd = new SqlCommand(" select isnull(directbus,0) + (select SUM(pinvalue) from directcur where loginid='" + loginid + "' and side='leftside' and CAST(DATE as date)=CAST(GETDATE() as date))  from (select SUM(pinvalue) as directbus from levelsponcer where loginid in( select directid from directcur where loginid='" + loginid + "' and side='leftside' and CAST(DATE as date)=CAST(GETDATE() as date))) as t ", con);

            con.Open();
            TRLeftPP.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            //cmd = new SqlCommand("select isnull(count(NEWID),0) from LevelSponcer where loginid='" + loginid + "' and level=1 and CAST(DATE as date)=CAST(GETDATE() as date)", con);
            cmd = new SqlCommand(" select isnull(directbus,0) + (select count(directid) from directcur where loginid='" + loginid + "' and side='leftside' and CAST(DATE as date)=CAST(GETDATE() as date))  from (select count(NEWID) as directbus from levelsponcer where loginid in( select directid from directcur where loginid='" + loginid + "' and side='leftside' and CAST(DATE as date)=CAST(GETDATE() as date))) as t ", con);

            con.Open();
            TRLeftUP.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            //TRLeftTP.Text = Convert.ToString(Convert.ToInt32(TRLeftPP.Text) + Convert.ToInt32(TRLeftUP.Text));


            //cmd = new SqlCommand("select isnull(SUM(t.pv),0) from (select loginid,SUM(pinvalue) as PV from levelsponcer where loginid in(select NEWID from levelsponcer where loginid='" + loginid + "' and level=1 and CAST(date as date)=CAST(GETDATE() as date))  group by loginid  ) as t where t.PV!=(select MAX(t.PV) from (select loginid,SUM(pinvalue) as PV from levelsponcer where loginid in(select NEWID from levelsponcer where loginid='" + loginid + "' and level=1) group by loginid ) as t )", con);
            cmd = new SqlCommand(" select isnull(directbus,0) + (select SUM(pinvalue) from directcur where loginid='" + loginid + "' and side='rightside' and CAST(DATE as date)=CAST(GETDATE() as date))  from (select SUM(pinvalue) as directbus from levelsponcer where loginid in( select directid from directcur where loginid='" + loginid + "' and side='rightside' and CAST(DATE as date)=CAST(GETDATE() as date))) as t ", con);

            con.Open();
            TRRightPP.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            //cmd = new SqlCommand("select isnull(count(NEWID),0) from LevelSponcer where loginid='" + loginid + "' and level=1 and CAST(DATE as date)=CAST(GETDATE() as date)", con);
            cmd = new SqlCommand(" select isnull(directbus,0) + (select count(directid) from directcur where loginid='" + loginid + "' and side='rightside' and CAST(DATE as date)=CAST(GETDATE() as date))  from (select count(NEWID) as directbus from levelsponcer where loginid in( select directid from directcur where loginid='" + loginid + "' and side='rightside' and CAST(DATE as date)=CAST(GETDATE() as date))) as t ", con);

            con.Open();
            TRRightUP.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            //   TRRightTP.Text = Convert.ToString(Convert.ToInt32(TRRightPP.Text) + Convert.ToInt32(TRRightUP.Text));


            //===========================================================================All paid/unpaid reg count========================================================

            cmd = new SqlCommand("select count(*) as LeftC from printview where intro='" + loginid + "' and pinval>0 and side like 'leftside%'", con);
            con.Open();
            ARLeftPC.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();


            cmd = new SqlCommand("select count(*) as LeftC from printview where intro='" + loginid + "' and pinval=0 and side like 'leftside%'", con);
            con.Open();
            ARLeftUC.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            // ARLeftTC.Text = Convert.ToString(Convert.ToInt32(ARLeftPC.Text) + Convert.ToInt32(ARLeftUC.Text));

            cmd = new SqlCommand("select count(*) as LeftC from printview where intro='" + loginid + "' and pinval>0 and side like 'rightside%'", con);
            con.Open();
            ARRightPC.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            cmd = new SqlCommand("select count(*) as LeftC from printview where intro='" + loginid + "' and pinval=0 and side like 'rightside%'", con);
            con.Open();
            ARRightUC.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            //ARRightTC.Text = Convert.ToString(Convert.ToInt32(ARRightPC.Text) + Convert.ToInt32(ARRightUC.Text));

            //===========================================================================All paid/unpaid reg point========================================================


            //SqlCommand cmd11 = new SqlCommand("select isnull(MAX(t.PV),0) from (select loginid,SUM(pinvalue) as PV from levelsponcer where loginid in(select NEWID from levelsponcer where loginid='" + loginid + "' and level=1) group by loginid ) as t inner join membermaster m on t.loginid=m.Loginid", con);
            // SqlCommand cmd11 = new SqlCommand("select ISNULL(MAX(finalpin),0) from (select tt.directid,isnull(SUM(tt.dpin + tt.newidsum),0) as finalpin from (SELECT d.directid, sum(d.pinvalue) as dpin, sum(l.pinvalue) AS newidsum from DirectCur d left JOIN LevelSponcer l ON d.directid = l.loginid where d.loginid='" + loginid + "' and d.status='pending' and l.status='Unpaid' group by d.directid ) as tt group by tt.directid) as t ", con);
            // con.Open();
            // double maxpv = Convert.ToDouble(cmd11.ExecuteScalar());
            // //ARLeftPP.Text = Convert.ToString(cmd11.ExecuteScalar());
            // con.Close();

            // //cmd = new SqlCommand("select isnull(sum(pinval),0) as LeftC from printview where intro='" + loginid + "' and pinval=0 and side like 'leftside%'", con);
            // //cmd = new SqlCommand("select count(t.loginid) from (select loginid,SUM(pinvalue) as PV from levelsponcer  where loginid in(select NEWID from levelsponcer where loginid='" + loginid + "' and level=1)   group by loginid  ) as t", con);
            // //con.Open();
            // //ARLeftUP.Text = "1";// Convert.ToString(cmd.ExecuteScalar());
            // //con.Close();


            // //SqlCommand cmd1 = new SqlCommand("select isnull(SUM(t.pv),0) from (select loginid,SUM(pinvalue) as PV from levelsponcer where loginid in(select NEWID from levelsponcer where loginid='" + loginid + "' and level=1)  group by loginid  ) as t where t.PV!=(select isnull(MAX(t.PV),0) from (select loginid,SUM(pinvalue) as PV from levelsponcer where loginid in(select NEWID from levelsponcer where loginid='" + loginid + "' and level=1) group by loginid ) as t )", con);
            // SqlCommand cmd1 = new SqlCommand("select isnull(SUM(tt.dpin + tt.newidsum),0) from (SELECT d.directid, sum(d.pinvalue) as dpin, sum(l.pinvalue) AS newidsum from DirectCur d left JOIN LevelSponcer l ON d.directid = l.loginid where d.loginid='" + loginid + "' and d.status='pending' and l.status='Unpaid' group by d.directid ) as tt", con);


            // con.Open();
            // double otherpv = Convert.ToDouble(cmd1.ExecuteScalar());

            //// ARRightPP.Text = Convert.ToString(cmd1.ExecuteScalar());
            // con.Close();
            // if (otherpv > maxpv)
            // otherpv = otherpv - maxpv;



            // if (maxpv > otherpv)
            // {
            //     ARLeftPP.Text = Convert.ToString(maxpv);
            //     ARRightPP.Text = Convert.ToString(otherpv);
            // }
            // else
            // {
            //     ARLeftPP.Text = Convert.ToString(otherpv);
            //     ARRightPP.Text = Convert.ToString(maxpv);

            // }



            // cmd = new SqlCommand("select isnull(count(x.directid),0)-1 from (select tt.directid,isnull(SUM(tt.dpin + tt.newidsum),0) as finalpin from (SELECT d.directid, sum(d.pinvalue) as dpin, sum(l.pinvalue) AS newidsum from DirectCur d left JOIN LevelSponcer l ON d.directid = l.loginid where d.loginid='" + loginid + "' group by d.directid ) as tt group by tt.directid) as x ", con);
            // con.Open();
            // double dblcnt = Convert.ToDouble(cmd.ExecuteScalar());
            // con.Close();
            // if (Convert.ToDouble(ARLeftPP.Text) == otherpv)
            // {
            //     ARLeftUP.Text = dblcnt.ToString();
            //     ARRightUP.Text = "1";
            // }
            // if (Convert.ToDouble(ARLeftPP.Text) == maxpv)
            // {
            //     ARLeftUP.Text = "1";
            //     ARRightUP.Text = dblcnt.ToString();
            // }

            //cmd = new SqlCommand("select count(t.loginid) from (select loginid,SUM(pinvalue) as PV from levelsponcer  where loginid in(select NEWID from levelsponcer where loginid='" + loginid + "' and level=1)   group by loginid  ) as t where t.PV!=(select MAX(t.PV) from  (select loginid,SUM(pinvalue) as PV from levelsponcer  where loginid in(select NEWID from levelsponcer where loginid='" + loginid + "' and level=1) group by loginid ) as t )", con);


            // ARRightTP.Text = Convert.ToString(Convert.ToInt32(ARRightPP.Text) + Convert.ToInt32(ARRightUP.Text));

            cmd = new SqlCommand(" select isnull(directbus,0) + (select SUM(pinvalue) from directcur where loginid='" + loginid + "' and side='leftside')  from (select SUM(pinvalue) as directbus from levelsponcer where loginid in( select directid from directcur where loginid='" + loginid + "' and side='leftside')) as t ", con);
            con.Open();
            ARLeftPP.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            cmd = new SqlCommand(" select isnull(directbus,0) + (select count(directid) from directcur where loginid='" + loginid + "' and side='leftside')  from (select count(NEWID) as directbus from levelsponcer where loginid in( select directid from directcur where loginid='" + loginid + "' and side='leftside')) as t ", con);

            con.Open();
            ARLeftUP.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            cmd = new SqlCommand(" select isnull(directbus,0) + (select SUM(pinvalue) from directcur where loginid='" + loginid + "' and side='rightside')  from (select SUM(pinvalue) as directbus from levelsponcer where loginid in( select directid from directcur where loginid='" + loginid + "' and side='rightside')) as t ", con);
            con.Open();
            ARRightPP.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            cmd = new SqlCommand(" select isnull(directbus,0) + (select count(directid) from directcur where loginid='" + loginid + "' and side='rightside')  from (select count(NEWID) as directbus from levelsponcer where loginid in( select directid from directcur where loginid='" + loginid + "' and side='rightside')) as t ", con);
            con.Open();
            ARRightUP.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            cmd = new SqlCommand("select TopupDate from findamaster where loginid=@loginid", con);
            cmd.Parameters.AddWithValue("@loginid", loginid);
            con.Open();

            // Retrieve the TopupDate and subtract 15 days
            object result12 = cmd.ExecuteScalar();
            con.Close();

            if (result12 != null && result12 != DBNull.Value)
            {
                DateTime topupDate = Convert.ToDateTime(result12);
                // Add 15 days to the topupDate
                DateTime newDate = topupDate.AddDays(15);

                // Calculate the difference between newDate and the current date
                TimeSpan difference = newDate - DateTime.Now;

                if (difference.TotalSeconds > 0) // Ensure there is time left
                {
                    // Extract days, hours, minutes, and seconds from the TimeSpan
                    int daysLeft = (int)Math.Floor(difference.TotalDays);
                    int hoursLeft = difference.Hours;
                    int minutesLeft = difference.Minutes;
                    int secondsLeft = difference.Seconds;
                    // Display the countdown in Label36
                    Label36.Text = daysLeft + " days, " + hoursLeft + " hours, " + minutesLeft + " minutes, " + secondsLeft + " seconds left";
                }
                else
                {
                    // If the date has passed
                    Label36.Text = "Time is up!";
                }
            }
            else
            {
                Label36.Text = "No Date Found";
            }

            //==================================================Monthly Performance Incentive====================================================================

            SqlCommand cmd3 = new SqlCommand("SELECT MPIleftPV,MPIrightPV FROM binarypurf WHERE LoginId = @LoginId", con);
            cmd3.Parameters.AddWithValue("@LoginId", loginid);

            con.Open();
            int MPIleftPV = 0, MPIrightPV = 0;

            using (SqlDataReader reader = cmd3.ExecuteReader())
            {
                if (reader.Read())
                {
                    MPIleftPV = reader.IsDBNull(0) ? 0 : Convert.ToInt32(reader.GetValue(0)); // Handle NULL or convert
                    MPIrightPV = reader.IsDBNull(1) ? 0 : Convert.ToInt32(reader.GetValue(1)); // Handle NULL or convert
                }
            }
            con.Close();
            //====================================================displaympi=======================================================
            double leftDisValue = 0;
            double rightDisValue = 0;
            double leftDisValue2 = 0;
            double rightDisValue2 = 0;
            double leftDisValue3 = 0;
            double rightDisValue3 = 0;
            double leftDisValue4 = 0;
            double rightDisValue4 = 0;
            double leftDisValue5 = 0;
            double rightDisValue5 = 0;
            double leftDisValue6 = 0;
            double rightDisValue6 = 0;
            double leftDisValue7 = 0;
            double rightDisValue7 = 0;
            double leftDisValue8 = 0;
            double rightDisValue8 = 0;
            double leftDisValue9 = 0;
            double rightDisValue9 = 0;
            double leftDisValue10 = 0;
            double rightDisValue10 = 0;
            double leftDisValue11 = 0;
            double rightDisValue11 = 0;
            double leftDisValue12 = 0;
            double rightDisValue12 = 0;
            double leftDisValue13 = 0;
            double rightDisValue13 = 0;
            double leftDisValue14 = 0;
            double rightDisValue14 = 0;
            double leftDisValue15 = 0;
            double rightDisValue15 = 0;
            double leftDisValue16 = 0;
            double rightDisValue16 = 0;
            double leftDisValue17 = 0;
            double rightDisValue17 = 0;
            double leftDisValue18 = 0;
            double rightDisValue18 = 0;


            using (SqlCommand cmd1 = new SqlCommand("MpiStatus1", con))
            {
                cmd1.CommandType = CommandType.StoredProcedure;

                // Add input parameters
                cmd1.Parameters.AddWithValue("@loginid", loginid);
                cmd1.Parameters.AddWithValue("@MPIleftPV", MPIleftPV);
                cmd1.Parameters.AddWithValue("@MPIrightPV", MPIrightPV);
                cmd1.Parameters.AddWithValue("@Status", "ACTIVE");
                cmd1.Parameters.AddWithValue("@pinval", 25);
                cmd1.Parameters.AddWithValue("@Reqleftpoint", 200);
                cmd1.Parameters.AddWithValue("@Reqrightpoint", 100);
                cmd1.Parameters.AddWithValue("@Reqleftpoint2", 600);
                cmd1.Parameters.AddWithValue("@Reqrightpoint2", 300);
                cmd1.Parameters.AddWithValue("@Reqleftpoint3", 1200);
                cmd1.Parameters.AddWithValue("@Reqrightpoint3", 600);
                cmd1.Parameters.AddWithValue("@Reqleftpoint4", 2400);
                cmd1.Parameters.AddWithValue("@Reqrightpoint4", 1200);
                cmd1.Parameters.AddWithValue("@Reqleftpoint5", 4800);
                cmd1.Parameters.AddWithValue("@Reqrightpoint5", 2400);
                cmd1.Parameters.AddWithValue("@Reqleftpoint6", 12000);
                cmd1.Parameters.AddWithValue("@Reqrightpoint6", 6000);
                cmd1.Parameters.AddWithValue("@Reqleftpoint7", 24000);
                cmd1.Parameters.AddWithValue("@Reqrightpoint7", 12000);
                cmd1.Parameters.AddWithValue("@Reqleftpoint8", 48000);
                cmd1.Parameters.AddWithValue("@Reqrightpoint8", 24000);
                cmd1.Parameters.AddWithValue("@Reqleftpoint9", 96000);
                cmd1.Parameters.AddWithValue("@Reqrightpoint9", 48000);
                cmd1.Parameters.AddWithValue("@Reqleftpoint10", 192000);
                cmd1.Parameters.AddWithValue("@Reqrightpoint10", 96000);
                cmd1.Parameters.AddWithValue("@Reqleftpoint11", 384000);
                cmd1.Parameters.AddWithValue("@Reqrightpoint11", 192000);
                cmd1.Parameters.AddWithValue("@Reqleftpoint12", 768000);
                cmd1.Parameters.AddWithValue("@Reqrightpoint12", 384000);
                cmd1.Parameters.AddWithValue("@Reqleftpoint13", 1536000);
                cmd1.Parameters.AddWithValue("@Reqrightpoint13", 768000);
                cmd1.Parameters.AddWithValue("@Reqleftpoint14", 3072000);
                cmd1.Parameters.AddWithValue("@Reqrightpoint14", 1536000);
                cmd1.Parameters.AddWithValue("@Reqleftpoint15", 6133000);
                cmd1.Parameters.AddWithValue("@Reqrightpoint15", 3072000);
                cmd1.Parameters.AddWithValue("@Reqleftpoint16", 12288000);
                cmd1.Parameters.AddWithValue("@Reqrightpoint16", 6133000);
                cmd1.Parameters.AddWithValue("@Reqleftpoint17", 24276000);
                cmd1.Parameters.AddWithValue("@Reqrightpoint17", 12288000);
                cmd1.Parameters.AddWithValue("@Reqleftpoint18", 49152000);
                cmd1.Parameters.AddWithValue("@Reqrightpoint18", 24276000);

                // Add output parameter for @DisValue
                SqlParameter disValueParam = new SqlParameter("@DisValue", SqlDbType.Float);
                disValueParam.Direction = ParameterDirection.Output;  // Set as output parameter
                cmd1.Parameters.Add(disValueParam);

                con.Open();

                using (SqlDataReader reader = cmd1.ExecuteReader())
                {
                    // Process results for Level 1
                    if (reader.Read())
                    {
                        leftDisValue = Convert.ToDouble(reader["LeftDisValue"]);
                        rightDisValue = Convert.ToDouble(reader["RightDisValue"]);

                        // If the values are negative, set them to zero
                        leftDisValue = leftDisValue < 0 ? 0 : leftDisValue;
                        rightDisValue = rightDisValue < 0 ? 0 : rightDisValue;
                    }

                    //// Process results for Level 2
                    if (reader.NextResult() && reader.Read())
                    {
                        leftDisValue2 = Convert.ToDouble(reader["LeftDisValue2"]);
                        rightDisValue2 = Convert.ToDouble(reader["RightDisValue2"]);

                        // If the values are negative, set them to zero
                        leftDisValue2 = leftDisValue2 < 0 ? 0 : leftDisValue2;
                        rightDisValue2 = rightDisValue2 < 0 ? 0 : rightDisValue2;
                    }

                    //// Process results for Level 3
                    if (reader.NextResult() && reader.Read())
                    {
                        // Retrieve the values from the reader and handle negative values
                        leftDisValue3 = Convert.ToDouble(reader["LeftDisValue3"]);
                        rightDisValue3 = Convert.ToDouble(reader["RightDisValue3"]);

                        // If the values are negative, set them to zero
                        leftDisValue3 = leftDisValue3 < 0 ? 0 : leftDisValue3;
                        rightDisValue3 = rightDisValue3 < 0 ? 0 : rightDisValue3;
                    }

                    //// Process results for Level 3
                    if (reader.NextResult() && reader.Read())
                    {
                        leftDisValue4 = Convert.ToDouble(reader["LeftDisValue4"]);
                        rightDisValue4 = Convert.ToDouble(reader["RightDisValue4"]);

                        // If the values are negative, set them to zero
                        leftDisValue4 = leftDisValue4 < 0 ? 0 : leftDisValue4;
                        rightDisValue4 = rightDisValue4 < 0 ? 0 : rightDisValue4;
                    }

                    ////// Process results for Level 3
                    if (reader.NextResult() && reader.Read())
                    {
                        leftDisValue5 = Convert.ToDouble(reader["LeftDisValue5"]);
                        rightDisValue5 = Convert.ToDouble(reader["RightDisValue5"]);

                        // If the values are negative, set them to zero
                        leftDisValue5 = leftDisValue5 < 0 ? 0 : leftDisValue5;
                        rightDisValue5 = rightDisValue5 < 0 ? 0 : rightDisValue5;

                    }

                    //// Process results for Level 3
                    if (reader.NextResult() && reader.Read())
                    {
                        leftDisValue6 = Convert.ToDouble(reader["LeftDisValue6"]);
                        rightDisValue6 = Convert.ToDouble(reader["RightDisValue6"]);

                        // If the values are negative, set them to zero
                        leftDisValue6 = leftDisValue6 < 0 ? 0 : leftDisValue6;
                        rightDisValue6 = rightDisValue6 < 0 ? 0 : rightDisValue6;
                    }

                    //// Process results for Level 3
                    if (reader.NextResult() && reader.Read())
                    {
                        leftDisValue7 = Convert.ToDouble(reader["LeftDisValue7"]);
                        rightDisValue7 = Convert.ToDouble(reader["RightDisValue7"]);

                        // If the values are negative, set them to zero
                        leftDisValue7 = leftDisValue7 < 0 ? 0 : leftDisValue7;
                        rightDisValue7 = rightDisValue7 < 0 ? 0 : rightDisValue7;
                    }

                    //// Process results for Level 3
                    if (reader.NextResult() && reader.Read())
                    {
                        leftDisValue8 = Convert.ToDouble(reader["LeftDisValue8"]);
                        rightDisValue8 = Convert.ToDouble(reader["RightDisValue8"]);

                        // If the values are negative, set them to zero
                        leftDisValue8 = leftDisValue8 < 0 ? 0 : leftDisValue8;
                        rightDisValue8 = rightDisValue8 < 0 ? 0 : rightDisValue8;
                    }

                    //// Process results for Level 3
                    if (reader.NextResult() && reader.Read())
                    {
                        leftDisValue9 = Convert.ToDouble(reader["LeftDisValue9"]);
                        rightDisValue9 = Convert.ToDouble(reader["RightDisValue9"]);

                        // If the values are negative, set them to zero
                        leftDisValue9 = leftDisValue9 < 0 ? 0 : leftDisValue9;
                        rightDisValue9 = rightDisValue9 < 0 ? 0 : rightDisValue9;
                    }

                    //// Process results for Level 3
                    if (reader.NextResult() && reader.Read())
                    {
                        leftDisValue10 = Convert.ToDouble(reader["LeftDisValue10"]);
                        rightDisValue10 = Convert.ToDouble(reader["RightDisValue10"]);

                        // If the values are negative, set them to zero
                        leftDisValue10 = leftDisValue10 < 0 ? 0 : leftDisValue10;
                        rightDisValue10 = rightDisValue10 < 0 ? 0 : rightDisValue10;
                    }

                    //// Process results for Level 3
                    if (reader.NextResult() && reader.Read())
                    {
                        leftDisValue11 = Convert.ToDouble(reader["LeftDisValue11"]);
                        rightDisValue11 = Convert.ToDouble(reader["RightDisValue11"]);

                        // If the values are negative, set them to zero
                        leftDisValue11 = leftDisValue11 < 0 ? 0 : leftDisValue11;
                        rightDisValue11 = rightDisValue11 < 0 ? 0 : rightDisValue11;
                    }

                    //// Process results for Level 3
                    if (reader.NextResult() && reader.Read())
                    {
                        leftDisValue12 = Convert.ToDouble(reader["LeftDisValue12"]);
                        rightDisValue12 = Convert.ToDouble(reader["RightDisValue12"]);

                        // If the values are negative, set them to zero
                        leftDisValue12 = leftDisValue12 < 0 ? 0 : leftDisValue12;
                        rightDisValue12 = rightDisValue12 < 0 ? 0 : rightDisValue12;
                    }

                    //// Process results for Level 3
                    if (reader.NextResult() && reader.Read())
                    {
                        leftDisValue13 = Convert.ToDouble(reader["LeftDisValue13"]);
                        rightDisValue13 = Convert.ToDouble(reader["RightDisValue13"]);

                        // If the values are negative, set them to zero
                        leftDisValue13 = leftDisValue13 < 0 ? 0 : leftDisValue13;
                        rightDisValue13 = rightDisValue13 < 0 ? 0 : rightDisValue13;
                    }

                    //// Process results for Level 3
                    if (reader.NextResult() && reader.Read())
                    {
                        leftDisValue14 = Convert.ToDouble(reader["LeftDisValue14"]);
                        rightDisValue14 = Convert.ToDouble(reader["RightDisValue14"]);

                        // If the values are negative, set them to zero
                        leftDisValue14 = leftDisValue14 < 0 ? 0 : leftDisValue14;
                        rightDisValue14 = rightDisValue14 < 0 ? 0 : rightDisValue14;
                    }

                    //// Process results for Level 3
                    if (reader.NextResult() && reader.Read())
                    {
                        leftDisValue15 = Convert.ToDouble(reader["LeftDisValue15"]);
                        rightDisValue15 = Convert.ToDouble(reader["RightDisValue15"]);

                        // If the values are negative, set them to zero
                        leftDisValue15 = leftDisValue15 < 0 ? 0 : leftDisValue15;
                        rightDisValue15 = rightDisValue15 < 0 ? 0 : rightDisValue15;
                    }

                    //// Process results for Level 3
                    if (reader.NextResult() && reader.Read())
                    {
                        leftDisValue16 = Convert.ToDouble(reader["LeftDisValue16"]);
                        rightDisValue16 = Convert.ToDouble(reader["RightDisValue16"]);

                        // If the values are negative, set them to zero
                        leftDisValue16 = leftDisValue16 < 0 ? 0 : leftDisValue16;
                        rightDisValue16 = rightDisValue16 < 0 ? 0 : rightDisValue16;
                    }

                    //// Process results for Level 3
                    if (reader.NextResult() && reader.Read())
                    {
                        leftDisValue17 = Convert.ToDouble(reader["LeftDisValue17"]);
                        rightDisValue17 = Convert.ToDouble(reader["RightDisValue17"]);

                        // If the values are negative, set them to zero
                        leftDisValue17 = leftDisValue17 < 0 ? 0 : leftDisValue17;
                        rightDisValue17 = rightDisValue17 < 0 ? 0 : rightDisValue17;
                    }

                    //// Process results for Level 3
                    if (reader.NextResult() && reader.Read())
                    {
                        leftDisValue18 = Convert.ToDouble(reader["LeftDisValue18"]);
                        rightDisValue18 = Convert.ToDouble(reader["RightDisValue18"]);

                        // If the values are negative, set them to zero
                        leftDisValue18 = leftDisValue18 < 0 ? 0 : leftDisValue18;
                        rightDisValue18 = rightDisValue18 < 0 ? 0 : rightDisValue18;
                    }
                }
                // Get the output parameter value @DisValue
             //   double outputDisValue = Convert.ToDouble(cmd1.Parameters["@DisValue"].Value);
                con.Close();
            }

            // Display the output values on the web page
            LeftDisValue.Text = leftDisValue.ToString();
            RightDisValue.Text = rightDisValue.ToString();
            trtSilver.Text = leftDisValue2.ToString();
            Label8.Text = rightDisValue2.ToString();
            Label7.Text = leftDisValue3.ToString();
            Label9.Text = rightDisValue3.ToString();
            Label23.Text = leftDisValue4.ToString();
            Label24.Text = rightDisValue4.ToString();
            Label25.Text = leftDisValue5.ToString();
            Label44.Text = rightDisValue5.ToString();
            Label47.Text = leftDisValue6.ToString();
            Label48.Text = rightDisValue6.ToString();
            Label49.Text = leftDisValue7.ToString();
            Label50.Text = rightDisValue7.ToString();
            Label51.Text = leftDisValue8.ToString();
            Label52.Text = rightDisValue8.ToString();
            Label53.Text = leftDisValue9.ToString();
            Label54.Text = rightDisValue9.ToString();
            Label55.Text = leftDisValue10.ToString();
            Label56.Text = rightDisValue10.ToString();
            Label57.Text = leftDisValue11.ToString();
            Label58.Text = rightDisValue11.ToString();
            Label59.Text = leftDisValue12.ToString();
            Label60.Text = rightDisValue12.ToString();
            Label61.Text = leftDisValue13.ToString();
            Label62.Text = rightDisValue13.ToString();
            Label63.Text = leftDisValue14.ToString();
            Label64.Text = rightDisValue14.ToString();
            Label65.Text = leftDisValue15.ToString();
            Label66.Text = rightDisValue15.ToString();
            Label67.Text = leftDisValue16.ToString();
            Label68.Text = rightDisValue16.ToString();
            Label69.Text = leftDisValue17.ToString();
            Label70.Text = rightDisValue17.ToString();
            Label71.Text = leftDisValue18.ToString();
            Label72.Text = rightDisValue18.ToString();

            ///////////////////////////////////////////////////end mpi/////////////////////////////////////////////

            //=================================================status================================================

            //cmd = new SqlCommand("SELECT MPIleftPV FROM binarypurf WHERE LoginId = @LoginId", con);
            //cmd.Parameters.AddWithValue("@LoginId", loginid);
            //con.Open();
            //object result3 = cmd.ExecuteScalar();
            //con.Close();

            //if (result3 != null && result3 != DBNull.Value)
            //{
            //    int mPIleftPV = Convert.ToInt32(result3);

            //    // Thresholds for RightPoint and corresponding labels
            //    int[] thresholds = { 100, 300, 600, 1200, 2400, 6000, 12000, 24000, 50000, 50000, 50000, 50000, 50000, 50000, 50000, 50000, 50000, 50000 };
            //    Label[] labels = { First_td_Status, Second_td_Status, Third_td_Status, Fourth_td_Status, Fifth_td_Status, Sixth_td_Status, Label10, Label11, Label3, Label13, Label14, Label6, Label16, Label17, Label18, Label19, Label20, Label21 };

            //    // Loop through thresholds and set labels based on the RightPoint value
            //    for (int i = 0; i < thresholds.Length; i++)
            //    {
            //        labels[i].Text = (mPIleftPV > thresholds[i]) ? "Active" : "Inactive";
            //    }
            //}
            //else
            //{
            //    // Assign "No data found" to all labels if result is null or DBNull
            //    Label[] labels = { First_td_Status, Second_td_Status, Third_td_Status, Fourth_td_Status, Fifth_td_Status, Sixth_td_Status, Label10, Label11, Label3, Label13, Label14, Label6, Label16, Label17, Label18, Label19, Label20, Label21 };

            //    foreach (var label in labels)
            //    {
            //        label.Text = "No data found";
            //    }
            //}

            //=================================================end status================================================

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.ToString();
        }
    }

    //protected void bindclubincome()
    //{
    //    cmd = new SqlCommand("select SUM(amount) from tblClubAchiversHistory where PayName='Silver Income' and Loginid='" + loginid + "'", con);
    //    con.Open();
    //    silverincome.Text = Convert.ToString(cmd.ExecuteScalar());
    //    con.Close();

    //    cmd = new SqlCommand("select SUM(amount) from tblClubAchiversHistory where PayName='Gold Income' and Loginid='" + loginid + "'", con);
    //    con.Open();
    //    goldincome.Text = Convert.ToString(cmd.ExecuteScalar());
    //    con.Close();

    //    cmd = new SqlCommand("select SUM(amount) from tblClubAchiversHistory where PayName='Ruby Income' and Loginid='" + loginid + "'", con);
    //    con.Open();
    //    rubyincome.Text = Convert.ToString(cmd.ExecuteScalar());
    //    con.Close();

    //    cmd = new SqlCommand("select SUM(amount) from tblClubAchiversHistory where PayName='Peral Income' and Loginid='" + loginid + "'", con);
    //    con.Open();
    //    peralincome.Text = Convert.ToString(cmd.ExecuteScalar());
    //    con.Close();

    //    cmd = new SqlCommand("select SUM(amount) from tblClubAchiversHistory where PayName='Diamond Income' and Loginid='" + loginid + "'", con);
    //    con.Open();
    //    diamondincome.Text = Convert.ToString(cmd.ExecuteScalar());
    //    con.Close();

    //    cmd = new SqlCommand("select sum(LevelIncome) from LevelIncome_Sponcer where Loginid='" + loginid + "'", con);
    //    con.Open();
    //    levelincome.Text = Convert.ToString(cmd.ExecuteScalar());
    //    con.Close();

    //    cmd = new SqlCommand("select grandtotal from ewallet where Loginid='" + loginid + "'", con);
    //    con.Open();
    //    ewalletincome.Text = Convert.ToString(cmd.ExecuteScalar());
    //    con.Close();


    //    //Club Status
    //   // cmd = new SqlCommand("select count(Loginid) from tblClubAchiversHistory where Loginid='" + loginid + "'", con);
    //    cmd = new SqlCommand("select count(Loginid) from tblsilver where Loginid='" + loginid + "'", con);
    //    con.Open();
    //    int cnt = Convert.ToInt16(cmd.ExecuteScalar());
    //    if (cnt > 0) doj.Text = Label20.Text = "Active"; else doj.Text = Label20.Text = "In-Active"; 
    //    con.Close();


    //}

    protected void bindProduct()
    {
        cmd = new SqlCommand("select productmaster.loginid,productmaster.amount,productmaster.pv,convert(varchar,productmaster.doj,3) as doj,convert(varchar,productmaster.topupdate,3) as topupdate,isnull(productmaster.productname,'---') as productname,isnull(productmaster.curriername,'---') as curriername,convert(varchar,productmaster.cdate,3) as cdate,isnull(productmaster.description,'---') as description,productmaster.status,membermaster.membername from productmaster inner join membermaster on productmaster.loginid=membermaster.loginid and productmaster.loginid='" + loginid + "'", con);
        if (con.State == ConnectionState.Closed) con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(dr);
        dr.Close();

        if (dt.Rows.Count > 0)
        {
            //doj.Text = Convert.ToString(dt.Rows[0]["doj"]);
            //tdate.Text = Convert.ToString(dt.Rows[0]["topupdate"]);
            //amount.Text = Convert.ToString(dt.Rows[0]["amount"]);
            //pv.Text = Convert.ToString(dt.Rows[0]["pv"]);
            //pname.Text = Convert.ToString(dt.Rows[0]["productname"]);
            //cname.Text = Convert.ToString(dt.Rows[0]["curriername"]);
            //cdate.Text = Convert.ToString(dt.Rows[0]["cdate"]);
            //desc.Text = Convert.ToString(dt.Rows[0]["description"]);
            //tstatus.Text = Convert.ToString(dt.Rows[0]["status"]);
            //if (tstatus.Text == "paid") { tstatus.ForeColor = System.Drawing.Color.Green; lblpm.Text = ""; } else if(tstatus.Text=="unpaid") { tstatus.ForeColor = System.Drawing.Color.Red; lblpm.Text = "Product not yet delivered"; }
        }
        else
        {
            // doj.Text = "---";
            // tdate.Text = "---";
            // amount.Text = "---";
            //  pv.Text = "---";
            //pname.Text = "---";
            //cname.Text = "---";
            //cdate.Text = "---";
            //desc.Text = "---";
            //tstatus.Text = "---";
            //tstatus.ForeColor = System.Drawing.Color.Red;
            // lblpm.Text = "";
        }

        //   SqlCommand cmd18 = new SqlCommand("select status from tblsilver  where loginid='" + loginid + "'", con);
        //string strRemark = Convert.ToString(cmd18.ExecuteScalar());
        //if (!string.IsNullOrEmpty(strRemark))
        //    doj.Text = strRemark; //"Active";
        //else doj.Text = "In-Active";


        //   SqlCommand cmd118 = new SqlCommand("select top 1 Remark from tblFiftyBusPlan  where loginid='" + loginid + "' and Remark='Gold'", con);
        //   strRemark = Convert.ToString(cmd118.ExecuteScalar());
        //   if (!string.IsNullOrEmpty(strRemark))
        //       tdate.Text = "Active";
        //   else tdate.Text = "In-Active";

        //   SqlCommand cmd128 = new SqlCommand("select top 1 Remark from tblFiftyBusPlan  where loginid='" + loginid + "' and Remark='Ruby'", con);
        //   strRemark = Convert.ToString(cmd128.ExecuteScalar());
        //   if (!string.IsNullOrEmpty(strRemark))
        //       amount.Text = "Active";
        //   else amount.Text = "In-Active";

        //   SqlCommand cmd138 = new SqlCommand("select top 1 Remark from tblFiftyBusPlan  where loginid='" + loginid + "' and Remark='Pearl'", con);
        //   strRemark = Convert.ToString(cmd138.ExecuteScalar());
        //   if (!string.IsNullOrEmpty(strRemark))
        //       pv.Text = "Active";
        //   else pv.Text = "In-Active";

        //   SqlCommand cmd148 = new SqlCommand("select top 1 Remark from tblFiftyBusPlan  where loginid='" + loginid + "' and Remark='Diamond'", con);
        //   strRemark = Convert.ToString(cmd148.ExecuteScalar());
        //   if (!string.IsNullOrEmpty(strRemark))
        //       pname.Text = "Active";
        //   else pname.Text = "In-Active";

        con.Close();
    }
    //private int GetLeftPointFromDatabase(string logId)
    //{
    //   // int leftpoint = 0;

    //    SqlCommand cmd = new SqlCommand("SELECT LeftPoint FROM binarypurf WHERE LoginId = @LoginId", con);
    //    cmd.Parameters.AddWithValue("@LoginId", logId);
    //    con.Open();
    //    object result = cmd.ExecuteScalar();
    //    if (result != null)
    //    {
    //        leftpoint = Convert.ToInt32(result);
    //    }
    //    return leftpoint;
    //}
    //protected void GetLeftPointFromDatabase()
    //{
    //    string query = "SELECT LeftPoint FROM binarypurf WHERE LoginId = @LoginId";
    //    SqlCommand cmd = new SqlCommand(query, con);
    //    cmd.Parameters.AddWithValue("@LoginId", loginid);
        
    //    try
    //    {
    //        con.Open();
    //        object result = cmd.ExecuteScalar();

    //        if (result != null && result != DBNull.Value)
    //        {
    //            int leftPoint = Convert.ToInt32(result);
    //            int tdValue = 2;

    //            // Check if LeftPoint is -199
    //            if (leftPoint > 2)
    //            {
    //                // Perform actions based on the condition, e.g., show a message or set the value
    //              //  txtBronze.Text = "LeftPoint is -199";
    //                txtBronze.Text = tdValue.ToString();
    //            }
    //            else
    //            {
    //                // Set the text to the actual LeftPoint value
    //                txtBronze.Text = leftPoint.ToString();
    //            } 
    //        }
    //        else
    //        {
    //            // Handle the case when no value is returned or it's null
    //            txtBronze.Text = "No data found";
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        // Handle exceptions
    //        txtBronze.Text = "Error: " + ex.Message;
    //    }
    //    finally
    //    {
    //        con.Close();
    //    }
    //}
}