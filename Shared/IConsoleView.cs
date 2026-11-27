using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IConsoleView
    {
        /// <summary>
        /// событие добавления протеза
        /// </summary>
        event Action<ProsthesisEventArgs> AddEvent;
        /// <summary>
        /// событие запроса на вывод всех протезов
        /// </summary>
        event Action GetAllEvent;
        /// <summary>
        /// событие запроса на вывод протеза по ID
        /// </summary>
        event Action GetByIdEvent;
        /// <summary>
        /// событие изменения протеза
        /// </summary>
        event Action<ProsthesisEventArgs> ChangeEvent;
        /// <summary>
        /// событие удаления протеза
        /// </summary>
        event Action<ProsthesisEventArgs> DeleteEvent;

        /// <summary>
        /// событие группировки по всем частям тела
        /// </summary>
        event Action GroupByAllBodyPartsEvent;
        /// <summary>
        /// событие поиска по локации
        /// </summary>
        event Action<ProsthesisEventArgs> FindByOriginEvent;

        /// <summary>
        /// событие сортировки по возрастанию % потери рассудка
        /// </summary>
        event Action SortPercentOfSanityLossEvent;
        /// <summary>
        /// событие сортировки по убыванию % потери рассудка
        /// </summary>
        event Action SortPercentOfSanityLossDescendingEvent;

        /// <summary>
        /// перерисовка консоли
        /// </summary>
        /// <param name="prostheses">список протезов для вывода</param>
        void RedrawConsole(List<ProsthesisDTO> prostheses);

        /// <summary>
        /// получение выбора из главного меню
        /// </summary>
        /// <returns>номер выбранного пункта</returns>
        int GetMainMenuChoice();
        /// <summary>
        /// получение ID выбранного протеза
        /// </summary>
        /// <returns>ID протеза или -1 при отмене</returns>
        int GetSelectedIdProsthesis();

        /// <summary>
        /// вывод сообщения в консоль
        /// </summary>
        /// <param name="msg">текст сообщения</param>
        void ShowMsg(string msg);
        /// <summary>
        /// вывод главного меню
        /// </summary>
        void ShowMainMenu();
        /// <summary>
        /// вывод одного протеза
        /// </summary>
        /// <param name="prosthesis">DTO протеза</param>
        void ShowProsthesis(ProsthesisDTO prosthesis);

        /// <summary>
        /// запуск основного цикла консольного приложения
        /// </summary>
        void ConsoleMain();

        /// <summary>
        /// загрузка списка частей тела
        /// </summary>
        /// <param name="bodyParts">список частей тела</param>
        void LoadBodyPartsList(List<string> bodyParts);
        /// <summary>
        /// загрузка списка локаций
        /// </summary>
        /// <param name="origin">список локаций</param>
        void LoadOriginList(List<string> origin);
    }
}
