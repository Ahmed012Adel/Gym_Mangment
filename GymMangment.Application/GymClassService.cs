using Gym.Mangment.Domain.Contract;
using Gym.Mangment.Domain.Entities;
using Gym.Mangment.Domain.Specifications;
using GymMangment.Application.Abstraction;
using GymMangment.Application.Abstraction.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangment.Application
{
    public class GymClassService(IGenericRepo<GYMClasses, int> repo ,UserManager<ApplicationUser> _UserManager) : IGymClassesService
    {
        public async Task<IEnumerable<GYMClassesDto>> GetAllAsync()
        {
            var spec = new GymClassesSpec();
            var classes = await repo.GetAllWithSpecAsync(spec);

            var classesDto = classes.Select(C => new GYMClassesDto()
            {
                Id = C.Id,
                Name = C.Name,
                Trainer = C.Trainer.UserName ?? " " ,
            });
            return classesDto;
        }
        public async Task<GYMClassesDto> GetAsync(int id)
        {
            var spec = GymClassesSpec.GetById(id);

            var classEntity = await repo.GetWithSpecAsync(spec);
            if (classEntity == null)
            {
                throw new KeyNotFoundException($"GYM Class with id {id} not found.");
            }
           var classDto = new GYMClassesDto()
           {
               Id = classEntity.Id,
               Name = classEntity.Name,
               Trainer = classEntity.Trainer.UserName ?? " ",
           };
            return classDto;
        }
        public async Task<GYMClassesDto> CreateAsync(CreateClassDto Model)
        {
            var trainer = await _UserManager.FindByIdAsync(Model.TrainerId);
            if (trainer == null)
            {
                throw new KeyNotFoundException($"Trainer with id {Model.TrainerId} not found.");
            }
            var GymClass = new GYMClasses()
            {
                Name = Model.Name,
                TrainerId = trainer.Id,
                Trainer = trainer
            };

            var GymClassDto = new GYMClassesDto()
            {
                Id = GymClass.Id,
                Name = GymClass.Name,
                Trainer = trainer.UserName ?? " "
            };
            return GymClassDto;
        }
        public async Task<GYMClassesDto> UpdateAsync(GYMClassesDto Model)
        {
            var GymClass = await repo.GetByIdAsync(Model.Id);
            if (GymClass is null)
                throw new KeyNotFoundException($"GymClass with id {Model.Id} not Exist.");
            var UbdateClass = new GYMClasses
            {
                Id = GymClass.Id,
                Name = Model.Name,
                TrainerId = GymClass.TrainerId,
                Trainer = GymClass.Trainer
            };

            return Model;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var GymClass =await repo.GetByIdAsync(id);
            if (GymClass is null)
                throw new KeyNotFoundException($"GymClass with id {id} not Exist.");
            repo.DeleteAsync(GymClass);
            return true; 
        }
    }
}
