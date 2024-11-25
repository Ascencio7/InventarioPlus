using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;

// Libreria para poder arrastrar el formulario con el puntero
using System.Runtime.InteropServices;

//base de datos
using System.Data.SqlClient;
using System.Data.Sql;

using System.Security.Cryptography;


namespace InventarioPlus
{
    public partial class frmLogin : Form
    {
        
        public frmLogin()
        {
            InitializeComponent();
        }


        #region Método para Mover

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        /*
            
            Documentacion:

            1.[DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]:

                1. [DllImport]: Es un atributo de C# que indica que se importa una función de 
                   la biblioteca dinámica (.DLL) externa de .NET. Se traen las funciones de la
                   biblioteca 'user32.DLL', que es parte del sistema operativo Windows.

                2. EntryPoint = "ReleaseCapture": Especifica el nombre exacto de la función que 
                   importa desde la DDL.

            2. Declaración de la función:
                
                private extern static void ReleaseCapture();
                
                    1. extern: Indicia que la función no está definida en C# sino en código externo DLL.
                    
                    2. static: La función es estática y se puede llamar sin instanciar un objeto.

                    3. void: No devuelve ningún valor.

            3. Función ReleaseCapture: Es la función de la biblioteca 'user32.DLL' que libera la captura 
               del mouse de la ventana activa. Permite que otros eventos con el mouse ocurra sin problemas, como
               arrastrar la ventana.


            4. [DllImport("user32.DLL", EntryPoint = "SendMessage")]:
                
                1. Se importa otra función desde 'user32.DLL' llamada 'SendMessage'.

            5. Declaración de la función:

                private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
                

                    1. System.IntPtr hwnd: Es un puntero que identifica una ventana o control especificado.
                       En el caso de la ventana de formulario, se pasa usando 'this.Handle'.

                    2. int wmsg: El código del mesnaje que se quiere enviar. El 0x112 representa el mensaje WM_SYSCOMMAND.

                    3. int wparam: Parámetro adicional relacionado con el mensaje. El 0xF012 especifica el comando SC_MOVE para mover la ventana.
                    
                    4. int lparam: Es otro parámetro adicional. Se pasa como 0 porque no se usa.

                    5. SendMessage: Envia el mensaje a la venta o control identificado por 'hwnd'. 

            
            6. Liberar el control del mouse: Usando ReleaseCapture, se libera la captura del mouse para que la ventana pueda procesar otros eventos.
            7. Simular un mensaje de movimiento de ventana: Usando SendMessage, se envía el mensaje WM_SYSCOMMAND con el parámetro SC_MOVE, lo que 
               le indica al sistema operativo que debe permitir el movimiento de la ventana.
         */


        #endregion



        #region Evento txt de Usuario y Contra
        private void txtUser_Enter(object sender, EventArgs e)
        {
            if(txtUser.Text == "Usuario") // Verifica si el txt tiene el texto 'Usuario',
            {
                txtUser.Text = ""; // si es asi, el txt se vacia para que el usuario pueda ingresar texto,
                txtUser.ForeColor = Color.Black; // y el texto es de color negro.
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if(txtUser.Text == "") // Verifica si el txt está vacío,
            {
                txtUser.Text = "Usuario"; // entonces el txt se llena con el texto 'Usuario',
                txtUser.ForeColor = Color.Black; // y el texto es de color negro.
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if(txtPass.Text == "Contraseña")// Verifica si el txt tiene el texto 'Contraseña',
            {
                txtPass.Text = ""; // si es asi, el txt se vacia para que el usuario pueda ingresar la contraseña,
                txtPass.ForeColor = Color.Black; // la contraseña será de color negro,
                txtPass.UseSystemPasswordChar = true; // UseSystemPasswordChar es la propiedad que hace que la contraseña sea como circulo y no se pueda ver,
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if(txtPass.Text == "") // Verifica si el txt está vacío,
            {
                txtPass.Text = "Contraseña"; // entonces el txt se llena con el texto 'Contraseña',
                txtPass.ForeColor = Color.Black; // el texto se vuelve de color negro,
                txtPass.UseSystemPasswordChar = false; // ya no oculta la contraseña y vuelve a mostrar el texto 'Contraseña'.
            }
        }
        #endregion



        #region Botones

        // Botón para cerrar el form de Iniciar sesión
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // Condición para el usuario, si responde "SI" entonces se cierra el form, si no, no pasará nada.
            if(MessageBox.Show("¿Desea cerrar la aplicación?", "ATLAS CORP | CERRAR APLICACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit(); // Cierra la aplicación
            }
        }

        // Botón para minimizar el formulario
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion



        #region Evento de mover el form
        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture(); // Permite arrastrar el formulario
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            /*
                
                this.Handle: Es el identificador de la ventana actual.
                
                0x112: Es el código del mensaje (WM_SYSCOMMAND) que indica que se 
                quiere ejecutar un comando del sistema.
                
                0xf012: Especifica el comando SC_MOVE que le indica al sistema que 
                debe mover la ventana.

                0: Es el parámetro adicional.
                
             */
        }

        private void panelLogo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBoxLogo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion



    }
}