using GymMangment.Application.Abstraction.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangment.Application.Abstraction
{
    public interface IGymClassesService
    {

        Task<IEnumerable<GYMClassesDto>> GetAllAsync();
        Task<GYMClassesDto> GetAsync(int id);
        Task<GYMClassesDto> CreateAsync(CreateClassDto Model);
        Task<GYMClassesDto> UpdateAsync(GYMClassesDto Model);
        Task<bool> DeleteAsync(int id);
    }
}
