using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RulesSnake.Enum;
using RulesSnake.Interface;
using RulesSnake.Model;

namespace RulesSnake.Controller
{
    public class SnakeControllers : IMoveble, IEating, IDraw, ICreated, ICloneable
    {
        #region ---===   Constant   ===---

        const char STANDART_SYMBOL_SNAKE = '*';
        const int STANDART_TAIL_SNAKE = 4;

        #endregion

        #region ---===   Private Data   ===---

        private readonly Snake _snake;

        private readonly Direction _direction = Direction.RIGHT;

        private readonly Point _tailSnake = new Point(
            (Console.WindowWidth / 2), // расположение змеи по середине относительно ширины игрового поля
            (Console.WindowHeight / 2),// расположение змеи по середине относительно высоты игрового поля
            STANDART_SYMBOL_SNAKE);

        #endregion

        #region ---===   Property   ===---

        public Snake Snake
        {
            get
            {
                return _snake;
            }
        }

        #endregion

        #region ---===   Ctor   ===---

        public SnakeControllers()
        {
            _snake = new Snake(_tailSnake, STANDART_TAIL_SNAKE, _direction);
        }

        #endregion

        #region ---===   IMoveble   ===---

        void IMoveble.Move()
        {
            Point tail = _snake.Points.First();
            _snake.Points.Remove(tail);

            Point head = GetNextPoint();
            _snake.Points.Add(head);

            tail.Clear();
            head.Draw();
        }

        //todo: Delete This
        //public void Move()
        //{
        //    Point tail = _snake.Points.First();
        //    _snake.Points.Remove(tail);

        //    Point head = GetNextPoint();
        //    _snake.Points.Add(head);

        //    tail.Clear();
        //    head.Draw();
        //}

        #endregion

        #region ---===   Icloneble   ===---

        public object Clone()
        {
            throw new NotImplementedException(); //TODO: Реализовать Клонирование
        }

        #endregion

        #region ---===   IEating   ===---

        bool IEating.Eat(object obj)
        {
            if (!(obj is Point food))
            {
                
                throw new Exception("Ой ой, что-то пошло нетак");
            }

            bool isEat = false;

            Point head = GetNextPoint();

            if (((IHits)head).IsHit(food))
            {
                food.Sym = head.Sym;
                _snake.Points.Add(food);

                isEat = true;
            }

            return isEat;
        }

        //todo: Delete This
        //public bool Eat(Point food)
        //{
        //    bool isEat = false;

        //    Point head = GetNextPoint();

        //    if (((IHits)head).IsHit(food))
        //    {
        //        food.Sym = head.Sym;
        //        _points.Add(food);

        //        isEat = true;
        //    }

        //    return isEat;
        //}

        #endregion

        #region ---===   IDraw   ===---

        void IDraw.Draw()
        {
            foreach (Point point in _snake.Points)
            {
                point.Draw();
            }
        }

        #endregion

        #region ---===   ICreated   ===---

        object ICreated.CreatedGameObject()
        {
            return _snake;
        }

        #endregion

        #region ---===   Public Method   ===---

        /// <summary>
        /// 
        /// Столкновение со своим хвостом
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// 
        /// Результат проверки столкновения с хвостом
        /// 
        /// </returns>
        public bool IsHitTail()
        {
            bool isTailHit = false;

            var head = _snake.Points.Last();

            for (int i = 0; i < _snake.Points.Count - 2; i++)
            {
                if (((IHits)head).IsHit(_snake.Points[i]))
                {
                    isTailHit = true;
                }
            }

            return isTailHit;
        }

        #endregion

        #region ---===   Private Method   ===---

        /// <summary>
        /// 
        /// Получение следующей точки
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// 
        /// Возвращает следующую точку
        /// 
        /// </returns>
        private Point GetNextPoint()
        {
            Point head = _snake.Points.Last();
            Point nextPoint = new Point(head);

            nextPoint.Move(1, _snake.Direction);

            return nextPoint;
        }

        /// <summary>
        /// 
        /// Обработка нажатий на клавиши
        /// 
        /// </summary>
        /// <param name="key"> Нажатая кнопка </param>
        public void HandleKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    {
                        _snake.Direction = Direction.LEFT;

                        break;
                    }

                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    {
                        _snake.Direction = Direction.RIGHT;

                        break;
                    }

                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    {
                        _snake.Direction = Direction.DOWN;

                        break;
                    }

                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    {
                        _snake.Direction = Direction.UP;

                        break;
                    }

                default:
                    break;
            }
        }

        

        #endregion
    }
}
