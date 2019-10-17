using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoImageProcessingWinForms;

namespace MoImageProcessingTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MoImageProcessingWinForms.Processing processing;  // = new MoImageProcessing();
            //Arrange
            Bitmap originalImage = new Bitmap(@"C:\Users\Public\test_224_299_Image.bmp");
            Size size = new Size(16);
            Processing.ConvertToGray(copy);

            //Act
            Bitmap resizedImage = Processing.ResizeImage(copy, size);

            //Assert


        }
    }
}
