using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public partial class ImageManipulationForm : Form
    {
        private readonly string[] formats = { "bmp", "png", "jpg" };
        private readonly OpenFileDialog openFileDialog;

        public ImageManipulationForm()
        {
            InitializeComponent();

            openFileDialog = new OpenFileDialog
            {
                Title = "Open Image File",
                FileName = "Select an image file",
                Filter = "Image File | *.jpg; *.png; *.bmp"
            };

            ConvertImageComboBox.Items.AddRange(formats);
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                MessageBox.Show(filename, "Chosen Image File");
            }
        }

        private void ConvertNowButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.FileName == "Select an image file")
            {
                MessageBox.Show("Please select an image file", "Image File");
            }
            else if (ConvertImageComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select image format to convert", "Image Format");
            }
            else
            {
                ConvertImage(openFileDialog.FileName, ConvertImageComboBox.SelectedItem.ToString());
                Console.WriteLine("Done");
            }
        }

        private void ConvertImage(string imagePath, string newFormat)
        {
            try
            {
                Image image = Image.FromFile(imagePath);

                if (ImageFormat.Jpeg.Equals(image.RawFormat) && newFormat == "jpg" ||
                    ImageFormat.Png.Equals(image.RawFormat) && newFormat == "png" ||
                    ImageFormat.Bmp.Equals(image.RawFormat) && newFormat == "bmp"
                    )
                {
                    MessageBox.Show("Image is already in the selected format!");
                }
                else
                { 
                    if (ImageFormat.Jpeg.Equals(image.RawFormat) ||
                        ImageFormat.Png.Equals(image.RawFormat) ||
                        ImageFormat.Bmp.Equals(image.RawFormat)
                        )
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            switch (newFormat)
                            {
                                case "bmp":
                                    image.Save(memoryStream, ImageFormat.Bmp);
                                    break;
                                case "jpg":
                                    image.Save(memoryStream, ImageFormat.Jpeg);
                                    break;
                                case "png":
                                    image.Save(memoryStream, ImageFormat.Png);
                                    break;
                                default:
                                    break;
                            }

                            Image convertedImage = Image.FromStream(memoryStream);
                            string convertedImagePath = imagePath.Substring(0, imagePath.LastIndexOf(".") + 1) + newFormat;
                            convertedImage.Save(convertedImagePath);
                        };
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: " + exception);
                throw;
            }
        }
    }
}
