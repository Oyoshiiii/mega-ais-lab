using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface ILogic
    {
        //дописать саммари
        /// <summary>
        /// 
        /// </summary>
        event Action<IEnumerable<Prosthesis>> DataChanged;

        /// <summary>
        /// Добавление протеза в лист протезов; если null - ничего не происходит
        /// </summary>
        /// <param name="modelName">Модель протеза</param>
        /// <param name="bodyPart">Часть тела на которую прикрепляется протез из списка частей тела</param>
        /// <param name="percentOfSanityLoss">% потери рассудка, от 2 до 90</param>
        /// <param name="buffDescript">Описание баффов</param>
        /// <param name="debuffDescript">Описание дебаффов</param>
        /// <param name="origin">Локация/место нахождения из списка локаций</param>
        void AddProsthesis(string modelName, string bodyPart, int percentOfSanityLoss, string buffDescript, string debuffDescript, string origin);

        /// <summary>
        /// Получение всех протезов, если протезов нет 
        /// </summary>
        /// <returns>Лист протезов</returns>
        List<Prosthesis> GetAllProstheses();

        /// <summary>
        /// Получение протеза по ID; если протеза нет - ничего не происходит
        /// </summary>
        /// <param name="id">ID протеза</param>
        /// <returns>Протез</returns>
        Prosthesis GetProsthesisById(int id);

        /// <summary>
        /// Изменение протеза
        /// </summary>
        /// <param name="id">ID протеза</param>
        /// <param name="modelName">Модель протеза</param>
        /// <param name="bodyPart">Часть тела на которую прикрепляется протезиз списка частей тела</param>
        /// <param name="percentOfSanityLoss">% потери рассудка от 2 до 90</param>
        /// <param name="buffDescript">Описание баффов</param>
        /// <param name="debuffDescript">Описание дебаффов</param>
        /// <param name="origin">Локация/место нахожденияиз списка локаций</param>
        void ChangeProsthesis(int id, string modelName, string bodyPart, int percentOfSanityLoss, string buffDescript, string debuffDescript, string origin);

        /// <summary>
        /// Удаление протеза по ID; если нет - ничего не происходит
        /// </summary>
        /// <param name="id">ID протеза</param>
        void DeleteProsthesis(int id);

        /// <summary>
        /// Получение листа всех частей тела, на которые крепятся протезы
        /// </summary>
        /// <returns>Лист частей тела</returns>
        List<string> GetBodyPartsList();

        /// <summary>
        /// Получения листа всех локаций/мест нахождения протезов
        /// </summary>
        /// <returns>Личт локаций/мест нахождения</returns>
        List<string> GetOriginList();

        /// <summary>
        /// Группирование по всем частям тела, за которые крепятся протезы
        /// </summary>
        /// <returns>Сгруппированный лист протезов</returns>
        List<Prosthesis> GroupByAllBodyParts();

        /// <summary>
        /// Группирование по конкретному месту нахождения протезов
        /// </summary>
        /// <param name="origin">Локация/место нахождения протезов</param>
        /// <returns>Сгруппированный лист протезов</returns>
        List<Prosthesis> GroupBySpecificOrigin(string origin);
        
        /// <summary>
        /// Сортирование по возрастанию % потери рассудка
        /// </summary>
        /// <param name="prosthesesList">% потери рассудка</param>
        /// <returns>Сортированный лист протезов</returns>
        List<Prosthesis> SortByPercentOfSanityLoss(List<Prosthesis> prosthesesList = null);

        /// <summary>
        /// Сортирование по убыванию % потери рассудка
        /// </summary>
        /// <returns>Сортированный лист протезов</returns>
        List<Prosthesis> SortByPercentOfSanityLossDescending();
    }
}
