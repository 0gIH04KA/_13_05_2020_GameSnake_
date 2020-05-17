using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesSnake.Interface
{
    public interface IHits
    {
        /// <summary>
        /// 
        /// Проверка столкновения объектов
        /// 
        /// </summary>
        /// <param name="gameObject"> Игровой обьект </param>
        /// <returns> Резкультат столкновения </returns>
        bool IsHit(object gameObject);
    }
}
