using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using Negocios;
using Entidades;

namespace Presentacion
{
    /// <summary>
    /// Interaction logic for WpfEmpleo.xaml
    /// </summary>
    public partial class WpfEmpleo : Window
    {
        nEmpleo neEmpleo = new nEmpleo();
        Empleo empleoSelection = null;
        int codEmpleo;
        public WpfEmpleo()
        {
            InitializeComponent();
            ConsultarEmpleos();
        }
        // Consultar empleos según el salario mínimo, máximo y el nombre del empleo
        private void ConsultarEmpleos()
        {
            dgEmpleos.ItemsSource = neEmpleo.ConsultarTodo();
        }
        private void CleanTextbox()
        {
            txtNombre.Clear();
            txtSalarioMinimo.Clear();
            txtSalarioMaximo.Clear();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if(txtNombre.Text != "" && txtSalarioMinimo.Text != "" && txtSalarioMaximo.Text != "")
            {
                // Crear objeto empleo y transferir data
                Empleo empleo = new Empleo();
                empleo.Nombre = txtNombre.Text;
                empleo.SalarioMinimo = Convert.ToDecimal(txtSalarioMinimo.Text);
                empleo.SalarioMaximo = Convert.ToDecimal(txtSalarioMaximo.Text);
                String respuesta = neEmpleo.Agregar(empleo);
                ConsultarEmpleos();
                CleanTextbox();
                MessageBox.Show(respuesta);
            }
            else
            {
                MessageBox.Show("Existen campos vacios, complételos !!!");
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (empleoSelection != null)
            {
                String respuesta = neEmpleo.Eliminar(codEmpleo);
                ConsultarEmpleos();
                CleanTextbox();
                MessageBox.Show(respuesta + " el empleo con código: " + codEmpleo.ToString());
            }
            else
            {
                MessageBox.Show("Para eliminar, debe seleccionar un Empleo");
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {   
            // Verificar que selecciono un Empleo
            if (empleoSelection != null)
            {   
                // Verificafr que el formulario tenga datos
                if (txtNombre.Text != "" && txtSalarioMinimo.Text != "" && txtSalarioMaximo.Text != "")
                {   
                    // Actualizando el empleoSelection con los datos del formulario
                    empleoSelection.Nombre = txtNombre.Text;
                    empleoSelection.SalarioMinimo = Convert.ToDecimal(txtSalarioMinimo.Text);
                    empleoSelection.SalarioMaximo = Convert.ToDecimal(txtSalarioMaximo.Text);
                    // Llamamos a Modificar de la capa datos
                    String respuesta = neEmpleo.Modificar(empleoSelection);
                    // Actualizamos el DataGrid con los datos de la Base de Datos
                    ConsultarEmpleos();
                    CleanTextbox();
                    MessageBox.Show(respuesta + " el empleo con código: " + codEmpleo.ToString());
                }
                else
                {
                    MessageBox.Show("Existen campos vacios, complételos !!!");
                }                
            }
            else
            {
                MessageBox.Show("Para modificar, debe seleccionar un Empleo");
            }
        }

        private void dgEmpleos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Copia el objeto seleccionado en el DataGrid al objeto empleoSelection
            empleoSelection = (Empleo)dgEmpleos.SelectedItem;
            if(empleoSelection != null)
            {
                codEmpleo = empleoSelection.CodEmpleo;
                // Colocar los datos en el formulario
                txtNombre.Text = empleoSelection.Nombre;
                txtSalarioMinimo.Text = empleoSelection.SalarioMinimo.ToString();
                txtSalarioMaximo.Text = empleoSelection.SalarioMaximo.ToString();
            }
        }
    }
}
