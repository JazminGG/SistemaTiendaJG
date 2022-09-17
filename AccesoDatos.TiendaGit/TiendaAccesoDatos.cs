using System;
using System.Collections.Generic;
using System.Data;
using Entidades.TiendaGit;

namespace AccesoDatos.TiendaGit
{
    public class TiendaAccesoDatos
    {
        Conexion con;
        public TiendaAccesoDatos()
        {
            con = new Conexion("localhost", "root", "", "Sistema", 3306);
        }
        public void GuardarProducto(Productos producto)
        {
            string consulta = string.Format("Insert into productos values({0},'{1}','{2}',{3})",
                producto.IdProducto, producto.Nombre, producto.Descripcion, producto.Precio);
            con.EjecutarConsulta(consulta);
        }
        public List<Productos> GetProductos(string dato)
        {
            var ListProductos = new List<Productos>();
            var ds = new DataSet();

            string consulta = string.Format("select * from productos where nombre like '%{0}%'", dato);
            ds = con.ObtenerDatos(consulta, "productos");

            var dt = new DataTable();
            dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var Productos = new Productos
                {
                    IdProducto = Convert.ToInt32(row["IdProducto"]),
                    Nombre = row["Nombre"].ToString(),
                    Descripcion = row["Descripcion"].ToString(),
                    Precio = Convert.ToInt32(row["Precio"])
                };
                ListProductos.Add(Productos);
            }
            return ListProductos;
        }
    }
}
