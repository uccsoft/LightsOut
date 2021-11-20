using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightsOut.Api.Models
{
    public class GameSettings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BoardSize { get; set; }
    }
}
