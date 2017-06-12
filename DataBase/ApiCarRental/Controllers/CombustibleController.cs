using System;
using Database;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiCarRental.Controllers
{
    public class CombustibleController : ApiController
    {
        // GET: api/Combustible
        public RespuestaAPI Get()
        {
            RespuestaAPI resultado = new RespuestaAPI();
            List<TipoCombustible> Combu = new List<TipoCombustible>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    Combu = Db.GetCombu();
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch
            {
                resultado.error = "Aqui no hay datos ERROR";
            }
            resultado.totalElementos = Combu.Count;
            resultado.dataCombu = Combu;
            return resultado;
        }

        // GET: api/Combustible/5
        public RespuestaAPI Get(int id)
        {
            {
                RespuestaAPI resultado = new RespuestaAPI();
                List<TipoCombustible> dataCombu = new List<TipoCombustible>();
                try
                {
                    Db.Conectar();
                    if (Db.EstaLaConexionAbierta())
                    {
                        dataCombu = Db.GET_COMBUSTIBLE_API_ID(id);
                        resultado.error = "";
                    }
                }
                catch
                {
                    resultado.error = "Error";
                }

                resultado.totalElementos = dataCombu.Count;
                resultado.dataCombu = dataCombu;
                return resultado;

            }
        }

        // POST: api/Combustible
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Combustible/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Combustible/5
        public void Delete(int id)
        {
        }
    }
}
