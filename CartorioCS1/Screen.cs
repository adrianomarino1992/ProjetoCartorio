using DataBaseLayer;
using DataBaseLayer.Models;
using DataBaseLayer.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace CartorioCS1
{
    public partial class Screen : Form
    {
        public Screen()
        {
            InitializeComponent();

            string conString = "Server=localhost;Port=5432;User Id=postgres;Password=123;Database=forumdb";

            PG_Connection.ConString = conString;

            ORMBusiness ORM = new ORMBusiness(PG_Connection.Instancia);



            if (ORM.CreateTable<IPessoa>())
            {
                MessageBox.Show("Criou pessoa");
            }
            else
            {
                MessageBox.Show("Falhou pessoa");
            }

            if (ORM.CreateTable<INascimento>())
            {
                MessageBox.Show("Criou nascimento");
            }
            else
            {
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
            

            if (ORM.CreateTable<ICasamento>())
            {
                MessageBox.Show("Criou casamento");
            }
            else
            {
                MessageBox.Show("Falhou casamento");
            }

            this.Controls.Add(new Controls.ControlBirths(typeof(ICasamento), ORM){ Dock = DockStyle.Fill });
        }
    }
}
