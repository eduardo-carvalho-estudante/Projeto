﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Projeto.DTO;
using Projeto.BLL;

namespace Projeto
{
    public partial class Duvidas : Form
    {
        public Duvidas()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Duvidas_Load(object sender, EventArgs e)
        {

            //Método que carrega os dados do grid
            CarregaGrid();
        }

        private void DgvDuvidas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sel = DgvDuvidas.CurrentRow.Index;

            txtNome.Text = Convert.ToString(DgvDuvidas["nome", sel].Value);
            txtEmail.Text = Convert.ToString(DgvDuvidas["email", sel].Value);
            mskTxtTelefone.Text = Convert.ToString(DgvDuvidas["telefone", sel].Value);
            txtMensagem.Text = Convert.ToString(DgvDuvidas["mensagem", sel].Value);
        }

        private void CarregaGrid()
        {
            try
            {
                IList<contatos_DTO> listContatos_DTO = new List<contatos_DTO>();
                listContatos_DTO = new ContatosBLL().cargaContatos();

                DgvDuvidas.DataSource = listContatos_DTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}