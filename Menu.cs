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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();            
        }

        private void Menu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
          
        private void Start_Click(object sender, EventArgs e)
        {
            bool create = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name.ToString() == "Sokoban")
                {
                    this.Hide();
                    form.Visible = true;
                    create = true;
                    break;
                }
            }
            if (create == false)
            {
                Sokoban s = new Sokoban();
                s.OpenLevel(1);
                this.Hide();
                s.Show();

            }
        }

        private void Editor_Click(object sender, EventArgs e)
        {
            bool create = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name.ToString() == "SokobanEditor")
                {
                    this.Hide();
                    form.Visible = true;
                    create = true;
                    break;
                }
            }
            if (create == false)
            {
                SokobanEditor s = new SokobanEditor();
                this.Hide();
                s.Show();
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ScoreTable_Click(object sender, EventArgs e)
        {
            bool create = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name.ToString() == "ScoreTable")
                {
                    this.Hide();
                    form.Visible = true;
                    create = true;
                    break;
                }
            }
            if (create == false)
            {
                ScoreTable s = new ScoreTable();
                this.Hide();
                s.Show();
            }
        }
    }
}
