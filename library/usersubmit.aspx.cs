using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usersubmit : System.Web.UI.Page
{
    static string str = @"server=DESKTOP-DU96QJS;Integrated Security=SSPI;database=ReportServer;";
    static Check us = new Check();
    protected void Page_Load(object sender, EventArgs e)
    {
        ibtn_yzm.ImageUrl = "ImageCode.aspx";
    }

    protected void BtnUserSubmit_Click(object sender, EventArgs e)
    {
        string UserName = txtUserName.Text;
        string UserPassword = txtUserPassword.Text;
        string CheckPassword = txtCheckPassword.Text;
        string UserPhone = txtPhone.Text;
        int Flag = us.SubmitCheckUser(UserName, UserPassword, CheckPassword, UserPhone);
        if (Flag == 1)
            Response.Write("<script>alert('请不要输入空字符');</script>");
        if (Flag == 2)
            Response.Write("<script>alert('请输入5-11位的用户名');</script>");
        if (Flag == 3)
            Response.Write("<script>alert('请输入5-11位的密码');</script>");
        if (Flag == 4)
            Response.Write("<script>alert('两次密码不匹配');</script>");
        if (Flag == 5)
            Response.Write("<script>alert('请输入正确的电话号码');</script>");
        if (Flag == 6)
        {
            //select * from libraryusers where username = N'"Name"'
            string sql = "select * from libraryusers where username = N'" + UserName + "'";
            SqlConnection conn = new SqlConnection(str);
            System.Data.DataTable dt = new DataTable();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            conn.Close();
            int count = dt.Rows.Count;
            if (count == 0)
            {
                string code = tbx_yzm.Text;
                HttpCookie htco = Request.Cookies["ImageV"];
                string scode = htco.Value.ToString();
                if (code != scode)
                    Response.Write("<script>alert('验证码输入不正确！')</script>");
                else
                {  
                //insert into libraryusers values(N'UserName','UserPassword','UserPhone')
                sql = "insert into libraryusers values(N'" + UserName + "', '" + UserPassword + "','" + UserPhone + "')";
                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('注册成功');location='libraryhome.aspx'</script>");
                }
            }
            else
                Response.Write("<script>alert('用户名已存在')</script>");
        }
           
    }
    protected void BackHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("libraryhome.aspx");
    }
}