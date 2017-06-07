using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebService;

namespace webtest
{
    public partial class login : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           if( "" != TextBox1.Text && "" != TextBox2.Text)
            {

            }else
            {
                Label3.Visible = true;
                return;
            }
            DataSet ds = new DataSet();
            ds= GetList("*", "w_uers", "name='" + TextBox1.Text + "'and passw='"+TextBox2.Text+"'");
            if (null != ds){
                //登陆正确
                if(0 !=ds.Tables[0].Rows.Count)
                Response.Redirect("login_ok.aspx?name="+TextBox1.Text+"");

            }else
            {
                Label3.Visible = true;
                Label3.Text = "用户信息不符！";
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("zc.aspx");
        }
    }
}