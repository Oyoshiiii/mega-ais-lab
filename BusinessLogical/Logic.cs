using Data;
using DataLayer;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Logic : ILogic
    {
        DataLogic dataLogic;
        CRUDLogic crudLogic;
        QueryLogic queryLogic;

        /// <summary>
        /// событие при изменении данных
        /// </summary>
        public event Action<IEnumerable<Prosthesis>> DataChanged;

        /// <summary>
        /// Инициализация фасада бизнес-логики, объединяющего работу со справочными материалами, CRUD-операциями и сложными запросами
        /// </summary>
        /// <param name="dataLogic">Экземпляр класса справочных материалов</param>
        /// <param name="crudLogic">Экземпляр класса crud-операций</param>
        /// <param name="queryLogic">экземпляр класса сложных запросов</param>
        public Logic(DataLogic dataLogic, CRUDLogic crudLogic, QueryLogic queryLogic)
        {
            this.dataLogic = dataLogic;
            this.crudLogic = crudLogic;
            this.queryLogic = queryLogic;
        }
        
        /// <summary>
        /// Добавление протеза в лист протезов; если null - ничего не происходит
        /// </summary>
        /// <param name="modelName">Модель протеза</param>
        /// <param name="bodyPart">Часть тела на которую прикрепляется протез из списка частей тела</param>
        /// <param name="percentOfSanityLoss">% потери рассудка, от 2 до 90</param>
        /// <param name="buffDescript">Описание баффов</param>
        /// <param name="debuffDescript">Описание дебаффов</param>
        /// <param name="origin">Локация/место нахождения из списка локаций</param>
        public void AddProsthesis(string modelName, string bodyPart, int percentOfSanityLoss, string buffDescript, string debuffDescript, string origin)
        {
            crudLogic.AddProsthesis(modelName, bodyPart, percentOfSanityLoss, buffDescript, debuffDescript, origin);
            DataChanged?.Invoke(crudLogic.GetAllProstheses());
        }

        /// <summary>
        /// Получение всех протезов
        /// </summary>
        /// <returns>Лист протезов</returns>
        public List<Prosthesis> GetAllProstheses()
        {
            return crudLogic.GetAllProstheses();
        }

        /// <summary>
        /// Получение протеза по ID
        /// </summary>
        /// <param name="id">ID протеза</param>
        /// <returns>Протез</returns>
        public Prosthesis GetProsthesisById(int id)
        {
            return crudLogic.GetProsthesisById(id);
        }

        /// <summary>
        /// Изменение протеза
        /// </summary>
        /// <param name="id">ID протеза</param>
        /// <param name="modelName">Модель протеза</param>
        /// <param name="bodyPart">Часть тела на которую прикрепляется протез</param>
        /// <param name="percentOfSanityLoss">% потери рассудка</param>
        /// <param name="buffDescript">Описание баффов</param>
        /// <param name="debuffDescript">Описание дебаффов</param>
        /// <param name="origin">Локация/место нахождения</param>
        public void ChangeProsthesis(int id, string modelName, string bodyPart, int percentOfSanityLoss, string buffDescript, string debuffDescript, string origin)
        {
            crudLogic.ChangeProsthesis(id, modelName, bodyPart, percentOfSanityLoss, buffDescript, debuffDescript, origin);
            DataChanged?.Invoke(crudLogic.GetAllProstheses());
        }

        /// <summary>
        /// Удаление протеза по ID
        /// </summary>
        /// <param name="id">ID протеза</param>
        public void DeleteProsthesis(int id)
        {
            crudLogic.DeleteProsthesis(id);
            DataChanged?.Invoke(crudLogic.GetAllProstheses());
        }

        /// <summary>
        /// Получение листа всех частей тела, на которые крепятся протезы
        /// </summary>
        /// <returns>Лист частей тела</returns>
        public List<string> GetBodyPartsList()
        {
            return dataLogic.GetBodyParts();
        }

        /// <summary>
        /// Получения листа всех локаций/мест нахождения протезов
        /// </summary>
        /// <returns>Личт локаций/мест нахождения</returns>
        public List<string> GetOriginList()
        {
            return dataLogic.GetOrigin();
        }

        /// <summary>
        /// Группирование по всем частям тела, за которые крепятся протезы
        /// </summary>
        /// <returns>Сгруппированный лист протезов</returns>
        public List<Prosthesis> GroupByAllBodyParts()
        {
            return queryLogic.GroupByAllBodyParts(dataLogic.GetBodyParts());
        }

        /// <summary>
        /// Группирование по конкретному месту нахождения протезов
        /// </summary>
        /// <param name="origin">Локация/место нахождения протезов</param>
        /// <returns>Сгруппированный лист протезов</returns>
        public List<Prosthesis> GroupBySpecificOrigin(string origin)
        {
            return queryLogic.GroupBySpecificOrigin(origin);
        }

        /// <summary>
        /// Сортирование по возрастанию % потери рассудка
        /// </summary>
        /// <param name="prosthesesList">% потери рассудка</param>
        /// <returns>Сортированный лист протезов</returns>
        public List<Prosthesis> SortByPercentOfSanityLoss(List<Prosthesis> prosthesesList = null)
        {
            return queryLogic.SortByPercentOfSanityLoss(prosthesesList);
        }

        /// <summary>
        /// Сортирование по убыванию % потери рассудка
        /// </summary>
        /// <returns>Сортированный лист протезов</returns>
        public List<Prosthesis> SortByPercentOfSanityLossDescending()
        {
            return queryLogic.SortByPercentOfSanityLossDescending();
        }
    }
}
