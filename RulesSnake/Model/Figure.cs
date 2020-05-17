using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RulesSnake.Interface;

namespace RulesSnake.Model
{
	/// <summary>
	/// 
	/// Фигуры как объект игры
	/// 
	/// </summary>
    public class Figure : IDraw, IHits, ICloneable
    {
        #region ---===   Protected Data   ===---

		/// <summary>
		/// 
		/// Коллекция точек
		/// 
		/// </summary>
        protected List<Point> _points;

		#endregion

		#region ---===   Property   ===---

		/// <summary>
		/// 
		/// Получение копии коллекции точек
		/// 
		/// </summary>
		internal List<Point> Points
		{
			get
			{
				return (List<Point>)Clone();
			}
			set
			{
				_points = value;
			}
		}

		#endregion

		#region ---===   IHits   ===---

		/// <summary>
		/// 
		/// Проверка столкновения с игровым объектом
		/// 
		/// </summary>
		/// <param name="gameObject"> Игровой объект </param>
		/// <returns> Результат столкновения </returns>
		bool IHits.IsHit(object gameObject)
		{
			if (!(gameObject is Figure figure))
			{
				throw new Exception("Ой ой, что-то пошло нетак");
			}

			bool isHit = false;

			foreach (Point walls in _points)
			{
				if (figure.IsHitOnPoints(walls))
				{
					isHit = true;
				}
			}

			return isHit;
		}

		#endregion
		
		#region ---===   IDraw   ===---

		/// <summary>
		/// 
		/// Отрисовка колекции точке
		/// 
		/// </summary>
		public virtual void Draw()
		{
			foreach (Point point in _points)
			{
				point.Draw();
			}
		}

		#endregion

		#region ---===   ICloneable   ===---

		/// <summary>
		/// 
		/// Глубокое клонирование колекции точек
		/// 
		/// </summary>
		/// <returns></returns>
		public object Clone()
		{
			List<Point> clonePoints = new List<Point>();

			foreach (var item in _points)
			{
				clonePoints.Add(new Point(item));
			}

			return clonePoints;
		}

		#endregion

		#region ---===   Private Function   ===---

		/// <summary>
		/// 
		/// Проверка столкновения точек
		/// 
		/// </summary>
		/// <param name="point"> Точка как игровой объект </param>
		/// <returns></returns>
		private bool IsHitOnPoints(Point point)
		{
			bool isHit = false;

			foreach (IHits p in _points)
			{
				if (p.IsHit(point))
				{
					isHit = true;
				}
			}

			return isHit;
		}

		#endregion

	}
}
