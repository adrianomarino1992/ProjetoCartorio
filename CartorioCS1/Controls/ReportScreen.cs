using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBaseLayer.Models;
using BusinessLayer.Models;
using DataBaseLayer;
using BusinessLayer;

namespace CartorioCS1.Controls
{
    public partial class ReportScreen : UserControl
    {
        public delegate void OverHandler(IOperation operation);

        public OverHandler DataGridViewCellClicked;

        private IORM _connection;
        public ReportScreen(IORM connection)
        {
            InitializeComponent();

            _connection = connection;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Text != "")
            {

                Type previewsType;

               
                    previewsType = typeof(INascimento);

                /* por falta de tempo tive que desrespeitar o principio 'Liskov Subistitution Principle'
                 que diz que ao trocar uma dependencia por uma de tipo ascendente, o codigo deve funcionar, nesse caso, 
                 tive que realizar um DownCasting de IORM ==> ORMBusiness :( */

                try
                {
                    List<Nascimento> nascimentos = ((ORMBusiness)_connection).SearchAll<Nascimento, INascimento>(
                        $"SELECT * FROM tb_nascimento WHERE dt_registro  = '{Validacoes.DataToString(dateTimePicker1.Value)}';"
                        );


                    dataGridView1.DataSource = nascimentos;

                    lblTotal.Text = "Total : " + nascimentos.Count;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Informe uma data");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Nascimento nascimento = (Nascimento)dataGridView1.SelectedRows[0].DataBoundItem;

                DataGridViewCellClicked(nascimento);
            }
        }

        private void RefHoverStart(object sender, EventArgs e)
        {
            Padroes.HoverStart((Control)sender);
        }

        private void RefHoverEnd(object sender, EventArgs e)
        {

            Padroes.HoverEnd((Control)sender);
        }
    }
}
