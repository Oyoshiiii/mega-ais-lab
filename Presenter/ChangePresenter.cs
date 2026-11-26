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

        private void OnSaveBtnClickEvent(ProsthesisEventArgs e)
        {
            logic.ChangeProsthesis(e.Id, e.ModelName, e.BodyPart, e.PercentOfSanityLoss,
                e.BuffDescription, e.DebuffDescription, e.Origin);

            changeView.CloseView();
        }
    }
}
