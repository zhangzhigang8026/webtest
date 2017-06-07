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
    public partial class xiugai : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ("" != TextBox1.Text && "" != TextBox2.Text && "" != TextBox3.Text && "" != TextBox4.Text && "" != TextBox5.Text)
            {
                if (TextBox3.Text == TextBox4.Text)//判断密码一致
                {
                    //输入合法 
                    DataSet ds = new DataSet();
                    string qw = DropDownList1.SelectedValue;

                    if ("1" == qw)
                    {
                        ds = GetList("*", "w_uers", "name='" + TextBox1.Text + "'and passw='" + TextBox2.Text + "'and daan='" + TextBox5.Text + "'");
                    }
                    else
                    {
                        ds = GetList("*", "w_uers", "name='" + TextBox1.Text + "'and passw='" + TextBox2.Text + "'and daan2='" + TextBox5.Text + "'");
                    }
                    if (null != ds)
                    {
                        //访问数据库成功
                        if (0 != ds.Tables[0].Rows.Count)
                        {
                            //查到数据
                              //向数据库写入
                        string msg;
                        string sql = "update w_uers set passw='"+TextBox3.Text+"' where name='"+TextBox1.Text+"'";
                        bool a = ExecuteQuery(sql, out msg);
                        if (true == a)
                        {
                            Label1.Text = "修改成功😀！";
                            Label1.Visible = true;
                                return;
                            }

                        }
                        if (0 == ds.Tables[0].Rows.Count)
                            {
                                Label1.Text = "修改失败😀！";
                                Label1.Visible = true;
                                return;
                            }
                    }
                    else//密码不一致
                    {
                        Label1.Visible = true;
                        Label1.Text = "密码两次输入不同！";
                        return;
                    }

                }
                else//信息不全
                {
                    Label1.Visible = true;
                    return;
                }

            }
        }
    }
}