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
            //creando e inicializando variables
            string nombre = nameTextBox.Text;
            int nota1 = Convert.ToInt32(nota1TextBox.Text), nota2 = Convert.ToInt32(nota2TextBox.Text), nota3 = Convert.ToInt32(nota3TextBox.Text),
                nota4 = Convert.ToInt32(nota4TextBox.Text);

            //creando variable de media e inicializandola con el valor que devuelve la funcino asincrona
            int media = await promedioAsync(nota1, nota2, nota3, nota4);
            MessageBox.Show($"El promedio es: {media}");



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
