using System;
using System.Windows.Forms;
using Entidades.TiendaGit;
using Manejador.TiendaGit;

namespace PresentacionTiendaGit
{
    public partial class FrmProducto : Form
    {
        private Funciones _funciones;
        private string _bandera;
        public FrmProducto()
        {
            InitializeComponent();
            _funciones = new Funciones();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        private void GuardarProducto()
        {
            Productos producto = new Productos();
            producto.IdProducto = Convert.ToInt32(txtIdProducto.Text);
            producto.Nombre = txtNombre.Text;
            producto.Descripcion = txtDescripcion.Text;
            producto.Precio = Convert.ToInt32(txtPrecio.Text);

            _funciones.GuardarProducto(producto);
        }
        private void LlenarProducto(string dato)
        {
            dgvProductos.DataSource = _funciones.GetProductos(dato);
        }
        private void ControlarBotones(bool nuevo, bool guardar, bool cancelar, bool eliminar, bool salir)
        {
            btnNuevo.Enabled = nuevo;
            btnGuardar.Enabled = guardar;
            btnCancelar.Enabled = cancelar;
            btnEliminar.Enabled = eliminar;
            btnSalir.Enabled = salir;
        }
        private void LimpiarCuadros()
        {
            txtIdProducto.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
        }
        private void ControlarCuadros(bool control)
        {
            txtIdProducto.Enabled = control;
            txtNombre.Enabled = control;
            txtDescripcion.Enabled = control;
            txtPrecio.Enabled = control;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ControlarBotones(false, true, true, false, false);
            ControlarCuadros(true);
            _bandera = "guardar";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ControlarBotones(true, false, false, true, true);
            LimpiarCuadros();
            ControlarCuadros(false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ControlarBotones(true, false, false, true, true);
                if (_bandera == "guardar")
                {
                    GuardarProducto();
                    LlenarProducto("");
                    MessageBox.Show("Se guardo correctamente");
                }
                else
                {
                    /*ModificarUsuario();
                    LlenarProducto("");
                    MessageBox.Show("Se actualizo correctamente");*/
                }
                LimpiarCuadros();
                ControlarCuadros(false);
                //LlenarProducto("");
            }
            catch (Exception)
            {
                MessageBox.Show("Verificar datos");
            }
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            LlenarProducto("");
            ControlarBotones(true, false, false, true, true);
            LimpiarCuadros();
            ControlarCuadros(false);
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _bandera = "actualizar";
                ControlarCuadros(true);
                ControlarBotones(false, true, true, false, false);
                txtIdProducto.Text = dgvProductos.CurrentRow.Cells["IdProducto"].Value.ToString();
                txtNombre.Text = dgvProductos.CurrentRow.Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = dgvProductos.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = dgvProductos.CurrentRow.Cells["Precio"].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al intentar actualizar");
            }
        }
    }
}
