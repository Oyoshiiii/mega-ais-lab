using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IChangeView : IView 
    {
        /// <summary>
        /// событие при нажатии кнопки сохранения изменений данных изменяемого протеза
        /// </summary>
        event Action<ProsthesisEventArgs> SaveBtnClickEvent;

        /// <summary>
        /// метод загрузки данных изменяемого протеза
        /// </summary>
        /// <param name="prosthesis"></param>
        void LoadChangedProsthesisData(ProsthesisDTO prosthesis);
        /// <summary>
        /// метод загрузки листа с частями тела протезов
        /// </summary>
        /// <param name="bodyParts">лист частей тела</param>
        void LoadBodyPartsList(List<string> bodyParts);
        /// <summary>
        /// метод загрузки листа с локациями протезов
        /// </summary>
        /// <param name="origin">лист локаций</param>
        void LoadOriginList(List<string> origin);

        /// <summary>
        /// метод закрытия формы
        /// </summary>
        void CloseView();
    }
}
