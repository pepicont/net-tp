using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;


namespace Forms
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };


        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            string desc = txtDesc.Text;
            int id = int.Parse(txtID.Text);
            CreatePlanDTO especialidad = new CreatePlanDTO(desc, id);
            var response = _httpClient.PostAsJsonAsync("planes", especialidad).Result;
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Especialidad cargada con éxito");

            }
            else
            {
                MessageBox.Show("Error al cargar la especialidad");

            }
        }
    }
}
