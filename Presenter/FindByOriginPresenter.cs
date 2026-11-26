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
    public class FindByOriginPresenter
    {
        IFindByOriginView findByOriginView;
        ILogic logic;

        public FindByOriginPresenter(IFindByOriginView findByOriginView, ILogic logic)
        {
            this.findByOriginView = findByOriginView;
            this.logic = logic;

            findByOriginView.SearchBtnClickEvent += OnSearchBtnClickEvent; ;

            findByOriginView.LoadOriginList(logic.GetOriginList());
        }

        private void OnSearchBtnClickEvent(ProsthesisEventArgs e)
        {
            findByOriginView.RedrawForm(ConvertToDTOProsthesesList(logic.GroupBySpecificOrigin(e.Origin)));
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
