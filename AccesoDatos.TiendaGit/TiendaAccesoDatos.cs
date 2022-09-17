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
            con = new Conexion("localhost", "root", "", "Tienda5to", 3306);
        }
        public void GuardarProducto(Productos producto)
        {
            string consulta = string.Format("INSERT INTO productos VALUES({0},'{1}','{2}',{3})", 
                producto.IdProducto, producto.Nombre, producto.Descripcion, producto.Precio);
            con.EjecutarConsulta(consulta);
        }
        public List<Productos> GetProductos(string dato)
        {
            var ListProductos = new List<Productos>();
            var ds = new DataSet();

            string consulta = string.Format("select * from productos where Nombre like '%{0}%'", dato);
            ds = con.ObtenerDatos(consulta, "productos");

            var dt = new DataTable();
            dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var productos = new Productos
                {
                    IdProducto = Convert.ToInt32(row["IdProducto"]),
                    Nombre = row["Nombre"].ToString(),
                    Descripcion = row["Descripcion"].ToString(),
                    Precio = Convert.ToInt32(row["Precio"])
                };
                ListProductos.Add(productos);
            }
            return ListProductos;
        }
    }
}
