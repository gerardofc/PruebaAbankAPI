using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SKU.Helper;
using SKU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SKUController : ControllerBase
    {
        // GET: api/<SKUController>
        [HttpGet]
        public List<Sku> ObtenerListaSKU()
        {
            List<Sku> listaSKU = new List<Sku>();
            try {
                using (MySqlConnection conn = MySQLConexion.obtenerConexion())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from SKU where estado=true", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaSKU.Add(new Sku()
                            {
                                id_sku = reader["id"].ToString(),
                                descripcion = reader["descripcion"].ToString(),
                                estado = Convert.ToBoolean(reader["estado"]),
                                existencia = Convert.ToInt32(reader["existencias"])
                            });
                        }
                    }
                    conn.Close();
                }
            }catch(Exception){}

            return listaSKU;
        }

        // GET api/SKU/5
        [HttpGet("{id}")]
        public Sku BuscarSKU(int id)
        {
            Sku SKuRespuesta = null;

            try
            {
                using (MySqlConnection conn = MySQLConexion.obtenerConexion())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(@"select * from SKU where id = @id_sku;", conn);
                    cmd.Parameters.AddWithValue("@id_sku", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            SKuRespuesta = new Sku()
                            {
                                id_sku = reader["id"].ToString(),
                                descripcion = reader["descripcion"].ToString(),
                                estado = Convert.ToBoolean(reader["estado"]),
                                existencia = Convert.ToInt32(reader["existencias"])
                            };
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception) { }

            return SKuRespuesta;
        }



        // POST api/SKU/eliminarsku/{id}
        [HttpGet("eliminarsku/{id}")]
        public Resultado EliminarSKU(string id)
        {
            Resultado resultado = new Resultado();
            try
            {
                using (MySqlConnection conn = MySQLConexion.obtenerConexion())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(@"update sku set estado=false where id=@id_sku", conn);
                    cmd.Parameters.AddWithValue("@id_sku", id);
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        resultado.OperacionExitosa();
                    }
                    else
                    {
                        resultado.OperacionFallida();
                    }
                    conn.Close();
                }
            }
            catch (Exception) { resultado.OperacionFallida(); }

            return resultado;
        }

        // POST api/<SKUController>
        [HttpPost("agregarsku")]
        public Resultado AgregarSKU(Sku sku)
        {
            Resultado resultado = new Resultado();
            try
            {
                using (MySqlConnection conn = MySQLConexion.obtenerConexion())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(@"insert into sku VALUES(@id_sku, @descripcion, @existencias, @estado);", conn);
                    cmd.Parameters.AddWithValue("@id_sku", sku.id_sku);
                    cmd.Parameters.AddWithValue("@descripcion", sku.descripcion);
                    cmd.Parameters.AddWithValue("@existencias", sku.existencia);
                    cmd.Parameters.AddWithValue("@estado", sku.estado);
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        resultado.OperacionExitosa();
                    } 
                    else
                    {
                        resultado.OperacionFallida();
                    }
                    conn.Close();
                }
            }
            catch (Exception e) { resultado.OperacionFallida(); }

            return resultado;
        }
    }
}
