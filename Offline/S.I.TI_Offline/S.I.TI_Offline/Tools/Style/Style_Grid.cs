using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace Separacao_de_Materiais.Styles
{
    public class Style_Grid : DataGridView
    {
        private int _cornerRadius = 20;  // Tamanho dos cantos arredondados
        private Color _borderColor = Color.Gray; // Cor da borda
        private int _borderSize = 2; // Tamanho da borda

        // Propriedade para ajustar o raio dos cantos
        public int CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; this.Invalidate(); } // Redesenha o controle ao alterar
        }

        // Propriedade para ajustar a cor da borda
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; this.Invalidate(); } // Redesenha o controle ao alterar
        }

        // Propriedade para ajustar o tamanho da borda
        public int BorderSize
        {
            get { return _borderSize; }
            set { _borderSize = value; this.Invalidate(); } // Redesenha o controle ao alterar
        }

        // Construtor padrão
        public Style_Grid()
        {
            this.BorderStyle = BorderStyle.None; // Remove a borda padrão do DataGridView
        }

        // Sobrescrevendo o método OnPaint para desenhar as bordas arredondadas
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Cria uma borda arredondada para o DataGridView
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, _cornerRadius, _cornerRadius, 180, 90); // Canto superior esquerdo
            path.AddArc(this.Width - _cornerRadius - 1, 0, _cornerRadius, _cornerRadius, 270, 90); // Canto superior direito
            path.AddArc(this.Width - _cornerRadius - 1, this.Height - _cornerRadius - 1, _cornerRadius, _cornerRadius, 0, 90); // Canto inferior direito
            path.AddArc(0, this.Height - _cornerRadius - 1, _cornerRadius, _cornerRadius, 90, 90); // Canto inferior esquerdo
            path.CloseFigure();

            // Define a região do DataGridView como arredondada
            this.Region = new Region(path);

            // Desenhar a borda ao redor do DataGridView
            using (Pen pen = new Pen(_borderColor, _borderSize))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; // Anti-aliasing para suavizar as bordas
                e.Graphics.DrawPath(pen, path); // Desenhar a borda arredondada
            }
        }
    }
}
