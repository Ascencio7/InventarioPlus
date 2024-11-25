using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InventarioPlus.ModeloUsuario
{
    public class UsuariosModel
    {
        public int UsuarioID { get; set; }
        public string Correo {  get; set; }
        public string NombreUsuario { get; set; }
        public byte[] Contrasena { get; set; }
        public int RolID {  get; set; }

        public UsuariosModel() { }
    }
}