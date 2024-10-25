using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Separacao_de_Materiais.Styles
{
    public class Style_Panel : Panel
    {
        private int _cornerRadius = 30; // Tamanho dos cantos arredondados

        public int CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; }//this.Invalidate(); } // Redesenhar o painel quando mudar
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Desenhar bordas arredondadas usando GraphicsPath
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, _cornerRadius, _cornerRadius, 180, 90);
            path.AddArc(this.Width - _cornerRadius - 1, 0, _cornerRadius, _cornerRadius, 270, 90);
            path.AddArc(this.Width - _cornerRadius - 1, this.Height - _cornerRadius - 1, _cornerRadius, _cornerRadius, 0, 90);
            path.AddArc(0, this.Height - _cornerRadius - 1, _cornerRadius, _cornerRadius, 90, 90);
            path.CloseFigure();

            // Definir a região do painel como a forma arredondada
            this.Region = new Region(path);
        }
    }
}
