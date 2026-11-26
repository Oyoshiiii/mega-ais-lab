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
            consoleView.DeleteEvent += OnDeleteEvent;

            consoleView.SortPercentOfSanityLossEvent += OnSortPercentOfSanityLossEvent;
            consoleView.SortPercentOfSanityLossDescendingEvent += OnSortPercentOfSanityLossDescendingEvent;

            logic.DataChanged += OnDataChanged;
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
