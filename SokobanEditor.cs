using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach
{
    public partial class SokobanEditor : Form
    {       
        PictureBox[,] box;
        Cell[,] cell;
        int width, height;
        Cell CurrentCell = Cell.none;
        LevelFile level;
        int CurrentLevel = 1;

        static int MinWidth = 5;
        static int MaxWidth = 40;
        static int MinHeight = 5;
        static int MaxHeight = 40;

        public SokobanEditor()
        {
            InitializeComponent();
        }

        private void SokobanEditor_Load(object sender, EventArgs e)
        {
            level = new LevelFile("levels.txt");
            CurrentLevel = 1;
            LoadLevel();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x, y;
            x = ((Point)((PictureBox)sender).Tag).X;
            y = ((Point)((PictureBox)sender).Tag).Y;
            if (e.Button == MouseButtons.Left)
            {
                ShowCell(x, y, CurrentCell);
            }
            if (e.Button == MouseButtons.Right)
            {
                ShowCell(x, y, Cell.none);
            }
        }
        private void ShowCell (int x, int y, Cell c) //размещает картинку в ячейке
        {
            if (c == Cell.user) //проверка, чтобы человечек был только один
            {
                for (int xx = 0; xx < width; xx++)
                    for (int yy = 0; yy < height; yy++)
                    {
                        if (cell[xx, yy] == Cell.user)
                            ShowCell(xx, yy, Cell.none);
                    }
            }
            cell[x, y] = c;
            box[x, y].Image = CellToPicture(c);
        }
        public void InitPictures() //создает массив из картинок
        {
            int bw, bh;
            bw = panel1.Width / width; 
            bh = panel1.Height / height;
            if (bw < bh) bh = bw; //чтобы ячейки были квадратные
            else bw = bh;
            box = new PictureBox[width, height];
            for (int x=0; x<width; x++)
                for (int y=0; y<height; y++)
                {
                    PictureBox picture = new PictureBox();
                    picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    picture.Location = new System.Drawing.Point(x*(bw-1), y*(bh-1)); //-1 чтобы границы не накладывались друг на друга
                    picture.Size = new System.Drawing.Size(bw, bh);
                    picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    picture.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
                    picture.Tag = new Point(x, y); //координаты каждой ячейки
                    panel1.Controls.Add(picture);
                    box[x, y] = picture;                   
                }
        }
        public void LoadPictures() //в массив картинок добавляет нужные картинки
        {
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    box[x, y].Image = CellToPicture(cell[x, y]);
                }
        }

        private void SokobanEditor_Resize(object sender, EventArgs e)
        {
            int bw=0, bh=0;
           if (width!=0) bw = panel1.Width / width;
           if (height!=0) bh = panel1.Height / height;
            if (bw < bh) bh = bw; //чтобы ячейки были квадратные
            else bw = bh;
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    box[x, y].Size = new System.Drawing.Size(bw, bh);
                    box[x, y].Location = new System.Drawing.Point(x * (bw - 1), y * (bh - 1));
                }
        }
        private void SetCurrentCell(Cell SelectedCell)
        {
            CurrentCell = SelectedCell;
            toolAbox.Checked = CurrentCell == Cell.abox;
            toolWall.Checked = CurrentCell == Cell.wall;
            toolNone.Checked = CurrentCell == Cell.none;
            toolDone.Checked = CurrentCell == Cell.done;
            toolHere.Checked = CurrentCell == Cell.here;
            toolUser.Checked = CurrentCell == Cell.user;
        }
        private void toolWall_Click(object sender, EventArgs e)
        {
            SetCurrentCell(Cell.wall);
        }

        private void toolAbox_Click(object sender, EventArgs e)
        {
            SetCurrentCell(Cell.abox);
        }

        private void toolHere_Click(object sender, EventArgs e)
        {
            SetCurrentCell(Cell.here);
        }

        private void toolDone_Click(object sender, EventArgs e)
        {
            SetCurrentCell(Cell.done);
        }

        private void toolNone_Click(object sender, EventArgs e)
        {
            SetCurrentCell(Cell.none);
        }

        private void toolUser_Click(object sender, EventArgs e)
        {
            SetCurrentCell(Cell.user);
        }
        private void ToolResizeAddRow_Click(object sender, EventArgs e)
        {
            ResizeLevel(width, height + 1);
        }

        private void ToolResizeDelRow_Click(object sender, EventArgs e)
        {
            ResizeLevel(width, height - 1);
        }

        private void ToolResizeAddCol_Click(object sender, EventArgs e)
        {
            ResizeLevel(width + 1, height);
        }

        private void ToolResizeDelCol_Click(object sender, EventArgs e)
        {
            ResizeLevel(width - 1, height);
        }
        private void ResizeLevel(int w, int h)
        {
            if (w < MinWidth || w > MaxWidth || h < MinHeight || h > MaxHeight) return;
            Cell[,] NewCell = new Cell[w, h];
            for (int x = 0; x < Math.Min(w, width); x++)
                for (int y = 0; y < Math.Min(h, height); y++)
                    NewCell[x, y] = cell[x, y];               
            width = w; 
            height = h;
            panel1.Controls.Clear(); 
            cell = NewCell;
            InitPictures();
            LoadPictures();
        }
        
        private string IsGoodLevel()
        {
            int users = CountItems(Cell.user);
            if (users == 0) return "Нужно указать начальное место для игрока";
            if (users > 1) return "Нужно указать только одного игрока";
            int aboxes = CountItems(Cell.abox);
            int heres = CountItems(Cell.here);
            if (aboxes == 0) return "Нужно поставить хотя бы один ящик";
            if (aboxes != heres) return "Количество ящиков должно соответсвовать количеству мест для них";
            return "";
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            SaveLevel();
        }
        private void SaveLevel()
        {
            string error = IsGoodLevel();
            if (error != "")
            {
                MessageBox.Show(error, "Ошибка!");
                return;
            }
            level.SaveLevel(CurrentLevel, cell);
        }

        private void toolPrev_Click(object sender, EventArgs e)
        {
            if (CurrentLevel>1)
            {
                SaveLevel();
                CurrentLevel--;
                LoadLevel();
            }
        }
        private void LoadLevel()
        {
            cell = level.EditorLoadLevel(CurrentLevel);
            width = cell.GetLength(0); height = cell.GetLength(1);
            panel1.Controls.Clear();
            InitPictures();
            LoadPictures();
        }

        private void toolNext_Click(object sender, EventArgs e)
        {
            SaveLevel();
            CurrentLevel++;
            LoadLevel();
        }

        private void toolResizeAdd10Row_Click(object sender, EventArgs e)
        {
            ResizeLevel(width, height + 10);
        }

        private void toolResizeDel10Row_Click(object sender, EventArgs e)
        {
            ResizeLevel(width, height - 10);
        }

        private void toolResizeAdd10Col_Click(object sender, EventArgs e)
        {
            ResizeLevel(width + 10, height);
        }

        private void toolResizeDel10Col_Click(object sender, EventArgs e)
        {
            ResizeLevel(width - 10, height);
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

        private int CountItems(Cell item)
        {
            int count = 0;
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    if (cell[x, y] == item)
                        count++;
            return count;
        }
        public Image CellToPicture(Cell c)
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
        }
    }
}
