using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangment.Application.Abstraction.Dtos
{
    public class CreateClassDto
    {
        public string Name { get; set; }
        public required string TrainerId { get; set; }
    }
}
