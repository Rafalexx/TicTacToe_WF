using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_TicTacToe
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            UserControl1 first = new UserControl1();
            this.Controls.Add(first);
            UserControl2 second = new UserControl2();
            this.Hide();//because usercontrols have not Close() property as forms
            this.Parent.Controls.Add(second);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            UserControl1 first = new UserControl1();
            this.Controls.Add(first);
            UserControl3 third = new UserControl3();
            this.Hide();//because usercontrols have not Close() property as forms
            this.Parent.Controls.Add(third);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            UserControl1 first = new UserControl1();
            this.Controls.Add(first);
            UserControl4 fourth = new UserControl4();
            this.Hide();//because usercontrols have not Close() property as forms
            this.Parent.Controls.Add(fourth);
        }
    }
}
