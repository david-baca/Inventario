using Domain.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using inventarioAPI.Services.Services;

namespace inventarioAPI.Services.IServices
{
    public interface ICatalogo
    {
        public Task<Response<List<CatalogoResponse>>> GetCatalogo(string Text);
        public Task<Response<CatalogoResponse>> CrearCatalogos (CatalogoResponse request);
        public Task<Response<CatalogoResponse>> ActualizaCatalogo(CatalogoResponse i, int id);
        public Task<Response<CatalogoResponse>> EliminarCatalogo(int id);
    }
}
