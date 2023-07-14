using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aula04AppBanco
{
    public partial class Form1 : Form
    {
        // variáveis globais
        List<string> extratos = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            double valor = double.Parse(txtValor.Text);
            double saldo = double.Parse (lblSaldo.Text.Replace("R$", ""));
            double soma;
            if(lblOperacao.Text == "SACAR")
            {
                soma = saldo - valor;
                extratos.Add("SAQUE NO VALOR DE R$" + valor);
            }
            else
            {
                soma = valor + saldo;
                extratos.Add("DEPÓSITO NO VALOR DE R$" + valor);
            }

            lblSaldo.Text = "R$" + soma;


            if(lblSaldo.Text == "0")
            {
                MessageBox.Show("Saldo insuficiente :(");
            }



        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            btnDepositar.BackColor = Color.Gainsboro;
            btnDepositar.ForeColor = Color.Black;
            btnSacar.BackColor = Color.LightBlue;
            btnSacar.ForeColor = Color.DodgerBlue;
            lblOperacao.Text = "SACAR";

            
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            btnSacar.BackColor = Color.Gainsboro;
            btnSacar.ForeColor = Color.Black;
            btnDepositar.BackColor = Color.LightBlue;
            btnDepositar.ForeColor = Color.DodgerBlue;
            lblOperacao.Text = "DEPOSITAR";
        }

        private void btnExtrato_Click(object sender, EventArgs e)
        {
            Form2 telaExtrato= new Form2();
            telaExtrato.extratos = extratos;
            telaExtrato.Show();
        }
    }
}
