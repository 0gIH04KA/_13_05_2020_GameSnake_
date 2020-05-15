using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RulesSnake.Interface;

namespace RulesSnake.Model
{
    public class Figure : IDraw
    {
        #region ---===   Protected Data   ===---

        protected List<Point> _points;

		#endregion

		#region ---===   Public Function   ===---

		public bool IsHit(Figure figure)
		{
			bool isHit = false;

			foreach (var p in _points)
			{
				if (figure.IsHit(p))
				{
					isHit = true;
				}
			}

			return isHit;
		}

		private bool IsHit(Point point)
		{
			bool isHit = false;

			foreach (var p in _points)
			{
				if (((IHits)p).IsHit(point))
				{
					isHit = true;
				}
			}

			return isHit;
		}

		public virtual void Draw()
		{
			foreach (Point point in _points)
			{
				point.Draw();
			}
		}

		#endregion

	}
}
