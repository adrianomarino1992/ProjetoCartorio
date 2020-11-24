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
using System.Reflection;
using DataBaseLayer;
using BusinessLayer.Models;
using Flags = DataBaseLayer.DataBaseFlags;

namespace CartorioCS1.Controls
{
    public partial class ControlBirths : UserControl
    {

        public delegate void OverHandler();

        public OverHandler Over;

        List<KeyValuePair<PropertyInfo, Control>> _bindControlsValues = new List<KeyValuePair<PropertyInfo, Control>>();

        private IOperation _operation;

        private IORM _connection;
        public ControlBirths(Type operationType, IORM connection)
        {
            InitializeComponent();

            Flags.DBFlags piAttr = (Flags.DBFlags)operationType.GetCustomAttribute(typeof(Flags.DBFlags));

            lblBuscar.Text = piAttr.LabelText;

            if (operationType == typeof(IPessoa))
            {
                _operation = (Pessoa)Activator.CreateInstance(typeof(Pessoa));
                lblTitulo.Text = "CADASTRAR PESSOAS";
            }
            else
            if (operationType == typeof(INascimento))
            {
                _operation = (Nascimento)Activator.CreateInstance(typeof(Nascimento));
                lblTitulo.Text = "CADASTRAR NASCIMENTOS";
            }
            else
            if (operationType == typeof(IObito))
            {
                _operation = (Obito)Activator.CreateInstance(typeof(Obito));
                lblTitulo.Text = "CADASTRAR OBITOS";
            }
            else
            if (operationType == typeof(ICasamento))
            {
                _operation = (Casamento)Activator.CreateInstance(typeof(Casamento));
                lblTitulo.Text = "CADASTRAR CASAMENTOS";
            }

            _connection = connection;

            txtValue.KeyPress += Validacoes.Integer_Validation;

            Reload(operationType);


        }

