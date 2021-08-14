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
    public class OrdenDetalleController : ControllerBase
    {
        // GET: api/<OrdenDetalleController>
        [HttpGet]
        public List<OrdenDetalle> ObtenerListaDetalle()
        {
            List<OrdenDetalle> ListaDetalle = new List<OrdenDetalle>();
            try {
                using (MySqlConnection conn = MySQLConexion.obtenerConexion())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select ordendetalle.id,sku.descripcion as id_sku,ordendetalle.cantidad,ordendetalle.estado,ordendetalle.fecha_ingreso  from ordendetalle inner join sku on sku.id=ordendetalle.id_sku where sku.estado=true", conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            ListaDetalle.Add(new OrdenDetalle()
                            {
                                id_orden = Convert.ToInt32(reader["id"]),
                                id_sku = reader["id_sku"].ToString(),
                                cantidad = Convert.ToInt32(reader["cantidad"]),
                                estado = Convert.ToBoolean(reader["estado"]),
                                fecha_ingreso= Convert.ToDateTime(reader["fecha_ingreso"])
                            });
                        }
                    }
                    conn.Close();
                }
            }
            catch(Exception) { }
            return ListaDetalle;
        }

        // GET api/<OrdenDetalleController>/5
        [HttpGet("cancelarorden/{id}")]
        public Resultado CancelarOrdenDetalle(int id)
        {
            Resultado resultado = new Resultado();
            try
            {
                using (MySqlConnection conn = MySQLConexion.obtenerConexion())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(@"update ordendetalle inner join sku on ordendetalle.id_sku=sku.id set ordendetalle.estado=false, sku.existencias=(sku.existencias + ordendetalle.cantidad) where ordendetalle.id=@id_orden and ordendetalle.estado=true ", conn) ; 
                    cmd.Parameters.AddWithValue("@id_orden", id);
                    var resultadoMySQL = cmd.ExecuteNonQuery();
                    if (resultadoMySQL >= 1)
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
            catch (Exception) { }
            return resultado;
        }

        // POST api/<OrdenDetalleController>
        [HttpPost("agregarOrden")]
        public Resultado AgregarOrdenDetalle(OrdenDetalle ordenDetalle)
        {
            Resultado resultado = new Resultado();
            try
            {
                if (validarExistencias(ordenDetalle))
                {
                    if (insertarOrden(ordenDetalle))
                    {
                        if (actualizarExistencias(ordenDetalle))
                        {
                            resultado.OperacionExitosa();
                        }
                        else
                        {
                            resultado.OperacionFallida();
                        }
                    }
                    else
                    {
                        resultado.OperacionFallida();
                    }
                }
                else 
                {
                    resultado.resultado = 1;
                    resultado.mensajeResultado = "La cantidad de la orden excede las existencias";
                }
            }
            catch (Exception e) { resultado.OperacionFallida(); }
            return resultado;
        }
        public bool validarExistencias(OrdenDetalle ordenDetalle)
        {
            int existencia = 0;
            using (MySqlConnection conn = MySQLConexion.obtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(@"select * from SKU where id = @id_sku;", conn);
                cmd.Parameters.AddWithValue("@id_sku", ordenDetalle.id_sku);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        existencia = Convert.ToInt32(reader["existencias"]);
                    }
                }
                conn.Close();
            }
            return (ordenDetalle.cantidad <= existencia);
        }
        public bool insertarOrden(OrdenDetalle ordenDetalle)
        {
            using (MySqlConnection conn = MySQLConexion.obtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(@"insert into ordendetalle (id_sku, cantidad, estado, fecha_ingreso) values(@id_sku,@cantidad,@estado,@fecha_ingreso)", conn);
                cmd.Parameters.AddWithValue("@id_sku", ordenDetalle.id_sku);
                cmd.Parameters.AddWithValue("@cantidad", ordenDetalle.cantidad);
                cmd.Parameters.AddWithValue("@estado", ordenDetalle.estado);
                cmd.Parameters.AddWithValue("@fecha_ingreso", ordenDetalle.fecha_ingreso);
                var resultadoMySQL = cmd.ExecuteNonQuery();
                conn.Close();
                return resultadoMySQL == 1;
            }
        }
        public bool actualizarExistencias(OrdenDetalle ordenDetalle)
        {
            using (MySqlConnection conn = MySQLConexion.obtenerConexion())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(@"UPDATE sku SET existencias = existencias - @cantidad WHERE id = @id_sku", conn);
                cmd.Parameters.AddWithValue("@id_sku", ordenDetalle.id_sku);
                cmd.Parameters.AddWithValue("@cantidad", ordenDetalle.cantidad);
                var resultadoMySQL = cmd.ExecuteNonQuery();
                conn.Close();
                return resultadoMySQL == 1;
            }
        }

    }
}
