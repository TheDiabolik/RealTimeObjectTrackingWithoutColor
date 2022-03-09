using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
//using OpenCvSharp.MachineLearning;
using OpenCvSharp.Blob;
using OpenCvSharp.UserInterface;
using OpenCvSharp.CPlusPlus;
using OpenCvSharp.Extensions;

namespace RealTimeObjectTrackingWithoutColor
{
    public partial class MainForm : Form
    {
        Mat differenceImage, frame1, frame2, grayImage1, grayImage2, threshold;
        VideoCapture captureCam;
        PictureBoxIpl m_pictureBoxIpl; 

        const int FRAME_WIDTH = 640;
        const int FRAME_HEIGHT = 480;

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        const int BLUR_SIZE = 10;

        public MainForm()
        {
            InitializeComponent();

            captureCam = new VideoCapture();

            differenceImage = new Mat();
            frame1 = new Mat();
            frame2 = new Mat();
            grayImage1 = new Mat();
            grayImage2 = new Mat();
            differenceImage = new Mat();
            differenceImage = new Mat();
            threshold = new Mat();

            m_pictureBoxIpl = new PictureBoxIpl();
            m_pictureBoxIpl.SizeMode = PictureBoxSizeMode.StretchImage;
            m_pictureBoxIpl.Size = new System.Drawing.Size(320, 280);

            m_panelCamera.Controls.Add(m_pictureBoxIpl); 
        }

        private void m_timer_Tick(object sender, EventArgs e)
        {
            if (!m_backgroundWorker.IsBusy)
                m_backgroundWorker.RunWorkerAsync();
        }

        private void m_backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!captureCam.IsOpened())
            {
                //captureCam.Open("arabalar.mkv");
                captureCam.Open("bouncingBall.avi");
                //captureCam.Open(0);

                captureCam.Set(CvConst.CV_CAP_PROP_FRAME_WIDTH, FRAME_WIDTH);
                captureCam.Set(CvConst.CV_CAP_PROP_FRAME_HEIGHT, FRAME_HEIGHT);
            }
            else
            {
                if( captureCam.Get(CaptureProperty.PosFrames) > captureCam.Get(CaptureProperty.FrameCount)-1)
                {
                     captureCam.Release();

                    captureCam.Open("bouncingBall.avi");
                    //captureCam.Open("arabalar.mkv");
                    //captureCam.Open(0);

                    captureCam.Set(CvConst.CV_CAP_PROP_FRAME_WIDTH, FRAME_WIDTH);
                captureCam.Set(CvConst.CV_CAP_PROP_FRAME_HEIGHT, FRAME_HEIGHT); 
                }

           
            }

            //captureCam.Read(cameraFeed);
            captureCam.Read(frame1);
            Cv2.CvtColor(frame1, grayImage1, ColorConversion.RgbToGray); 
            
            captureCam.Read(frame2);
            Cv2.CvtColor(frame2, grayImage2, ColorConversion.RgbToGray);

            if (frame1.Width != 0 && frame1.Height != 0 && frame2.Width != 0 && frame2.Height != 0)
            { 
                Cv2.Absdiff(grayImage1, grayImage2, differenceImage);

                Cv2.Threshold(differenceImage, threshold, Convert.ToInt32(m_numericUpDownSensitivity.Value)  , 255, ThresholdType.Binary);

                Cv2.Blur(threshold, threshold, new OpenCvSharp.CPlusPlus.Size(BLUR_SIZE, BLUR_SIZE));

                Cv2.Threshold(differenceImage, threshold, Convert.ToInt32(m_numericUpDownSensitivity.Value), 255, ThresholdType.Binary);

                if (m_checkBoxTrackObject.Checked)
                    SearchForMovement.searchForMovement(threshold, frame1);

                //if (cameraFeed.Width != 0 && cameraFeed.Height != 0)
                m_pictureBoxIpl.ImageIpl = frame1.ToIplImage();
            }
        }

     
        private void m_buttonStart_Click(object sender, EventArgs e)
        {
            if (m_timer.Enabled)
                m_timer.Stop();
            else
                m_timer.Start();
        }
    }
}
