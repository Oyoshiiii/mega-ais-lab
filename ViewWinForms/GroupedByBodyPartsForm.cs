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
        //List<Prosthesis> prostheses = new List<Prosthesis>();

        /*/// <summary>
        /// Инициализация формы группировки протезов по всем частям тела
        /// </summary>
        /// <param name="logic">Экземпляр класса бизнес-логики <see cref="Logic"/></param>
        public GroupedByBodyPartsForm(Logic logic)
        {
            InitializeComponent();

            prostheses = logic.GroupByAllBodyParts();
            GetGroupedProstheses();
        }*/

        public GroupedByBodyPartsForm()
        {
            InitializeComponent();
        }

        public void RedrawForm(List<ProsthesisDTO> prostheses)
        {
            prosthesesDataGridView.Rows.Clear();

            foreach (var pros in prostheses)
            {
                prosthesesDataGridView.Rows.Add(pros.Id, pros.ModelName, pros.BodyPart, pros.PercentOfSanityLoss,
                    pros.DebuffDescription, pros.BuffDescription, pros.Origin);
            }
        }

        /*private void GetGroupedProstheses()
        {
            prosthesesDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            prosthesesDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            prosthesesDataGridView.Rows.Clear();

            foreach (Prosthesis prosthesis in prostheses)
            {
                prosthesesDataGridView.Rows.Add(
                    prosthesis.Id,
                    prosthesis.ModelName,
                    prosthesis.BodyPart,
                    prosthesis.PercentOfSanityLoss,
                    prosthesis.BuffDescription,
                    prosthesis.DebuffDescription,
                    prosthesis.Origin
                );
            }
        }*/
    }
}
