using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userlogin : System.Web.UI.Page
{
    static string str = @"server=DESKTOP-DU96QJS;Integrated Security=SSPI;database=ReportServer;";
    protected void Page_Load(object sender, EventArgs e)
    {
        ibtn_yzm.ImageUrl = "ImageCode.aspx";
    }

    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        string UserName = txtUserName.Text;
        string UserPassword = txtUserPassword.Text;
        string UserPhone = txtPhone.Text;
        //select * from libraryusers where username = N'UserName' and password = 'UserPassword' and phone = 'UserPhone'
        string sql = "select * from libraryusers where username = N'" + UserName + "'and password = '" + UserPassword + "'and phone ='" + UserPhone + "'";
        SqlConnection conn = new SqlConnection(str);
        System.Data.DataTable dt = new DataTable();
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.Fill(dt);
        conn.Close();
        int count = dt.Rows.Count;
        if (count == 0)
            Response.Write("<script>alert('用户名或密码或手机号错误！');</script>");
        else
        {
            string code = tbx_yzm.Text;
            HttpCookie htco = Request.Cookies["ImageV"];
            string scode = htco.Value.ToString();
            if (code != scode)
                Response.Write("<script>alert('验证码输入不正确！')</script>");
            else
                Response.Write("<script>alert('登录成功');</script>");
        }
            
    }
    protected void BackHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("libraryhome.aspx");
    }
}