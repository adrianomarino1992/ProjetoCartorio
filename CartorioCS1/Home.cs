using DataBaseLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBaseLayer.ORM;
using DataBaseLayer.Models;
using System.Configuration;
using BusinessLayer;

namespace CartorioCS1
{
    public partial class Home : Form
    {
        private IORM _ORM;
        public Home()
        {
            InitializeComponent();


            string conString = ConfigurationManager.AppSettings["connString"];

            PG_Connection.ConString = conString;

            _ORM = new ORMBusiness(/*PG_Connection.Instancia encapsula uma classe singleton*/PG_Connection.Instancia);


        }

        private void pnlPanelLateral_Paint(object sender, PaintEventArgs e)
        {
            Padroes.Gradient(this.pnlPanelLateral, Color.Gainsboro, Color.White, 90F, e);
        }

        private void pnlPanelLateral_Resize(object sender, EventArgs e)
        {
            Padroes.FormResize(this.pnlPanelLateral);
        }

        private void RefHoverStart(object sender, EventArgs e)
        {
            Padroes.HoverStart((Control)sender);
        }

        private void RefHoverEnd(object sender, EventArgs e)
        {

            Padroes.HoverEnd((Control)sender);
        }

        private void pnlBtnNascimento_Click(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Clear();
            this.pnlContainer.Controls.Add(new Controls.ControlBirths(typeof(INascimento), _ORM)
            {
                Dock = DockStyle.Fill,
                Over = () => { this.pnlContainer.Controls.Clear(); }
            });
        }

        private void pnlBtnCasamentos_Click(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Clear();
            this.pnlContainer.Controls.Add(new Controls.ControlBirths(typeof(ICasamento), _ORM)
            {
                Dock = DockStyle.Fill,
                Over = () => { this.pnlContainer.Controls.Clear(); }
            });
        }

        private void pnlBtnObitos_Click(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Clear();
            this.pnlContainer.Controls.Add(new Controls.ControlBirths(typeof(IObito), _ORM)
            {
                Dock = DockStyle.Fill,
                Over = () => { this.pnlContainer.Controls.Clear(); }
            });
        }

        private void pnlBtnPessoas_Click(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Clear();
            this.pnlContainer.Controls.Add(new Controls.ControlBirths(typeof(IPessoa), _ORM)
            {
                Dock = DockStyle.Fill,
                Over = () => { this.pnlContainer.Controls.Clear(); }
            });
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("A aplicação utilizará a string de conecção fornecida no " +
                            "arquivo de configuração para realizar uma conexão com a base de dados e, se " +
                            "bem sucedida, criar as tabelas " +
                            "e habilitar as outras funções do software", "ATENÇÃO", MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            {

                try
                {

                    string conString = ConfigurationManager.AppSettings["connString"];

                    PG_Connection.ConString = conString;

                    if (PG_Connection.Instancia.TestConnection())
                    {
                        _ORM = new ORMBusiness(/*PG_Connection.Instancia encapsula uma classe singleton*/PG_Connection.Instancia);

                        MessageBox.Show("Conexão bem sucessida, criando banco ...");

                        if (_ORM.CreateTable<IPessoa>())
                        {
                            MessageBox.Show("Criou tabela PESSOA");
                        }
                        else
                        {
                            MessageBox.Show("Falhou tabela PESSOA");
                        }

                        if (_ORM.CreateTable<INascimento>())
                        {
                            MessageBox.Show("Criou tabela NASCIMENTO");
                        }
                        else
                        {
                            MessageBox.Show("Falhou tabela NASCIMENTO");
                        }


                        if (_ORM.CreateTable<IObito>())
                        {
                            MessageBox.Show("Criou tabela OBITO");
                        }
                        else
                        {
                            MessageBox.Show("Falhou tabela OBITO");
                        }


                        if (_ORM.CreateTable<ICasamento>())
                        {
                            MessageBox.Show("Criou tabela CASAMENTO");
                        }
                        else
                        {
                            MessageBox.Show("Falhou tabela CASAMENTO");
                        }


                        pnlBtnBanco.Enabled = false;
                        pnlBtnNascimento.Enabled = true;
                        pnlBtnObitos.Enabled = true;
                        pnlBtnCasamentos.Enabled = true;
                        pnlBtnPessoas.Enabled = true;
                        pnlBtnRelatorios.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Conexão mal sucessida");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Tudo bloqueado até criar as tabelas !");
            }
        }
    }
}
