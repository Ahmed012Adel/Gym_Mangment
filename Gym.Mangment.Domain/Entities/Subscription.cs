﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Mangment.Domain.Entities
{
    public class Subscription
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public required string MemberId { get; set; }
        public required ApplicationUser Member { get; set; }
    }
}
