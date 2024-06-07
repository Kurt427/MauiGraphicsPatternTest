using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MauiGraphicsPatternTest
{
    public class GraphicsDrawable : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            RectF objRect = new(50, 50, 200, 200);
            IPattern thePattern;
            PatternPaint thePaint;
            using (PictureCanvas picture = new PictureCanvas(0, 0, 8, 8))
            {
                picture.StrokeSize = 1;
                picture.StrokeColor = Colors.Black;
                // Hatch pattern
                picture.DrawLine(0, 8, 8, 0);
                thePattern = new PicturePattern(picture.Picture, 8, 8);
                thePaint = new PatternPaint
                {
                    Pattern = thePattern
                };
            }
            canvas.SetFillPaint(thePaint, RectF.Zero);
            canvas.FillCircle(objRect.Center, objRect.Width / 2);
        }
    }

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}
