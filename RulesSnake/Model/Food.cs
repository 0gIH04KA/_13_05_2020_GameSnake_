using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesSnake.Model
{
    public class Food 
    {
        #region ---===   Private Data   ===---

        private readonly Point _food;

        #endregion

        #region ---===   Property   ===---

        public int CoordinateX
        {
            get
            {
                return _food.X;
            }
            set
            {
                _food.X = value;
            }
        }

        public int CoordinateY
        {
            get
            {
                return _food.Y;
            }
            set
            {
                _food.Y = value;
            }
        }

        public char Symbol
        {
            get
            {
                return _food.Sym;
            }
            set
            {
                _food.Sym = value;
            }
        }

        #endregion

        #region ---===   Ctor   ===---

        public Food(int coordinateWidth, int coordinateHeight, char sym)
        {
            _food = new Point(coordinateWidth, coordinateHeight, sym);
        }

        #endregion


    }
}
