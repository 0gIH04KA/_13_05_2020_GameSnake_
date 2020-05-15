using RulesSnake.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesSnake.Model
{
    internal class Walls
    {
        #region ---===   Private Data   ===---

        /// <summary>
        /// 
        /// Массив стен игрового поля
        /// 
        /// </summary>
        private readonly List<Figure> _walls;

        #endregion

        #region ---===   Property   ===---

        /// <summary>
        /// 
        /// Получение доступа к игровому поля
        /// 
        /// </summary>
        public List<Figure> WallsList
        {
            get
            {
                return _walls;  // TODO: возможно нужно реализовать ICloneble для Heap
            }
        }

        #endregion

        #region ---===   Ctor  ===---

        /// <summary>
        /// 
        /// Создание стенок по периметру игрового поля
        /// 
        /// </summary>
        /// <param name="mapWidth"> Ширина игрового поля </param>
        /// <param name="mapHeight"> Высота игрового поля </param>
        public Walls(int mapWidth, int mapHeight, char sym)
        {
            Validation(mapWidth, mapHeight);

            _walls = new List<Figure>();

            HorizontalLine upLine = new HorizontalLine(0, mapWidth - 1, 0, sym);
            VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, sym);
            VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 1, sym);
            HorizontalLine downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, sym);

            AddToList(upLine, leftLine, rightLine, downLine);
        }

        #endregion

        #region ---===   Private Method   ===---

        /// <summary>
        /// 
        /// Проверка входных параметров перед созданием стен
        /// 
        /// </summary>
        /// <param name="width"> Ширина игрового поля </param>
        /// <param name="height"> Высота игрового поля </param>
        private void Validation(int width, int height)
        {
            if (width <= 0)
            {
                throw new ArgumentException("Ширина игрового поля не может быть отрицательной!");
            }

            if (height <= 0)
            {
                throw new ArgumentException("Высота игрового поля не может быть отрицательной!");
            }
        }

        /// <summary>
        /// 
        /// Добавление стен в общий массив
        /// 
        /// </summary>
        /// <param name="upLine"> Верхняя стена </param>
        /// <param name="leftLine"> Левая стена </param>
        /// <param name="rightLine"> Правая стена </param>
        /// <param name="downLine"> Нижняя стена </param>
        private void AddToList(HorizontalLine upLine, VerticalLine leftLine, VerticalLine rightLine, HorizontalLine downLine)
        {
            _walls.Add(upLine);
            _walls.Add(leftLine);
            _walls.Add(rightLine);
            _walls.Add(downLine);
        }

        #endregion
    }
}
