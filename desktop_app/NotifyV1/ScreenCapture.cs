using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace NotifyV1
{
    class ScreenCapture
    {
        private Rectangle canvasBounds = Screen.GetBounds(Point.Empty);
        
        public ScreenCapture()
        {
            //SetCanvas();
        }

        public Bitmap GetSnapShot()
        {
               
            using (Image image = new Bitmap(canvasBounds.Width, canvasBounds.Height))
            {
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    //Console.WriteLine("{0}", canvasBounds.Size);

                    //Console.WriteLine("{0}", canvasBounds.Location);
                    //Console.WriteLine("{0} {1}", canvasBounds.Left, canvasBounds.Top);

                    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    graphics.CopyFromScreen(canvasBounds.Left, canvasBounds.Top, 0, 0, canvasBounds.Size);
                    //graphics.DrawImage(printscreen, 0, 0, canvasBounds, GraphicsUnit.Pixel);
                }
                return new Bitmap(image);
            }
            
            /*
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width,Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(printscreen as Image);
            g.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            printscreen.Save(@"E:\snip.png");

            Console.WriteLine("Res {0}", Screen.PrimaryScreen.Bounds);
            */
            
        }

        /*
        private Image SetBorder(Image srcImg, Color color, int width)
        {
            // Create a copy of the image and graphics context
            Image dstImg = srcImg.Clone() as Image;
            Graphics g = Graphics.FromImage(dstImg);

            // Create the pen
            Pen pBorder = new Pen(color, width)
            {
                Alignment = PenAlignment.Center
            };

            // Draw
            g.DrawRectangle(pBorder, 0, 0, dstImg.Width - 1, dstImg.Height - 1);

            // Clean up
            pBorder.Dispose();
            g.Save();
            g.Dispose();

            // Return
            return dstImg;
        }
        */
        public bool SetCanvas()
        {
            using (Canvas canvas = new Canvas())
            {
                if (canvas.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    canvasBounds = canvas.GetRectangle();

                    //Console.WriteLine("Location {0} ", canvasBounds.Location);
                    //Console.WriteLine("Size {0} ", canvasBounds.Size);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
