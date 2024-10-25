using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Separacao_de_Materiais.Styles
{
    public class Style_Button : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            // Definir a borda arredondada
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, 40, 40, 180, 90);
            path.AddArc(Width - 41, 0, 40, 40, 270, 90);
            path.AddArc(Width - 41, Height - 41, 40, 40, 0, 90);
            path.AddArc(0, Height - 41, 40, 40, 90, 90);
            path.CloseFigure();

            // Aplicar a borda arredondada ao botão
            this.Region = new Region(path);

            
            
        }
    }
}
