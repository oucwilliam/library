using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userfindpassword : System.Web.UI.Page
{
    static string str = @"server=DESKTOP-DU96QJS;Integrated Security=SSPI;database=ReportServer;";
    protected void Page_Load(object sender, EventArgs e)
    {
        ibtn_yzm.ImageUrl = "ImageCode.aspx";
    }

    protected void BtnFindPassword_Click(object sender, EventArgs e)
    {
        string Name = txtUserName.Text;
        string Phone = txtPhone.Text;
        //select * from libraryusers where username = N'"Name"'
        string sql = "select * from libraryusers where username = N'" + Name + "'";
        SqlConnection conn = new SqlConnection(str);
        System.Data.DataTable dt = new DataTable();
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.Fill(dt);
        conn.Close();
        int count = dt.Rows.Count;
        string password = dt.Rows[0][2].ToString();
        string phone = dt.Rows[0][3].ToString();
        if (count == 0)
            Response.Write("<script>alert('用户名不存在');</script>");
        else if (Phone != phone)
            Response.Write("<script>alert('绑定的手机号不正确');</script>");
        else
        {
            string code = tbx_yzm.Text;
            HttpCookie htco = Request.Cookies["ImageV"];
            string scode = htco.Value.ToString();
            if (code != scode)
                Response.Write("<script>alert('验证码输入不正确！')</script>");
            else
                Response.Write("<script>alert('您的密码是：" + password + "');location='libraryhome.aspx'</script>");
        }
    }

    protected void BackHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("libraryhome.aspx");
    }
}