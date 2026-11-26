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

        private void OnSortPercentOfSanityLossEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnSortPercentOfSanityLossDescendingEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnDeleteEvent(object sender, ProsthesisEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnGetAllEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnDataChanged(IEnumerable<Prosthesis> obj)
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
