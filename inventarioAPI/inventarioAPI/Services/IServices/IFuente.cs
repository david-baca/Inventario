using Domain.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using inventarioAPI.Services.Services;
namespace inventarioAPI.Services.IServices
{
    public interface IFuente
    {
        public Task<Response<List<FuenteResponse>>> GetFuente(string Text);
        public Task<Response<FuenteResponse>> CrearFuente(FuenteResponse request);
        public Task<Response<FuenteResponse>> ActualizaFuente(FuenteResponse i, int id);
        public Task<Response<FuenteResponse>> EliminarFuente(int id);

    }
}
