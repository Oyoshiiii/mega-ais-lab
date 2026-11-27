using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface ISearchByIdView : IView
    {
        /// <summary>
        /// событие нажатия кнопки поиска
        /// </summary>
        event Action<ProsthesisEventArgs> SearchBtnCLickEvent;

        /// <summary>
        /// отображение найденного протеза
        /// </summary>
        /// <param name="prosthesis">DTO найденного протеза</param>
        void ShowFoundProsthesis(ProsthesisDTO prosthesis);
        /// <summary>
        /// отображение сообщения, что протез не найден
        /// </summary>
        /// <param name="msg">текст сообщения</param>
        void ShowNotFoundProsthesis(string msg);
    }
}
