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
        public event EventHandler GetAllBtnClickEvent;
        public event EventHandler GetByIdBtnClickEvent;
        public event EventHandler AddBtnClickEvent;
        public event EventHandler<ProsthesisEventArgs> ChangeBtnClickEvent;
        public event EventHandler<ProsthesisEventArgs> DeleteBtnClickEvent;
        public event EventHandler SortAscendingCheckedChangedEvent;
        public event EventHandler SortDescendingCheckedChangedEvent;
        public event EventHandler GroupByBodyPartClickEvent;
        public event EventHandler FindBuOriginBtnClickEvent;

        public MainForm()
        {
            InitializeComponent();
        }

        private void GetAllBtn_Click(object sender, EventArgs e)
        {
            GetAllBtnClickEvent?.Invoke(this, EventArgs.Empty);
        }

        private void GetByIDBtn_Click(object sender, EventArgs e)
        {
            GetByIdBtnClickEvent?.Invoke(this, EventArgs.Empty);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            AddBtnClickEvent?.Invoke(this, EventArgs.Empty);
        }

        private void ChangeBtn_Click(object sender, EventArgs e)
        {
            int id = GetSelectedProsthesisId();

            if (id != -1)
            {
                ChangeBtnClickEvent?.Invoke(this, new ProsthesisEventArgs(id));
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            int id = GetSelectedProsthesisId();

            if (id != -1)
            {
                DeleteBtnClickEvent?.Invoke(this, new ProsthesisEventArgs(id));
            }
        }

        private void ascending_CheckedChanged(object sender, EventArgs e)
        {
            SortAscendingCheckedChangedEvent?.Invoke(this, EventArgs.Empty);
        }

        private void descending_CheckedChanged(object sender, EventArgs e)
        {
            SortDescendingCheckedChangedEvent?.Invoke(this, EventArgs.Empty);
        }

        private void GroupByBodyPart_Click(object sender, EventArgs e)
        {
            GroupByBodyPartClickEvent?.Invoke(this, EventArgs.Empty);
        }

        private void FindByOriginBtn_Click(object sender, EventArgs e)
        {
            FindBuOriginBtnClickEvent?.Invoke(this, EventArgs.Empty);
        }

        public void RedrawForm(List<ProsthesisDTO> prostheses)
        {
            prosthesesDataGridView.Rows.Clear();

            foreach (var pros in prostheses)
            {
                prosthesesDataGridView.Rows.Add(pros.Id, pros.ModelName, pros.BodyPart, pros.PercentOfSanityLoss,
                    pros.BuffDescription, pros.DebuffDescription, pros.Origin);
            }
        }

        public int GetSelectedProsthesisId()
        {
            if (prosthesesDataGridView.SelectedRows.Count == 0) return -1;
            return Convert.ToInt32(prosthesesDataGridView.SelectedRows[0].Cells["Id"].Value);
        }
    }
}
