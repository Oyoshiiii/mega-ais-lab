using BusinessLogic;
using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public class MainPresenter
    {
        IMainView mainView;
        ILogic logic;

        public MainPresenter(IMainView mainView, ILogic logic)
        {
            this.mainView = mainView;
            this.logic = logic;

            mainView.GetAllBtnClickEvent += OnGetAllBtnClickEvent;
            mainView.GetByIdBtnClickEvent += OnGetByIdBtnClickEvent;
            mainView.AddBtnClickEvent += OnAddBtnClickEvent;
            mainView.ChangeBtnClickEvent += OnChangeBtnClickEvent;
            mainView.DeleteBtnClickEvent += OnDeleteBtnClickEvent;

            mainView.GroupByBodyPartClickEvent += OnGroupByBodyPartClickEvent;
            mainView.FindBuOriginBtnClickEvent += OnFindBuOriginBtnClickEvent;

            mainView.SortAscendingCheckedChangedEvent += OnSortAscendingCheckedChangedEvent;
            mainView.SortDescendingCheckedChangedEvent += OnSortDescendingCheckedChangedEvent;

            logic.DataChanged += OnDataChanged;
        }

        private void OnDataChanged(IEnumerable<Prosthesis> obj)
        {
            throw new NotImplementedException();
        }

        private void OnSortDescendingCheckedChangedEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnSortAscendingCheckedChangedEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnFindBuOriginBtnClickEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnGroupByBodyPartClickEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnDeleteBtnClickEvent(object sender, ProsthesisEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnChangeBtnClickEvent(object sender, ProsthesisEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnAddBtnClickEvent(object sender, ProsthesisEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnGetByIdBtnClickEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnGetAllBtnClickEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private List<ProsthesisDTO> ConvertToDTOProsthesesList(List<Prosthesis> prostheses)
        {
            List<ProsthesisDTO> prosthesesDTO = prostheses.Select(prosthesis => new ProsthesisDTO(
                prosthesis.Id,
                prosthesis.ModelName,
                prosthesis.BodyPart,
                prosthesis.PercentOfSanityLoss,
                prosthesis.DebuffDescription,
                prosthesis.BuffDescription,
                prosthesis.Origin
            )).ToList();

            return prosthesesDTO;
        }
    }
}
