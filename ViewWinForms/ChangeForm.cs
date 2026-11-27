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
    public partial class ChangeForm : Form, IChangeView
    {
        /// <summary>
        /// событие при нажатии кнопки сохранения изменённых данных о протезе
        /// </summary>
        public event Action<ProsthesisEventArgs> SaveBtnClickEvent;

        /// <summary>
        /// конструктор формы изменения протеза
        /// </summary>
        public ChangeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// метод закрытия формы
        /// </summary>
        public void CloseView()
        {
            this.Close();
        }

        /// <summary>
        /// метод загрузки листа с частями тела протезов
        /// </summary>
        /// <param name="bodyParts">лист частей тела</param>
        public void LoadBodyPartsList(List<string> bodyParts)
        {
            CmbBodyPart.DataSource = bodyParts;
        }

        /// <summary>
        /// метод заполнения полей формы текущими данными изменяемого протеза
        /// </summary>
        /// <param name="prosthesis">DTO с данными изменяемого протеза</param>
        public void LoadChangedProsthesisData(ProsthesisDTO prosthesis)
        {
            TxtID.Text = prosthesis.Id.ToString();
            TxtModelName.Text = prosthesis.ModelName;
            CmbBodyPart.SelectedItem = prosthesis.BodyPart;
            NumPercentOfSanityLoss.Value = prosthesis.PercentOfSanityLoss;
            TxtBuffDescript.Text = prosthesis.BuffDescription;
            TxtDebuffDescript.Text = prosthesis.DebuffDescription;
            CmbOrigin.SelectedItem = prosthesis.Origin;
        }

        /// <summary>
        /// метод загрузки листа с локациями протезов
        /// </summary>
        /// <param name="origin">лист локаций</param>
        public void LoadOriginList(List<string> origin)
        {
            CmbOrigin.DataSource = origin;
        }


        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtModelName.Text))
            {
                MessageBox.Show("Введите название модели");
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

            int Id = Convert.ToInt32(TxtID.Text);
            string ModelName = TxtModelName.Text.Trim();
            string BodyPart = CmbBodyPart.SelectedItem.ToString();
            int PercentOfSanityLoss = (int)NumPercentOfSanityLoss.Value;
            string BuffDescription = TxtBuffDescript.Text.Trim();
            string DebuffDescription = TxtDebuffDescript.Text.Trim();
            string Origin = CmbOrigin.SelectedItem.ToString();

            var prosthesisArgs = new ProsthesisEventArgs(Id, ModelName, BodyPart, PercentOfSanityLoss, BuffDescription, DebuffDescription, Origin);
            SaveBtnClickEvent?.Invoke(prosthesisArgs);

            MessageBox.Show("Изменения сохранены");
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
