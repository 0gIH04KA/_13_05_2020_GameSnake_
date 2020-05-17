using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesSnake.Model
{
    /// <summary>
    /// 
    /// Еда как игровой объект
    /// 
    /// </summary>
    public class Food : Point
    {
        #region ---===   Private Data   ===---

        /// <summary>
        /// 
        /// Еда на игровом поле
        /// 
        /// </summary>
        private readonly Point _food;

        #endregion

        #region ---===   Ctor   ===---

        /// <summary>
        /// 
        /// Создание еды
        /// 
        /// </summary>
        /// <param name="coordinateWidth"> Координата по ширине </param>
        /// <param name="coordinateHeight"> Координата по высоте </param>
        /// <param name="sym"> Символ для еды </param>
        public Food(int coordinateWidth, int coordinateHeight, char sym)
            :base(coordinateWidth, coordinateHeight, sym)
        {
            _food = new Point(coordinateWidth, coordinateHeight, sym);
        }

        /// <summary>
        /// 
        /// Создание копии еды
        /// 
        /// </summary>
        /// <param name="food"> Текущая еда </param>
        public Food (Food food)
            :this(food.X, food.Y, food.Sym)
        {
        }

        #endregion

    }
}
