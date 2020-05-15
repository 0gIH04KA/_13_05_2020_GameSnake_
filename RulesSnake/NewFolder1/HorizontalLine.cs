using RulesSnake.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RulesSnake.Controller
{
    public class HorizontalLine : Figure
    {

        #region ---===   Ctor   ===---

        public HorizontalLine(int xLeft, int xRight, int y, char sym)
        {
            _points = new List<Point>();

            for (int x = xLeft; x <= xRight; x++)
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
