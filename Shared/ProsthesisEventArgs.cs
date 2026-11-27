using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProsthesisEventArgs : EventArgs
    {
        public int Id { get; }
        public string ModelName { get; }
        public string BodyPart { get; }
        public int PercentOfSanityLoss { get; }
        public string BuffDescription { get; }
        public string DebuffDescription { get; }
        public string Origin { get; }

        /// <summary>
        /// пустой конструктор для отработки кнопок, которые подразумевают использование prosEA в дальнейшем,но пока не нужны
        /// (пример: mainform и consoleview имеют общую реализацию event Action<ProsthesisEventArgs> AddBtnClickEvent
        /// для консоли нужны данные, тк у нее 1 представление. для мейнформ еще нет, тк этим занимается открываемая им форма addform)
        /// </summary>
        public ProsthesisEventArgs()
        {

        }

        /// <summary>
        /// Конструктор для удаления или передачи по ID
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
        public ProsthesisEventArgs(string name, string bodyPart, int percentOfSanityLoss, string buffDescription, string debuffDescription, string origin)
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
