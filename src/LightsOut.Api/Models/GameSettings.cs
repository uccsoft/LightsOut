using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LightsOut.Api.Models
{
    public class GameSettings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BoardSize { get; set; }
        [NotMapped]
        public List<List<int>> InitialState { get; set; }
    }
}
