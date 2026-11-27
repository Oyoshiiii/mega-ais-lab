using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProsthesisDTO
    {
        public int Id { get; }
        public string ModelName { get; }
        public string BodyPart { get; }
        public int PercentOfSanityLoss { get; }
        public string BuffDescription { get; }
        public string DebuffDescription { get; }
        public string Origin { get; }

        /// <summary>
        /// конструктор DTO протеза для передачи данных между слоями
        /// </summary>
        /// <param name="id">ID протеза</param>
        /// <param name="modelName">название модели</param>
        /// <param name="bodyPart">часть тела</param>
        /// <param name="percentOfSanityLoss">% потери рассудка</param>
        /// <param name="buffDescription">описание баффов</param>
        /// <param name="debuffDescription">описание дебаффов</param>
        /// <param name="origin">локация/место нахождения</param>
        public ProsthesisDTO(int id, string modelName, string bodyPart, int percentOfSanityLoss, string buffDescription, string debuffDescription, string origin)
        {
            Id = id;
            ModelName = modelName;
            BodyPart = bodyPart;
            PercentOfSanityLoss = percentOfSanityLoss;
            BuffDescription = buffDescription;
            DebuffDescription = debuffDescription;
            Origin = origin;
        }
    }
}
