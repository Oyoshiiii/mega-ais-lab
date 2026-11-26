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

        private void OnSaveBtnClickEvent(ProsthesisEventArgs e)
        {
            logic.AddProsthesis(e.ModelName, e.BodyPart, e.PercentOfSanityLoss,
                e.BuffDescription, e.DebuffDescription, e.Origin);

            addView.CloseView();
        }
    }
}
