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
    public class ChangePresenter
    {
        IChangeView changeView;
        ILogic logic;

        public ChangePresenter(IChangeView changeView, ILogic logic, ProsthesisDTO prosthesis)
        {
            this.changeView = changeView;
            this.logic = logic;

            changeView.SaveBtnClickEvent += OnSaveBtnClickEvent;

            changeView.LoadChangedProsthesisData(prosthesis);

            changeView.LoadBodyPartsList(logic.GetBodyPartsList());
            changeView.LoadOriginList(logic.GetOriginList());
        }

        private void OnSaveBtnClickEvent(object sender, ProsthesisEventArgs e)
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
