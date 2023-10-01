using Domain.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using inventarioAPI.Services.Services;

namespace inventarioAPI.Services.IServices
{
    public interface IArea
    {
        public Task<Response<List<AreaResponse>>> GetArea(string Text);
        public  Task<Response<AreaResponse>> CrearArea (AreaResponse request);
        public  Task<Response<AreaResponse>> ActualizaArea (AreaResponse i, int id);
        public  Task<Response<AreaResponse>> EliminarArea(int id);
    }
}
