using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.MiscServices
{
    public class GenerateImage
    {
        public IFormFile GenerateNewImage(string text, int height, int width, float fontSize)
        {
            Font font = new Font(FontFamily.GenericSansSerif, fontSize, FontStyle.Bold);
            Color textColor = Color.White;
            Color backColor = Color.Purple;
            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);
            SizeF textSize = drawing.MeasureString(text, font);
            img.Dispose();
            drawing.Dispose();
            img = new Bitmap(height, width);
            drawing = Graphics.FromImage(img);
            drawing.Clear(backColor);
            Brush brush = new SolidBrush(textColor);
            StringFormat stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
            RectangleF rectangleF = new RectangleF(0, 0, img.Width, img.Height);
            drawing.DrawString(text, font, brush, rectangleF, stringFormat);
            drawing.Save();
            brush.Dispose();
            drawing.Dispose();
            var stream = new MemoryStream();
            img.Save(stream, ImageFormat.Jpeg);
            stream.Position = 0;
            return new FormFile(stream, 0, stream.Length, "", "");
        }
    }
}
