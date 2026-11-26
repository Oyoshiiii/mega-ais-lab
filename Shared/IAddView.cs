using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IAddView
    {
        /// <summary>
        /// событие при нажатии кнопки сохранения данных о добавляемом протезе
        /// </summary>
        event EventHandler<ProsthesisEventArgs> SaveBtnClickEvent;

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
