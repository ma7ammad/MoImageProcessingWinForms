using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using MaterialSkin.Controls;
using System.IO;

namespace MoImageProcessingWinForms
{
    public partial class MoImageProcessing : MaterialForm  //needs MaterialForm Nuget package download
    {
        public MoImageProcessing()
        {
            InitializeComponent();
        }

        Bitmap originalImage;
        private void Label1_Click(object sender, EventArgs e){}
        private void OpenImage_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofile = new OpenFileDialog
            {
                Filter = "Image File (*.bmp, *.jpg)|*.bmp;*.jpg"
            };
            //ofile
            if (DialogResult.OK == ofile.ShowDialog())
            {
                originalImage = new Bitmap(ofile.FileName);
                this.pBox.Image = originalImage; ;
                this.pBox.Width = originalImage.Width;
                this.pBox.Height = originalImage.Height;
                // this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            //check user has loaded an image
            if (originalImage == null)
            {
                MessageBox.Show("Please select a valid image");
                return;
            }

            Bitmap copy = new Bitmap((Bitmap)this.pBox.Image);

            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Image File (*.bmp, *.jpg)|*.bmp;*.jpg";

            if (file.ShowDialog() == DialogResult.OK)
            {
                copy.Save(file.FileName);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e){}

        private void Convert2Gray_Click(object sender, EventArgs e)
        {
            //check user has loaded an image to edit
            if (originalImage == null)
            {
                MessageBox.Show("Please select a valid image");
                return;
            }

            Bitmap copy = new Bitmap((Bitmap)this.pBox.Image);
            Processing.ConvertToGray(copy);
            this.pBox.Image = copy;
        }

        private void ResizeImage_Click(object sender, EventArgs e)
        {
            //check user has loaded an image to edit
            if (originalImage == null)
            {
                MessageBox.Show("Please select a valid image");
                return;
            }

            var size = GetUserSize(sender, e);
            if (size.IsEmpty) { return; }
            else
            {
                Bitmap copy = new Bitmap((Bitmap)this.pBox.Image);
                Image resized = Processing.ResizeImage(copy, size);
                this.pBox.Image = (Bitmap)resized;
            }
        }
        private void Crop_Click(object sender, EventArgs e)
        {
            //check user has loaded an image to edit, and selected a cropMode
            if ( CropMode.SelectedItem==null || originalImage == null)
            {
                MessageBox.Show("Please select a valid Image and CropMode ");
                return;
            }
            Bitmap copy = new Bitmap(originalImage);
            var size = GetUserSize(sender, e);
            if (size.IsEmpty) { return; } ////////////// check ?
            else
            {/////////////////////////////////////////
                var rectangle = new Rectangle();
                
                var mode =  CropMode.SelectedItem.ToString();

                switch (mode)
                {
                    case "Centered":
                        var x = ((pBox.Width - size.Width) / 2);
                        var y = ((pBox.Height - size.Height) / 2);
                        rectangle = new Rectangle(x, y, size.Width, size.Height);
                        break;
                    default:
                        rectangle = new Rectangle(0, 0, size.Width, size.Height);
                        break;
                }
                
                try {copy = new Bitmap((Bitmap)this.pBox.Image);}
                catch (Exception ex)
                {

                    MessageBox.Show($"Error: {0} please make inputs are valid",ex.Message);
                }
                var cropResult = Processing.CropImage(copy, rectangle);
                Image cropped;
                if (cropResult.ContainsKey("Success"))
                {
                    cropped =  cropResult.Values.FirstOrDefault();
                    this.pBox.Image = (Bitmap)cropped;
                }
                else
                {
                    cropped = cropResult.Values.FirstOrDefault();
                    String str = cropResult.Keys.FirstOrDefault();

                    this.pBox.Image = (Bitmap)cropped;

                    MessageBox.Show(str);

                }
            }
        }
        private void Rotate_Click(object sender, EventArgs e)
        {
            //check user has loaded an image to edit
            if (originalImage == null)
            {
                MessageBox.Show("Please select a valid image");
                return;
            }

            var newSize = GetUserSize(sender, e);
            Size oldSize = new Size
            {
                Width = this.pBox.Image.Width,
                Height = this.pBox.Image.Height
            };

            var angle = GetAngle(sender, e);

            if (newSize.IsEmpty || angle == null) { return; }
            else
            {
                Bitmap copy = new Bitmap((Bitmap)this.pBox.Image);
                Image resized, rotated;

                if (oldSize != newSize)
                {
                    resized = Processing.ResizeImage(copy, newSize);
                    rotated = Processing.RotateImage(resized, (float)angle);
                }
                else
                {
                    rotated = Processing.RotateImage(copy, (float)angle);
                }
                this.pBox.Width = rotated.Width;
                this.pBox.Height = rotated.Height;
                this.pBox.Image = (Bitmap)rotated;
            }
        }

        private float? GetAngle(object sender, EventArgs e)
        {
            float a = new int();
            if (float.TryParse(Angle.Text, out float ang))
            {
                a = ang;
                return a;
            }
            else
            {
                MessageBox.Show("Please make sure to input a valid angle in the Angle input-box");
                return null;
            }
        }

        private Size GetUserSize(object sender, EventArgs e)
        {
            //try catch error handeling
            int w, h = new int();
            if (int.TryParse(inputWidth.Text, out int wid))
            {
                w = wid;
            }
            else
            {
                MessageBox.Show("Please make sure to input an integer in the Width and Height input-box");
                return Size.Empty;
            }
            if (int.TryParse(inputHeigth.Text, out int hei))
            {
                h = hei;
            }
            else
            {
                MessageBox.Show("Please make sure to input an integer in the Width and Heigth input-box");
                return Size.Empty;
            }
            var size = new Size(w, h);
            return size;
        }
        private void InputWidth_TextChanged(object sender, EventArgs e)
        {

        }
        private void InputHeight_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
