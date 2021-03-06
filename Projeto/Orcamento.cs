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
    public partial class Orcamento :  MetroFramework.Forms.MetroForm
    {
        public Orcamento()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Orcamento_Load(object sender, EventArgs e)
        {

            //Método que chama o grid
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            IList<orcamentos_DTO> listaOrcamento = new List<orcamentos_DTO>();
            listaOrcamento = new OrcamentosBLL().CargaOrcamentos();

            DvgOrcamento.DataSource = listaOrcamento;
        }

        private void DvgOrcamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sel = DvgOrcamento.CurrentRow.Index;

            txtNome.Text = Convert.ToString(DvgOrcamento["nome", sel].Value);
            txtTelefone.Text = Convert.ToString(DvgOrcamento["telefone", sel].Value);
            txtEmail.Text = Convert.ToString(DvgOrcamento["email", sel].Value);

            if (Convert.ToString(DvgOrcamento["situacao", sel].Value) == "1")
            {
                cboSituacao.Text = "Não Respondido";
            }

            /*else
            {
                cboSituacao.Text = "Respondido";
              
            }*/


        }

        private void BtnResponder_Click(object sender, EventArgs e)
        {
            if (cboSituacao.Text == "Não Respondido")
            {
                MessageBox.Show("MUDE A SITUAÇÃO!!");
            }
            else if (txtNome.Text == "")
            {
                MessageBox.Show("Selecione um Orçamento!!");
            }
            else
            {
                string emailform = txtEmail.Text;
                string assunto = "Orçamento";
                MetroFramework.Forms.MetroForm email = new Email(emailform, assunto);
                email.Show(); ;
            }

        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            txtTelefone.Text = "";
            cboSituacao.Text = "";
            CarregaGrid();

        }
    }
}
