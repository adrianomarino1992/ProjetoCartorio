using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CartorioCS1
{

    public static class Padroes
    {
        public static void Gradient(Panel panel, Color from, Color to, float angle, PaintEventArgs e)
        {

            using (LinearGradientBrush brush = new LinearGradientBrush(panel.ClientRectangle,from,to, angle))
            {
                e.Graphics.FillRectangle(brush, panel.ClientRectangle);
            }

        }

        public static void FormResize(Panel panel)
        {            
                panel.Invalidate();           

        }

        public static void CloseForm(Form toClose)
        {
            toClose.Close();
        }

        private static Color _aux;
        public static void HoverStart(Control control) {

            Control refControl;

            if (control.GetType() == typeof(Panel))
            {

                refControl = (Panel)control;

            }
            else {

                refControl = ((Panel)control.Parent);
            
            }

            if (_aux != refControl.BackColor)
            {
                _aux = refControl.BackColor;
                refControl.BackColor = Color.DarkGray;
            }
        }

        public static void HoverEnd(Control control)
        {
            Control refControl;

            if (control.GetType() == typeof(Panel))
            {

                refControl = (Panel)control;

            }
            else
            {

                refControl = ((Panel)control.Parent);

            }

            refControl.BackColor = _aux;

            _aux = Color.Empty;
                
            

        }
    }
}
