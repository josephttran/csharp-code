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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public partial class ImageManipulationForm : Form
    {
        private readonly string[] formats = { "bmp", "png", "jpg" };
        private readonly string[] resolutionSizes =
        {
            "No change",
            "500, 500",
            "640, 480", "800, 600",
            "1280, 720", "1600, 900",
            "1280,800", "1440,900",
        };
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
            ChangeResolutionComboBox.Items.AddRange(resolutionSizes);
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
                ConvertImage(
                    openFileDialog.FileName,
                    ConvertImageComboBox.SelectedItem.ToString(),
                    ChangeResolutionComboBox.Text.ToString());

                Console.WriteLine("Done");
            }
        }

        private void ConvertImage(string imagePath, string newFormat, string resolutionSize)
        {
            string convertedImagePath = imagePath.Substring(0, imagePath.LastIndexOf(".") + 1) + newFormat;

            ImageFormat format = GetImageFormat(newFormat);

            try
            {
                Image image = Image.FromFile(imagePath);

                if (resolutionSize == "No change")
                {
                    if (ImageFormat.Jpeg.Equals(image.RawFormat) && newFormat != "jpg" ||
                        ImageFormat.Png.Equals(image.RawFormat) && newFormat != "png" ||
                        ImageFormat.Bmp.Equals(image.RawFormat) && newFormat != "bmp")
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            image.Save(memoryStream, format);
                            Image convertedImage = Image.FromStream(memoryStream);
                            convertedImage.Save(convertedImagePath);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No changes");
                    }
                }
                else
                {
                    string pattern = @"^\d{3,4},\s?\d{3,4}$";

                    if (!Regex.IsMatch(resolutionSize, pattern))
                    {
                        errorProvider1.SetError(ChangeResolutionComboBox, "Invalid resolution format");
                    }
                    else
                    {
                        errorProvider1.SetError(ChangeResolutionComboBox, "");

                        string[] widthHeight = resolutionSize.Split(',');
                        int newWidth = int.Parse(widthHeight[0].Trim());
                        int newHeight = int.Parse(widthHeight[1].Trim());

                        using (Bitmap bitmap = new Bitmap(image, new Size(newWidth, newHeight)))
                        {
                            image.Dispose();

                            if (File.Exists(imagePath))
                            {
                                File.Delete(imagePath);
                            }

                            bitmap.Save(imagePath);
                        }
                    }
                }

                image.Dispose();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: " + exception);
                throw;
            }
        }

        private ImageFormat GetImageFormat(string selectedFormat)
        {
            switch (selectedFormat)
            {
                case "bmp":
                    return ImageFormat.Bmp;
                case "jpg":
                    return ImageFormat.Jpeg;
                case "png":
                    return ImageFormat.Png;
                default:
                    return null;
            }
        }
    }
}
