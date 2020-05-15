using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RulesSnake.Enum;
using RulesSnake.Interface;

namespace RulesSnake.Model
{
    public class Point : IHits, IDraw
    {
        #region ---===   Private Data   ===---

        private int _x;
        private int _y;
        private char _sym;

        #endregion

        #region ---===   Property   ===---

        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

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

        public Point(int x, int y, char sym)
        {
            _x = x;
            _y = y;
            _sym = sym;
        }

        public Point(Point point)
        {
            _x = point._x;
            _y = point._y;
            _sym = point._sym;
        }

        #endregion

        #region ---===   Public Function   ===---

        internal void Move (int offset, Direction direction)
        {
            switch (direction)
            {                   
                case Direction.LEFT:
                    {
                        _x -= offset;

                        break;
                    }
                    
                case Direction.RIGHT:
                    {
                        _x += offset;

                        break;
                    }
                    
                case Direction.UP:
                    {
                        _y -= offset;

                        break;
                    }

                case Direction.DOWN:
                    {
                        _y += offset;

                        break;
                    }
            }
        }

        bool IHits.IsHit(object obj)
        {
            if (!(obj is Point point))
            {
                throw new Exception("Ой ой, что-то пошло нетак ");
            }

            return ((point._x == _x)
                && (point._y == _y));
        }

        //todo: Delete This!
        //public bool IsHit(Point point)
        //{
        //    return ((point._x == _x)
        //         && (point._y == _y));
        //}

        public void Draw()
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write(_sym);
        }

        public void Clear()
        {
            _sym = ' ';
            Draw();
        }

        #endregion

        #region ---===   Override Method   ===---

        public override string ToString()
        {
            return _x + ", " + _y + ", " + _sym;
        }

        #endregion

    }
}
