using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Mangment.Domain.Entities
{
    public class ApplicationUser :IdentityUser
    {
        // classes has trainer
        public required ICollection<GYMClasses> Classes { get; set; }

        //members Attend classes
        public required ICollection<GYMClasses> MembersAttend { get; set; }
        //members subscrip classes
        public required ICollection<Subscription> Subscripes { get; set; }

    }
}
