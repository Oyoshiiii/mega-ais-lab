using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProsthesisDTO
    {
        int Id { get; }
        string ModelName { get; }
        string BodyPart { get; }
        int PercentOfSanityLoss { get; }
        string BuffDescription { get; }
        string DebuffDescription { get; }
        string Origin { get; }
    }
}
