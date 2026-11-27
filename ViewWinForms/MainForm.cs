using Shared;
using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewWinForms
{
    public partial class MainForm : Form, IMainView
    {
        /// <summary>
        /// событие при нажатии кнопки вывода всех протезов
        /// </summary>
        public event Action GetAllBtnClickEvent;
        /// <summary>
        /// событие при нажатии кнопки поиска протеза по ID
        /// </summary>
        public event Action GetByIdBtnClickEvent;
        /// <summary>
        /// событие при нажатии кнопки добавления протеза
        /// </summary>
        public event Action AddBtnClickEvent;
        /// <summary>
        /// событие при нажатии кнопки изменения выбранного протеза
        /// </summary>
        public event Action<ProsthesisEventArgs> ChangeBtnClickEvent;
        /// <summary>
        /// событие при нажатии кнопки удаления выбранного протеза
        /// </summary>
        public event Action<ProsthesisEventArgs> DeleteBtnClickEvent;

        /// <summary>
        /// событие при выборе сортировки по возрастанию % потери рассудка
        /// </summary>
        public event Action SortAscendingCheckedChangedEvent;
        /// <summary>
        /// событие при выборе сортировки по убыванию % потери рассудка
        /// </summary>
        public event Action SortDescendingCheckedChangedEvent;

        /// <summary>
        /// событие при нажатии кнопки группировки по частям тела
        /// </summary>
        public event Action GroupByBodyPartClickEvent;
        /// <summary>
        /// событие при нажатии кнопки поиска по локации
        /// </summary>
        public event Action FindBuOriginBtnClickEvent;

        /// <summary>
        /// конструктор главной формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        private void GetAllBtn_Click(object sender, EventArgs e)
        {
            GetAllBtnClickEvent?.Invoke();
        }

        private void GetByIDBtn_Click(object sender, EventArgs e)
        {
            GetByIdBtnClickEvent?.Invoke();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            AddBtnClickEvent?.Invoke();
        }

        private void ChangeBtn_Click(object sender, EventArgs e)
        {
            int id = GetSelectedProsthesisId();

            if (id != -1)
            {
                ChangeBtnClickEvent?.Invoke(new ProsthesisEventArgs(id));
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            int id = GetSelectedProsthesisId();

            if (id != -1)
            {
                DeleteBtnClickEvent?.Invoke(new ProsthesisEventArgs(id));
            }
        }

        private void ascending_CheckedChanged(object sender, EventArgs e)
        {
            SortAscendingCheckedChangedEvent?.Invoke();
        }

        private void descending_CheckedChanged(object sender, EventArgs e)
        {
            SortDescendingCheckedChangedEvent?.Invoke();
        }

        private void GroupByBodyPart_Click(object sender, EventArgs e)
        {
            GroupByBodyPartClickEvent?.Invoke();
        }

        private void FindByOriginBtn_Click(object sender, EventArgs e)
        {
            FindBuOriginBtnClickEvent?.Invoke();
        }

        /// <summary>
        /// метод перерисовки таблицы с протезами
        /// </summary>
        /// <param name="prostheses">лист DTO протезов для отображения</param>
        public void RedrawForm(List<ProsthesisDTO> prostheses)
        {
            prosthesesDataGridView.Rows.Clear();

            foreach (var pros in prostheses)
            {
                prosthesesDataGridView.Rows.Add(pros.Id, pros.ModelName, pros.BodyPart, pros.PercentOfSanityLoss,
                    pros.BuffDescription, pros.DebuffDescription, pros.Origin);
            }
        }

        /// <summary>
        /// метод получения ID выбранного в таблице протеза
        /// </summary>
        /// <returns>ID выбранного протеза или -1, если ничего не выбрано</returns>
        public int GetSelectedProsthesisId()
        {
            if (prosthesesDataGridView.SelectedRows.Count == 0) return -1;
            return Convert.ToInt32(prosthesesDataGridView.SelectedRows[0].Cells["Id"].Value);
        }
    }
}
