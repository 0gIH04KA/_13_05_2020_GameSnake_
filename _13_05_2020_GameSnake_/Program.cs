using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using RulesSnake.Interface;
using RulesSnake.Controller;
using RulesSnake.Model;

namespace _13_05_2020_GameSnake_
{
	class Program
	{
		static void Main(string[] args)
		{
			#region ---===   Language   ===---

			CultureInfo culture = CultureInfo.CurrentCulture;
			ResourceManager resourceMenager = new ResourceManager("_13_05_2020_GameSnake_.Languages.Messages", typeof(Program).Assembly);

			#endregion

			#region ---===   Constant   ===---

			#endregion

			ConsoleKey exit;

			do
			{
				#region ---===   Controllers   ===---

				WallController wallController = new WallController(Console.WindowWidth - 20, Console.WindowHeight - 10);
				SnakeControllers snakeControllers = new SnakeControllers();
				FoodController foodController = new FoodController(wallController);

				#endregion

				CratedGameObject(snakeControllers, foodController);
				DrawGameObject(wallController, snakeControllers, foodController);

				GameProcess(wallController, snakeControllers, foodController, resourceMenager, culture);
				
				exit = ProcessingPressKey(resourceMenager, culture);

				Console.Clear();

			} while (!(exit == ConsoleKey.Escape 
					|| exit == ConsoleKey.N) 
				    && (exit == ConsoleKey.Y));
		}

		#region ---===   Game Process   ===---

		/// <summary>
		/// 
		/// Метод который реализует игровое поведение змеи
		/// 
		/// </summary>
		/// <param name="culture"> Регион пользователя </param>
		/// <param name="resourceMenager"> Ресурсы для отображения сообщений пользователю </param>
		private static void GameProcess(WallController wallController,
										SnakeControllers snakeControllers,
										FoodController foodController,
										ResourceManager resourceMenager,
										CultureInfo culture)
		{
			while (!IsGameOver(wallController, snakeControllers))
			{
				if (IsEatingSnake(snakeControllers, foodController))
				{
					Point food = (Point)((ICreated)foodController).CreatedGameObject();
					DrawGameObject(food);
				}
				else
				{
					MoveGameObject(snakeControllers);
				}

				Thread.Sleep(100);
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey(true);
					snakeControllers.HandleKey(key.Key);
				}
			}

			WriteGameOver(resourceMenager, culture);
		}

		/// <summary>
		/// 
		/// Проверка поедания еды
		/// 
		/// </summary>
		/// <param name="snake"> Змея на игровом поле </param>
		/// <param name="food"> Еда на игровом поле </param>
		/// <returns></returns>
		private static bool IsEatingSnake(IEating snake, FoodController food)
		{
			return (snake).Eat(food.Food);
		}

		/// <summary>
		/// 
		/// Игра продолжается до тех пор пока змейка 
		/// не столкнется с сенкой или своим хвостом
		/// 
		/// </summary>
		/// <param name="wall"> Сены на игровом поле </param>
		/// <param name="snake"> Змея на игровом поле </param>
		/// <returns></returns>
		private static bool IsGameOver(IHits wall, SnakeControllers snake)
		{
			return (wall).IsHit(snake.Snake)
				 || (snake.IsHitTail());
		}

		#endregion

		#region ---===   Manipulation Game Object   ===---

		/// <summary>
		/// 
		/// Создание игровых обьектов
		/// 
		/// </summary>
		/// <param name="gameObject"> Игровой объект </param>
		private static void CratedGameObject(params ICreated[] gameObject)
		{
			foreach (ICreated item in gameObject)
			{
				item.CreatedGameObject();
			}
		}

		/// <summary>
		/// 
		/// Отрисовка игровых обьектов 
		/// 
		/// </summary>
		/// <param name="gameObject"> Игровой объект </param>
		private static void DrawGameObject(params IDraw[] gameObject)
		{
			foreach (IDraw item in gameObject)
			{
				item.Draw();
			}
		}

		private	static void MoveGameObject(params IMoveble[] gameObject)
		{
			foreach (IMoveble item in gameObject)
			{
				item.Move();
			}
		}

		#endregion

		#region ---===   Private Method   ===---

		/// <summary>
		///  
		/// Обработка нажатий для продолжения игры
		/// 
		/// </summary>
		/// <param name="resource"> Ресурсы для отображения сообщений пользователю </param>
		/// <param name="culture"> Регион пользователя </param>
		/// <returns> Ожидаемую кнопку </returns>
		private static ConsoleKey ProcessingPressKey(ResourceManager resource, CultureInfo culture)
		{
			ConsoleKey key;

			while (true)
			{
				key = Console.ReadKey(true).Key;

				switch (key)
				{
					case ConsoleKey.Escape:
					case ConsoleKey.N:
					case ConsoleKey.Y:

						return key;

					default:

						WriteGameOver(resource, culture);

						continue;
				}
			}
		}

		/// <summary>
		/// 
		/// Отображение текста в укзанных координатах
		/// игрового поля
		/// 
		/// </summary>
		/// <param name="text"> Отображаемый текст </param>
		/// <param name="xOffset"> Cмещение по оси Х </param>
		/// <param name="yOffset"> Смещение по оси Y </param>
		static void WriteText(string text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}

		#endregion

		#region ---===   Message For User   ===

		/// <summary>
		/// 
		/// Надпись завершения игры
		/// 
		/// </summary>
		/// <param name="resource"> Ресурсы для отображения сообщений пользователю </param>
		/// <param name="culture"> Регион пользователя </param>
		static void WriteGameOver(ResourceManager resource, CultureInfo culture)
		{
			int xOffset = 25;
			int yOffset = 8;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(xOffset, yOffset++);

			WriteText($"{resource.GetString("LineGameOver", culture)}", xOffset, yOffset++);
			WriteText($"{resource.GetString("GameOver", culture)}", xOffset, yOffset++);
			WriteText($"{resource.GetString("LineGameOver", culture)}", xOffset, yOffset++);
			WriteText($"{resource.GetString("TryAgain_1", culture)}", xOffset - 5, yOffset++);
			WriteText($"{resource.GetString("TryAgain_2", culture)}", xOffset - 3, yOffset++);
		}

		#endregion
	}
}
#region ---===   Private Data   ===---

#endregion

#region ---===   Property   ===---

#endregion

#region ---===   Ctor   ===---

#endregion