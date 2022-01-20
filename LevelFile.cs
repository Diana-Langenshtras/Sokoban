using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static kursach.SokobanEditor;
using System.IO;

namespace kursach
{
    class LevelFile
    {
        int new_level_size = 8;
        string filename;
        public LevelFile(string filename)
        {
            this.filename = filename;
        }
        //функция дря загрузки уровня, возвращает матрицу ячеек, где находится загруженный уровень
        public Cell [,] LoadLevel (int level_nr) //для загрузки уровня в матрицу из файла
        {
            Cell[,] cell = null;
            string[] lines;
            try
            {
                lines = File.ReadAllLines(filename); //считываем уровень из файла
            } 
            catch { return cell; }
            int curr = 0;
            int curr_level_nr = 0;
            int  width;
            int height;
            while (curr<lines.Length) //пока не дошли до конца массива
            {
                ReadLevelHeader(lines[curr], out curr_level_nr, out width, out height); // считали данные об уровне
                if (level_nr == curr_level_nr)
                {
                    cell = new Cell[width, height];
                    for (int y = 0; y < height; y++)
                        for (int x = 0; x < width; x++)
                            cell[x, y] = CharToCell(lines[curr+1+y] [x]);

                    break;
                }
                else curr = curr + 1 + height; //если не совпали то пропускаем строку с данными об уровне, сам уровень и переходим к следующему
            }

            //этот кусок только для редактора 
            //разделить потом этот код для редактора и для игры

        /*    if (cell == null) //если след уровень не нашли (не существует)
            {
                Array.Resize(ref lines, lines.Length + new_level_size + 1);
                lines[curr] = (curr_level_nr + 1).ToString() + " " + new_level_size.ToString() + " " + new_level_size.ToString();
                for (int j = 0; j < new_level_size; j++)
                    lines[curr + j + 1] = new String(' ', new_level_size);
                File.WriteAllLines(filename, lines);
                return LoadLevel(level_nr);
            }*/
            return cell;
        }
        public Cell[,] EditorLoadLevel(int level_nr) //для загрузки уровня в матрицу из файла
        {
            Cell[,] cell = null;
            string[] lines;
            try
            {
                lines = File.ReadAllLines(filename); //считываем уровень из файла
            }
            catch { return cell; }
            int curr = 0;
            int curr_level_nr = 0;
            int width;
            int height;
            while (curr < lines.Length) //пока не дошли до конца массива
            {
                ReadLevelHeader(lines[curr], out curr_level_nr, out width, out height); // считали данные об уровне
                if (level_nr == curr_level_nr)
                {
                    cell = new Cell[width, height];
                    for (int y = 0; y < height; y++)
                        for (int x = 0; x < width; x++)
                            cell[x, y] = CharToCell(lines[curr + 1 + y][x]);

                    break;
                }
                else curr = curr + 1 + height; //если не совпали то пропускаем строку с данными об уровне, сам уровень и переходим к следующему
            }

            //этот кусок только для редактора 
            //разделить потом этот код для редактора и для игры

                if (cell == null) //если след уровень не нашли (не существует)
                {
                    Array.Resize(ref lines, lines.Length + new_level_size + 1);
                    lines[curr] = (curr_level_nr + 1).ToString() + " " + new_level_size.ToString() + " " + new_level_size.ToString();
                    for (int j = 0; j < new_level_size; j++)
                        lines[curr + j + 1] = new String(' ', new_level_size);
                    File.WriteAllLines(filename, lines);
                    return LoadLevel(level_nr);
                }
            return cell;
        }
        private void ReadLevelHeader(string line, out int level_nr, out int width, out int height)
        {
            string[] parts = line.Split(); //разбиваем строку по пробелам
            level_nr = 0;
            width = 0;
            height = 0;
            if (parts.Length != 3) //если не получили 3 значения(номер, ширину, высоту), то выходим
                return;
            int.TryParse(parts[0], out level_nr); //преобразуем строки в цифры
            int.TryParse(parts[1], out width);
            int.TryParse(parts[2], out height);
        }
        public void SaveLevel (int level_nr, Cell [,] cell) //для сохранения уровня в файл // номер уровня, размеры
        {
            string[] lines;
            try
            {
                lines = File.ReadAllLines(filename); //считываем уровень из файла
            }
            catch { return; }
            int curr = 0;
            int curr_level_nr;
            int width = 0;
            int height = 0;
            while (curr < lines.Length) //пока не дошли до конца массива
            {
                ReadLevelHeader(lines[curr], out curr_level_nr, out width, out height); // считали данные об уровне
                if (level_nr == curr_level_nr)
                {
                    break;
                }
                else curr = curr + 1 + height; //если не совпали то пропускаем строку с данными об уровне, сам уровень и переходим к следующему
            }
            int old_length = lines.Length;
            int delta = cell.GetLength(1) - height;
            int new_length = old_length + delta;
            if (new_length > old_length)
            {               
                Array.Resize(ref lines, new_length);
                for (int z = new_length - 1; z > curr; z--)
                    lines[z] = lines[z - delta];
            }
            if (new_length < old_length)
            {
                Array.Resize(ref lines, new_length);
                for (int z = curr+1; z < new_length; z++)
                    lines[z] = lines[z + delta];
            }
            int w = cell.GetLength(0);
            int h = cell.GetLength(1);
            lines[curr] = level_nr + " " + w.ToString() + " " + h.ToString();
            for (int y = 0; y < h; y++)
            {
                lines[curr + 1 + y] = "";
                for (int x = 0; x < w; x++)
                    lines[curr + 1 + y] += CellToChar(cell[x, y]);
            }
            try
            {
                File.WriteAllLines(filename, lines);
            }
            catch { return; }
        }
        public Cell CharToCell(char x)
        {
            switch(x)
            {
                case ' ': return Cell.none;
                case '#': return Cell.wall;
                case 'O': return Cell.abox;
                case '.': return Cell.here;
                case 'C': return Cell.done;
                case '1': return Cell.user;
                default: return Cell.none;
            }
        }
        public char CellToChar(Cell c)
        {
            switch (c)
            {
                case Cell.none: return ' ';
                case Cell.wall: return '#';
                case Cell.abox: return 'O';
                case Cell.here: return '.';
                case Cell.done: return 'C';
                case Cell.user: return '1';
                default: return ' ';
            }
        }
    }
}
