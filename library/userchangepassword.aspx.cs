using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userchangepassword : System.Web.UI.Page
{
    static string str = @"server=DESKTOP-DU96QJS;Integrated Security=SSPI;database=ReportServer;";
    static Check us = new Check();
    protected void Page_Load(object sender, EventArgs e)
    {
        ibtn_yzm.ImageUrl = "ImageCode.aspx";
    }

    protected void BtnChangePassword_Click(object sender, EventArgs e)
    {
        string Name = txtUserName.Text;
        string OldPassword = txtOldPassword.Text;
        string NewPassword = txtNewPassword.Text;
        string CheckPassword = txtCheckPassword.Text;
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
        if (count == 0)
            Response.Write("<script>alert('用户名不存在');</script>");
        else
        {
            string password = dt.Rows[0][2].ToString();
            string phone = dt.Rows[0][3].ToString();
            if (OldPassword != password)
                Response.Write("<script>alert('原密码不正确');</script>");
            else if (us.Space(NewPassword) == false)
                Response.Write("<script>alert('新密码不能含有空格');</script>");
            else if (CheckPassword != NewPassword)
                Response.Write("<script>alert('两次输入的密码一样');</script>");
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
                { //update libraryusers set password = N'NewPassword' where username = 'Name'
                    sql = "update libraryusers set password = N'" + NewPassword + "' where username = '" + Name + "'";
                    SqlConnection con = new SqlConnection(str);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('修改成功！');location='libraryhome.aspx'</script>");
                }
            }





        }
    }
    protected void BackHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("libraryhome.aspx");
    }
}