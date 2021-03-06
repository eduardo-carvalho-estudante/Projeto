﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using Projeto.DTO;
using Projeto.BLL;

namespace Projeto
{ 
    public partial class Email : MetroFramework.Forms.MetroForm
    {
        private string emailForm;
        private string assuntoTela;
        public Email(string email, string assunto)
        {
            InitializeComponent();
            txtPara.Text = email;
            txtAssunto.Text = assunto;
            emailForm = email;
            assuntoTela = assunto;
        }

        private void Email_Load(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            SendEmail();

        }

        private void SendEmail()
        {

            try { 
            //Para  enviar  email atráves de um windows forms tem que usar
            //System.Net.Mail
            MailMessage message = new MailMessage();

            //Aqui colocamos o "PARA" campo do formulário
            message.To.Add(txtPara.Text);

            //Aqui adicionamos o DE
            message.CC.Add(txtDe.Text);

            //Namesspace Attachments que permite adicionar um anexo
            Attachment anexo = new Attachment(txtFicheiro.Text);
            message.Attachments.Add(anexo);

            //Assunto do email
            message.Subject = txtAssunto.Text;

            //Endereço de email da pessoa que vai enviar ele
            message.From = new MailAddress("ideamais.gestao@gmail.com");

            //Corpo do email
            message.Body = txtMensagem.Text;

            //Instancia de um smtp
            SmtpClient smtp = new SmtpClient();

            //Definição do Host do smtp
            smtp.Host = "smtp.gmail.com";

            //Se for Gmail isso deve ser true
            smtp.EnableSsl = true;

            //Definição da Porta 
            smtp.Port = 587;

            //Desabilitar as credenciais padrões
            smtp.UseDefaultCredentials = false;

            //Definição das credenciais a serem usadas
            //Lembrando que o acesso de segunraça do google deve estar habilitado
            smtp.Credentials = new System.Net.NetworkCredential("ideamais.gestao@gmail.com", "ideamais123");

            smtp.Send(message);

            MessageBox.Show("Email enviado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if(assuntoTela == "Responde sua Dúvida!!")
                {
                    ContatosBLL contatosBLL = new ContatosBLL();
                    contatosBLL.AtualizaSituacao(emailForm);
                    Close();
                }
                else
                {
                    OrcamentosBLL orcamentosBLL = new OrcamentosBLL();
                    orcamentosBLL.AtualizaSituacao(emailForm);
                    Close();
                }

 

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnProcurar_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtFicheiro.Text = openFileDialog1.FileName;
        }
    }

}
