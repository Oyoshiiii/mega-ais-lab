using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewWinForms
{
    public partial class AddForm : Form, IAddView
    {
        public event Action<ProsthesisEventArgs> SaveBtnClickEvent;
        public AddForm()
        {
            InitializeComponent();
        }

        private void TxtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtModelName.Text))
            {
                MessageBox.Show("Введите название модели");
                TxtModelName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtBuffDescript.Text))
            {
                MessageBox.Show("Введите баффы протеза");
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtDebuffDescript.Text))
            {
                MessageBox.Show("Введите дебаффы протеза");
                return;
            }

            string ModelName = TxtModelName.Text.Trim();
            string BodyPart = CmbBodyPart.SelectedItem.ToString();
            int PercentOfSanityLoss = (int)NumPercentOfSanityLoss.Value;
            string BuffDescription = TxtBuffDescript.Text.Trim();
            string DebuffDescription = TxtDebuffDescript.Text.Trim();
            string Origin = CmbOrigin.SelectedItem.ToString();

            var prosthesisArgs = new ProsthesisEventArgs(ModelName, BodyPart, PercentOfSanityLoss, BuffDescription, DebuffDescription, Origin);
            SaveBtnClickEvent?.Invoke(prosthesisArgs);

            MessageBox.Show("Протез добавлен");
        }

        public void LoadBodyPartsList(List<string> bodyParts)
        {
            CmbBodyPart.DataSource = bodyParts;
        }

        public void LoadOriginList(List<string> origin)
        {
            CmbOrigin.DataSource = origin;
        }

        public void ShowDialogView()
        {
            this.ShowDialog();
        }

        public void CloseView()
        {
            this.Close();
        }
    }
}
