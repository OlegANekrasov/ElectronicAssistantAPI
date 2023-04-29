using ElectronicAssistantAPI.BLL.Models.PersonnelManagement;
using ElectronicAssistantAPI.DAL.Models.PersonnelManagement;
using ElectronicAssistantAPI.DAL.Repository;
using ElectronicAssistantAPI.DAL.Repository.PersonnelManagement;

namespace ElectronicAssistantAPI.BLL.Services.PersonnelManagement
{
    public class PositionService : IPositionService
    {
        private readonly IRepository<Position> _positionsRepository;
        private readonly ILogger<PositionService> _logger;

        public PositionService(IRepository<Position> positionsRepository, ILogger<PositionService> logger)
        {
            _positionsRepository = positionsRepository;
            _logger = logger;
        }

        public IEnumerable<Position> Get()
        {
            return ((PositionsRepository)_positionsRepository).GetPositions();
        }

        public async Task<Position> GetByIdAsync(string id)
        {
            return await ((PositionsRepository)_positionsRepository).GetPositionByIdAsync(id);
        }

        public async Task<Position> AddAsync(AddPosition model)
        {
            return await ((PositionsRepository)_positionsRepository).AddPositionAsync(model);
        }

        public async Task<Position> UpdateAsync(UpdatePosition model)
        {
            return await ((PositionsRepository)_positionsRepository).UpdatePositionAsync(model);
        }

        public async Task DeleteAsync(DelPosition model)
        {
            await ((PositionsRepository)_positionsRepository).DeletePositionAsync(model.Id);
        }
    }
}
