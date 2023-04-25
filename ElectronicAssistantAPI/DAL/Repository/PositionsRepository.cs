using ElectronicAssistantAPI.BLL.Models.PersonnelManagement;
using ElectronicAssistantAPI.DAL.EF;
using ElectronicAssistantAPI.DAL.Models.PersonnelManagement;
using Microsoft.AspNetCore.Identity;
using System.Xml;

namespace ElectronicAssistantAPI.DAL.Repository
{
    public class PositionsRepository : Repository<Position>
    {
        public PositionsRepository(ApplicationDbContext db) : base(db) 
        {

        }

        public IEnumerable<Position> Get()
        {
            return base.Get();
        }

        public async Task<Position> GetByIdAsync(string id)
        {
            return await Set.FindAsync(id);
        }

        public async Task CreateAsync(AddPosition model)
        {
            var item = new Position()
            {
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                Description = model.Description,
            };

            await CreateAsync(item);
        }

        public async Task DeleteAsync(DelPosition model)
        {
            var position = await GetByIdAsync(model.Id);
            if (position != null)
            {
                await DeleteAsync(position);
            }
        }

        public async Task UpdateAsync(UpdatePosition model)
        {
            var position = await GetByIdAsync(model.Id);
            if (position != null)
            {
                position.Name = model.Name;
                position.Description = model.Description;
                
                await UpdateAsync(position);
            }
        }
    }
}
