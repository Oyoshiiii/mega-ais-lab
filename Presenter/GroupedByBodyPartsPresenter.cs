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

        /// <summary>
        /// конструктор презентера группировки по частям тела
        /// </summary>
        /// <param name="groupedByBodyPartsView">представление группировки по частям тела</param>
        /// <param name="logic">бизнес-логика</param>
        public GroupedByBodyPartsPresenter(IGroupedByBodyPartsView groupedByBodyPartsView, ILogic logic)
        {
            this.groupedByBodyPartsView = groupedByBodyPartsView;
            this.logic = logic;

            groupedByBodyPartsView.RedrawForm(ConvertToDTOProsthesesList(logic.GroupByAllBodyParts()));

            logic.DataChanged += OnDataChanged;
        }

        private void OnDataChanged(IEnumerable<Prosthesis> prostheses)
        {
            groupedByBodyPartsView.RedrawForm(ConvertToDTOProsthesesList(logic.GroupByAllBodyParts()));
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
