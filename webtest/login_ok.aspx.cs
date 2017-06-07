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
    public partial class login_ok : BaseClass
    {

        public void show()
        {
            DataSet ds = new DataSet();
            ds = GetList("*", "w_uers", "name='" + Request.QueryString["name"] + "'");
            TextBox1.Text = ds.Tables[0].Rows[0][1].ToString();
            TextBox2.Text = ds.Tables[0].Rows[0][3].ToString();
            TextBox3.Text = ds.Tables[0].Rows[0][4].ToString();
            TextBox4.Text = ds.Tables[0].Rows[0][5].ToString();
            TextBox5.Text = ds.Tables[0].Rows[0][6].ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                show();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("xiugai.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            DataSet ds = new DataSet();
            string msg;
            string sql = "update w_uers set mibao='" + TextBox2.Text + "',daan='"+TextBox3.Text+"',mibao2='"+TextBox4.Text+"',daan2='"+TextBox5.Text+"'   where name='" + TextBox1.Text + "'";
            bool a = ExecuteQuery(sql, out msg);
            if (true == a)
            {
                Label10.Text = "修改成功😀！";
                Label10.Visible = true;
                show();
            }

        }
    }
}