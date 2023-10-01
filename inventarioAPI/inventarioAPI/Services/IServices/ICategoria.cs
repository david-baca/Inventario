using Domain.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using inventarioAPI.Services.Services;
namespace inventarioAPI.Services.IServices
{
    public interface ICategoria
    {
        public Task<Response<List<CategoriaResponse>>> GetCategoria(string Text, int fk);
        public Task<Response<CategoriaResponse>> CrearCategorias(CategoriaResponse request);
        public Task<Response<CategoriaResponse>> ActualizaCategoria(CategoriaResponse i, int id);
        public Task<Response<CategoriaResponse>> EliminarCategoria(int id);
    }
}
