using asmpro131_Shared.Models;

namespace asmpro131.IServices
{
    public interface IColorService
    {
        public Task<bool> CreateColor(Color color);
        public Task<bool> UpdateColor(Color color);
        public Task<bool> DeleteColor(Guid id);
        public Task<Color> GetColorById(Guid id);
        public Task<List<Color>> GetColorByName(string name);
        public Task<List<Color>> GetAllColor();
    }
}
