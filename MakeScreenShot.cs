using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace PrintScreenMaker
{
    class MakeScreenShot
    {

        public void CaptureMyScreen(string path)

        {

            try

            {

                //Creating a new Bitmap object

                Bitmap captureBitmap = new Bitmap(1440, 900, PixelFormat.Format64bppArgb);


                //Bitmap captureBitmap = new Bitmap(int width, int height, PixelFormat);

                //Creating a Rectangle object which will  

                //capture our Current Screen

                Rectangle captureRectangle = Screen.PrimaryScreen.WorkingArea;



                //Creating a New Graphics Object

                Graphics captureGraphics = Graphics.FromImage(captureBitmap);



                //Copying Image from The Screen

                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);


                Font font = new Font("Arial", 25, FontStyle.Bold, GraphicsUnit.Pixel);
                Color color = Color.FromArgb(230, 186, 186, 1);
                Point atpoint = new Point(captureBitmap.Width-180, captureBitmap.Height-50);
                SolidBrush brush = new SolidBrush(color);
              //  Graphics graphics = Graphics.FromImage(captureBitmap);
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                captureGraphics.DrawString("CheremonGames.com", font, brush, atpoint, sf);
                captureGraphics.Dispose();

                //Saving the Image File (I am here Saving it in My E drive).
                string imgFilename = "Image_" + DateTime.Now.ToString("hhMMss");
                captureBitmap.Save(@""+path+"\\"+imgFilename+".jpg", ImageFormat.Jpeg);
                captureBitmap.Dispose();



                //Displaying the Successfull Result



                //  MessageBox.Show("Screen Captured");

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }

        }

    }
}
