using Domain.Dto;
using Domain.Entity;

namespace inventarioAPI.Services.IServices
{
    public interface IProvedor
    {
        public Task<Response<List<ProvedorResponse>>> GetProvedor(string Text);
        public Task<Response<ProvedorResponse>> CrearProvedor(ProvedorResponse request);
        public Task<Response<ProvedorResponse>> ActualizaProvedor(ProvedorResponse i, int id);
        public Task<Response<ProvedorResponse>> EliminarProvedor(int id);
    }
}
