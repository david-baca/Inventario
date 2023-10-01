using Domain.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using inventarioAPI.Services.Services;

namespace inventarioAPI.Services.IServices
{
    public interface IResponsable
    {
        public Task<Response<List<ResponsableResponse>>> GetResponsable(string Text, int fk);
        public Task<Response<ResponsableResponse>> CrearResponsable(ResponsableResponse request);
        public Task<Response<ResponsableResponse>> ActualizaResponsables(ResponsableResponse i, int id);
        public Task<Response<ResponsableResponse>> EliminarResponsables(int id);
    }
}
