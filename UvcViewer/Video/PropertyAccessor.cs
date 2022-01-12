using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UvcViewer.Video
{
    internal class PropertyAccessor
    {
        private Dictionary<CameraControlProperty, PropertyItem> _props = new Dictionary<CameraControlProperty, PropertyItem>();
        public IReadOnlyDictionary<CameraControlProperty, PropertyItem> Props => _props;

        public PropertyAccessor()
        {

        }
        public PropertyAccessor(VideoCaptureDevice video)
        {
            CameraControlProperty[] props = new CameraControlProperty[]
            {
                CameraControlProperty.Pan,
                CameraControlProperty.Tilt,
                CameraControlProperty.Roll,
                CameraControlProperty.Zoom,
                CameraControlProperty.Exposure,
                CameraControlProperty.Iris,
                CameraControlProperty.Focus
            };

            foreach (var prop in props)
            {
                _props.Add(prop, new PropertyItem(video, prop));
            }
        }
    }
}
