using System.Diagnostics;
using System.Runtime.InteropServices;
using UvcViewer.Utils;

namespace UvcViewer
{
    public partial class MainForm : Form
    {
        private double _ratio = 1.0;
        private Size _offsetSize = new Size();
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _offsetSize = new Size(Width - _pictureBox.Width, Height - _pictureBox.Height);
            _ratio = (double)ClientSize.Width / ClientSize.Height;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            _deviceSelectControl.ReloadCameraDevices();
            _deviceSelectControl.NewFrameGot += _deviceSelectControl_NewFrameGot;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _deviceSelectControl.Stop(true);
            _deviceSelectControl.NewFrameGot -= _deviceSelectControl_NewFrameGot;
            base.OnFormClosing(e);
        }


        private void _deviceSelectControl_NewFrameGot(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            if (IsDisposed) return;

            if (InvokeRequired)
            {
                try
                {
                    Invoke(UpdateDisplayImage, eventArgs.Frame);
                }
                catch (ObjectDisposedException ex)
                {
                    // through.
                    Debug.WriteLine(ex.Message);
                }
                return;
            }
            UpdateDisplayImage(eventArgs.Frame);
        }

        private void UpdateDisplayImage(Bitmap img)
        {
            if (_pictureBox.Image != null)
            {
                _pictureBox.Image.Dispose();
            }
            _pictureBox.Image = (Bitmap)img.Clone();
        }

        protected override void WndProc(ref Message m)
        {
            WindowSizeUtil.CorrectWindowAspectOnSizing(m, _ratio, this, MinimumSize);
            base.WndProc(ref m);
        }


        private void _deviceSelectControl_ResolutionSelected(object sender, EventArgs e)
        {
            // VideoDeviceの出力解像度変化に応じて維持すべきアスペクト比を再算出する
            double ratio = (double)_deviceSelectControl.Resolution.Height / _deviceSelectControl.Resolution.Width;

            int nextHeight = (int)(_pictureBox.Width * ratio);
            Height = nextHeight + _offsetSize.Height;
            _ratio = (double)ClientSize.Width / ClientSize.Height;
        }
    }
}