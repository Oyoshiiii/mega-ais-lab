using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IFindByOriginView : IView
    {
        /// <summary>
        /// событие при нажатии кнопки поиск протезов по локации
        /// </summary>
        event Action<ProsthesisEventArgs> SearchBtnClickEvent;

        /// <summary>
        /// метод загрузки листа с локациями протезов
        /// </summary>
        /// <param name="origin">лист локаций</param>
        void LoadOriginList(List<string> origin);

        /// <summary>
        /// метод отрисовки формы с обновленными данными
        /// </summary>
        /// <param name="prostheses">лист протезов</param>
        void RedrawForm(List<ProsthesisDTO> prostheses);
    }
}
