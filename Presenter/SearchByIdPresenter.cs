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
    public class SearchByIdPresenter
    {
        ISearchByIdView searchByIdView;
        ILogic logic;

        public SearchByIdPresenter(ISearchByIdView searchByIdView, ILogic logic)
        {
            this.searchByIdView = searchByIdView;
            this.logic = logic;

            searchByIdView.SearchBtnCLickEvent += OnSearchBtnCLickEvent;
        }

        private void OnSearchBtnCLickEvent(object sender, ProsthesisEventArgs e)
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
