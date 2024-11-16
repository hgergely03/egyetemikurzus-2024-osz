using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYVAM0.Model
{
    internal record Result
    {
        public required Cat Cat { get; init; }
        public required string Description { get; init; }
    }
}
