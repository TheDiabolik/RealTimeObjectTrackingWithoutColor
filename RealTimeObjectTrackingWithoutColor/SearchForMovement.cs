using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenCvSharp;
//using OpenCvSharp.MachineLearning;
using OpenCvSharp.Blob;
using OpenCvSharp.UserInterface;
using OpenCvSharp.CPlusPlus;
using OpenCvSharp.Extensions;
namespace RealTimeObjectTrackingWithoutColor
{
    class SearchForMovement
    {
        static Rect objectBoundingRectangle = new Rect(0, 0, 0, 0);
        static int[] theObject = new int[2] { 0, 0 };

        public static void searchForMovement(Mat thresholdImage, Mat cameraFeed)
        {
            bool objectDetected = false;

            Mat temp = new Mat();
            thresholdImage.CopyTo(temp);

            OpenCvSharp.CPlusPlus.Point[][] contours;
            HiearchyIndex[] hierarchy;
            //find contours of filtered image using openCV findContours function
            Cv2.FindContours(temp, out contours, out hierarchy, ContourRetrieval.CComp, ContourChain.ApproxSimple);

            if (contours.Length > 0)
                objectDetected = true;
            else
                objectDetected = false;

            if (objectDetected)
            {
                List<OpenCvSharp.CPlusPlus.Point[]> largestContourVec = new List<OpenCvSharp.CPlusPlus.Point[]>();

                for (int i = 0; i < contours.Length; i++)
                    largestContourVec.Add(contours[i]);

                objectBoundingRectangle = Cv2.BoundingRect((largestContourVec[0]));
                int xpos = objectBoundingRectangle.X + objectBoundingRectangle.Width / 2;
                int ypos = objectBoundingRectangle.Y + objectBoundingRectangle.Height / 2;

                theObject[0] = xpos;
                theObject[1] = ypos;
            }

            int x = theObject[0];
            int y = theObject[1];

          


            //draw some crosshairs on the object
            Cv2.Circle(cameraFeed, new OpenCvSharp.CPlusPlus.Point(x, y), 20, new Scalar(0, 255, 0), 2);
            Cv2.Line(cameraFeed, new OpenCvSharp.CPlusPlus.Point(x, y), new OpenCvSharp.CPlusPlus.Point(x, y - 25), new Scalar(0, 255, 0), 2);
            Cv2.Line(cameraFeed, new OpenCvSharp.CPlusPlus.Point(x, y), new OpenCvSharp.CPlusPlus.Point(x, y + 25), new Scalar(0, 255, 0), 2);
            Cv2.Line(cameraFeed, new OpenCvSharp.CPlusPlus.Point(x, y), new OpenCvSharp.CPlusPlus.Point(x - 25, y), new Scalar(0, 255, 0), 2);
            Cv2.Line(cameraFeed, new OpenCvSharp.CPlusPlus.Point(x, y), new OpenCvSharp.CPlusPlus.Point(x + 25, y), new Scalar(0, 255, 0), 2);
            Cv2.PutText(cameraFeed, "Tracking object at (" + x.ToString() + "," + y.ToString() + ")", new OpenCvSharp.CPlusPlus.Point(x, y), FontFace.HersheyComplex, 1, new Scalar(255, 0, 0), 2);
        }

    }
}
