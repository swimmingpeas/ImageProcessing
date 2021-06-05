namespace ImageProcessing
{
    partial class FormStart
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
            this.ButtonLoadImage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonLoadImage
            // 
            this.ButtonLoadImage.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ButtonLoadImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLoadImage.Location = new System.Drawing.Point(249, 170);
            this.ButtonLoadImage.Name = "ButtonLoadImage";
            this.ButtonLoadImage.Size = new System.Drawing.Size(239, 78);
            this.ButtonLoadImage.TabIndex = 0;
            this.ButtonLoadImage.Text = "Load Image";
            this.ButtonLoadImage.UseVisualStyleBackColor = false;
            this.ButtonLoadImage.Click += new System.EventHandler(this.ButtonLoadImage_Click);
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ButtonLoadImage);
            this.Name = "FormStart";
            this.Text = "Start Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonLoadImage;
    }
}