        private void Reload(Type operationType, IOperation obj = null)
        {
            if (obj != null)
            {
                if (obj.Id == 0)
                    MessageBox.Show("Nada foi econtrado");
            }

            pnlContainer.Controls.Clear();

            foreach (PropertyInfo pi in operationType.GetPublicProperties())
            {
                Flags.DBFlags piAttr = (Flags.DBFlags)pi.GetCustomAttribute(typeof(Flags.DBFlags));


                if (!piAttr.Private)
                {

                    pnlContainer.Controls.Add(new Label()
                    {
                        Text = pi.Name + " : ",
                        Location = new Point(10, (pnlContainer.Controls.Count * 30) + 10),
                        Size = new Size(100, 30)
                    });

                    TextBox textBox = new TextBox()
                    {
                        Location = new Point(120, ((pnlContainer.Controls.Count - 1) * 30) + 10),
                    };

                    if (obj != null)
                    {
                        if (obj.Id != 0)
                            textBox.Text = pi.GetValue(obj).ToString();
                    }

                    textBox.Enabled = piAttr.Editable;

                    pnlContainer.Controls.Add(textBox);

                    KeyValuePair<PropertyInfo, Control> keyValuePropertyControl = new KeyValuePair<PropertyInfo, Control>(pi, textBox);
                    _bindControlsValues.Add(keyValuePropertyControl);
                }

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            if (txtValue.Text != "")
            {

                Type previewsType;

                if (_operation.GetType() == typeof(Pessoa))
                {
                    previewsType = typeof(IPessoa);
                    _operation = _connection.Search<IPessoa, Pessoa>(txtValue.Text);

                }
                else if (_operation.GetType() == typeof(Obito))
                {
                    previewsType = typeof(IObito);
                    _operation = _connection.Search<IObito, Obito>(txtValue.Text);

                }
                else if (_operation.GetType() == typeof(Nascimento))
                {
                    previewsType = typeof(INascimento);
                    _operation = _connection.Search<INascimento, Nascimento>(txtValue.Text);

                }
                else
                {
                    previewsType = typeof(ICasamento);
                    _operation = _connection.Search<ICasamento, Casamento>(txtValue.Text);

                }

                Reload(previewsType, _operation);

            }
            else
            {
                MessageBox.Show("Informe um id");
            }
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (_operation.Id != 0)
            {
                MessageBox.Show("Este registro ja existe, voce pode apenas editar ou excluir");
                return;
            }

            foreach (KeyValuePair<PropertyInfo, Control> kp in _bindControlsValues)
            {
                foreach (PropertyInfo po in _operation.GetType().GetPublicProperties())
                {

                    

                    if (po.Name == kp.Key.Name)
                    {
                      
                        if (po.PropertyType == typeof(int))
                        {
                            try
                            {
                                po.SetValue(_operation, Convert.ToInt32(((TextBox)kp.Value).Text));
                            }
                            catch
                            {

                            }
                        }
                        if (po.PropertyType == typeof(double))
                        {
                            try
                            {
                                po.SetValue(_operation, Convert.ToDouble(((TextBox)kp.Value).Text));
                            }
                            catch
                            {

                            }
                        }
                        if (po.PropertyType == typeof(string))
                        {
                            try
                            {
                                po.SetValue(_operation, Convert.ToString(((TextBox)kp.Value).Text));
                            }
                            catch
                            {

                            }
                        }
                        if (po.PropertyType == typeof(DateTime))
                        {
                            try
                            {
                                po.SetValue(_operation, Convert.ToDateTime(((TextBox)kp.Value).Text));
                            }
                            catch
                            {

                            }
                        }


                    }
                }

            }


            if (!_operation.Validar()) {

                MessageBox.Show("PREENCHA TODOS OS CAMPOS");
                return;
            }
            

            if (_operation.GetType() == typeof(Pessoa))
            {
                
                if (_connection.Save<IPessoa>((IPessoa)_operation))
                {
                    MessageBox.Show(_connection.Message);

                    this.Over();
                }
                else
                {
                    MessageBox.Show(_connection.Message);
                }
            }
            else
            if (_operation.GetType() == typeof(Nascimento))
            {
                if (_connection.Save<INascimento>((INascimento)_operation))
                {
                    MessageBox.Show(_connection.Message);
                    this.Over();
                }
                else
                {
                    MessageBox.Show(_connection.Message);
                }
            }
            else
            if (_operation.GetType() == typeof(Obito))
            {
                if (_connection.Save<IObito>((IObito)_operation))
                {
                    MessageBox.Show(_connection.Message);
                    this.Over();
                }
                else
                {
                    MessageBox.Show(_connection.Message);
                }
            }
            else
            {
                if (_connection.Save<ICasamento>((Casamento)_operation))
                {
                    MessageBox.Show(_connection.Message);
                    this.Over();
                }
                else
                {
                    MessageBox.Show(_connection.Message);
                }
            }


        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (_operation.Id != 0)
            {

                if (_operation.GetType() == typeof(Pessoa))
                {


                    if (_connection.Remove<IPessoa>((IPessoa)_operation))
                    {
                        MessageBox.Show("Registro removido");
                        _operation = new Pessoa();
                        this.Over();
                    }

                }
                else if (_operation.GetType() == typeof(Obito))
                {
                    if (_connection.Remove<IObito>((IObito)_operation))
                    {
                        MessageBox.Show("Registro removido");
                        _operation = new Obito();
                        this.Over();
                    }

                }
                else if (_operation.GetType() == typeof(Nascimento))
                {
                    if (_connection.Remove<INascimento>((INascimento)_operation))
                    {
                        MessageBox.Show("Registro removido");
                        _operation = new Nascimento();
                        this.Over();
                    }

                }
                else
                {
                    if (_connection.Remove<ICasamento>((ICasamento)_operation))
                    {
                        MessageBox.Show("Registro removido");
                        _operation = new Casamento();
                        this.Over();
                    }

                }

            }
            else
            {
                MessageBox.Show("Localize um registro");
            }
        }
    }
}
