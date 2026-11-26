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
    public class ConsolePresenter
    {
        IConsoleView consoleView;
        ILogic logic;

        public ConsolePresenter(IConsoleView consoleView, ILogic logic)
        {
            this.consoleView = consoleView;
            this.logic = logic;

            consoleView.GetAllEvent += OnGetAllEvent;
            consoleView.GetByIdEvent += OnGetByIdEvent;
            consoleView.AddEvent += OnAddEvent;
            consoleView.ChangeEvent += OnChangeEvent;
            consoleView.DeleteEvent += OnDeleteEvent;

            consoleView.FindByOriginEvent += OnFindByOriginEvent;
            consoleView.GroupByAllBodyPartsEvent += OnGroupByAllBodyPartsEvent;

            consoleView.SortPercentOfSanityLossEvent += OnSortPercentOfSanityLossEvent;
            consoleView.SortPercentOfSanityLossDescendingEvent += OnSortPercentOfSanityLossDescendingEvent;

            logic.DataChanged += OnDataChanged;

            consoleView.LoadBodyPartsList(logic.GetBodyPartsList());
            consoleView.LoadOriginList(logic.GetOriginList());
        }

        private void OnGroupByAllBodyPartsEvent()
        {
            consoleView.RedrawConsole(ConvertToDTOProsthesesList(logic.GroupByAllBodyParts()));
        }

        private void OnFindByOriginEvent(ProsthesisEventArgs e)
        {
            consoleView.RedrawConsole(ConvertToDTOProsthesesList(logic.GroupBySpecificOrigin(e.Origin)));
        }

        private void OnChangeEvent(ProsthesisEventArgs e)
        {
            logic.ChangeProsthesis(e.Id, e.ModelName, e.BodyPart, e.PercentOfSanityLoss,
                e.BuffDescription, e.DebuffDescription, e.Origin);
        }

        private void OnAddEvent(ProsthesisEventArgs e)
        {
            logic.AddProsthesis(e.ModelName, e.BodyPart, e.PercentOfSanityLoss,
                e.BuffDescription, e.DebuffDescription, e.Origin);
        }

        private void OnGetByIdEvent()
        {
            int id = consoleView.GetSelectedIdProsthesis();
            var prosthesis = logic.GetProsthesisById(id);

            if (prosthesis == null)
            {
                return;
            }

            var prosDto = new ProsthesisDTO(prosthesis.Id, prosthesis.ModelName, prosthesis.BodyPart, prosthesis.PercentOfSanityLoss, 
                prosthesis.BuffDescription, prosthesis.DebuffDescription, prosthesis.Origin);
            
            consoleView.ShowProsthesis(prosDto);
        }

        private void OnSortPercentOfSanityLossDescendingEvent()
        {
            consoleView.RedrawConsole(ConvertToDTOProsthesesList(logic.SortByPercentOfSanityLossDescending()));
        }

        private void OnSortPercentOfSanityLossEvent()
        {
            consoleView.RedrawConsole(ConvertToDTOProsthesesList(logic.SortByPercentOfSanityLoss()));
        }

        private void OnGetAllEvent()
        {
            consoleView.RedrawConsole(ConvertToDTOProsthesesList(logic.GetAllProstheses()));
        }

        private void OnDeleteEvent(ProsthesisEventArgs e)
        {
            logic.DeleteProsthesis(e.Id);
        }

        private void OnDataChanged(IEnumerable<Prosthesis> prostheses)
        {
            consoleView.RedrawConsole(ConvertToDTOProsthesesList(prostheses.ToList()));
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
