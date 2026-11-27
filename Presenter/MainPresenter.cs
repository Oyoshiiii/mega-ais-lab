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

        /// <summary>
        /// конструктор основного презентера 
        /// </summary>
        /// <param name="mainView">основное представление</param>
        /// <param name="logic">бизнес логика</param>
        public MainPresenter(IMainView mainView, ILogic logic)
        {
            this.mainView = mainView;
            this.logic = logic;

            this.mainView.GetAllBtnClickEvent += OnGetAllBtnClickEvent;
            this.mainView.GetByIdBtnClickEvent += OnGetByIdBtnClickEvent;
            this.mainView.AddBtnClickEvent += OnAddBtnClickEvent;
            this.mainView.ChangeBtnClickEvent += OnChangeBtnClickEvent;
            this.mainView.DeleteBtnClickEvent += OnDeleteBtnClickEvent;

            this.mainView.GroupByBodyPartClickEvent += OnGroupByBodyPartClickEvent;
            this.mainView.FindByOriginBtnClickEvent += OnFindByOriginBtnClickEvent;

            this.mainView.SortAscendingCheckedChangedEvent += OnSortAscendingCheckedChangedEvent;
            this.mainView.SortDescendingCheckedChangedEvent += OnSortDescendingCheckedChangedEvent;

            logic.DataChanged += OnDataChanged;
        }

        private void OnGetByIdBtnClickEvent()
        {
            int id = mainView.GetSelectedProsthesisId();

            var prosthesis = logic.GetProsthesisById(id);
            if (prosthesis == null)
            {
                if (mainView is IConsoleView consView)
                {
                    consView.ShowMsg($"Протез с ID = {id} не найден");
                }
                return;
            }

            var prosDto = new ProsthesisDTO(prosthesis.Id, prosthesis.ModelName, prosthesis.BodyPart,
                prosthesis.PercentOfSanityLoss, prosthesis.BuffDescription, prosthesis.DebuffDescription, prosthesis.Origin);

            if (mainView is IConsoleView consoleView)
            {
                consoleView.ShowProsthesis(prosDto);
            }
        }

        private void OnChangeBtnClickEvent(ProsthesisEventArgs args)
        {
            if (args != null && !string.IsNullOrEmpty(args.ModelName))
            {
                logic.ChangeProsthesis(args.Id, args.ModelName, args.BodyPart, args.PercentOfSanityLoss,
                    args.BuffDescription, args.DebuffDescription, args.Origin);
            }
        }

        private void OnFindByOriginBtnClickEvent(ProsthesisEventArgs args)
        {
            if (args != null && !string.IsNullOrEmpty(args.Origin))
            {
                mainView.RedrawView(ConvertToDTOProsthesesList(logic.GroupBySpecificOrigin(args.Origin)));
            }
        }

        private void OnGroupByBodyPartClickEvent()
        {
            mainView.RedrawView(ConvertToDTOProsthesesList(logic.GroupByAllBodyParts()));
        }

        private void OnAddBtnClickEvent(ProsthesisEventArgs args)
        {
            if (args != null && !string.IsNullOrEmpty(args.ModelName))
            {
                logic.AddProsthesis(args.ModelName, args.BodyPart, args.PercentOfSanityLoss,
                    args.BuffDescription, args.DebuffDescription, args.Origin);
            }
        }

        private void OnSortDescendingCheckedChangedEvent()
        {
            mainView.RedrawView(ConvertToDTOProsthesesList(logic.SortByPercentOfSanityLossDescending()));
        }

        private void OnSortAscendingCheckedChangedEvent()
        {
            mainView.RedrawView(ConvertToDTOProsthesesList(logic.SortByPercentOfSanityLoss()));
        }

        private void OnDeleteBtnClickEvent(ProsthesisEventArgs e)
        {
            logic.DeleteProsthesis(e.Id);
        }

        private void OnGetAllBtnClickEvent()
        {
            mainView.RedrawView(ConvertToDTOProsthesesList(logic.GetAllProstheses()));
        }

        private void OnDataChanged(IEnumerable<Prosthesis> prostheses)
        {
            mainView.RedrawView(ConvertToDTOProsthesesList(prostheses.ToList()));
        }


        private List<ProsthesisDTO> ConvertToDTOProsthesesList(List<Prosthesis> prostheses)
        {
            List<ProsthesisDTO> prosthesesDTO = prostheses.Select(prosthesis => new ProsthesisDTO(
                prosthesis.Id,
                prosthesis.ModelName,
                prosthesis.BodyPart,
                prosthesis.PercentOfSanityLoss,
                prosthesis.BuffDescription,
                prosthesis.DebuffDescription,
                prosthesis.Origin
            )).ToList();

            return prosthesesDTO;
        }
    }
}
