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
        public event Action GetAllBtnClickEvent;
        public event Action GetByIdBtnClickEvent;
        public event Action AddBtnClickEvent;
        public event Action<ProsthesisEventArgs> ChangeBtnClickEvent;
        public event Action<ProsthesisEventArgs> DeleteBtnClickEvent;
        public event Action SortAscendingCheckedChangedEvent;
        public event Action SortDescendingCheckedChangedEvent;
        public event Action GroupByBodyPartClickEvent;
        public event Action FindBuOriginBtnClickEvent;

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
