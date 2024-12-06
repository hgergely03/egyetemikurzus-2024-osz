using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYVAM0.Model
{
    public record Result
    {
        public required Cat Cat { get; init; }
        public required string Description { get; init; }
    }
}
