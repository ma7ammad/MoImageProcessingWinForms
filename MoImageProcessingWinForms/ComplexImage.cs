using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;

namespace MoImageProcessingWinForms
{
    public class ComplexImage
    {

        //***************************************************************************************

        /// <summary>
        /// Create complex image from grayscale bitmap.
        /// </summary>
        /// 
        /// <param name="image">Source grayscale bitmap (8 bpp indexed).</param>
        /// 
        /// <returns>Returns an instance of complex image.</returns>
        /// 
        /// <exception cref="Exception">The source image has incorrect pixel format.</exception>
        /// <exception cref="InvalidImagePropertiesException">Image width and height should be power of 2.</exception>
        /// 
        public static Complex[,] ConvertBitmapImageToComplex(Bitmap image)
        {
            // check image format
            if (image.PixelFormat != PixelFormat.Format8bppIndexed)
            {
                throw new Exception("Source image can be graysclae (8bpp indexed) image only.");
            }

            // lock source bitmap data
            BitmapData imageData = image.LockBits(
                new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);

            Complex[,] complexImage;

            try
            {
                complexImage = FromBitmap(imageData);
            }
            finally
            {
                // unlock source images
                image.UnlockBits(imageData);
            }

            return complexImage;
        }

        /// <summary>
        /// Create complex image from grayscale bitmap.
        /// </summary>
        /// 
        /// <param name="imageData">Source image data (8 bpp indexed).</param>
        /// 
        /// <returns>Returns an instance of complex image.</returns>
        /// 
        /// <exception cref="Exception">The source image has incorrect pixel format.</exception>
        /// <exception cref="InvalidImagePropertiesException">Image width and height should be power of 2.</exception>
        /// 
        public static Complex[,] FromBitmap(BitmapData imageData)
        {
            // check image format
            if (imageData.PixelFormat != PixelFormat.Format8bppIndexed)
            {
                throw new Exception("Source image can be graysclae (8bpp indexed) image only.");
            }

            // get source image size
            int width = imageData.Width;
            int height = imageData.Height;
            int offset = imageData.Stride - width;

            // check image size
            if ((!IsPowerOfTwo(width)) || (!IsPowerOfTwo(height)))
            {
                throw new Exception("Image width and height should be power of 2.");
            }

            // create new complex image
            Complex[,] complexImage = new Complex[width, height];  //ComplexImage
            //Complex[,] data = complexImage.data;

            // do the job
            unsafe
            {
                byte* src = (byte*)imageData.Scan0.ToPointer();

                // for each line
                for (int y = 0; y < height; y++)
                {
                    // for each pixel
                    for (int x = 0; x < width; x++, src++)
                    {
                        complexImage[y, x] = new Complex((float)*src / 255, 0);
                    }
                    src += offset;
                }
            }

            return complexImage;
        }

        /// <summary>
        /// Convert complex image to bitmap.
        /// </summary>
        /// 
        /// <returns>Returns grayscale bitmap.</returns>
        /// 
        public static Bitmap ConvertComplexImageToBitmap(Complex[,] complexIm)
        {
            int width = complexIm.GetLength(0);
            int height = complexIm.GetLength(1);

            // create new image
            Bitmap dstImage = CreateGrayscaleImage(width, height);

            // lock destination bitmap data
            BitmapData dstData = dstImage.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);

            int offset = dstData.Stride - width;
            double scale = (isForwardTransformed) ? Math.Sqrt(width * height) : 1;

            // do the job
            unsafe
            {
                byte* dst = (byte*)dstData.Scan0.ToPointer();

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++, dst++)
                    {
                        *dst = (byte)System.Math.Max(0, System.Math.Min(255, complexIm[y, x].Magnitude * scale * 255));
                    }
                    dst += offset;
                }
            }
            // unlock destination images
            dstImage.UnlockBits(dstData);

            return dstImage;
        }

        //***************************************************************************************

        public static unsafe Bitmap ToGrayscale(Bitmap colorBitmap)
        {
            int Width = colorBitmap.Width;
            int Height = colorBitmap.Height;

            Bitmap grayscaleBitmap = new Bitmap(Width, Height, PixelFormat.Format8bppIndexed);

            grayscaleBitmap.SetResolution(colorBitmap.HorizontalResolution,
                                 colorBitmap.VerticalResolution);

            ///////////////////////////////////////
            // Set grayscale palette
            ///////////////////////////////////////
            ColorPalette colorPalette = grayscaleBitmap.Palette;
            for (int i = 0; i < colorPalette.Entries.Length; i++)
            {
                colorPalette.Entries[i] = Color.FromArgb(i, i, i);
            }
            grayscaleBitmap.Palette = colorPalette;
            ///////////////////////////////////////
            // Set grayscale palette
            ///////////////////////////////////////
            BitmapData bitmapData = grayscaleBitmap.LockBits(
                new Rectangle(Point.Empty, grayscaleBitmap.Size),
                ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

            Byte* pPixel = (Byte*)bitmapData.Scan0;

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Color clr = colorBitmap.GetPixel(x, y);

                    Byte byPixel = (byte)((30 * clr.R + 59 * clr.G + 11 * clr.B) / 100);

                    pPixel[x] = byPixel;
                }

                pPixel += bitmapData.Stride;
            }

            grayscaleBitmap.UnlockBits(bitmapData);

            return grayscaleBitmap;
        }

        public static Bitmap CreateGrayscaleImage(int width, int height)
        {
            // create new image
            Bitmap image = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            // set palette to grayscale
            SetGrayscalePalette(image);
            // return new image
            return image;
        }

        public static void SetGrayscalePalette(Bitmap image)
        {
            // check pixel format
            if (image.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new Exception("Source image is not 8 bpp image.");

            // get palette
            ColorPalette cp = image.Palette;
            // init palette
            for (int i = 0; i < 256; i++)
            {
                cp.Entries[i] = Color.FromArgb(i, i, i);
            }
            // set palette back
            image.Palette = cp;
        }

        public static bool IsPowerOfTwo(int x)
        {
            return (x != 0) && ((x & (x - 1)) == 0);
        }

        public static bool isForwardTransformed = false;

    }
}
