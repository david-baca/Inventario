using Domain.Dto;

namespace inventarioAPI.Services.IServices
{
    public interface IHistorial
    {
        public Task<Response<List<HistorialResponse>>> GetHistorial(string text);

    }
}
