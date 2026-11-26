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
        public event EventHandler SearchBtnClickEvent;

        /*Logic logic;
        List<Prosthesis> prostheses = new List<Prosthesis>();*/

        /*/// <summary>
        /// Инициализация формы поиска протезов по локации/месту нахождения
        /// </summary>
        /// <param name="logic">Экземпляр класса бизнес-логики <see cref="Logic"/></param>
        public FindByOriginForm(Logic logic)
        {
            InitializeComponent();
            this.logic = logic;
            CmbOrigin.DataSource = logic.GetOriginList();
        }*/

        public FindByOriginForm()
        {
            InitializeComponent();
        }

        public void LoadOriginList(List<string> origin)
        {
            CmbOrigin.DataSource = origin;
        }

        public void RedrawForm(List<ProsthesisDTO> prostheses)
        {
            prosthesesDataGridView.Rows.Clear();

            foreach(var pros in prostheses)
            {
                prosthesesDataGridView.Rows.Add(pros.Id, pros.ModelName, pros.BodyPart, pros.PercentOfSanityLoss,
                    pros.DebuffDescription, pros.BuffDescription, pros.Origin);
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            //prostheses = logic.GroupBySpecificOrigin(CmbOrigin.Text);
            //GetBySpecificOriginProstheses();

            //if(prostheses.Count == 0) MessageBox.Show("В этой локации нет протезов");

            string origin = CmbOrigin.SelectedItem?.ToString();

            if(origin != null && origin != "")
            {
                SearchBtnClickEvent?.Invoke(this, new ProsthesisEventArgs(origin));
            }
        }

        /*private void GetBySpecificOriginProstheses()
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
