using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Text;
using System.Security.Cryptography;
using WinFormsApp1;

namespace Steganography
{
    /// <summary>
    /// Summary description for SteganographyForm.
    /// </summary>
    public class SteganographyForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button buttonHideMessage;
        private System.Windows.Forms.Panel panelOriginalImage;
        private System.Windows.Forms.Panel panelModifiedImage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonExtractMessage;
        private System.Windows.Forms.TextBox textBoxExtractedlMessage;
        private System.Windows.Forms.GroupBox groupBox2;
        private Button Openbutton;
        private Button Downloadbutton;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private Button DownloadTextbutton;
        private String fileName;
        private String text;

        public SteganographyForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            /*try
            {
                //load original bitmap from a file
                bitmapOriginal = (Bitmap)Bitmap.FromFile(
                    @"..\..\plaintext.jpg");

                //center to screen
                this.CenterToScreen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading image. " +
                    ex.Message);
            }*/
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void Openbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Imafe Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    panelOriginalImage.BackgroundImage = new Bitmap(ofd.FileName);
                    bitmapOriginal = new Bitmap(ofd.FileName);
                    fileName = ofd.FileName;


                }
                catch
                {
                    MessageBox.Show("Невезможно открыть выбранный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Downloadbutton_Click(object sender, EventArgs e)
        {
            if (bitmapModified != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Сохранить картинку как...";
                saveFileDialog.OverwritePrompt = true;
                saveFileDialog.CheckPathExists = true;
                saveFileDialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files(*.*)|*.*";
                saveFileDialog.ShowHelp = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        bitmapModified = new Bitmap(
                    bitmapModified,
                    bitmapModified.Width + 524,
                    bitmapModified.Height + 524);
                        bitmapModified.Save(saveFileDialog.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonHideMessage = new Button();
            panelOriginalImage = new Panel();
            panelModifiedImage = new Panel();
            groupBox3 = new GroupBox();
            Openbutton = new Button();
            groupBox4 = new GroupBox();
            Downloadbutton = new Button();
            buttonExtractMessage = new Button();
            textBoxExtractedlMessage = new TextBox();
            groupBox2 = new GroupBox();
            DownloadTextbutton = new Button();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // buttonHideMessage
            // 
            buttonHideMessage.Location = new Point(22, 763);
            buttonHideMessage.Name = "buttonHideMessage";
            buttonHideMessage.Size = new Size(168, 39);
            buttonHideMessage.TabIndex = 0;
            buttonHideMessage.Text = "Hide Message";
            buttonHideMessage.Click += buttonHideMessage_Click;
            // 
            // panelOriginalImage
            // 
            panelOriginalImage.BackgroundImageLayout = ImageLayout.Zoom;
            panelOriginalImage.Location = new Point(17, 100);
            panelOriginalImage.Name = "panelOriginalImage";
            panelOriginalImage.Size = new Size(492, 589);
            panelOriginalImage.TabIndex = 0;
            // 
            // panelModifiedImage
            // 
            panelModifiedImage.BackgroundImageLayout = ImageLayout.Zoom;
            panelModifiedImage.Location = new Point(532, 100);
            panelModifiedImage.Name = "panelModifiedImage";
            panelModifiedImage.Size = new Size(492, 589);
            panelModifiedImage.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(Openbutton);
            groupBox3.Location = new Point(11, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(504, 702);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Original Image";
            // 
            // Openbutton
            // 
            Openbutton.Location = new Point(6, 40);
            Openbutton.Name = "Openbutton";
            Openbutton.Size = new Size(94, 29);
            Openbutton.TabIndex = 0;
            Openbutton.Text = "Загрузить";
            Openbutton.UseVisualStyleBackColor = true;
            Openbutton.Click += Openbutton_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(Downloadbutton);
            groupBox4.Location = new Point(526, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(504, 702);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Modified Image";
            // 
            // Downloadbutton
            // 
            Downloadbutton.Location = new Point(6, 40);
            Downloadbutton.Name = "Downloadbutton";
            Downloadbutton.Size = new Size(94, 29);
            Downloadbutton.TabIndex = 0;
            Downloadbutton.Text = "Скачать";
            Downloadbutton.UseVisualStyleBackColor = true;
            Downloadbutton.Click += Downloadbutton_Click;
            // 
            // buttonExtractMessage
            // 
            buttonExtractMessage.Location = new Point(538, 763);
            buttonExtractMessage.Name = "buttonExtractMessage";
            buttonExtractMessage.Size = new Size(168, 39);
            buttonExtractMessage.TabIndex = 2;
            buttonExtractMessage.Text = "Extract Message";
            buttonExtractMessage.Click += buttonExtractMessage_Click;
            // 
            // textBoxExtractedlMessage
            // 
            textBoxExtractedlMessage.Location = new Point(739, 763);
            textBoxExtractedlMessage.Name = "textBoxExtractedlMessage";
            textBoxExtractedlMessage.ReadOnly = true;
            textBoxExtractedlMessage.Size = new Size(280, 27);
            textBoxExtractedlMessage.TabIndex = 3;
            // 
            // groupBox2
            // 
            groupBox2.Location = new Point(717, 726);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(325, 89);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Extractedl Message";
            // 
            // DownloadTextbutton
            // 
            DownloadTextbutton.Location = new Point(290, 763);
            DownloadTextbutton.Name = "DownloadTextbutton";
            DownloadTextbutton.Size = new Size(168, 39);
            DownloadTextbutton.TabIndex = 4;
            DownloadTextbutton.Text = "Загрузить файл";
            DownloadTextbutton.UseVisualStyleBackColor = true;
            DownloadTextbutton.Click += DownloadTextbutton_Click;
            // 
            // SteganographyForm
            // 
            AutoScaleBaseSize = new Size(7, 20);
            ClientSize = new Size(1326, 841);
            Controls.Add(DownloadTextbutton);
            Controls.Add(buttonHideMessage);
            Controls.Add(panelModifiedImage);
            Controls.Add(panelOriginalImage);
            Controls.Add(groupBox3);
            Controls.Add(groupBox4);
            Controls.Add(buttonExtractMessage);
            Controls.Add(textBoxExtractedlMessage);
            Controls.Add(groupBox2);
            Name = "SteganographyForm";
            Text = "Steganography";
            Paint += SteganographyForm_Paint;
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new SteganographyForm());
        }

        private void SteganographyForm_Paint(
            object sender,
            System.Windows.Forms.PaintEventArgs e)
        {
            try
            {
                //get Graphics object for painting original
                //Graphics gPanelOriginal =
                //Graphics.FromHwnd(
                //  panelOriginalImage.Handle);

                //draw original bitmap into panel
                // gPanelOriginal.DrawImage(
                //  bitmapOriginal, new Point(0, 0));

                //return if there is no modified image yet
                if (bitmapModified == null)
                    return;

                //get Graphics object for painting modified
                Graphics gPanelModified =
                    Graphics.FromHwnd(
                       panelModifiedImage.Handle);

                //draw modified bitmap into panel
                gPanelModified.DrawImageUnscaled(
                   bitmapModified, 0, 28, 50, 50);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error drawing image." +
                    ex.Message);
                this.Close();
            }
        }

        private void buttonHideMessage_Click(
            object sender, System.EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
            if (form1.check)
            {
                form1.Close();
                try
                {
                    //show wait cursor
                    this.Cursor = Cursors.WaitCursor;

                    //start off with copy of original image
                    bitmapModified = new Bitmap(
                        bitmapOriginal,
                        bitmapOriginal.Width - 524,
                        bitmapOriginal.Height - 524);

                    //get original message to be hidden
                    int numberbytes =
                        (byte)text.Length * 2;//TODO
                    byte[] bytesOriginal = new byte[numberbytes + 1];
                    bytesOriginal[0] = (byte)numberbytes;
                    Encoding.UTF8.GetBytes(
                        text,
                        0,
                        text.Length,
                        bytesOriginal,
                        1);

                    //set bits 1, 2, 3 of byte into LSB red
                    //set bits 4, 5, 6 of byte into LSB green
                    //set bits 7 and 8 of byte into LSB blue
                    int byteCount = 0;
                    for (int i = 0; i < bitmapOriginal.Width; i++)
                    {
                        for (int j = 0; j < bitmapOriginal.Height; j++)
                        {
                            if (bytesOriginal.Length == byteCount)
                                return;

                            Color clrPixelOriginal =
                                bitmapOriginal.GetPixel(i, j);
                            byte r =
                                (byte)((clrPixelOriginal.R & ~0x7) |
                                (bytesOriginal[byteCount] >> 0) & 0x7);
                            byte g =
                                (byte)((clrPixelOriginal.G & ~0x7) |
                                (bytesOriginal[byteCount] >> 3) & 0x7);
                            byte b =
                                (byte)((clrPixelOriginal.B & ~0x3) |
                                (bytesOriginal[byteCount] >> 6) & 0x3);
                            byteCount++;

                            //set pixel to modified color
                            bitmapModified.SetPixel(
                                i, j, Color.FromArgb(r, g, b));
                        }

                    }
                    panelModifiedImage.BackgroundImage = bitmapModified;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error hiding message." +
                        ex.Message);
                }
                finally
                {
                    //show normal cursor
                    this.Cursor = Cursors.Arrow;

                    //repaint
                    Invalidate();
                }

            }
        }
        private void buttonExtractMessage_Click(
            object sender, System.EventArgs e)
        {
            //get bytes of message from modified image
            byte[] bytesExtracted = new byte[256 + 1];
            try
            {
                //show wait cursor, can be time-consuming
                this.Cursor = Cursors.WaitCursor;

                //get bits 1, 2, 3 of byte from LSB red
                //get bits 4, 5, 6 of byte from LSB green
                //get bits 7 and 8 of byte from LSB blue
                int byteCount = 0;
                for (int i = 0; i < bitmapModified.Width; i++)
                {
                    for (int j = 0; j < bitmapModified.Height; j++)
                    {
                        if (bytesExtracted.Length == byteCount)
                            return;

                        Color clrPixelModified =
                            bitmapModified.GetPixel(i, j);
                        byte bits123 =
                            (byte)((clrPixelModified.R & 0x7) << 0);
                        byte bits456 = (
                            byte)((clrPixelModified.G & 0x7) << 3);
                        byte bits78 = (
                            byte)((clrPixelModified.B & 0x3) << 6);

                        bytesExtracted[byteCount] =
                            (byte)(bits78 | bits456 | bits123);
                        byteCount++;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error extracting message." +
                    ex.Message);
            }
            finally
            {
                //show normal cursor
                this.Cursor = Cursors.Arrow;

                //get number of bytes from start of array
                int numberbytes = bytesExtracted[0];

                //get remaining bytes in array into string
                textBoxExtractedlMessage.Text =
                    Encoding.UTF8.GetString(
                    bytesExtracted,
                    1,
                    numberbytes);
            }
        }

        //shared private fields
        private Bitmap bitmapOriginal;
        private Bitmap bitmapModified;

        private void DownloadTextbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                text = File.ReadAllText(openFileDialog.FileName);
            }
        }
    }
}