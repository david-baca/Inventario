using Domain.Dto;
using Domain.Entity;

namespace inventarioAPI.Services.IServices
{
    public interface IArticulo
    {

        public Task<Response<List<ArticuloRequest>>> GetArticulo(string Text, int fk);
        public Task<Response<ArticuloResponse>> CrearArticulo(ArticuloResponse request);
        public Task<Response<ArticuloResponse>> ActualizaArticulo(ArticuloResponse i, int id);
        public Task<Response<ArticuloResponse>> EliminarArticulo(int id);
    }
}
