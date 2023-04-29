using ElectronicAssistantAPI.BLL.Models.PersonnelManagement;
using ElectronicAssistantAPI.DAL.EF;
using ElectronicAssistantAPI.DAL.Models.PersonnelManagement;
using Microsoft.AspNetCore.Identity;
using System.Xml;

namespace ElectronicAssistantAPI.DAL.Repository.PersonnelManagement
{
    public class PositionsRepository : Repository<Position>
    {
        public PositionsRepository(ApplicationDbContext db) : base(db)
        {

        }

        public IEnumerable<Position> GetPositions()
        {
            return base.Get();
        }

        public async Task<Position> GetPositionByIdAsync(string id)
        {
            return await Set.FindAsync(id);
        }

        public async Task<Position> AddPositionAsync(AddPosition model)
        {
            var position = new Position()
            {
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                Description = model.Description,
            };

            await CreateAsync(position);
            return position;
        }

        public async Task<Position> UpdatePositionAsync(UpdatePosition model)
        {
            var position = await GetByIdAsync(model.Id);
            if (position != null)
            {
                position.Name = model.Name;
                position.Description = model.Description;

                await UpdateAsync(position);
                return position;
            }

            return null;
        }

        public async Task DeletePositionAsync(string id)
        {
            await DeleteAsync(id);
        }
    }
}
