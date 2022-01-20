using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach
{
    //ячейка игры
    public enum Cell
    {
        none, wall, abox, done, here, user
    };
    public struct Place
    {
        public int x;
        public int y;
        public Place (int ax, int ay)
        {
            x = ax; y = ay;
        }
    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WelcomeForm());
        }
    }
}
