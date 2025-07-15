using Gym.Mangment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangment.Application.Abstraction.Dtos
{
    public class GYMClassesDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Trainer { get; set; }

    }
}
