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
    /// <summary>
    /// 
    /// Контроллер Змейки
    /// 
    /// </summary>
    public class SnakeControllers : IMoveble, IEating, IDraw, ICreated, ICloneable
    {
        #region ---===   Constant   ===---

        /// <summary>
        /// 
        /// Отображение змейки на игровом поле
        /// 
        /// </summary>
        const char STANDART_SYMBOL_SNAKE = '*';

        /// <summary>
        /// 
        /// Начальная инициализация хвоста змейки
        /// 
        /// </summary>
        const int STANDART_TAIL_SNAKE = 2;

        #endregion

        #region ---===   Private Data   ===---

        /// <summary>
        /// 
        /// Змейка как игровой объект
        /// 
        /// </summary>
        private readonly Snake _snake;

        /// <summary>
        /// 
        /// Инициализация движения змейки
        /// 
        /// </summary>
        private readonly Direction _direction = Direction.Right;

        /// <summary>
        /// 
        /// Создание хвоста змейки
        /// 
        /// </summary>
        private readonly Point _tailSnake = new Point(
            (Console.WindowWidth / 2), // расположение змеи по середине относительно ширины игрового поля
            (Console.WindowHeight / 2),// расположение змеи по середине относительно высоты игрового поля
            STANDART_SYMBOL_SNAKE);

        #endregion

        #region ---===   Property   ===---

        /// <summary>
        /// 
        /// Получение доступа к копии змейки
        /// 
        /// </summary>
        public Snake Snake
        {
            get
            {
                return (Snake)Clone();
            }
        }

        #endregion

        #region ---===   Ctor   ===---

        /// <summary>
        /// 
        /// Создание змейки как игрового объекта
        /// 
        /// </summary>
        public SnakeControllers()
        {
            _snake = new Snake(_tailSnake, STANDART_TAIL_SNAKE, _direction);
        }

        #endregion

        #region ---===   IMoveble   ===---

        /// <summary>
        /// 
        /// Алгоритм движения змейки на игровом поле
        /// 
        /// </summary>
        void IMoveble.Move()
        {
            Point tail= _snake.Tails.First();
            _snake.Tails.Remove(tail);

            Point head = GetNextPoint();
            _snake.Tails.Add(head);

            tail.Clear();
            head.Draw();
        }

        #endregion

        #region ---===   Icloneble   ===---

        /// <summary>
        /// 
        /// Колонирование змейки
        /// 
        /// </summary>
        /// <returns> иговорой обьект </returns>
        public object Clone()
        {
            return new Snake(_snake);
        }

        #endregion

        #region ---===   IEating   ===---

        /// <summary>
        /// 
        /// Реализация алгоритма поедания еды
        /// и увеличения хвоста змейки
        /// 
        /// </summary>
        /// <param name="gameObject"> игровой объект </param>
        /// <returns></returns>
        bool IEating.Eat(object gameObject)
        {
            if (!(gameObject is Food food))
            {
                throw new Exception("Ой ой, что-то пошло нетак");
            }

            bool isEat = false;

            Point head = GetNextPoint();

            if (((IHits)head).IsHit(food))
            {
                food.Sym = head.Sym;
                _snake.Tails.Add(food);

                isEat = true;
            }

            return isEat;
        }

        #endregion

        #region ---===   IDraw   ===---

        /// <summary>
        /// 
        /// Отрисовка хвоста змейки
        /// 
        /// </summary>
        void IDraw.Draw()
        {
            foreach (Point point in _snake.Tails)
            {
                point.Draw();
            }
        }

        #endregion

        #region ---===   ICreated   ===---

        object ICreated.CreatedGameObject()
        {
            return Snake;
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

            var head = _snake.Tails.Last();

            for (int i = 0; i < _snake.Tails.Count - 2; i++)
            {
                if (((IHits)head).IsHit(_snake.Tails[i]))
                {
                    isTailHit = true;
                }
            }

            return isTailHit;
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
                        _snake.Direction = Direction.Left;

                        break;
                    }

                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    {
                        _snake.Direction = Direction.Right;

                        break;
                    }

                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    {
                        _snake.Direction = Direction.Down;

                        break;
                    }

                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    {
                        _snake.Direction = Direction.Up;

                        break;
                    }

                default:
                    break;
            }
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
            Point head = _snake.Tails.Last();
            Point nextPoint = new Point(head);

            nextPoint.Move(1, _snake.Direction);

            return nextPoint;
        }

        #endregion

    }
}
