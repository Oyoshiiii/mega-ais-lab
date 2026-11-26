using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IConsoleView
    {
        event EventHandler<ProsthesisEventArgs> AddEvent;
        event EventHandler GetAllEvent;
        event EventHandler GetByIdEvent;
        event EventHandler<ProsthesisEventArgs> ChangeEvent;
        event EventHandler<ProsthesisEventArgs> DeleteEvent;

        event EventHandler GroupByAllBodyPartsEvent;
        event EventHandler FindByOriginEvent;

        event EventHandler SortPercentOfSanityLossEvent;
        event EventHandler SortPercentOfSanityLossDescendingEvent;

        void RedrawConsole(List<ProsthesisDTO> prostheses);

        int ShowMainMenuGetMainMenuChoice();
        void ShowProsthesis(ProsthesisDTO prosthesis);

        int GetSelectedIdProsthesis();
    }
}
