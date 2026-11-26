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
    public class AddPresenter
    {
        IAddView addView;
        ILogic logic;

        public AddPresenter(IAddView addView, ILogic logic)
        {
            this.addView = addView;
            this.logic = logic;

            addView.SaveBtnClickEvent += OnSaveBtnClickEvent;
            
            addView.LoadBodyPartsList(logic.GetBodyPartsList());
            addView.LoadOriginList(logic.GetOriginList());
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
