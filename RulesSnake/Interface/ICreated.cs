using RulesSnake.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesSnake.Interface
{
    public interface ICreated
    {
        /// <summary>
        /// 
        /// Создание игровых объектов
        /// 
        /// </summary>
        /// <returns> Игровой объект </returns>
        object CreatedGameObject();
    }
}
