using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RulesSnake.Enum;
using RulesSnake.Interface;

namespace RulesSnake.Model
{
    /// <summary>
    /// 
    /// Точка - минимальный объект игры
    /// 
    /// </summary>
    public class Point : IHits, IDraw
    {
        #region ---===   Private Data   ===---

        /// <summary>
        /// 
        /// Координата по оси Х
        /// 
        /// </summary>
        private int _x;

        /// <summary>
        /// 
        /// Координата по оси Y
        /// 
        /// </summary>
        private int _y;

        /// <summary>
        /// 
        /// Символ для отображения
        /// 
        /// </summary>
        private char _sym;

        #endregion

        #region ---===   Property   ===---

        /// <summary>
        /// 
        /// Получение координаты по оси X и валидация данных
        /// 
        /// </summary>
        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Координата не может быть отрицательной");
                }

                _x = value;
            }
        }

        /// <summary>
        /// 
        /// Получение координаты по оси Y и валидация данных
        /// 
        /// </summary>
        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Координата не может быть отрицательной");
                }

                _y = value;
            }
        }

        /// <summary>
        /// 
        /// Получение символа 
        /// 
        /// </summary>
        public char Sym
        {
            get
            {
                return _sym;
            }
            set
            {
                _sym = value;
            }
        }

        #endregion

        #region ---===   Ctor   ===---

        /// <summary>
        /// 
        /// Созжание точки
        /// 
        /// </summary>
        /// <param name="x"> Координата по Х </param>
        /// <param name="y"> Координата по Y </param>
        /// <param name="sym"> Символ отображения </param>
        public Point(int x, int y, char sym)
        {
            _x = x;
            _y = y;
            _sym = sym;
        }

        /// <summary>
        /// 
        /// Создание копии точки 
        /// 
        /// </summary>
        /// <param name="point"> Точка как объект игры </param>
        public Point(Point point)
        {
            _x = point._x;
            _y = point._y;
            _sym = point._sym;
        }

        #endregion

        #region ---===   IHits   ===---

        /// <summary>
        /// 
        /// Проверка столкновения объектов
        /// 
        /// </summary>
        /// <param name="gameObject"> Игровой обьект </param>
        /// <returns> Результат столкновения </returns>
        bool IHits.IsHit(object gameObject)
        {
            if (!(gameObject is Point point))
            {
                throw new Exception("Ой ой, что-то пошло нетак ");
            }

            return ((point._x == _x)
                && (point._y == _y));
        }

        #endregion

        #region ---===   IDraw   ===---

        /// <summary>
        /// 
        /// Отрисовка точек в указаных координатах
        /// 
        /// </summary>
        public void Draw()
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write(_sym);
        }

        /// <summary>
        /// 
        /// Затирание хвоста после змейки
        /// 
        /// </summary>
        public void Clear()
        {
            _sym = ' ';
            Draw();
        }

        #endregion

        #region ---===   Internal Method   ===---

        /// <summary>
        /// 
        /// Реализация движения в укзанном направвлении
        /// 
        /// </summary>
        /// <param name="offset"> Величина сдвига </param>
        /// <param name="direction"> Направление </param>
        internal void Move (int offset, Direction direction)
        {
            switch (direction)
            {                   
                case Direction.Left:
                    {
                        _x -= offset;

                        break;
                    }
                    
                case Direction.Right:
                    {
                        _x += offset;

                        break;
                    }
                    
                case Direction.Up:
                    {
                        _y -= offset;

                        break;
                    }

                case Direction.Down:
                    {
                        _y += offset;

                        break;
                    }
            }
        }

        #endregion

    }
}
