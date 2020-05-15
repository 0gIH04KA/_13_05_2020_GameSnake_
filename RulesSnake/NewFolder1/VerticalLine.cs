using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RulesSnake.Model;

namespace RulesSnake.Controller
{
    public class VerticalLine : Figure
    {
        #region ---===   Ctor   ===---

        public VerticalLine(int yUp, int yDown, int x, char sym)
        {
            _points = new List<Point>();

            for (int y = yUp; y < yDown; y++)
            {
                Point point = new Point(x, y, sym);

                _points.Add(point);
            }
        }

        #endregion

        #region ---===   Override FUnction   ===---

        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            base.Draw();

            Console.ForegroundColor = ConsoleColor.White;
        }

        #endregion
    }
}
