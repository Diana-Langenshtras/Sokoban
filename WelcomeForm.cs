using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach
{
    public partial class WelcomeForm : Form
    {
        ScoreFile scorefname;
        string lines;
        public WelcomeForm()
        {
            InitializeComponent();
            scorefname = new ScoreFile("scoretable.txt");
        }

        private void WelcomeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
            if (UserName.Text != "" && e.KeyCode==Keys.Enter)
            {
                bool create = false;

                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name.ToString() == "Menu")
                    {
                        this.Hide();
                        form.Visible = true;
                        create = true;
                        break;
                    }
                }
                if (create == false)
                {
                    Menu s = new Menu();
                    this.Hide();
                    s.Show();
                }
            }
        }

        private void UserName_TextChanged(object sender, EventArgs e)
        {
               lines = UserName.Text;
        }

        private void UserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && UserName.Text != "")
            {
                ScoreFile.user_name = lines;
                scorefname.RewriteFile(0, lines);
            }
        }
    }
}
