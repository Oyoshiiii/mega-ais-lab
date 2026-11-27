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
        List<string> bodyParts = new List<string>();
        List<string> origin = new List<string>();

        public event Action<ProsthesisEventArgs> AddBtnClickEvent;
        public event Action GetAllBtnClickEvent;
        public event Action GetByIdBtnClickEvent;
        public event Action<ProsthesisEventArgs> ChangeBtnClickEvent;
        public event Action<ProsthesisEventArgs> DeleteBtnClickEvent;

        public event Action GroupByBodyPartClickEvent;
        public event Action<ProsthesisEventArgs> FindByOriginBtnClickEvent;

        public event Action SortAscendingCheckedChangedEvent;
        public event Action SortDescendingCheckedChangedEvent;

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
                        GetAllBtnClickEvent?.Invoke();
                        break;

                    case 2:
                        GetByIdBtnClickEvent?.Invoke();
                        break;

                    case 3:
                        var addArgs = ProsthesisDataForAdd();

                        if (addArgs != null)
                        {
                            AddBtnClickEvent?.Invoke(addArgs);
                        }

                        ShowMsg("\tПротез добавлен");
                        break;

                    case 4:
                        GetAllBtnClickEvent?.Invoke();

                        int idChange = GetSelectedProsthesisId();

                        if (idChange != -1)
                        {
                            var changeArgs = ProsthesisDataForChange(idChange);
                            if (changeArgs != null)
                            {
                                ChangeBtnClickEvent?.Invoke(changeArgs);
                            }
                        }

                        ShowMsg("\tИзменения сохранены");
                        break;

                    case 5:
                        GetAllBtnClickEvent?.Invoke();

                        int idDelete = GetSelectedProsthesisId();

                        if (idDelete != -1)
                        {
                            DeleteBtnClickEvent?.Invoke(new ProsthesisEventArgs(idDelete));
                        }

                        ShowMsg("\tПротез удален");
                        break;

                    case 6:
                        GroupByBodyPartClickEvent?.Invoke();
                        break;

                    case 7:
                        string origin = ChooseOriginFromList();
                        FindByOriginBtnClickEvent?.Invoke(new ProsthesisEventArgs(origin));
                        break;

                    case 8:
                        SortAscendingCheckedChangedEvent?.Invoke();
                        break;

                    case 9:
                        SortDescendingCheckedChangedEvent?.Invoke();
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

        public void RedrawView(List<ProsthesisDTO> prostheses)
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

        public int GetSelectedProsthesisId()
        {
            Console.Write("\nВведите ID протеза: ");
            int id = 0;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("\n\t\t!! Ошибка ввода, попробуйте снова\n\nВвод: ");
            }
            return id;
        }

        private ProsthesisEventArgs ProsthesisDataForAdd()
        {
            Console.Write("Введите название модели: ");
            string modelName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(modelName)) 
            { 
                ShowMsg("Название модели не может быть пустым"); 
                return null; 
            }

            Console.Write("Введите % потери рассудка от применения протеза (от 2 до 90): ");
            int percent = FullValidationCheck("\n\t\t% потери рассудка вне диапазона, попробуйте снова\n", 2, 90);

            Console.Write("Введите описание баффов: ");
            string buff = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(buff)) 
            { 
                ShowMsg("Описание баффов не может быть пустым"); 
                return null; 
            }

            Console.Write("Введите описание дебаффов: ");
            string debuff = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(debuff)) 
            { 
                ShowMsg("Описание дебаффов не может быть пустым"); 
                return null; 
            }

            string bodyPart = ChooseBodyPartFromList();
            if (bodyPart == null) return null;

            string origin = ChooseOriginFromList();
            if (origin == null) return null;

            return new ProsthesisEventArgs(modelName, bodyPart, percent, buff, debuff, origin);
        }

        private ProsthesisEventArgs ProsthesisDataForChange(int id)
        {
            Console.Write("Введите название модели: ");
            string modelName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(modelName)) 
            { 
                ShowMsg("Название модели не может быть пустым"); 
                return null; 
            }

            Console.Write("Введите % потери рассудка (от 2 до 90): ");
            int percent = FullValidationCheck("\n\t\t% потери рассудка вне диапазона, попробуйте снова\n", 2, 90);

            Console.Write("Введите описание баффов: ");
            string buff = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(buff)) 
            { 
                ShowMsg("Описание баффов не может быть пустым"); 
                return null;
            }

            Console.Write("Введите описание дебаффов: ");
            string debuff = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(debuff)) 
            { 
                ShowMsg("Описание дебаффов не может быть пустым"); 
                return null; 
            }

            string bodyPart = ChooseBodyPartFromList();
            if (bodyPart == null) return null;

            string origin = ChooseOriginFromList();
            if (origin == null) return null;

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

        public void LoadBodyPartsList(List<string> bodyParts)
        {
            this.bodyParts = bodyParts;
        }

        public void LoadOriginList(List<string> origin)
        {
            this.origin = origin;
        }

        public void ShowMsg(string msg)
        {
            Console.WriteLine("\n" + msg);
        }

        private string ChooseBodyPartFromList()
        {
            if (bodyParts == null || bodyParts.Count == 0)
            {
                ShowMsg("\tСписок частей тела пуст");
                return null;
            }

            Console.WriteLine("\nВыберите часть тела, на которую крепится протез или которую он заменяет:");
            for (int i = 0; i < bodyParts.Count; i++)
            {
                Console.WriteLine($"[{i + 1}.] {bodyParts[i]}");
            }
            Console.Write("Ввод: ");

            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return null;

            int choice;
            while (!int.TryParse(input, out choice) || choice < 1 || choice > bodyParts.Count)
            {
                Console.Write("\n\t\t!! Такого варианта ответа нет, попробуйте снова\nВвод: ");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) return null;
            }

            return bodyParts[choice - 1];
        }

        private string ChooseOriginFromList()
        {
            if (origin == null || origin.Count == 0)
            {
                ShowMsg("\tСписок локаций пуст");
                return null;
            }

            Console.WriteLine("\nВыберите локацию/место нахождения протеза:");
            for (int i = 0; i < origin.Count; i++)
            {
                Console.WriteLine($"[{i + 1}.] {origin[i]}");
            }
            Console.Write("Ввод: ");

            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return null;

            int choice;
            while (!int.TryParse(input, out choice) || choice < 1 || choice > origin.Count)
            {
                Console.Write("\n\t\t!! Такого варианта ответа нет, попробуйте снова\nВвод: ");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) return null;
            }

            return origin[choice - 1];
        }
    }
}
