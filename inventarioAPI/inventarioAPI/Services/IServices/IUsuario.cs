using Domain.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using inventarioAPI.Services.Services;
namespace inventarioAPI.Services.IServices
{
    public interface IUsuario
    {
        public Task<Response<List<UsuarioResponse>>> GetUsuario(string Usuario, string Contrasena);
        public Task<Response<UsuarioResponse>> CrearUsuarios(UsuarioResponse request);
        public Task<Response<UsuarioResponse>> ActualizaUsuario(UsuarioResponse i, int id);
        public Task<Response<UsuarioResponse>> EliminarUsuario(int id);
    }
}
