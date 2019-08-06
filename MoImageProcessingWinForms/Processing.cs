using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MoImageProcessingWinForms
{
    public class Processing
    {
        public static bool ConvertToGray(Bitmap b)
        {
            for (int i = 0; i < b.Width; i++)

                for (int j = 0; j < b.Height; j++)
                {
                    Color c1 = b.GetPixel(i, j);
                    int r1 = c1.R;
                    int g1 = c1.G;
                    int b1 = c1.B;
                    int gray = (byte)(.299 * r1 + .587 * g1 + .114 * b1);
                    r1 = gray;
                    g1 = gray;
                    b1 = gray;
                    b.SetPixel(i, j, Color.FromArgb(r1, g1, b1));
                }  
            // yield return xxx;  // deferred execution sub method
            return true;
        }

        public static Image ResizeImage(Image sourceIm, Size size)
        {
            var oldW = sourceIm.Width;
            var oldH = sourceIm.Height;

            float reFactor;

            var newWFac = (size.Width / (float)oldW);
            var newHFac = (size.Height / (float)oldH);

            reFactor = Math.Min(newWFac, newHFac);
            //if (reFactor == 1) { return sourceIm; }

            var newW = (int)(oldW * reFactor);
            var newH = (int)(oldH * reFactor);

            var newImage = new Bitmap(newW, newH);
            using (var g = Graphics.FromImage(newImage))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(sourceIm, 0, 0, newW, newH);
            }

            return newImage;
        }

        public static Dictionary<string,Image> CropImage(Image copy, Rectangle area)
        {
            var result = new Dictionary<string, Image >();
            String str = "";
            try
            {
                if (( copy.Width - area.Width) < 8 && (copy.Height-area.Height)<8)
                {
                   str = "Crop Dimensions invalid, Please choose different values";
                    result.Add(str, copy);
                    return result;
                }
                var bitmap = new Bitmap(copy);
                var crop = bitmap.Clone(area, bitmap.PixelFormat);
                str = "Success";
                result.Add(str, crop);
                return result;
            }
            catch (Exception e)
            {
                str = $"Exception caught: {e.Message}";
                result.Add(str, copy);
                return result;
            }
        }

        internal static Image RotateImage(Image im, float angle)
        {

            int w, h, x, y;

            double degree = Math.Abs(angle);
            double radians = degree * Math.PI / 180.0;
            double sin = (float)Math.Abs(Math.Sin(radians));
            double cos = (float)Math.Abs(Math.Cos(radians));

            // refactor as image gets deformed when rotating with same size
            w = (int)(sin * im.Height + cos * im.Width);
            h = (int)(sin * im.Width + cos * im.Height);
            x = (w - im.Width) / 2;
            y = (h - im.Height) / 2;

            float newCentreX = (float)im.Width / 2 + x;
            float newCentreY = (float)im.Height / 2 + y;

            var rotated = new Bitmap(w, h);
            rotated.SetResolution(im.HorizontalResolution, im.VerticalResolution);

            using(var g = Graphics.FromImage(rotated))
            {
                //g.Clear(bkColour);

                //set rotation poit to centre
                g.TranslateTransform(newCentreX, newCentreY);

                //rotate
                g.RotateTransform(angle);

                //move image back
                g.TranslateTransform(-newCentreX , -newCentreY);

                //draw passed in image onto graphis object
                g.DrawImage(im, new PointF(0 + x, 0 + y));
            }

            return rotated;
        }
    }    
}
