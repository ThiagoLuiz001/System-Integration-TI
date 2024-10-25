using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Separacao_de_Materiais.Styles
{
    public class Style_TextBox : TextBox
    {
        private int _cornerRadius = 15;  // Tamanho dos cantos arredondados
        private Color _borderColor = Color.Gray; // Cor da borda
        private int _borderSize = 2; // Tamanho da borda
        private int _padding = 20;

        public int CornerRadius
        {
            get { return _cornerRadius; }
            set
            {
                _cornerRadius = value;
                this.Invalidate();
                this.Refresh(); // Forçar a atualização imediata
            }
        }


        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                //this.Invalidate();
                this.Refresh(); // Forçar a atualização imediata
            }
        }

        public int BorderSize
        {
            get { return _borderSize; }
            set
            {
                _borderSize = value;
               // this.Invalidate();
                this.Refresh(); // Forçar a atualização imediata
            }
        }

        public Style_TextBox()
        {
            this.BorderStyle = BorderStyle.Fixed3D; // Remover a borda padrão
             this.Padding = new Padding(20); // Ajustar o padding interno
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Cria uma borda arredondada
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, _cornerRadius, _cornerRadius, 180, 90);
            path.AddArc(this.Width - _cornerRadius - 1, 0, _cornerRadius, _cornerRadius, 270, 90);
            path.AddArc(this.Width - _cornerRadius - 1, this.Height - _cornerRadius - 1, _cornerRadius, _cornerRadius, 0, 90);
            path.AddArc(0, this.Height - _cornerRadius - 1, _cornerRadius, _cornerRadius, 90, 90);
            path.CloseFigure();

            // Definir a região do TextBox como arredondada
            this.Region = new Region(path);

            // Desenhar a borda personalizada
            using (Pen pen = new Pen(_borderColor, _borderSize))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(pen, path);
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_PAINT = 0xF;
            if (m.Msg == WM_PAINT)
            {
                // Customizar a pintura
                using (Graphics graphics = this.CreateGraphics())
                {
                    // Chamar OnPaint para que a borda seja redesenhada
                    PaintEventArgs paintArgs = new PaintEventArgs(graphics, this.ClientRectangle);
                    OnPaint(paintArgs);
                }
            }
            base.WndProc(ref m);
        }
    }
}
