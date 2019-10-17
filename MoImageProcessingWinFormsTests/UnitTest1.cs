using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoImageProcessingWinForms;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MoImageProcessingWinFormsTests
{
    [TestClass]
    public class UnitTest1
    {
        // 1. ConvertToGrey 
        [TestMethod]
        public void ConvertToGray_When_Passed_An_Image_Returns_An_Image_Where_The_First_And_Last_Pixels_Have_The_Calculated_Grey_Value_For_The_Red_Blue_And_Green_Components()
        {
            //Arrange
            Bitmap originalImage = new Bitmap(@"C:\Users\Public\test_224_299_Image.bmp");
            Color oldImageFirstPixel = originalImage.GetPixel(0, 0);
            int grayOldImageFirstPixel = (byte)(.299 * oldImageFirstPixel.R + .587 * oldImageFirstPixel.G + .114 * oldImageFirstPixel.B);

            Color oldImageLastPixel = originalImage.GetPixel(298, 223);
            int grayoldImageLastPixel = (byte)(.299 * oldImageLastPixel.R + .587 * oldImageLastPixel.G + .114 * oldImageLastPixel.B);

            //Act
            Processing.ConvertToGrey(originalImage);
            Color newImageFirstPixel = originalImage.GetPixel(0, 0);
            Color newImageLastPixel = originalImage.GetPixel(298, 223);

            Color newImageTopLeftPixel = originalImage.GetPixel(0, 0);
            int newImageWidth = originalImage.Width;
            int newImageHeight = originalImage.Height;

            //Assert
            //First Pixel is greyed
            Assert.AreEqual(grayOldImageFirstPixel, newImageFirstPixel.R);
            Assert.AreEqual(grayOldImageFirstPixel, newImageFirstPixel.G);
            Assert.AreEqual(grayOldImageFirstPixel, newImageFirstPixel.B);

            //Last Pixel is greyed
            Assert.AreEqual(grayoldImageLastPixel, newImageLastPixel.R);
            Assert.AreEqual(grayoldImageLastPixel, newImageLastPixel.G);
            Assert.AreEqual(grayoldImageLastPixel, newImageLastPixel.B);

        }

        // 2. Resize
        [TestMethod]
        public void ResizeImage_When_Passed_An_Image_And_A_New_Size_Of_265_198_Returns_Correct_New_Width_And_Height_Within_A_Tolerance_Of_7_Pixels()
        {
            //Arrange
            Bitmap originalImage = new Bitmap(@"C:\Users\Public\test_224_299_Image.bmp");
            Size size = new Size(265, 198);

            //Act
            Bitmap resizedImage = (Bitmap)Processing.ResizeImage(originalImage, size);
            int newImageWidth = resizedImage.Width;
            int newImageHeight = resizedImage.Height;
            //Assert
            Assert.IsTrue(272 > newImageWidth && newImageWidth > 258);
            Assert.IsTrue(205 > newImageHeight && newImageHeight > 190);
        }

        // 3. CropImag 1
        [TestMethod]
        public void CropImage_When_Passed_An_Image_With_Coordinates_TopLeft_And_A_New_Size_Of_265_198_Returns_Message_Success_And_Returns_Correct_New_Width_And_Height_Within_A_Tolerance_Of_7_Pixels()
        {
            //Arrange
            Bitmap originalImage = new Bitmap(@"C:\Users\Public\test_224_299_Image.bmp");
            Rectangle size = new Rectangle(0, 0, 265, 198);

            //Act
            Dictionary<string, Image> result = Processing.CropImage(originalImage, size);
            Bitmap croppedImage = (Bitmap)result.FirstOrDefault().Value;
            string croppedImageMessage = result.FirstOrDefault().Key;
            int newWidth = croppedImage.Width;
            int newHeight = croppedImage.Height;

            //Assert
            Assert.IsTrue(272 > newWidth && newWidth > 258);
            Assert.IsTrue(205 > newHeight && newHeight > 190);
            Assert.AreEqual(croppedImageMessage, "Success");
        }

        // 4. CropImag 2
        [TestMethod]
        public void CropImage_When_Passed_An_Image_With_Coordinates_TopLeft_And_A_New_Size_4_Pixels_Different_Than_Original_Size_Returns_Message_Dimensions_Invalid_And_Returns_Original_Image()
        {
            //Arrange
            Bitmap originalImage = new Bitmap(@"C:\Users\Public\test_224_299_Image.bmp");
            int oldImageWidth = originalImage.Width;
            int oldImageHeight = originalImage.Height;
            Rectangle size = new Rectangle(0, 0, oldImageWidth - 4, oldImageHeight - 4);

            //Act
            Dictionary<string, Image> result = Processing.CropImage(originalImage, size);
            Bitmap croppedImage = (Bitmap)result.FirstOrDefault().Value;
            string croppedImageMessage = result.FirstOrDefault().Key;

            //Assert
            Assert.AreEqual(croppedImage, originalImage);
            Assert.AreEqual(croppedImageMessage, "Crop Dimensions invalid, Please choose new valid values");
        }

        // 5. CropImag 3
        [TestMethod]
        public void CropImage_When_Passed_An_Image_With_Coordinates_TopLeft_And_A_New_Negative_Size_Returns_Message_Out_Of_Memory_And_Returns_Original_Image()
        {
            //Arrange
            Bitmap originalImage = new Bitmap(@"C:\Users\Public\test_224_299_Image.bmp");
            int oldImageWidth = originalImage.Width;
            int oldImageHeight = originalImage.Height;
            Rectangle size = new Rectangle(0, 0, -oldImageWidth, -oldImageHeight);

            //Act
            Dictionary<string, Image> result = Processing.CropImage(originalImage, size);
            Bitmap croppedImage = (Bitmap)result.FirstOrDefault().Value;
            string croppedImageMessage = result.FirstOrDefault().Key;
            System.Console.WriteLine(croppedImageMessage);

            //Assert
            Assert.AreEqual(croppedImage, originalImage);
            Assert.AreEqual(croppedImageMessage, "Exception caught: Out of memory.");
        }

        // 6. RotateImage 1
        [TestMethod]
        public void RotateImage_When_Passed_An_Image_With_Coordinates_TopLeft_And_An_Angle_Of_90_Returns_An_Image_With_Expected_Corner_Pixels()
        {
            //Arrange
            Bitmap originalImage = new Bitmap(@"C:\Users\Public\test_224_299_Image.bmp");
            Bitmap ExpectedImage = new Bitmap(@"C:\Users\Public\test_224_299_Image_Rotated_90.bmp");
            int angle = 90;

            //getting the 4 corner pixels of the expected image
            Color ExpectedImagePoint_1 = ExpectedImage.GetPixel(0, 0);
            Color ExpectedImagePoint_2 = ExpectedImage.GetPixel(0, 298);
            Color ExpectedImagePoint_3 = ExpectedImage.GetPixel(223, 298);
            Color ExpectedImagePoint_4 = ExpectedImage.GetPixel(223, 0);

            //Act
            Bitmap rotatedImage = (Bitmap)Processing.RotateImage(originalImage, angle);

            //getting the 4 corner pixels of the rotated image
            Color rotatedImagePoint_1 = rotatedImage.GetPixel(0, 0);
            Color rotatedImagePoint_2 = rotatedImage.GetPixel(0, 298);
            Color rotatedImagePoint_3 = rotatedImage.GetPixel(223, 298);
            Color rotatedImagePoint_4 = rotatedImage.GetPixel(223, 0);

            //Assert
            Assert.AreEqual(ExpectedImagePoint_1, rotatedImagePoint_1);
            Assert.AreEqual(ExpectedImagePoint_2, rotatedImagePoint_2);
            Assert.AreEqual(ExpectedImagePoint_3, rotatedImagePoint_3);
            Assert.AreEqual(ExpectedImagePoint_4.A, rotatedImagePoint_4.A);
        }

        // 7. RotateImage 2
        [TestMethod]
        public void RotateImage_When_Passed_An_Image_With_Coordinates_TopLeft_And_An_Angle_Of_180_Returns_An_Image_With_Expected_Corner_Pixels()
        {
            //Arrange
            Bitmap originalImage = new Bitmap(@"C:\Users\Public\test_224_299_Image.bmp");
            Bitmap ExpectedImage = new Bitmap(@"C:\Users\Public\test_224_299_Image_Rotated_180.bmp");
            int angle = 180;

            //getting the 4 corner pixels of the expected image
            Color ExpectedImagePoint_1 = ExpectedImage.GetPixel(0, 0);
            Color ExpectedImagePoint_2 = ExpectedImage.GetPixel(0, 223);
            Color ExpectedImagePoint_3 = ExpectedImage.GetPixel(298, 223);
            Color ExpectedImagePoint_4 = ExpectedImage.GetPixel(298, 0);

            //Act
            Bitmap rotatedImage = (Bitmap)Processing.RotateImage(originalImage, angle);

            //getting the 4 corner pixels of the rotated image
            Color rotatedImagePoint_1 = rotatedImage.GetPixel(0, 0);
            Color rotatedImagePoint_2 = rotatedImage.GetPixel(0, 223);
            Color rotatedImagePoint_3 = rotatedImage.GetPixel(298, 223);
            Color rotatedImagePoint_4 = rotatedImage.GetPixel(298, 0);

            //Assert
            Assert.AreEqual(ExpectedImagePoint_1, rotatedImagePoint_1);
            Assert.AreEqual(ExpectedImagePoint_2, rotatedImagePoint_2);
            Assert.AreEqual(ExpectedImagePoint_3, rotatedImagePoint_3);
            Assert.AreEqual(ExpectedImagePoint_4.A, rotatedImagePoint_4.A);
        }

        // 8. RotateImage 3
        [TestMethod]
        public void RotateImage_When_Passed_An_Image_With_Coordinates_TopLeft_And_An_Angle_Of_Minus_90_Returns_An_Image_With_Expected_Corner_Pixels()
        {
            //Arrange
            Bitmap originalImage = new Bitmap(@"C:\Users\Public\test_224_299_Image.bmp");
            Bitmap ExpectedImage = new Bitmap(@"C:\Users\Public\test_224_299_Image_Rotated_Minus_90.bmp");
            int angle = -90;

            //getting the 4 corner pixels of the expected image
            Color ExpectedImagePoint_1 = ExpectedImage.GetPixel(0, 0);
            Color ExpectedImagePoint_2 = ExpectedImage.GetPixel(0, 298);
            Color ExpectedImagePoint_3 = ExpectedImage.GetPixel(223, 298);
            Color ExpectedImagePoint_4 = ExpectedImage.GetPixel(223, 0);

            //Act
            Bitmap rotatedImage = (Bitmap)Processing.RotateImage(originalImage, angle);

            //getting the 4 corner pixels of the rotated image
            Color rotatedImagePoint_1 = rotatedImage.GetPixel(0, 0);
            Color rotatedImagePoint_2 = rotatedImage.GetPixel(0, 298);
            Color rotatedImagePoint_3 = rotatedImage.GetPixel(223, 298);
            Color rotatedImagePoint_4 = rotatedImage.GetPixel(223, 0);

            //Assert
            Assert.AreEqual(ExpectedImagePoint_1, rotatedImagePoint_1);
            Assert.AreEqual(ExpectedImagePoint_2, rotatedImagePoint_2);
            Assert.AreEqual(ExpectedImagePoint_3, rotatedImagePoint_3);
            Assert.AreEqual(ExpectedImagePoint_4.A, rotatedImagePoint_4.A);
        }

        // 9. RotateImage 4
        [TestMethod]
        public void RotateImage_When_Passed_An_Image_With_Coordinates_TopLeft_And_An_Angle_Of_Minus_180_Returns_An_Image_With_Expected_Corner_Pixels()
        {
            //Arrange
            Bitmap originalImage = new Bitmap(@"C:\Users\Public\test_224_299_Image.bmp");
            Bitmap ExpectedImage = new Bitmap(@"C:\Users\Public\test_224_299_Image_Rotated_Minus_180.bmp");
            int angle = -180;

            //getting the 4 corner pixels of the expected image
            Color ExpectedImagePoint_1 = ExpectedImage.GetPixel(0, 0);
            Color ExpectedImagePoint_2 = ExpectedImage.GetPixel(0, 223);
            Color ExpectedImagePoint_3 = ExpectedImage.GetPixel(298, 223);
            Color ExpectedImagePoint_4 = ExpectedImage.GetPixel(298, 0);

            //Act
            Bitmap rotatedImage = (Bitmap)Processing.RotateImage(originalImage, angle);

            //getting the 4 corner pixels of the rotated image
            Color rotatedImagePoint_1 = rotatedImage.GetPixel(0, 0);
            Color rotatedImagePoint_2 = rotatedImage.GetPixel(0, 223);
            Color rotatedImagePoint_3 = rotatedImage.GetPixel(298, 223);
            Color rotatedImagePoint_4 = rotatedImage.GetPixel(298, 0);

            //Assert
            Assert.AreEqual(ExpectedImagePoint_1, rotatedImagePoint_1);
            Assert.AreEqual(ExpectedImagePoint_2, rotatedImagePoint_2);
            Assert.AreEqual(ExpectedImagePoint_3, rotatedImagePoint_3);
            Assert.AreEqual(ExpectedImagePoint_4.A, rotatedImagePoint_4.A);
        }

    }
}
