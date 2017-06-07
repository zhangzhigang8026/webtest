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
    public partial class zc : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ("" != TextBox1.Text && "" != TextBox2.Text && "" != TextBox3.Text)
            {
                if (TextBox2.Text == TextBox3.Text)//判断密码一致
                {
                    //输入合法
                    DataSet ds = new DataSet();
                    ds = GetList("*", "w_uers", "name='" + TextBox1.Text + "'");
                    if (null != ds)
                    {
                        //访问数据库成功
                        if (0 != ds.Tables[0].Rows.Count)
                        {
                            Label3.Text = "用户名已存在";
                            Label3.Visible = true;
                            return;
                        }
                           

                        //向数据库写入
                        string msg;
                        string sql = "INSERT INTO w_uers (name, passw,mibao,daan,mibao2,daan2)VALUES('" + TextBox1.Text + "', '" + TextBox2.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "')";
                        bool a = ExecuteQuery(sql, out msg);
                        if (true == a)
                        {
                            Label3.Text = "注册成功！";
                            Label3.Visible = true;
                        }
                    }
                    else//密码不一致
                    {
                        Label3.Visible = true;
                        Label3.Text = "密码两次输入不同！";
                        return;
                    }

                }
                else//信息不全
                {
                    Label3.Visible = true;
                    return;
                }

            }
        }
    }
}