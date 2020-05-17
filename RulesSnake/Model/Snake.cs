using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RulesSnake.Enum;

namespace RulesSnake.Model
{
    /// <summary>
    /// 
    /// Змейка как игровой обьект
    /// 
    /// </summary>
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
        /// Получение хвоста змейки
        /// 
        /// </summary>
        public List<Point> Tails
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

        /// <summary>
        /// 
        /// Клонирование змейки
        /// 
        /// </summary>
        /// <param name="snake"> Змейка как игровой объект </param>
        internal Snake(Snake snake) 
        {
            _direction = snake._direction;
            _points = new List<Point>();

            foreach (var item in snake.Tails)
            {
                Point point = new Point(item);
                point.Move(1, snake._direction);
                _points.Add(point);
            }
        }

        #endregion

    }
}
