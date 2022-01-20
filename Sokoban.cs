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
    public delegate void deShowItem(Place place, Cell item);
    public delegate void deShowStat(int placed, int totals);
    public partial class Sokoban : Form
    {
        int count_level;
        int level_nr;
        int last_level_nr;
        int width, height;
        PictureBox[,] box;
        Game game;
        ScoreFile scoreFile;

        public Sokoban()
        {
            InitializeComponent();
            scoreFile = new ScoreFile("scoretable.txt");
            count_level = scoreFile.RewriteFile()-1;
            last_level_nr = count_level+1;
            game = new Game(ShowItem, ShowStat);
        }
        public void OpenLevel (int level_nr)
        {
            if (level_nr > last_level_nr) return;
            this.level_nr = level_nr;
            if (!game.Init(level_nr, out width, out height))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                return;
            }
            InitPictures();
            game.ShowLevel();
        }
        public void InitPictures()
        {
                box = new PictureBox[width, height];            
                int bw, bh;
                bw = panel1.Width / width;
                bh = panel1.Height / height;
                if (bw < bh) bh = bw; //чтобы ячейки были квадратные
                else bw = bh;
                panel1.Controls.Clear();
                for (int x = 0; x < width; x++)
                    for (int y = 0; y < height; y++)
                    {
                        PictureBox picture = new PictureBox();
                        picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        picture.Location = new System.Drawing.Point(x * (bw - 1), y * (bh - 1)); //-1 чтобы границы не накладывались друг на друга
                        picture.Size = new System.Drawing.Size(bw, bh);
                        picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        picture.Tag = new Place(x, y); //координаты каждой ячейки
                        panel1.Controls.Add(picture);
                        box[x, y] = picture;
                    }            
        }

        private void toolMenu_Click(object sender, EventArgs e)
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
        public void ShowItem(Place place, Cell item)
        {
            box[place.x, place.y].Image = Images.CellToPicture(item);
        }
        public void ShowStat(int placed, int totals)
        {
            toolStat.Text = placed.ToString() + " из " + totals.ToString();
            toolLevel.Text = level_nr.ToString();
            toolDone.Visible = placed == totals;
            if (placed == totals)
                if (level_nr == last_level_nr)
                {
                    last_level_nr++;
                    count_level++;
                    scoreFile.RewriteFile(count_level);
                }
        }

        private void toolPrev_Click(object sender, EventArgs e)
        {
            if (level_nr > 1)
                OpenLevel(level_nr - 1);
        }

        private void toolNext_Click(object sender, EventArgs e)
        {
                OpenLevel(level_nr + 1);
        }

        private void Sokoban_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left: game.Step(-1, 0); break;
                case Keys.Right: game.Step(1, 0); break;
                case Keys.Down: game.Step(0, 1); break;
                case Keys.Up: game.Step(0, -1); break;
            }
        }

        private void toolRestart_Click(object sender, EventArgs e)
        {
            game.Init(level_nr, out width, out height);
            game.ShowLevel();
        }

        private void Sokoban_Resize(object sender, EventArgs e)
        { 
            int bw = 0, bh = 0;
            if (width != 0)  bw = panel1.Width / width;
            if (height != 0)  bh = panel1.Height / height;
            if (bw < bh) bh = bw; //чтобы ячейки были квадратные
            else bw = bh;
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    box[x,y].Location = new System.Drawing.Point(x * (bw - 1), y * (bh - 1)); //-1 чтобы границы не накладывались друг на друга
                    box[x,y].Size = new System.Drawing.Size(bw, bh);
                }
        }

      /*  public Image CellToPicture(Cell c)
        {
            switch (c)
            {
                case Cell.none: return Properties.Resources.none;
                case Cell.wall: return Properties.Resources.wall;
                case Cell.abox: return Properties.Resources.abox;
                case Cell.here: return Properties.Resources.here;
                case Cell.done: return Properties.Resources.done;
                case Cell.user: return Properties.Resources.user1;
                default: return Properties.Resources.none;
            }
        }*/

    }
}
