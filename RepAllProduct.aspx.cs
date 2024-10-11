using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Agent_RepAllProduct : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    string logId;
    int rv, mrp, qty, rno;
    int totrv, totmrp, totqty;
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter adpt = new SqlDataAdapter();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["ALog"].Value == null)
        {
            lblmsg.Text = "Session Expired.Please Login Again ...";
        }
        else
        {
            logId = Request.Cookies["ALog"].Value;
            //logId = Session["user_id"].ToString();
            bindProduct();
            bindDetail();

        }
    }
    protected void bindDetail()
    {
        int pqty = 0, prv = 0, pmrp = 0;
        string pcode;
        cmd = new SqlCommand("select count(*) as cnt,isnull(sum(TotalRV),0) as TotalRV,isnull(sum(TotalMRP),0) as TotalMRP from repurchase_master2 where loginid='" + logId + "' and status='unpaid'", con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DataTable dts = new DataTable();
        dts.Load(dr);
        dr.Close();
        con.Close();
        if (dts.Rows.Count > 0)
        {
            //lblAmt.Text = Convert.ToString(dts.Rows[0]["TotalMRP"]);
            //lblPv.Text = Convert.ToString(dts.Rows[0]["TotalRV"]);
            lblCart.Text = Convert.ToString(dts.Rows[0]["cnt"]);
        }
        else
        {
            //lblAmt.Text = "0";
            //lblPv.Text = "0";
            lblCart.Text = "0";
        }


        cmd = new SqlCommand("select productcode,isnull(qty,0) as qty from repurchase_master2  where loginid='" + logId + "' and status='unpaid'", con);
        con.Open();
        dr = cmd.ExecuteReader();
        DataTable dts1 = new DataTable();
        dts1.Load(dr);
        dr.Close();
        con.Close();
        try
        {
            if (dts1.Rows.Count > 0)
            {
                for (int i = 0; i < dts1.Rows.Count; i++)
                {
                    pqty = 0; rv = 0; mrp = 0;

                    pqty = Convert.ToInt32(dts1.Rows[i]["qty"]);
                    pcode = Convert.ToString(dts1.Rows[i]["productcode"]);

                    adpt = new SqlDataAdapter("select isnull(productrv,0) as productrv,isnull(offerprice,0) as offerprice from product where productcode='" + pcode + "'", con);
                    adpt.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        rv = Convert.ToInt32(ds.Tables[0].Rows[i]["productrv"]);
                        mrp = Convert.ToInt32(ds.Tables[0].Rows[i]["offerprice"]);
                    }

                    prv = prv + (rv * pqty);
                    pmrp = pmrp + (mrp * pqty);
                }
                lblAmt.Text = Convert.ToString(pmrp);
                lblPv.Text = Convert.ToString(prv);
            }
            else
            {
                lblAmt.Text = "0";
                lblPv.Text = "0";
            }
        }
        catch (Exception)
        {
            Response.Write("<script language='java script'>alert ('No further processing possible(Please contact your system administrator)')</script>");
        }

    }
    public void bindProduct()
    {
        SqlDataAdapter adptre = new SqlDataAdapter("select * from Product order by Id desc ", con);
        //SqlDataAdapter adptre = new SqlDataAdapter("select Product.*,isnull(repurchase_master2.qty,0) as qtys from Product left outer join repurchase_master2 on product.ProductCode=repurchase_master2.ProductCode and repurchase_master2.Loginid='" + logId + "' and repurchase_master2.status='unpaid'", con);
        DataSet dsre = new DataSet();
        adptre.Fill(dsre);
        if (dsre.Tables[0].Rows.Count > 0)
        {
            lblJoin.Text = "";
            dlAds.DataSource = dsre.Tables[0];
            dlAds.DataBind();
        }
        else
        {
            lblJoin.Text = "Repurchase products Not Available";
        }
    }
    protected string GetImageUrl1(object imagePath)
    {
        if (imagePath != null && !string.IsNullOrEmpty(imagePath.ToString()))
        {
            string fullImagePath = imagePath.ToString();
            if (System.IO.File.Exists(Server.MapPath(fullImagePath)))
            {
                return ResolveUrl(fullImagePath);
            }
        }
        return ResolveUrl("~/Images/Receipts/default.png");
    }

    protected void lnkJoin_Click(object sender, EventArgs e)
    {
        var btn = ((LinkButton)sender).CommandArgument;
        Response.Redirect("~/Agent/pagenews.aspx?code=" + btn);

    }
    protected void lnkAddToCart_Click(object sender, EventArgs e)
    {
        var btn = ((LinkButton)sender).CommandArgument;
        //Response.Redirect("~/Agent/Cart.aspx?code=" + btn);
        rv = mrp = totmrp = totrv = totqty = 0;

        //var btn = ((ImageButton)sender).CommandArgument;
        cmd = new SqlCommand("select isnull(quantity,0) as quantity from product where productcode='" + btn + "'", con);
        con.Open();
        int pcnt = Convert.ToInt32(cmd.ExecuteScalar());
        con.Close();
        if (pcnt > 0)
        {
            adpt = new SqlDataAdapter("select isnull(productrv,0) as productrv,isnull(offerprice,0) as offerprice from product where productcode='" + btn + "'", con);
            adpt.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rv = Convert.ToInt32(ds.Tables[0].Rows[0]["productrv"]);
                mrp = Convert.ToInt32(ds.Tables[0].Rows[0]["offerprice"]);
            }

            cmd = new SqlCommand("select count(*) from repurchase_master2 where loginid='" + logId + "' and status='unpaid' and productcode='" + btn + "'", con);
            con.Open();
            int cnt = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            if (cnt > 0)
            {
                cmd = new SqlCommand("select * from repurchase_master2 where loginid='" + logId + "' and status='unpaid' and productcode='" + btn + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    //totrv = Convert.ToInt32(dt.Rows[0]["TotalRV"]);
                    //totmrp= Convert.ToInt32(dt.Rows[0]["TotalMRP"]);
                    totqty = Convert.ToInt32(dt.Rows[0]["Qty"]);

                    totrv = (totqty * rv) + rv;
                    totmrp = (totqty * mrp) + mrp;
                    totqty = totqty + 1;

                    cmd = new SqlCommand("update repurchase_master2 set qty=@qty where loginid=@loginid and productcode=@productcode", con);
                    cmd.Parameters.AddWithValue("@loginid", logId);
                    cmd.Parameters.AddWithValue("@productcode", btn);
                    cmd.Parameters.AddWithValue("@qty", totqty);
                    //cmd.Parameters.AddWithValue("@TotalRV", totrv);
                    //cmd.Parameters.AddWithValue("@TotalMRP", totmrp);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            else
            {
                qty = 1;
                cmd = new SqlCommand("insert into repurchase_master2(loginid,productcode,qty,status)values(@loginid,@productcode,@qty,@status)", con);
                cmd.Parameters.AddWithValue("@loginid", logId);
                cmd.Parameters.AddWithValue("@productcode", btn);
                cmd.Parameters.AddWithValue("@qty", qty);
                //cmd.Parameters.AddWithValue("@TotalRV", rv);
                //cmd.Parameters.AddWithValue("@TotalMRP", mrp);
                cmd.Parameters.AddWithValue("@status", "unpaid");
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            cmd = new SqlCommand("update product set quantity=quantity-1 where productcode='" + btn + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            bindProduct();
            bindDetail();
        }
        else
        {
            Response.Write("<script>alert('Insufficient Stock');</script>");
        }
    }
    protected void lnkPlus_Click(object sender, EventArgs e)
    {
        //rv = mrp = totmrp = totrv = totqty = 0;

        //var btn = ((ImageButton)sender).CommandArgument;
        //cmd = new SqlCommand("select isnull(quantity,0) as quantity from product where productcode='" + btn + "'",con);
        //con.Open();
        //int pcnt = Convert.ToInt32(cmd.ExecuteScalar());
        //con.Close();
        //if (pcnt > 0)
        //{
        //    adpt = new SqlDataAdapter("select isnull(productrv,0) as productrv,isnull(offerprice,0) as offerprice from product where productcode='" + btn + "'", con);
        //    adpt.Fill(ds);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        rv = Convert.ToInt32(ds.Tables[0].Rows[0]["productrv"]);
        //        mrp = Convert.ToInt32(ds.Tables[0].Rows[0]["offerprice"]);
        //    }

        //    cmd = new SqlCommand("select count(*) from repurchase_master2 where loginid='" + logId + "' and status='unpaid' and productcode='" + btn + "'", con);
        //    con.Open();
        //    int cnt = Convert.ToInt32(cmd.ExecuteScalar());
        //    con.Close();
        //    if (cnt > 0)
        //    {
        //        cmd = new SqlCommand("select * from repurchase_master2 where loginid='" + logId + "' and status='unpaid' and productcode='" + btn + "'",con);
        //        con.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        DataTable dt = new DataTable();
        //        dt.Load(dr);
        //        dr.Close();
        //        con.Close();
        //        if (dt.Rows.Count > 0)
        //        {
        //            //totrv = Convert.ToInt32(dt.Rows[0]["TotalRV"]);
        //            //totmrp= Convert.ToInt32(dt.Rows[0]["TotalMRP"]);
        //            totqty= Convert.ToInt32(dt.Rows[0]["Qty"]);

        //            totrv = (totqty * rv) + rv;
        //            totmrp = (totqty * mrp) + mrp;
        //            totqty = totqty + 1;

        //            cmd = new SqlCommand("update repurchase_master2 set qty=@qty where loginid=@loginid and productcode=@productcode",con);
        //            cmd.Parameters.AddWithValue("@loginid", logId);
        //            cmd.Parameters.AddWithValue("@productcode", btn);
        //            cmd.Parameters.AddWithValue("@qty", totqty);
        //            //cmd.Parameters.AddWithValue("@TotalRV", totrv);
        //            //cmd.Parameters.AddWithValue("@TotalMRP", totmrp);
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //    }
        //    else
        //    {
        //        qty = 1;
        //        cmd = new SqlCommand("insert into repurchase_master2(loginid,productcode,qty,status)values(@loginid,@productcode,@qty,@status)", con);
        //        cmd.Parameters.AddWithValue("@loginid",logId);
        //        cmd.Parameters.AddWithValue("@productcode", btn);
        //        cmd.Parameters.AddWithValue("@qty", qty);
        //        //cmd.Parameters.AddWithValue("@TotalRV", rv);
        //        //cmd.Parameters.AddWithValue("@TotalMRP", mrp);
        //        cmd.Parameters.AddWithValue("@status", "unpaid");
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        //    cmd = new SqlCommand("update product set quantity=quantity-1 where productcode='" + btn + "'",con);
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    bindProduct();
        //    bindDetail();
        //}
        //else
        //{
        //    Response.Write("<script>alert('Insufficient Stock');</script>");
        //}
    }
    protected void lnkMinus_Click(object sender, EventArgs e)
    {
        var btn = ((ImageButton)sender).CommandArgument;
        rv = mrp = totmrp = totrv = totqty = 0;

        cmd = new SqlCommand("select isnull(qty,0) as qty from repurchase_master2 where loginid='" + logId + "' and status='unpaid' and productcode='" + btn + "'", con);
        con.Open();
        int qty = Convert.ToInt32(cmd.ExecuteScalar());
        con.Close();
        if (qty > 0)
        {
            adpt = new SqlDataAdapter("select isnull(productrv,0) as productrv,isnull(offerprice,0) as offerprice from product where productcode='" + btn + "'", con);
            adpt.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rv = Convert.ToInt32(ds.Tables[0].Rows[0]["productrv"]);
                mrp = Convert.ToInt32(ds.Tables[0].Rows[0]["offerprice"]);
            }

            cmd = new SqlCommand("select * from repurchase_master2 where loginid='" + logId + "' and status='unpaid' and productcode='" + btn + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            con.Close();
            if (dt.Rows.Count > 0)
            {
                //totrv = Convert.ToInt32(dt.Rows[0]["TotalRV"]);
                //totmrp = Convert.ToInt32(dt.Rows[0]["TotalMRP"]);
                totqty = Convert.ToInt32(dt.Rows[0]["Qty"]);

                //totrv = (totqty * rv)- rv;
                //totmrp = (totqty * mrp)-mrp;
                totqty = totqty - 1;

                if (totqty > 0)
                {
                    cmd = new SqlCommand("update repurchase_master2 set qty=@qty where loginid=@loginid and productcode=@productcode and status='unpaid'", con);
                    cmd.Parameters.AddWithValue("@loginid", logId);
                    cmd.Parameters.AddWithValue("@productcode", btn);
                    cmd.Parameters.AddWithValue("@qty", totqty);
                    //cmd.Parameters.AddWithValue("@TotalRV", totrv);
                    cmd.Parameters.AddWithValue("@TotalMRP", totmrp);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    cmd = new SqlCommand("delete from repurchase_master2 where loginid=@loginid and productcode=@productcode and status='unpaid'", con);
                    cmd.Parameters.AddWithValue("@loginid", logId);
                    cmd.Parameters.AddWithValue("@productcode", btn);
                    cmd.Parameters.AddWithValue("@qty", totqty);
                    cmd.Parameters.AddWithValue("@TotalRV", totrv);
                    cmd.Parameters.AddWithValue("@TotalMRP", totmrp);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                cmd = new SqlCommand("update product set quantity=quantity+1 where  productcode=@productcode", con);
                cmd.Parameters.AddWithValue("@productcode", btn);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                bindProduct();
                bindDetail();
            }


        }
        else
        {

        }
    }

    protected void Image1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("RepCart.aspx", false);
    }
}


