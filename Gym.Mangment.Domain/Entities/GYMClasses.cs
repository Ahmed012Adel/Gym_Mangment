using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Mangment.Domain.Entities
{
    public class GYMClasses
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required ICollection<ApplicationUser> Trainer { get; set; }
        public required ICollection<ApplicationUser> Member { get; set; }
    }
}
