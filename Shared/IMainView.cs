using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IMainView
    {
        /// <summary>
        /// Событие при нажатии кнопки получения всех протезов
        /// </summary>
        event EventHandler GetAllBtnClickEvent;
        /// <summary>
        /// событие при нажатии кнопки получения протеза по ID
        /// </summary>
        event EventHandler GetByIdBtnClickEvent;
        /// <summary>
        /// событие при нажатии кнопки добавления протеза
        /// </summary>
        event EventHandler AddBtnClickEvent;
        /// <summary>
        /// событие при нажатии кнопки изменения протеза
        /// </summary>
        event EventHandler<ProsthesisEventArgs> ChangeBtnClickEvent;
        /// <summary>
        /// событие при нажатии кнопки удаления протеза
        /// </summary>
        event EventHandler<ProsthesisEventArgs> DeleteBtnClickEvent;

        /// <summary>
        /// событие при выборе радиобатона сортировки по возрастанию
        /// </summary>
        event EventHandler SortAscendingCheckedChangedEvent;
        /// <summary>
        /// событие при выборе радиобатона сортировки по убыванию 
        /// </summary>
        event EventHandler SortDescendingCheckedChangedEvent;

        /// <summary>
        /// событие при нажатии кнопки группировки протезов по частям тела
        /// </summary>
        event EventHandler GroupByBodyPartClickEvent;
        /// <summary>
        /// событие при нажатии кнопки поиска протезов по определенной локации
        /// </summary>
        event EventHandler FindBuOriginBtnClickEvent;

        /// <summary>
        /// метод отрисовки формы с обновленными данными
        /// </summary>
        /// <param name="prostheses">лист протезов</param>
        void RedrawForm(List<ProsthesisDTO> prostheses);
        /// <summary>
        /// метод получения ID выбранного протеза в таблице
        /// </summary>
        /// <returns>выбранный ID</returns>
        int GetSelectedProsthesisId();
    }
}
