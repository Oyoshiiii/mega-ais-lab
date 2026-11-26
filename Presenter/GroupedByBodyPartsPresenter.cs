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
    public class GroupedByBodyPartsPresenter
    {
        IGroupedByBodyPartsView groupedByBodyPartsView;
        ILogic logic;

        public GroupedByBodyPartsPresenter(IGroupedByBodyPartsView groupedByBodyPartsView, ILogic logic)
        {
            this.groupedByBodyPartsView = groupedByBodyPartsView;
            this.logic = logic;

            groupedByBodyPartsView.RedrawForm(ConvertToDTOProsthesesList(logic.GroupByAllBodyParts()));
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
