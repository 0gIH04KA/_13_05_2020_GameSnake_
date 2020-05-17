using RulesSnake.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesSnake.Model
{
    /// <summary>
    /// 
    /// Стена как игровой объект
    /// 
    /// </summary>
    internal class Walls : ICloneable
    {
        #region ---===   Private Data   ===---

        /// <summary>
        /// 
        /// Массив стен игрового поля
        /// 
        /// </summary>
        private readonly List<Figure> _walls;

        /// <summary>
        /// 
        /// Ширина игрового поля
        /// 
        /// </summary>
        private int _width;

        /// <summary>
        /// 
        /// Высота игрового поля
        /// 
        /// </summary>
        private int _height;

        #endregion

        #region ---===   Property   ===---

        /// <summary>
        /// 
        /// Получение ширины игрового поля и валидация
        /// 
        /// </summary>
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Ширина игрового поля не может быть отрицательной!");
                }

                _width = value;
            }
        }

        /// <summary>
        /// 
        /// Получение высоты игрового поля и валидация
        /// 
        /// </summary>
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Высота игрового поля не может быть отрицательной!");
                }

                _height = value;
            }
        }

        /// <summary>
        /// 
        /// Получение доступа к клону игрового поля
        /// 
        /// </summary>
        public List<Figure> WallsList
        {
            get
            {
                return (List<Figure>)Clone(); 
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
            Width = mapWidth;
            Height = mapHeight;            

            _walls = new List<Figure>();

            HorizontalLine upLine = new HorizontalLine(0, _width - 1, 0, sym);
            VerticalLine leftLine = new VerticalLine(0, _height - 1, 0, sym);
            VerticalLine rightLine = new VerticalLine(0, _height - 1, _width - 1, sym);
            HorizontalLine downLine = new HorizontalLine(0, _width - 2, _height - 1, sym);

            _walls.AddRange(new List<Figure> 
            {
                upLine,
                leftLine,
                rightLine,
                downLine
            });
        }

        #endregion

        #region ---===   ICloneable   ===---

        /// <summary>
        /// 
        /// Клонирование игровых стенок
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new List<Figure>(_walls);
        }

        #endregion

        #region ---===   Private Method   ===---

        #endregion
    }
}
