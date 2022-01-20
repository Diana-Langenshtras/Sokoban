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
    public partial class ScoreTable : Form
    {
        string path;
        string[] lines;
        public ScoreTable()
        {
            InitializeComponent();
            TableEditor();
        }

        private void TableEditor()
        {
            Label[] bt; 
            int curr = 1; int i = 0;
            path = "scoretable.txt";
            lines = File.ReadAllLines(path);
            int[] count = new int[lines.Length/2];
            while (curr < lines.Length) //пока не дошли до конца массива
            {
                    int buff;
                    int.TryParse(lines[curr], out buff);
                    count[i] = buff;
                    curr += 2;
                    i++;
            }
            curr = 1;
            if (count.Length>5)  bt = new Label[5];
            else bt = new Label[count.Length];
            Array.Sort(count);
            for (i=0; i<bt.Length;)
            {
                while (curr < lines.Length) //пока не дошли до конца массива
                {
                    int buff;
                    int.TryParse(lines[curr], out buff);
                    if (buff==count[count.Length-1-i])
                    {
                        bt[i] = new Label();
                        bt[i].AutoSize = true;
                        bt[i].Font = new System.Drawing.Font("Segoe Script", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        bt[i].Location = new System.Drawing.Point(26, 28+70*(i));
                        bt[i].Tag = i;
                        bt[i].Size = new System.Drawing.Size(600, 44);
                        bt[i].TabIndex = 0;
                        bt[i].Text = (i+1).ToString() + "." + lines[curr - 1] + " - " + "пройденных уровней - " + buff.ToString();
                        panel.Controls.Add(bt[i]);
                        i++;
                        if (i >= bt.Length) break;
                       // break;
                       /////////////////////
                    }
                    curr += 2;
                }
                curr = 1;
            }
            
        }

        private void Menu_Click(object sender, EventArgs e)
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
}
