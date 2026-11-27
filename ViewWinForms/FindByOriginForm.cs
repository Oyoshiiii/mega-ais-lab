using Shared;
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
    public partial class FindByOriginForm : Form, IFindByOriginView
    {
        /// <summary>
        /// событие при нажатии кнопки поиска протезов по локации
        /// </summary>
        public event Action<ProsthesisEventArgs> SearchBtnClickEvent;

        /// <summary>
        /// конструктор формы поиска по локации
        /// </summary>
        public FindByOriginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// метод загрузки листа с локациями протезов
        /// </summary>
        /// <param name="origin">лист локаций</param>
        public void LoadOriginList(List<string> origin)
        {
            CmbOrigin.DataSource = origin;
        }

        /// <summary>
        /// метод перерисовки таблицы с найденными протезами
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


        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string origin = CmbOrigin.SelectedItem?.ToString();

            if(!string.IsNullOrWhiteSpace(origin))
            {
                SearchBtnClickEvent?.Invoke(new ProsthesisEventArgs(origin));
            }
        }

        /// <summary>
        /// метод открытия формы
        /// </summary>
        public void ShowDialogView()
        {
            this.ShowDialog();
        }
    }
}
