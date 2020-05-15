using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RulesSnake.Interface;
using RulesSnake.Model;

namespace RulesSnake.Controller
{
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
        private readonly Walls walls;

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
            walls = new Walls(mapWidth, mapHeight, mapSymbol);
        }

        #endregion

        #region ---===   IHits   ===---

        /// <summary>
        /// 
        /// Проверка столкновения с игровым полем
        /// 
        /// </summary>
        /// 
        /// <param name="obj"> Обьект игры </param>
        /// 
        /// <returns> 
        /// 
        /// Возвращает результат проверки 
        /// столкновения с обьектом игрового поря
        /// 
        /// </returns>
        bool IHits.IsHit(object obj)
        {
            if (!(obj is Figure figure))
            {
                throw new Exception("Ой ой, что-то пошло нетак ");
            }

            bool isHit = false;

            foreach (var wall in walls.WallsList)
            {
                if (wall.IsHit(figure))
                {
                    isHit = true;
                }
            }

            return isHit;
        }

        //todo: Delete This!
        //public bool IsHit(Figure figure) 
        //{
        //    bool isHit = false;

        //    foreach (var wall in walls.WallsList)
        //    {
        //        if (wall.IsHit(figure))
        //        {
        //            isHit = true;
        //        }
        //    }

        //    return isHit;
        //}

        #endregion

        #region ---===   IDraw   ===---

        /// <summary>
        /// 
        /// Реализация интерфейса для рисования
        /// 
        /// </summary>
        void IDraw.Draw()
        {
            foreach (var wall in walls.WallsList)
            {
                wall.Draw();
            }
        }

        //todo: Delete This!
        //public void Draw()   
        //{
        //    foreach (var wall in walls.WallsList)
        //    {
        //        wall.Draw();
        //    }
        //}

        #endregion

    }
}
