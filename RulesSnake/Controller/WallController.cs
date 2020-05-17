using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RulesSnake.Interface;
using RulesSnake.Model;

namespace RulesSnake.Controller
{
    /// <summary>
    /// 
    /// Контроллер который отвечает за логику стен
    /// 
    /// </summary>
    public class WallController : IDraw, IHits
    {
        #region ---===   Constant    ===---

        /// <summary>
        /// 
        /// Стандартный символ 
        /// для заполнения стен на игровом поле
        /// 
        /// </summary>
        private const char STANDART_SYMBOL = '#';

        #endregion

        #region ---===   Private Data   ===---

        /// <summary>
        /// 
        /// Cтены в игровой зоне
        /// 
        /// </summary>
        private readonly Walls _walls;

        #endregion

        #region ---===   Property   ===---

        internal int Width
        {
            get
            {
                return _walls.Width;
            }
        }

        internal int Height
        {
            get
            {
                return _walls.Height;
            }
        }

        #endregion

        #region ---===   Ctor   ===---

        /// <summary>
        /// 
        /// Создание контроллера для стен
        /// 
        /// </summary>
        /// <param name="mapWidth"> Ширина игрового поля </param>
        /// <param name="mapHeight"> Высота игрового поля </param>
        /// <param name="mapSymbol"> Символ игрового поря </param>
        public WallController(int mapWidth, int mapHeight, char mapSymbol = STANDART_SYMBOL)
        {
            _walls = new Walls(mapWidth, mapHeight, mapSymbol);
        }

        #endregion

        #region ---===   IHits   ===---

        /// <summary>
        /// 
        /// Проверка столкновения с игровым полем
        /// 
        /// </summary>
        /// 
        /// <param name="gameObject"> Обьект игры </param>
        /// 
        /// <returns> 
        /// 
        /// Возвращает результат проверки 
        /// столкновения с обьектом игрового поря
        /// 
        /// </returns>
        bool IHits.IsHit(object gameObject)
        {
            if (!(gameObject is Figure figure))
            {
                throw new Exception("Ой ой, что-то пошло нетак ");
            }

            bool isHit = false;

            foreach (IHits wall in _walls.WallsList)
            {
                if (wall.IsHit(figure))
                {
                    isHit = true;
                }
            }

            return isHit;
        }

        #endregion

        #region ---===   IDraw   ===---

        /// <summary>
        /// 
        /// Реализация интерфейса для рисования
        /// 
        /// </summary>
        void IDraw.Draw()
        {
            foreach (var wall in _walls.WallsList)
            {
                wall.Draw();
            }
        }

        #endregion

    }
}
