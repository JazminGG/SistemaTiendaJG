using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        
    }
}
