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
        public event EventHandler<ProsthesisEventArgs> SearchBtnClickEvent;

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
                    pros.BuffDescription, pros.DebuffDescription, pros.Origin);
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string origin = CmbOrigin.SelectedItem?.ToString();

            if(!string.IsNullOrWhiteSpace(origin))
            {
                SearchBtnClickEvent?.Invoke(this, new ProsthesisEventArgs(origin));
            }
        }

        public void ShowDialogView()
        {
            this.ShowDialog();
        }
    }
}
