using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach
{
    class ScoreFile
    {
        string filename;
        string[] lines;
        public static string user_name;
        public int last_level;
        //bool flag;
        public ScoreFile(string filename)
        {
            this.filename = filename;
            lines = File.ReadAllLines(filename);
            if (lines.Length != 0)
            {
              //  user_name = lines[lines.Length - 2];
             //   string buff = File.ReadAllLines(filename).Last();
             //   int.TryParse(buff, out last_level);
            }
        }

        public int RewriteFile(int count_level=0, string username = " ")
        {
            int curr = 0;
            if (username == " ") username = user_name;
            if (lines.Length > 1)
            {
                while (curr < lines.Length - 1) //пока не дошли до конца массива
                {
                    if (lines[curr].CompareTo(username) == 0) //если такой пользователь уже есть
                    {
                        
                        if (last_level==0) 
                            int.TryParse(lines[curr + 1], out count_level); //преобразуем строки в цифры
                        File.WriteAllLines(filename, lines.Take(lines.Length - 2).ToArray());
                        lines[curr + 1] = count_level.ToString();
                        last_level = count_level+1;
                        File.WriteAllLines(filename, lines);
                        return last_level;
                    }
                    else curr++; //если не совпали, то пропускаем строку
                }
            }
                using (StreamWriter sw = File.AppendText(filename))
                {
                    last_level = 1;
                    sw.WriteLine(username);              
                    sw.WriteLine(count_level.ToString());
                    return 0;
                }
            return 0;
        }
    }
}
