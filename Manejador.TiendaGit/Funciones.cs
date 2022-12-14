using System.Collections.Generic;
using AccesoDatos.TiendaGit;
using Entidades.TiendaGit;

namespace Manejador.TiendaGit
{
    public class Funciones
    {
        private TiendaAccesoDatos _tiendaAccesoDatos = new TiendaAccesoDatos();
        public List<Productos> GetProductos(string dato)
        {
            var listProductos = _tiendaAccesoDatos.GetProductos(dato);
            return listProductos;
        }
        public void GuardarProducto(Productos producto)
        {
            _tiendaAccesoDatos.GuardarProducto(producto);
        }
        public void EliminarProducto(int idProducto)
        {
            _tiendaAccesoDatos.EliminarProducto(idProducto);
        }
        public void ModificarProducto(Productos producto)
        {
            _tiendaAccesoDatos.ModificarProducto(producto);
        }
    }
}
