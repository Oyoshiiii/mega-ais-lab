using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface ISearchByIdView
    {
        event EventHandler<ProsthesisEventArgs> SearchBtnCLickEvent;

        void ShowFoundProsthesis(ProsthesisDTO prosthesis);
        void ShowNotFoundProsthesis(string msg);
    }
}
