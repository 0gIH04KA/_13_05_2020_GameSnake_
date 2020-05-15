using RulesSnake.Interface;
using RulesSnake.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesSnake.Controller
{
    public class FoodController : IDraw, ICreated
    {

        #region ---===   Constant   ===---

        const char STANDART_SYMBOL_FOOD = '$';

        #endregion

        #region ---===   Private Data   ===---

        readonly Random random = new Random();
        readonly Food _food;

        #endregion

        #region ---===   Property   ===---

        public Point Food
        {
            get
            {
                return new Point(_food.CoordinateX, _food.CoordinateY, _food.Symbol);
            }
        }

        #endregion

        #region ---===   Ctor   ===---

        public FoodController(char symbol = STANDART_SYMBOL_FOOD)
        {
            _food = new Food(Console.WindowWidth/3 , Console.WindowHeight/3, symbol);
        }

        #endregion

        object ICreated.CreatedGameObject()
        {
            _food.CoordinateX = random.Next(2, Console.BufferWidth - 2);
            _food.CoordinateY = random.Next(2, Console.BufferHeight - 2);

            return new Point(_food.CoordinateX, _food.CoordinateY, _food.Symbol);
        }

        //object ICreated.CreatedGameObject()
        //{
        //    _food.X = random.Next(2, Console.WindowWidth - 2);
        //    _food.Y = random.Next(2, Console.WindowHeight - 2);

        //    return new Point(_food.X, _food.Y, _food.Sym);
        //}

        void IDraw.Draw()
        {
            Console.SetCursorPosition(_food.CoordinateX, _food.CoordinateY);
            Console.Write(_food.Symbol);
        }

        //public void Drow()
        //{
        //    Console.SetCursorPosition(_food.X, _food.Y);
        //    Console.Write("@");
        //}
    }
}
