using Domain.Dto;

namespace inventarioAPI.Services.IServices
{
    public interface IInit
    {
        public Task RootAsync();
        public Task BDAsync();
    }
}
