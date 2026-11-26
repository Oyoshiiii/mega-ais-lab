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
