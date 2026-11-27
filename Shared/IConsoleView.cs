using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IConsoleView : IMainView
    {   
        /// <summary>
        /// получение выбора из главного меню
        /// </summary>
        /// <returns>номер выбранного пункта</returns>
        int GetMainMenuChoice();

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
