using System.Text;

namespace Steganographia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.png;*.bmp)|*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string textToHide = Microsoft.VisualBasic.Interaction.InputBox("Введите текст для скрытия:", "Ввод текста", "");

                if (!string.IsNullOrEmpty(textToHide))
                {
                    Bitmap image = new Bitmap(filePath);
                    Bitmap newImage = EmbedText(textToHide, image);
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Image Files (*.png)|*.png"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        newImage.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        MessageBox.Show("Текст успешно скрыт в изображении.");
                    }
                }
                else
                {
                    MessageBox.Show("Текст для скрытия не должен быть пустым.");
                }
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.png;*.bmp)|*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                Bitmap image = new Bitmap(filePath);
                string hiddenText = ExtractText(image);
                MessageBox.Show("Скрытый текст: " + hiddenText);
            }
        }
        private Bitmap EmbedText(string text, Bitmap bmp)
        {
            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            byte[] lengthBytes = BitConverter.GetBytes(textBytes.Length);

            if (textBytes.Length > (bmp.Width * bmp.Height * 3) / 8)
            {
                throw new ArgumentException("Текст слишком длинный для данного изображения.");
            }

            int pixelIndex = 0;

            for (int i = 0; i < lengthBytes.Length * 8; i++)
            {
                int x = pixelIndex % bmp.Width;
                int y = pixelIndex / bmp.Width;
                Color pixel = bmp.GetPixel(x, y);
                byte r = pixel.R;
                r = (byte)(r & 0xFE | (lengthBytes[i / 8] >> (7 - i % 8) & 1));
                bmp.SetPixel(x, y, Color.FromArgb(r, pixel.G, pixel.B));
                pixelIndex++;
            }

            for (int i = 0; i < textBytes.Length * 8; i++)
            {
                int x = pixelIndex % bmp.Width;
                int y = pixelIndex / bmp.Width;
                Color pixel = bmp.GetPixel(x, y);
                byte r = pixel.R;
                r = (byte)(r & 0xFE | (textBytes[i / 8] >> (7 - i % 8) & 1));
                bmp.SetPixel(x, y, Color.FromArgb(r, pixel.G, pixel.B));
                pixelIndex++;
            }

            return bmp;
        }

        private string ExtractText(Bitmap bmp)
        {
            byte[] lengthBytes = new byte[4];
            int pixelIndex = 0;

            for (int i = 0; i < lengthBytes.Length * 8; i++)
            {
                int x = pixelIndex % bmp.Width;
                int y = pixelIndex / bmp.Width;
                Color pixel = bmp.GetPixel(x, y);
                lengthBytes[i / 8] = (byte)(lengthBytes[i / 8] | ((pixel.R & 1) << (7 - i % 8)));
                pixelIndex++;
            }

            int textLength = BitConverter.ToInt32(lengthBytes, 0);
            byte[] textBytes = new byte[textLength];

            for (int i = 0; i < textBytes.Length * 8; i++)
            {
                int x = pixelIndex % bmp.Width;
                int y = pixelIndex / bmp.Width;
                Color pixel = bmp.GetPixel(x, y);
                textBytes[i / 8] = (byte)(textBytes[i / 8] | ((pixel.R & 1) << (7 - i % 8)));
                pixelIndex++;
            }

            return Encoding.UTF8.GetString(textBytes);
        }
    }
}
