using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Video.DirectShow;

namespace UvcViewer.Video
{
    internal class PropertyItem
    {
        public int Min;
        public int Max;
        public int Step;
        public int Default;
        public CameraControlFlags controlType;

        public PropertyItem(VideoCaptureDevice video, CameraControlProperty targetProperty)
        {
            video.GetCameraPropertyRange(targetProperty, out Min, out Max, out Step, out Default, out controlType);
        }
    }
}
