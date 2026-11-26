using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IGroupedByBodyPartsView : IView
    {
        /// <summary>
        /// метод отрисовки формы с обновленными данными
        /// </summary>
        /// <param name="prostheses">лист протезов</param>
        void RedrawForm(List<ProsthesisDTO> prostheses);
    }
}
