using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PromedioEstudiantes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void calcularButton_Click(object sender, EventArgs e)
        {
            //Validando que no haya campos vacios
            if (nameTextBox.Text == "")
            {
                errorProvider1.SetError(nameTextBox, "No puede dejar este campo vacío");
                return;
            }
            errorProvider1.Clear();
            if (nota1TextBox.Text == "")
            {
                errorProvider1.SetError(nota1TextBox, "No puede dejar este campo vacío");
                return;
            }

            if (nota2TextBox.Text == "")
            {
                errorProvider1.SetError(nota2TextBox, "No puede dejar este campo vacío");
                return;
            }

            if (nota3TextBox.Text == "")
            {
                errorProvider1.SetError(nota3TextBox, "No puede dejar este campo vacío");
                return;
            }

            if (nota4TextBox.Text == "")
            {
                errorProvider1.SetError(nota4TextBox, "No puede dejar este campo vacío");
                return;
            }

            //quitando advertencia luego que el usuario ingrese el dato necesario en las cajas de texto luego de haber validado
            errorProvider1.Clear();

            //creando e inicializando variables
            string nombre = nameTextBox.Text;
            int nota1 = Convert.ToInt32(nota1TextBox.Text), nota2 = Convert.ToInt32(nota2TextBox.Text), nota3 = Convert.ToInt32(nota3TextBox.Text),
                nota4 = Convert.ToInt32(nota4TextBox.Text);
          
            //Imprimiendo resultado obtenido por  medio de un Message.Box con la llamada de la funcion asincronica
            MessageBox.Show("El promedio de " + nombre + $" es {await  promedioAsync(nota1, nota2, nota3, nota4)}");

        }
        //creando funcion asincrona
        private async Task<int> promedioAsync(int n1, int n2, int n3, int n4)//pasandole parametros formales
        {
            int media = await Task.Run(() =>
            {
                return (n1 + n2 + n3 + n4) / 4;// calculando promedio
            });
            return media;// retornando promedio
        }
    }
}
