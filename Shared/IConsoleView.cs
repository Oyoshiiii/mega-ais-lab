using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IConsoleView
    {
        event Action<ProsthesisEventArgs> AddEvent;
        event Action GetAllEvent;
        event Action GetByIdEvent;
        event Action<ProsthesisEventArgs> ChangeEvent;
        event Action<ProsthesisEventArgs> DeleteEvent;

        event Action GroupByAllBodyPartsEvent;
        event Action<ProsthesisEventArgs> FindByOriginEvent;

        event Action SortPercentOfSanityLossEvent;
        event Action SortPercentOfSanityLossDescendingEvent;

        void RedrawConsole(List<ProsthesisDTO> prostheses);

        int GetMainMenuChoice();
        void ShowMainMenu();
        void ShowProsthesis(ProsthesisDTO prosthesis);

        int GetSelectedIdProsthesis();
        void ConsoleMain();
    }
}
