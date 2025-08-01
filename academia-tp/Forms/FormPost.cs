﻿using System;
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
    public partial class FormPost : Form
    {
        public FormPost()
        {
            InitializeComponent();
        }
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5290")
        };

        private async void buttonPost_Click(object sender, EventArgs e)
        {
            string desc = RichTextBoxDescripcion.Text;
            EspecialidadDTO especialidad = new EspecialidadDTO(desc);
            var response = await _httpClient.PostAsJsonAsync("especialidades",especialidad);
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
