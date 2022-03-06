using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Visual_Compass
{
    public partial class Compass_Form : Form
    {
        static Pen myPen = new Pen(Color.Black);
        
        Graphics g = null;
     


        static Bitmap baseImage = (Bitmap)Image.FromFile(@"C:\Compass_Images\Compass2.png");  // this is the compass background image

        static Image imgpk = Image.FromFile(@"C:\Compass_Images\Compass2.png");      // alternative image format

        
        static int start_x = 0;
        static int start_y = 0;
        static int end_x  = 0; 
        static int end_y  = 0;
        static int length = 55;
        static int AzimuthOffset = 90;
        static int Azimuth = 0;


  
        public Compass_Form()
        {
            
            InitializeComponent();

            Canvas.BackgroundImage = baseImage;


            start_x = Canvas.Width / 2;       //Canvas is the name of the panel control, this defines the centre point
            start_y = Canvas.Height / 2;

            //todo remove if not using the picturebox
           // start_x = pictureBox1.Width / 2;
            //start_y = pictureBox1.Height / 2;
          //  Canvas.BackgroundImage = baseImage;
            
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {

            
            g = e.Graphics;                            // uses the Canvas_Paint event handler e instead of creategraphics()
            myPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor ;     // pen with arrowhead
            myPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;          // pen with rounded ends
            myPen.Width = 1;

           //  g = Canvas.CreateGraphics();            // graphics just for the canvas panel
            
            //g = e.Graphics;                            // uses the Canvas_Paint event handler e instead of creategraphics()
           
            
           
           g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            
            drawLine();                               // pass the azimuth to this
            
            g.Dispose();
          

        }
        private void drawLine()    // in the compass / encoder version this will need a parameter - Azimuth
        {
            end_x = (int)(start_x + Math.Cos((Azimuth + AzimuthOffset) * 0.017453292519) * length);    // the plus 90 is an offset such that the 
            end_y = (int)(start_y + Math.Sin((Azimuth + AzimuthOffset) * 0.017453292519) * length);    // pointer points to the correct position for a given Azimuth

            Point[] points =
            {
                new Point (start_x, start_y) ,              // note comma
                new Point (end_x , end_y )                  // 
            };                                              // note ; after }
            
            g.DrawLines(myPen, points);                 // draws the line with the points given

            
        }  // end drawline

   

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Canvas.Invalidate();
         
            Azimuth = hScrollBar1.Value;
            //Canvas.Refresh();
            
           //Canvas.Invalidate();
            
           
            
        }

        
    }
}
