using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//логика игры
namespace kursach
{
    class Game
    {
        Place mouse; //координата человечка
        Cell[,] map; //недвижимые объекты: here и стена
        Cell[,] top; //движимые объекты: ящик и игрок
        int w, h;
        deShowItem ShowItem;
        deShowStat ShowStat;
        int placed, totals; //сколько ящиков стоит на месте, сколько всего ящиков
        public Game (deShowItem ShowItem, deShowStat ShowStat)
        {
            this.ShowItem = ShowItem;
            this.ShowStat = ShowStat;
        }
        public bool Init (int level_nr, out int width, out int height)
        {
            LevelFile level = new LevelFile("levels.txt");
            map = level.LoadLevel(level_nr);
            if (map == null)
            {
                width = 0; height = 0;
                return false;
            }
            width = w = map.GetLength(0);
            height = h = map.GetLength(1);
            top = new Cell[width, height];
            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                {
                    switch (map[x,y])
                    {
                        case Cell.user:
                                          mouse = new Place(x, y);
                                          map[x, y] = Cell.none;
                                          top[x, y] = Cell.user;
                                          break;
                        case Cell.none:
                        case Cell.wall:
                        case Cell.here:
                                          top[x, y] = Cell.none;
                                          break;
                        case Cell.abox:
                                          top[x, y] = Cell.abox;
                                          map[x, y] = Cell.none;
                                          break;
                        case Cell.done:
                                          top[x, y] = Cell.abox;
                                          map[x, y] = Cell.here;
                                          break;
                    }
                }

                    return true;
        }
        public void ShowLevel()
        {
            placed = 0; totals = 0;
            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                {
                    ShowMapTop(x, y);
                    if (map[x, y] == Cell.here)
                    {
                        totals++;
                        if (top[x, y] == Cell.abox) 
                            placed++;
                    }
                   // ShowItem(new Place(x, y), map[x, y]);
                }
            ShowStat(placed, totals);
        }

        private void ShowMapTop(int x, int y)
        {
            if (top[x,y] == Cell.none)
                ShowItem(new Place(x, y), map[x, y]);
            else
                if (top[x, y] == Cell.abox && map[x,y] == Cell.here)
                    ShowItem(new Place(x, y), Cell.done);
                else
                    ShowItem(new Place(x, y), top[x, y]);
        }
        //шаг
        public void Step(int sx, int sy)
        {
            Place place = new Place(mouse.x + sx, mouse.y + sy);
            if (!InRange(place)) return;
            if (top[place.x,place.y] == Cell.none)
            {
                top[mouse.x, mouse.y] = Cell.none; ShowMapTop(mouse.x, mouse.y);
                top[place.x, place.y] = Cell.user; ShowMapTop(place.x, place.y);
                mouse = place;
                return;
            }
            if (top[place.x, place.y] == Cell.abox)
            {
                Place after = new Place(place.x + sx, place.y + sy); //что находится за ящиком
                if (!InRange(after)) return;
                if (top[after.x, after.y] != Cell.none) return; //за ящиком должно быть свободно
                if (map[place.x, place.y] == Cell.here) placed--; //если столкнули ящика с места-парковки
                if (map[after.x, after.y] == Cell.here) placed++; //если толкнули ящик в место-парковку
                ShowStat(placed, totals);
                top[mouse.x, mouse.y] = Cell.none; ShowMapTop(mouse.x, mouse.y);
                top[place.x, place.y] = Cell.user; ShowMapTop(place.x, place.y);
                top[after.x, after.y] = Cell.abox; ShowMapTop(after.x, after.y);               
                mouse = place;
            }
        }
        //для проверки можно ли пойти в такую точку //только чтобы не налететь на стену или не уйти за пределы
        public bool InRange (Place place)
        {
            if (place.x < 0 || place.x >= w)
                return false;
            if (place.y < 0 || place.y >= h)
                return false;
            if (map[place.x, place.y] == Cell.none)
                return true;
            if (map[place.x, place.y] == Cell.here)
                return true;
            return false;
        }
    }
}
