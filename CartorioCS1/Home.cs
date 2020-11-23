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

namespace CartorioCS1
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void pnlPanelLateral_Paint(object sender, PaintEventArgs e)
        {
            Padroes.Gradient(this.pnlPanelLateral, Color.Gainsboro, Color.White, 90F, e);
        }

        private void pnlPanelLateral_Resize(object sender, EventArgs e)
        {
            Padroes.FormResize(this.pnlPanelLateral);
        }

        private void RefHoverStart(object sender, EventArgs e )
        {
            Padroes.HoverStart((Control)sender);
        }

        private void RefHoverEnd(object sender, EventArgs e) {

            Padroes.HoverEnd((Control)sender);
        }

        private void panel3_Click(object sender, EventArgs e)
        {
          string conString = "Server=localhost;Port=5432;User Id=postgres;Password=123;Database=cartorio";

            PG_Connection.ConString = conString;

            DefaultORM ORM = new DefaultORM(PG_Connection.Instancia);
                       

            if (ORM.CreateTable<INascimento>())
            {
                MessageBox.Show("Criou nascimento");
            }
            else {
                MessageBox.Show("Falhou nascimento");
            }


            if (ORM.CreateTable<IObito>())
            {
                MessageBox.Show("Criou obito");
            }
            else
            {
                MessageBox.Show("Falhou obito");
            }

            if (ORM.CreateTable<IPessoa>())
            {
                MessageBox.Show("Criou pessoa");
            }
            else
            {
                MessageBox.Show("Falhou pessoa");
            }

            if (ORM.CreateTable<ICasamento>())
            {
                MessageBox.Show("Criou casamento");
            }
            else
            {
                MessageBox.Show("Falhou casamento");
            }
        }
    }
}
