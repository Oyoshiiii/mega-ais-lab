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

        /// <summary>
        /// конструктор презентера поиска по локации протезов
        /// </summary>
        /// <param name="searchByIdView">представление поиска по локации протезов</param>
        /// <param name="logic">бизнес-логика</param>
        public SearchByIdPresenter(ISearchByIdView searchByIdView, ILogic logic)
        {
            this.searchByIdView = searchByIdView;
            this.logic = logic;

            searchByIdView.SearchBtnCLickEvent += OnSearchBtnCLickEvent;
        }

        private void OnSearchBtnCLickEvent(ProsthesisEventArgs e)
        {
            var prosthesis = logic.GetProsthesisById(e.Id);
            if (prosthesis == null)
            {
                searchByIdView.ShowNotFoundProsthesis($"Протез с ID = {e.Id} не найден");
                return;
            }

            var prosDto = new ProsthesisDTO(prosthesis.Id, prosthesis.ModelName, prosthesis.BodyPart,
                prosthesis.PercentOfSanityLoss, prosthesis.BuffDescription, prosthesis.DebuffDescription, prosthesis.Origin);
            
            searchByIdView.ShowFoundProsthesis(prosDto);
        }
    }
}
