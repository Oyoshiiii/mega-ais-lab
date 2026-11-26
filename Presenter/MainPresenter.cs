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
            mainView.DeleteBtnClickEvent += OnDeleteBtnClickEvent;

            mainView.SortAscendingCheckedChangedEvent += OnSortAscendingCheckedChangedEvent;
            mainView.SortDescendingCheckedChangedEvent += OnSortDescendingCheckedChangedEvent;

            logic.DataChanged += OnDataChanged;
        }

        private void OnSortDescendingCheckedChangedEvent()
        {
            mainView.RedrawForm(ConvertToDTOProsthesesList(logic.SortByPercentOfSanityLossDescending()));
        }

        private void OnSortAscendingCheckedChangedEvent()
        {
            mainView.RedrawForm(ConvertToDTOProsthesesList(logic.SortByPercentOfSanityLoss()));
        }

        private void OnDeleteBtnClickEvent(ProsthesisEventArgs e)
        {
            logic.DeleteProsthesis(e.Id);
        }

        private void OnGetAllBtnClickEvent()
        {
            mainView.RedrawForm(ConvertToDTOProsthesesList(logic.GetAllProstheses()));
        }

        private void OnDataChanged(IEnumerable<Prosthesis> prostheses)
        {
            mainView.RedrawForm(ConvertToDTOProsthesesList(prostheses.ToList()));
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
