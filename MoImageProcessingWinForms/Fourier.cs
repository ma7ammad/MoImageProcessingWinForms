using System;
using System.Numerics;

namespace MoImageProcessingWinForms
{
    public static class Fourier
    {
        public static void FFT1D(int direction, Complex[] complexData1D)
        {
            int N = complexData1D.Length;
            int nm1 = N - 1;
            int nd2 = N / 2;
            int m = (int)Math.Log(N, 2);
            int numberOfBits, halfNumberOfBits;
            double realConstant, imaginaryConstant, sinusoidRealComponent, sinusoidImaginaryComponent;
            int jm1;
            int oddIndex;
            double tempReal, tempImaginary;

            if (direction == -1)
            {
                for (int i = 0; i < N; i++)
                {
                    var realComponent = complexData1D[i].Real;
                    var imaginaryComponent = complexData1D[i].Imaginary;
                    complexData1D[i] = new Complex(realComponent, -imaginaryComponent);
                }

            }

            // Do the bit reversal 
            int mirrorIndex = 0;
            for (int i = 0; i < N - 1; i++)
            {
                if (i < mirrorIndex)
                {
                    var temp = complexData1D[i];
                    complexData1D[i] = complexData1D[mirrorIndex];
                    complexData1D[mirrorIndex] = temp;
                }
                int k = N / 2;
                while (k <= mirrorIndex)
                {
                    mirrorIndex -= k;
                    k >>= 1;
                }
                mirrorIndex += k;
            }

            ////////////////////////////////////////////////////////////////////////////
            ///
            //calculate the FFT
            // Loop each stage
            for (int l = 1; l <= m; l++)
            {
                numberOfBits = (int)Math.Pow(2.0, l);
                halfNumberOfBits = numberOfBits / 2;
                realConstant = 1;
                imaginaryConstant = 0;

                // Calculate sine and cosine values
                var angle = Math.PI / halfNumberOfBits;
                sinusoidRealComponent = Math.Cos(angle);
                sinusoidImaginaryComponent = -Math.Sin(angle);

                // Loop for each sub DFT
                for (int j = 1; j <= halfNumberOfBits; j++)
                {
                    jm1 = j - 1;
                    // Loop for each butterfly
                    for (int evenIndex = jm1; evenIndex <= nm1; evenIndex += numberOfBits)
                    {
                        // ip = i + le2;
                        oddIndex = evenIndex + halfNumberOfBits;
                        var dataRealComponentEvenIndex = complexData1D[evenIndex].Real;
                        var dataImaginaryComponentEvenIndex = complexData1D[evenIndex].Imaginary;

                        var dataRealComponentOddIndex = complexData1D[oddIndex].Real;
                        var dataImaginaryComponentOddIndex = complexData1D[oddIndex].Imaginary;

                        tempReal = dataRealComponentOddIndex * realConstant - dataImaginaryComponentOddIndex * imaginaryConstant;
                        tempImaginary = dataRealComponentOddIndex * imaginaryConstant + dataImaginaryComponentOddIndex * realConstant;
                        dataRealComponentOddIndex = dataRealComponentEvenIndex - tempReal;
                        dataImaginaryComponentOddIndex = dataImaginaryComponentEvenIndex - tempImaginary;
                        dataRealComponentEvenIndex += tempReal;
                        dataImaginaryComponentEvenIndex += tempImaginary;
                        complexData1D[evenIndex] = new Complex(dataRealComponentEvenIndex, dataImaginaryComponentEvenIndex);
                        complexData1D[oddIndex] = new Complex(dataRealComponentOddIndex, dataImaginaryComponentOddIndex);
                    }
                    tempReal = realConstant;
                    realConstant = tempReal * sinusoidRealComponent - imaginaryConstant * sinusoidImaginaryComponent;
                    imaginaryConstant = tempReal * sinusoidImaginaryComponent + imaginaryConstant * sinusoidRealComponent;
                }
            }

            //Scale data if forward transformation
            if (direction == 1)
            {
                for (int i = 0; i < N; i++)
                {
                    double imageRealComponent, imageImaginaryComponent;
                    imageRealComponent = complexData1D[i].Real / N;
                    imageImaginaryComponent = complexData1D[i].Imaginary / N;
                    complexData1D[i] = new Complex(imageRealComponent, imageImaginaryComponent);
                }
                // set the fourierTransformed to true
                ComplexImage.isForwardTransformed = true;
            }
            else if (direction == -1)
            {
                for (int i = 0; i < N; i++)
                {
                    double imageRealComponent, imageImaginaryComponent;
                    imageRealComponent = complexData1D[i].Real / N;
                    imageImaginaryComponent = complexData1D[i].Imaginary / -N;
                    complexData1D[i] = new Complex(imageRealComponent, imageImaginaryComponent);
                }

                // set the fourierTransformed to false
                ComplexImage.isForwardTransformed = false;
            }
        }


        public static void FFT2D(Complex[,] complexImage, int direction)
        {
            int width = complexImage.GetLength(0);
            int height = complexImage.GetLength(1);

            //check data size
            if (
                (!ComplexImage.IsPowerOfTwo(width)) ||
                (!ComplexImage.IsPowerOfTwo(height))
                )
            {
                throw new ArgumentException("Incorrect data length.");
            }

            //process the rows 
            Complex[] row = new Complex[width];

            for (int j = 0; j < height; j++)
            {
                // copy row
                for (int i = 0; i < width; i++)
                    row[i] = complexImage[i, j];
                // transform it
                FFT1D(direction, row);
                // copy back
                for (int i = 0; i < width; i++)
                    complexImage[i, j] = row[i];
            }

            // process the columns
            Complex[] column = new Complex[height];

            for (int i = 0; i < width; i++)
            {
                // copy row
                for (int j = 0; j < height; j++)
                    column[j] = complexImage[i, j];
                // transform it
                FFT1D(direction, column);
                // copy back
                for (int j = 0; j < height; j++)
                    complexImage[i, j] = column[j];
            }
        }
    }
}
