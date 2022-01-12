using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UvcViewer.Controls
{
    internal class VideoCapabilitiesItem
    {
        public VideoCapabilities Capabilities { get; private set; }
        public VideoCapabilitiesItem(VideoCapabilities capabilities)
        {
            Capabilities = capabilities;
        }

        public override string ToString()
        {
            return $"{Capabilities.FrameSize.Width}x{Capabilities.FrameSize.Height} {Capabilities.AverageFrameRate}fps {Capabilities.BitCount}bps";
        }
    }
}
