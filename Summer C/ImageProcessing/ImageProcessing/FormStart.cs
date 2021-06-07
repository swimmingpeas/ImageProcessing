using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class FormStart : Form
    {
        int m_iCurrentSelectedFile = 0;
        Bitmap m_CurrentEditingPictureBitmap = null;
        int g_iPictureWidth = 520;
        int g_iPictureHeight = 400;

        int m_xPosBeforeDragging = 0;
        int m_yPosBeforeDragging = 0;

        int iOriginalPictureStart_X = 0;
        int iOriginalPictureStart_Y = 0;

        public FormStart()
        {
            InitializeComponent();

            g_iPictureWidth = pictureBoxOriginal.Width;
            g_iPictureHeight = pictureBoxOriginal.Height;

            pictureBoxOriginal.Image = new Bitmap(g_iPictureWidth, g_iPictureHeight);
            loadSelectedFile();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            m_iCurrentSelectedFile--;
            loadSelectedFile();
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            m_iCurrentSelectedFile++;
            loadSelectedFile();
        }

        private void loadSelectedFile()
        {
            string[] arrFiles = Directory.GetFiles("testpictures");
            if (arrFiles.Length > 0)
            {
                if (m_iCurrentSelectedFile < 0)
                    m_iCurrentSelectedFile += arrFiles.Length;
                int iSelectIndex = m_iCurrentSelectedFile % arrFiles.Length;
                m_CurrentEditingPictureBitmap = new Bitmap(arrFiles[iSelectIndex]);

                if (m_CurrentEditingPictureBitmap.Height < g_iPictureHeight || m_CurrentEditingPictureBitmap.Width < g_iPictureWidth)
                {
                    MessageBox.Show("The picture has at least " + g_iPictureWidth + "*" + g_iPictureHeight + " pixels. Please select another picture.");
                    return;
                }

                showOriginalPicture();
            }
            else
            {
                m_CurrentEditingPictureBitmap = null;
                MessageBox.Show("Please check if there are files in testpictures folder");
            }
        }

        private void showOriginalPicture()
        {
            for (int x = 0; x < g_iPictureWidth; x++)
            {
                for (int y = 0; y < g_iPictureHeight; y++)
                {
                    Color pixelColor = m_CurrentEditingPictureBitmap.GetPixel(iOriginalPictureStart_X + x, iOriginalPictureStart_Y + y);
                    ((Bitmap)pictureBoxOriginal.Image).SetPixel(x, y, pixelColor);
                }
            }
            pictureBoxOriginal.Refresh();
        }


        private void pictureBoxOriginal_MouseDown(object sender, MouseEventArgs e)
        {
            m_xPosBeforeDragging = e.X;
            m_yPosBeforeDragging = e.Y;
        }

        private void pictureBoxOriginal_MouseUp(object sender, MouseEventArgs e)
        {
            if (m_CurrentEditingPictureBitmap == null)
                return;
            iOriginalPictureStart_X += (m_xPosBeforeDragging - e.X);
            iOriginalPictureStart_Y += (m_yPosBeforeDragging - e.Y);

            if (iOriginalPictureStart_X < 0)
                iOriginalPictureStart_X = 0;
            if (iOriginalPictureStart_X >= m_CurrentEditingPictureBitmap.Width - g_iPictureWidth)
                iOriginalPictureStart_X = m_CurrentEditingPictureBitmap.Width - g_iPictureWidth - 1;

            if (iOriginalPictureStart_Y < 0)
                iOriginalPictureStart_Y = 0;
            if (iOriginalPictureStart_Y >= m_CurrentEditingPictureBitmap.Height - g_iPictureHeight)
                iOriginalPictureStart_Y = m_CurrentEditingPictureBitmap.Height - g_iPictureHeight - 1;

            showOriginalPicture();
        }

        private void pictureBoxOriginal_SizeChanged(object sender, EventArgs e)
        {
            g_iPictureWidth = pictureBoxOriginal.Width;
            g_iPictureHeight = pictureBoxOriginal.Height;

            pictureBoxOriginal.Image = new Bitmap(g_iPictureWidth, g_iPictureHeight);
            loadSelectedFile();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            pictureBoxAfterEditing.Image = new Bitmap(g_iPictureWidth, g_iPictureHeight);
            showEditedPicture();
        }

        private void showEditedPicture()
        {
            for (int x = 0; x < g_iPictureWidth; x++)
            {
                for (int y = 0; y < g_iPictureHeight; y++)
                {
                    Color pixelColor = m_CurrentEditingPictureBitmap.GetPixel(iOriginalPictureStart_X + x, iOriginalPictureStart_Y + y);
                    ((Bitmap)pictureBoxAfterEditing.Image).SetPixel(x, y, pixelColor);
                }
            }
            pictureBoxAfterEditing.Refresh();
        }
    }
        
}
