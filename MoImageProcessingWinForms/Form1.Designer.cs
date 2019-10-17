using System;

namespace MoImageProcessingWinForms
{
    partial class MoImageProcessing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pBox = new System.Windows.Forms.PictureBox();
            this.inputWidth = new System.Windows.Forms.TextBox();
            this.inputHeigth = new System.Windows.Forms.TextBox();
            this.CropMode = new System.Windows.Forms.ComboBox();
            this.Angle = new System.Windows.Forms.TextBox();
            this.OpenImagee = new MaterialSkin.Controls.MaterialFlatButton();
            this.Rotate = new MaterialSkin.Controls.MaterialFlatButton();
            this.Crop = new MaterialSkin.Controls.MaterialFlatButton();
            this.Resizee = new MaterialSkin.Controls.MaterialFlatButton();
            this.Convert2Gray = new MaterialSkin.Controls.MaterialFlatButton();
            this.Save = new MaterialSkin.Controls.MaterialFlatButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.FFT = new MaterialSkin.Controls.MaterialFlatButton();
            this.IFFT = new MaterialSkin.Controls.MaterialFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBox
            // 
            this.pBox.Location = new System.Drawing.Point(32, 233);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(355, 281);
            this.pBox.TabIndex = 3;
            this.pBox.TabStop = false;
            this.pBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // inputWidth
            // 
            this.inputWidth.Location = new System.Drawing.Point(24, 118);
            this.inputWidth.Name = "inputWidth";
            this.inputWidth.Size = new System.Drawing.Size(80, 20);
            this.inputWidth.TabIndex = 6;
            this.inputWidth.Text = "Width";
            this.inputWidth.TextChanged += new System.EventHandler(this.InputWidth_TextChanged);
            // 
            // inputHeigth
            // 
            this.inputHeigth.Location = new System.Drawing.Point(124, 118);
            this.inputHeigth.Name = "inputHeigth";
            this.inputHeigth.Size = new System.Drawing.Size(82, 20);
            this.inputHeigth.TabIndex = 7;
            this.inputHeigth.Text = "Height";
            this.inputHeigth.TextChanged += new System.EventHandler(this.InputHeight_TextChanged);
            // 
            // CropMode
            // 
            this.CropMode.FormattingEnabled = true;
            this.CropMode.Items.AddRange(new object[] {
            "Centered",
            "TopLeft"});
            this.CropMode.Location = new System.Drawing.Point(312, 117);
            this.CropMode.Name = "CropMode";
            this.CropMode.Size = new System.Drawing.Size(98, 21);
            this.CropMode.TabIndex = 9;
            this.CropMode.Text = "CropMode";
            // 
            // Angle
            // 
            this.Angle.Location = new System.Drawing.Point(212, 118);
            this.Angle.Name = "Angle";
            this.Angle.Size = new System.Drawing.Size(94, 20);
            this.Angle.TabIndex = 11;
            this.Angle.Text = "Angle";
            // 
            // OpenImagee
            // 
            this.OpenImagee.AutoSize = true;
            this.OpenImagee.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OpenImagee.Depth = 0;
            this.OpenImagee.Location = new System.Drawing.Point(467, 158);
            this.OpenImagee.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.OpenImagee.MouseState = MaterialSkin.MouseState.HOVER;
            this.OpenImagee.Name = "OpenImagee";
            this.OpenImagee.Primary = false;
            this.OpenImagee.Size = new System.Drawing.Size(90, 36);
            this.OpenImagee.TabIndex = 12;
            this.OpenImagee.Text = "OpenImage";
            this.OpenImagee.UseVisualStyleBackColor = true;
            this.OpenImagee.Click += new System.EventHandler(this.OpenImage_Click_1);
            // 
            // Rotate
            // 
            this.Rotate.AutoSize = true;
            this.Rotate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Rotate.Depth = 0;
            this.Rotate.Location = new System.Drawing.Point(300, 157);
            this.Rotate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Rotate.MouseState = MaterialSkin.MouseState.HOVER;
            this.Rotate.Name = "Rotate";
            this.Rotate.Primary = false;
            this.Rotate.Size = new System.Drawing.Size(64, 36);
            this.Rotate.TabIndex = 13;
            this.Rotate.Text = "Rotate";
            this.Rotate.UseVisualStyleBackColor = true;
            this.Rotate.Click += new System.EventHandler(this.Rotate_Click);
            // 
            // Crop
            // 
            this.Crop.AutoSize = true;
            this.Crop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Crop.Depth = 0;
            this.Crop.Location = new System.Drawing.Point(101, 158);
            this.Crop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Crop.MouseState = MaterialSkin.MouseState.HOVER;
            this.Crop.Name = "Crop";
            this.Crop.Primary = false;
            this.Crop.Size = new System.Drawing.Size(48, 36);
            this.Crop.TabIndex = 15;
            this.Crop.Text = "Crop";
            this.Crop.UseVisualStyleBackColor = true;
            this.Crop.Click += new System.EventHandler(this.Crop_Click);
            // 
            // Resizee
            // 
            this.Resizee.AutoSize = true;
            this.Resizee.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Resizee.Depth = 0;
            this.Resizee.Location = new System.Drawing.Point(24, 158);
            this.Resizee.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Resizee.MouseState = MaterialSkin.MouseState.HOVER;
            this.Resizee.Name = "Resizee";
            this.Resizee.Primary = false;
            this.Resizee.Size = new System.Drawing.Size(56, 36);
            this.Resizee.TabIndex = 16;
            this.Resizee.Text = "Resize";
            this.Resizee.UseVisualStyleBackColor = true;
            this.Resizee.Click += new System.EventHandler(this.ResizeImage_Click);
            // 
            // Convert2Gray
            // 
            this.Convert2Gray.AutoSize = true;
            this.Convert2Gray.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Convert2Gray.Depth = 0;
            this.Convert2Gray.Location = new System.Drawing.Point(175, 158);
            this.Convert2Gray.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Convert2Gray.MouseState = MaterialSkin.MouseState.HOVER;
            this.Convert2Gray.Name = "Convert2Gray";
            this.Convert2Gray.Primary = false;
            this.Convert2Gray.Size = new System.Drawing.Size(117, 36);
            this.Convert2Gray.TabIndex = 17;
            this.Convert2Gray.Text = "Convert2Gray";
            this.Convert2Gray.UseVisualStyleBackColor = true;
            this.Convert2Gray.Click += new System.EventHandler(this.Convert2Gray_Click);
            // 
            // Save
            // 
            this.Save.AutoSize = true;
            this.Save.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Save.Depth = 0;
            this.Save.Location = new System.Drawing.Point(565, 157);
            this.Save.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Save.MouseState = MaterialSkin.MouseState.HOVER;
            this.Save.Name = "Save";
            this.Save.Primary = false;
            this.Save.Size = new System.Drawing.Size(46, 36);
            this.Save.TabIndex = 18;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1023, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripComboBox1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(182, 97);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem3.Text = "toolStripMenuItem3";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            // 
            // FFT
            // 
            this.FFT.AutoSize = true;
            this.FFT.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FFT.Depth = 0;
            this.FFT.Location = new System.Drawing.Point(372, 158);
            this.FFT.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.FFT.MouseState = MaterialSkin.MouseState.HOVER;
            this.FFT.Name = "FFT";
            this.FFT.Primary = false;
            this.FFT.Size = new System.Drawing.Size(35, 36);
            this.FFT.TabIndex = 20;
            this.FFT.Text = "FFT";
            this.FFT.UseVisualStyleBackColor = true;
            this.FFT.Click += new System.EventHandler(this.FFT_Click);
            // 
            // IFFT
            // 
            this.IFFT.AutoSize = true;
            this.IFFT.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.IFFT.Depth = 0;
            this.IFFT.Location = new System.Drawing.Point(415, 158);
            this.IFFT.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.IFFT.MouseState = MaterialSkin.MouseState.HOVER;
            this.IFFT.Name = "IFFT";
            this.IFFT.Primary = false;
            this.IFFT.Size = new System.Drawing.Size(39, 36);
            this.IFFT.TabIndex = 21;
            this.IFFT.Text = "IFFT";
            this.IFFT.UseVisualStyleBackColor = true;
            this.IFFT.Click += new System.EventHandler(this.IFFT_Click);
            // 
            // MoImageProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 566);
            this.Controls.Add(this.IFFT);
            this.Controls.Add(this.FFT);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Convert2Gray);
            this.Controls.Add(this.Resizee);
            this.Controls.Add(this.Crop);
            this.Controls.Add(this.Rotate);
            this.Controls.Add(this.OpenImagee);
            this.Controls.Add(this.Angle);
            this.Controls.Add(this.CropMode);
            this.Controls.Add(this.inputHeigth);
            this.Controls.Add(this.inputWidth);
            this.Controls.Add(this.pBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MoImageProcessing";
            this.Text = "MOImageProcessing";
            this.Load += new System.EventHandler(this.MoImageProcessing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void MoImageProcessing_Load(object sender, EventArgs e) { }

        #endregion
        private System.Windows.Forms.PictureBox pBox;
        private System.Windows.Forms.TextBox inputWidth;
        private System.Windows.Forms.TextBox inputHeigth;
        private System.Windows.Forms.ComboBox CropMode;
        private System.Windows.Forms.TextBox Angle;
        private MaterialSkin.Controls.MaterialFlatButton OpenImagee;
        private MaterialSkin.Controls.MaterialFlatButton Rotate;
        private MaterialSkin.Controls.MaterialFlatButton Crop;
        private MaterialSkin.Controls.MaterialFlatButton Resizee;
        private MaterialSkin.Controls.MaterialFlatButton Convert2Gray;
        private MaterialSkin.Controls.MaterialFlatButton Save;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private MaterialSkin.Controls.MaterialFlatButton FFT;
        private MaterialSkin.Controls.MaterialFlatButton IFFT;
    }
}

