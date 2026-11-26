using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProsthesisEventArgs : EventArgs
    {
        int Id { get; }
        string ModelName { get; }
        string BodyPart { get; }
        int PercentOfSanityLoss { get; }
        string BuffDescription { get; }
        string DebuffDescription { get; }
        string Origin { get; }

        /// <summary>
        /// Конструктор для удаления или поиска по ID
        /// </summary>
        /// <param name="id">ID уадаляемого протеза или искомого по ID</param>
        public ProsthesisEventArgs(int id)
        {
            Id = id;
        }

        /// <summary>
        /// Конструктор для добавления
        /// </summary>
        /// <param name="name">имя модели добавляемого протеза</param>
        /// <param name="bodyPart">часть тела на которой располагается добавляемый протез</param>
        /// <param name="percentOfSanityLoss">% потери рассудка у добавляемого протеза</param>
        /// <param name="debuffDescription">дебаффы добавляемого рпотеза</param>
        /// <param name="buffDescription">баффы добавляемого протеза</param>
        /// <param name="origin">локация добавляемого протеза</param>
        public ProsthesisEventArgs(string name, string bodyPart, int percentOfSanityLoss, string debuffDescription, string buffDescription, string origin)
        {
            ModelName = name;
            BodyPart = bodyPart;
            PercentOfSanityLoss = percentOfSanityLoss;
            DebuffDescription = debuffDescription;
            BuffDescription = buffDescription;
            Origin = origin;
        }

        /// <summary>
        /// Конструктор для изменения
        /// </summary>
        /// <param name="id">ID изменяемого протеза</param>
        /// <param name="name">имя модели изменяемого протеза</param>
        /// <param name="bodyPart">часть тела на которой располагается изменяемый протез</param>
        /// <param name="percentOfSanityLoss">% потери рассудка у изменяемого протеза</param>
        /// <param name="debuffDescription">дебаффы изменяемого рпотеза</param>
        /// <param name="buffDescription">баффы изменяемого протеза</param>
        /// <param name="origin">локация изменяемого протеза</param>
        public ProsthesisEventArgs(int id, string modelName, string bodyPart, int percentOfSanityLoss, string buffDescription, string debuffDescription, string origin) : this(id)
        {
            Id = id;
            ModelName = modelName;
            BodyPart = bodyPart;
            PercentOfSanityLoss = percentOfSanityLoss;
            BuffDescription = buffDescription;
            DebuffDescription = debuffDescription;
            Origin = origin;
        }

        /// <summary>
        /// конструктор для поиска по локации
        /// </summary>
        /// <param name="origin">локация искомых протезов</param>
        public ProsthesisEventArgs(string origin)
        {
            Origin = origin;
        }
    }
}
