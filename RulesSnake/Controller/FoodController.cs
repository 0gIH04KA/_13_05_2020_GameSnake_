using RulesSnake.Interface;
using RulesSnake.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesSnake.Controller
{
    /// <summary>
    /// 
    /// Контроллер еды
    /// 
    /// </summary>
    public class FoodController : IDraw, ICreated
    {
        #region ---===   Constant   ===---

        /// <summary>
        /// 
        /// Стандартный символ для отображения еды на игровом поле
        /// 
        /// </summary>
        const char STANDART_SYMBOL_FOOD = '$';

        #endregion

        #region ---===   Private Data   ===---

        /// <summary>
        /// 
        /// Объект еды
        /// 
        /// </summary>
        private readonly Food _food;

        /// <summary>
        /// 
        /// Ширина игрового поря
        /// 
        /// </summary>
        private int _widthMap;

        /// <summary>
        /// 
        /// Высота игрового поля
        /// 
        /// </summary>
        private int _heightMap;

        /// <summary>
        /// 
        /// Экземпляр класса рандом
        /// 
        /// </summary>
        private readonly Random random = new Random();

        #endregion

        #region ---===   Property   ===---

        /// <summary>
        /// 
        /// Получение доступа к копии еды
        /// 
        /// </summary>
        public Food Food
        {
            get
            {
                return new Food(_food);
            }
        }

        #endregion

        #region ---===   Ctor   ===---

        /// <summary>
        /// 
        /// Создание контроллера еды
        /// 
        /// </summary>
        /// <param name="wall"> Игровые стены </param>
        /// <param name="symbol"> Символ отображеия еды </param>
        public FoodController(WallController wall ,char symbol = STANDART_SYMBOL_FOOD)
        {
            _widthMap = wall.Width;
            _heightMap = wall.Height;

            _food = new Food(_widthMap / 3 , _heightMap / 3, symbol);
        }

        #endregion

        #region ---===   ICreated   ===---

        /// <summary>
        /// 
        /// Создание еды в Слуайной координате
        /// 
        /// </summary>
        /// <returns> Возвращает игровой объект </returns>
        object ICreated.CreatedGameObject()
        {
            _food.X = random.Next(2, _widthMap - 2);
            _food.Y = random.Next(2, _heightMap - 2);

            return new Food(_food.X, _food.Y, _food.Sym);
        }

        #endregion

        #region ---===   IDraw   ===---

        /// <summary>
        /// 
        /// Отрисовка еды
        /// 
        /// </summary>
        void IDraw.Draw()
        {
            Console.SetCursorPosition(_food.X, _food.Y);
            Console.Write(_food.Sym);
        }

        #endregion

    }
}
