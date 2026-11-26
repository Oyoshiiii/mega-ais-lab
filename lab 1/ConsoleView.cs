using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    public class ConsoleView : IConsoleView
    {
        public event Action<ProsthesisEventArgs> AddEvent;
        public event Action GetAllEvent;
        public event Action GetByIdEvent;
        public event Action<ProsthesisEventArgs> ChangeEvent;
        public event Action<ProsthesisEventArgs> DeleteEvent;

        public event Action GroupByAllBodyPartsEvent;
        public event Action<ProsthesisEventArgs> FindByOriginEvent;

        public event Action SortPercentOfSanityLossEvent;
        public event Action SortPercentOfSanityLossDescendingEvent;

        public void ConsoleMain()
        {
            bool worked = true;
            while (worked)
            {
                ShowMainMenu();
                int choice = GetMainMenuChoice();

                switch (choice)
                {
                    case 1:
                        GetAllEvent?.Invoke();
                        break;

                    case 2:
                        GetByIdEvent?.Invoke();
                        break;

                    case 3:
                        var addArgs = CollectProsthesisDataForAdd();

                        if (addArgs != null)
                        {
                            AddEvent?.Invoke(addArgs);
                        }
                        break;

                    case 4:
                        int idChange = GetSelectedIdProsthesis();

                        if (idChange != -1)
                        {
                            var changeArgs = CollectProsthesisDataForChange(idChange);
                            if (changeArgs != null)
                            {
                                ChangeEvent?.Invoke(changeArgs);
                            }
                        }
                        break;

                    case 5:
                        int idDelete = GetSelectedIdProsthesis();

                        if (idDelete != -1)
                        {
                            DeleteEvent?.Invoke(new ProsthesisEventArgs(idDelete));
                        }
                        break;

                    case 6:
                        GroupByAllBodyPartsEvent?.Invoke();
                        break;

                    case 7:
                        Console.Write("Введите локацию: ");
                        string origin = Console.ReadLine();

                        FindByOriginEvent?.Invoke(new ProsthesisEventArgs(origin));
                        break;

                    case 8:
                        SortPercentOfSanityLossEvent?.Invoke();
                        break;

                    case 9:
                        SortPercentOfSanityLossDescendingEvent?.Invoke();
                        break;

                    case 10:
                        worked = false;
                        break;
                }

                if (worked)
                {
                    Console.WriteLine("\n\tНажмите любую клавишу, чтобы продолжить ->");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("\x1b[3J");
                }
            }

            Console.WriteLine("\n\tВыход из консоли ->");
            Console.ReadKey();
        }

        public void ShowMainMenu()
        {
            Console.Write("[1.] Вывести все протезы\n" +
                "[2.] Вывести протез по Id\n" +
                "[3.] Добавить протез\n" +
                "[4.] Изменить протез\n" +
                "[5.] Удалить протез\n" +
                "[6.] Группировать по расположению на теле и вывести все протезы\n" +
                "[7.] Поиск по местам нахождения протезов\n" +
                "[8.] Сортировать по % потери рассудка по убыванию\n" +
                "[9.] Сортировать по % потери рассудка по возрастанию\n" +
                "[10.] Выход\n\n" +
                "Ввод: ");

        }

        public int GetMainMenuChoice()
        {
            int userChoice = 0;
            while (!int.TryParse(Console.ReadLine(), out userChoice))
            {
                Console.Write("\n\t\t!! Ошибка ввода, попробуйте снова\n\nВвод: ");
            }

            return userChoice;
        }

        public void RedrawConsole(List<ProsthesisDTO> prostheses)
        {
            foreach (var p in prostheses)
            {
                Console.WriteLine("\n----------------------------------------------------------\n" +
                    "ID: " + p.Id + "\nМодель: " + p.ModelName + "\n% потери рассудка: " + p.PercentOfSanityLoss + "%\nЧасть тела: " +
                    p.BodyPart + "\nБаффы: " + p.BuffDescription + "\nДебаффы: " + p.DebuffDescription + "\nЛокация/место нахождения: " + p.Origin +
                    "\n----------------------------------------------------------\n");
            }
        }

        public void ShowProsthesis(ProsthesisDTO prosthesis)
        {
            Console.WriteLine("\n----------------------------------------------------------\n" +
                "ID: " + prosthesis.Id + "\nМодель: " + prosthesis.ModelName + "\n% потери рассудка: " + prosthesis.PercentOfSanityLoss + "%\nЧасть тела: " +
                prosthesis.BodyPart + "\nБаффы: " + prosthesis.BuffDescription + "\nДебаффы: " + prosthesis.DebuffDescription + "\nЛокация/место нахождения: " + prosthesis.Origin +
                "\n----------------------------------------------------------\n");
        }

        public int GetSelectedIdProsthesis()
        {
            Console.Write("\nВведите ID протеза: ");
            int id = 0;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("\n\t\t!! Ошибка ввода, попробуйте снова\n\nВвод: ");
            }
            return id;
        }

        private ProsthesisEventArgs CollectProsthesisDataForAdd()
        {
            Console.Write("Введите название модели: ");
            string modelName = Console.ReadLine();

            Console.Write("Введите % потери рассудка от применения протеза (от 2 до 90): ");
            int percent = FullValidationCheck("\n\t\t% потери рассудка вне диапазона, попробуйте снова\n", 2, 90);

            Console.Write("Введите описание баффов: ");
            string buff = Console.ReadLine();

            Console.Write("Введите описание дебаффов: ");
            string debuff = Console.ReadLine();

            Console.Write("Введите локацию/место нахождения: ");
            string origin = Console.ReadLine();

            Console.Write("Введите часть тела: ");
            string bodyPart = Console.ReadLine();

            return new ProsthesisEventArgs(modelName, bodyPart, percent, buff, debuff, origin);
        }

        private ProsthesisEventArgs CollectProsthesisDataForChange(int id)
        {
            Console.Write("Введите название модели: ");
            string modelName = Console.ReadLine();

            Console.Write("Введите % потери рассудка (от 2 до 90): ");
            int percent = FullValidationCheck("\n\t\t% потери рассудка вне диапазона, попробуйте снова\n", 2, 90);

            Console.Write("Введите описание баффов: ");
            string buff = Console.ReadLine();

            Console.Write("Введите описание дебаффов: ");
            string debuff = Console.ReadLine();

            Console.Write("Введите локацию/место нахождения: ");
            string origin = Console.ReadLine();

            Console.Write("Введите часть тела: ");
            string bodyPart = Console.ReadLine();

            return new ProsthesisEventArgs(id, modelName, bodyPart, percent, buff, debuff, origin);
        }

        private int FullValidationCheck(string msg, int minVal, int maxVal)
        {
            int result = 0;
            bool valid = false;

            while (!valid)
            {
                if (!int.TryParse(Console.ReadLine(), out result))
                {
                    Console.WriteLine("\n\t\t!! Ошибка ввода, попробуйте снова\n");
                    continue;
                }
                if (result < minVal || result > maxVal)
                {
                    Console.WriteLine(msg);
                    continue;
                }
                valid = true;
            }
            return result;
        }
    }
}
