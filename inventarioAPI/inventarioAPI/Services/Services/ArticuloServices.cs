using Domain.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using inventarioAPI.Services.IServices;
using System.Collections.Generic;
using static inventarioAPI.Context.Aplication_DB_Context;


namespace inventarioAPI.Services.Services
{
    public class ArticuloServices : IArticulo
    {

        //var response = await _context.Articulos.Include(x => x.Categoria).Include(x => x.Provedor).
        //    Include(x => x.Fuente).Include(x => x.Area).ToListAsync();
        private readonly AplicationdbContext _context;
        public string Mensaje;
        public ArticuloServices(AplicationdbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<ArticuloRequest>>> GetArticulo(string Text, int fk)
        {
            try
            {
                Mensaje = "La lista de Articulos";
                //var response = await _context.ListaRAs.Include(x => x.Articulo).Include(x => x.Responsable).ToListAsync();
                var response = await _context.Articulos
                        .Where(x => x.Estado == true && x.FkResponsable == fk)
                        .Include(x => x.Categoria)
                            .ThenInclude(c => c.Catalogo)
                        .Include(x => x.Responsable)
                            .ThenInclude(r => r.Rol)
                        .Include(x => x.Fuente)
                        .Include(x => x.Provedor)
                        .Include(x => x.Area)
                        .ToListAsync();

                if (Text != null)
                {
                    response = await _context.Articulos
                        .Where(x => x.Estado == true && x.FkResponsable == fk &&
                               (x.Polisa.Contains(Text) || x.Factura.Contains(Text) || x.Token.Contains(Text)))
                        .Include(x => x.Categoria)
                            .ThenInclude(c => c.Catalogo)
                        .Include(x => x.Responsable)
                            .ThenInclude(r => r.Rol)
                        .Include(x => x.Fuente)
                        .Include(x => x.Provedor)
                        .Include(x => x.Area)
                        .ToListAsync();
                }

                if (fk == 0)
                {
                    response = await _context.Articulos
                        .Where(x => x.Estado && x.Token == Text)
                        .Include(x => x.Categoria)
                            .ThenInclude(c => c.Catalogo)
                        .Include(x => x.Responsable)
                            .ThenInclude(r => r.Rol)
                        .Include(x => x.Fuente)
                        .Include(x => x.Provedor)
                        .Include(x => x.Area)
                        .ToListAsync();
                }



                if (response.Count > 0)
                {
                    Mensaje = "La lista de Articulos";
                    ArticuloRequest x = new ArticuloRequest();
                    var respuesta = x.ListConvert(response);
                    return new Response<List<ArticuloRequest>>(respuesta, Mensaje);
                }
                else
                {
                    Mensaje = "No se encontra ningun registro";
                    return new Response<List<ArticuloRequest>>(Mensaje, true);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Response<ArticuloResponse>> CrearArticulo(ArticuloResponse request)
        {
            try
            {
                var token = _context.Articulos.Where(x=>x.Token == request.Token).ToList();
                if(token.Count > 0)
                {
                    return new Response<ArticuloResponse>("El No.Inventario ya existe en otro articulo", false);
                }
                var x = request.Inversor(request);
                await _context.Articulos.AddAsync(x);
                await _context.SaveChangesAsync();

                return new Response<ArticuloResponse>("Elemento exitosamente guardado",true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<ArticuloResponse>> ActualizaArticulo(ArticuloResponse i, int id)
        {
            try
            {
                var token = _context.Articulos.Where(x => x.Token == i.Token && x.PkArticulo != i.Pk).ToList();
                if (token.Count > 0)
                {
                    return new Response<ArticuloResponse>("El No.Inventario ya existe en otro articulo", false);
                }

                ArticuloResponse x = new ArticuloResponse();
                var resquest = _context.Articulos.Where(x => x.Estado == true && x.PkArticulo == id).FirstOrDefault();

                if (resquest == null)
                {
                    return new Response<ArticuloResponse>("No esxite este dato en la base de datos", false);
                }

                resquest.FEQADD = DateTime.Parse(i.FEQADD);
                resquest.FEQ_ASC = DateTime.Parse(i.FEQASIC);
                resquest.Polisa = i.Polisa;
                resquest.Factura = i.Factura;
                resquest.Token = i.Token;
                resquest.Costo = i.Costo;
                resquest.Estado_Articulo = i.Estado;
                resquest.FkResponsable = i.fkResonsable;
                resquest.FkCategoria = i.FkCategoria;
                resquest.FkProvedor = i.FkProvedor;
                resquest.FkFuente = i.FkFuente;
                resquest.FkArea = i.FkArea;


                _context.Articulos.Update(resquest);
                await _context.SaveChangesAsync();

                return new Response<ArticuloResponse>("Elemento exitosamente editado", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        public async Task<Response<ArticuloResponse>> EliminarArticulo(int id)
        {
            try
            {
                ArticuloResponse x = new ArticuloResponse();
                var resquest = _context.Articulos.Where(x => x.Estado == true && x.PkArticulo == id).FirstOrDefault();

                if (resquest == null)
                {
                    return new Response<ArticuloResponse>("No esxite este dato en la base de datos", false);
                }

                resquest.Estado = false;
                _context.Articulos.Update(resquest);
                await _context.SaveChangesAsync();

                return new Response<ArticuloResponse>("Elemento exitosamente eliminado", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
    }
}
