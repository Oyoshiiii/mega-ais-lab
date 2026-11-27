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
    public partial class GroupedByBodyPartsForm : Form, IGroupedByBodyPartsView
    {
        /// <summary>
        /// конструктор формы отображения протезов, сгруппированных по частям тела
        /// </summary>
        public GroupedByBodyPartsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// метод перерисовки таблицы с сгруппированными протезами
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
        /// метод открытия формы
        /// </summary>
        public void ShowDialogView()
        {
            this.ShowDialog();
        }
    }
}
