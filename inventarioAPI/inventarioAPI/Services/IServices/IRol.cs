
using Domain.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using inventarioAPI.Services.Services;


namespace inventarioAPI.Services.IServices
{
    public interface IRol
    {
        public Task<Response<List<RolResponse>>> GetRol(string Text);
        public Task<Response<RolResponse>> CrearRoles(RolResponse request);
        public Task<Response<RolResponse>> ActualizaRol(RolResponse request, int id);
        public Task<Response<RolResponse>> EliminarRol(int id);
    }
}
