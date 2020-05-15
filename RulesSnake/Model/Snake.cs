using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RulesSnake.Enum;

namespace RulesSnake.Model
{
    public class Snake : Figure
    {
        #region ---===   Private Data   ===---

        /// <summary>
        /// 
        /// Направления движения
        /// 
        /// </summary>
        private Direction _direction;

        #endregion

        #region ---===   Property   ===---

        /// <summary>
        /// 
        /// Направление движения
        /// 
        /// </summary>
        internal Direction Direction 
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;
            }
        }

        /// <summary>
        /// 
        /// Получение точек
        /// 
        /// </summary>
        public List<Point> Points
        {
            get
            {
                return _points;
            }
        }

        #endregion

        #region ---===   Ctor   ===---

        /// <summary>
        /// 
        /// Создание Змеи как игрового обьекта
        /// 
        /// </summary>
        /// <param name="tail"> Хвост змеи </param>
        /// <param name="length"> Длина хвоста змеи </param>
        /// <param name="direction"> Направление движения змеи </param>
        internal Snake(Point tail, int length, Direction direction)
        {
            _direction = direction;
            _points = new List<Point>();

            for (int i = 0; i < length; i++)
            {
                Point point = new Point(tail);
                point.Move(i, direction);
                _points.Add(point);
            }
        }

        #endregion

    }
}
