using Accord.Video.VFW;
using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using UvcViewer.Video;

namespace UvcViewer.Controls
{
    public partial class DeviceSelectControl : UserControl
    {
        private int _frameCount = 0;
        private System.Timers.Timer _frameCountTimer = new System.Timers.Timer(1000);
        private FilterInfoCollection _videoDevices;
        private VideoCaptureDevice _videoSource;
        private PropertyAccessor _props;
        public event NewFrameEventHandler NewFrameGot = delegate { };
        public event EventHandler ResolutionSelected = delegate { };    
        public Size Resolution => _videoSource.VideoResolution?.FrameSize ?? new Size(0,0);

        public DeviceSelectControl()
        {
            
            InitializeComponent();
            _videoSource = new VideoCaptureDevice();
            _videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            _props = new PropertyAccessor();
            _frameCountTimer.Elapsed += _frameCountTimer_Elapsed;
            UpdateConnectingStatus(false);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _comboBoxCapability.SelectedIndexChanged += ResolutionSelected;
        }
        private void _frameCountTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            int currentFrameCount = _frameCount;
            _frameCount = 0;
            BeginInvoke(() => { _labelStatusIndicator.Text = $"Running.. {currentFrameCount}fps"; });
        }

        public void ReloadCameraDevices()
        {
            try
            {
                TryReloadCameraDevices();
            }
            catch (ApplicationException e)
            {
                _labelStatusIndicator.Text = e.Message;
            }
        }
        internal void Stop(bool sync)
        {
            if (_videoSource == null) return;
            if (!_videoSource.IsRunning) return;

            _videoSource.NewFrame -= NewFrameGot;
            _videoSource.NewFrame -= FrameCounter;
            _frameCountTimer.Stop();

            // 停止に失敗することがあるので WautForStopだと返ってこないことがある。
            // そのため SignalToStop x IsRunningで何度かに分けてチェック & 停止リトライをおこなう。
            int stopRetryCount = 3;
            while (sync && stopRetryCount-- > 0 && _videoSource.IsRunning)
            {
                _videoSource.SignalToStop();

                Task.Run(() =>
                {
                    for (int i = 0; i < 5; ++i)
                    {
                        Thread.Sleep(50);
                        if (!_videoSource.IsRunning)
                        {
                            return;
                        }
                    }
                }).Wait();
            }
        }
        private void Start()
        {
            if (_videoSource == null) return;
            if (_videoSource.IsRunning) return;

            _frameCount = 0;
            _videoSource.NewFrame += FrameCounter;
            _videoSource.NewFrame += NewFrameGot;
            _videoSource.Start();
            _frameCountTimer.Start();
        }
        private void FrameCounter(object sender, AForge.Video.NewFrameEventArgs e)
        {
            ++_frameCount;
        }

        private void _buttonConnect_Click(object sender, EventArgs e)
        {
            Start();
            UpdateConnectingStatus(true);
        }

        private void _buttonDisconnect_Click(object sender, EventArgs e)
        {
            Stop(true);
            UpdateConnectingStatus(false);
        }

        private void TryReloadCameraDevices()
        {
            if (_videoDevices.Count == 0)
            {
                throw new ApplicationException("No device.");
            }
            UpdateDeviceNames(); // デバイスリストが更新された時点で_comboBoxDeviceListのindexが更新され、それを受けてCapabilityも更新される。
        }

        private void UpdateDeviceNames()
        {
            _comboBoxDeviceList.Items.Clear();
            foreach (FilterInfo device in _videoDevices)
            {
                _comboBoxDeviceList.Items.Add(device.Name);
            }
            _comboBoxDeviceList.SelectedIndex = 0;   // make default to first cam.
        }
        private void UpdateCapabilities()
        {
            _comboBoxCapability.Items.Clear();

            foreach (var cap in _videoSource.VideoCapabilities)
            {
                _comboBoxCapability.Items.Add(new VideoCapabilitiesItem(cap));
            }

            _comboBoxCapability.SelectedIndex = 0;  
        }

        private void _deviceListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool existAvailableDevice = _videoDevices != null && _videoDevices.Count != 0;
            if (!existAvailableDevice) return;

            string targetMoniker = _videoDevices[_comboBoxDeviceList.SelectedIndex].MonikerString;
            CreateVideoSource(targetMoniker);
            _buttonConnect.Enabled = true;
            UpdateCapabilities();
        }

        private void CreateVideoSource(string targetMoniker)
        {
            _videoSource.PlayingFinished -= _videoSource_PlayingFinished;
            _videoSource.VideoSourceError -= _videoSource_VideoSourceError;

            _videoSource = new VideoCaptureDevice(targetMoniker);
            _videoSource.PlayingFinished += _videoSource_PlayingFinished;
            _videoSource.VideoSourceError += _videoSource_VideoSourceError;

            _props = new PropertyAccessor(_videoSource);

            // デバッグ用
            foreach (var prop in _props.Props) {
                StringBuilder typeBuilder = new StringBuilder();
                if (prop.Value.controlType == CameraControlFlags.None)
                {
                    typeBuilder.Append('N');
                }
                else
                {
                    if ((prop.Value.controlType & CameraControlFlags.Auto) == CameraControlFlags.Auto){
                        typeBuilder.Append('A');
                    }
                    if ((prop.Value.controlType & CameraControlFlags.Manual) == CameraControlFlags.Manual){
                        typeBuilder.Append('M');
                    }
                }
                Debug.WriteLine($"{prop.Key, 20} Min:{prop.Value.Min,3} Max:{prop.Value.Max,3} Step:{prop.Value.Step,3} Def:{prop.Value.Default,3} Type:{typeBuilder,3}");
            }
        }

        private void _videoSource_PlayingFinished(object sender, ReasonToFinishPlaying reason)
        {
            Debug.WriteLine(reason.ToString());
        }

        private void _videoSource_VideoSourceError(object sender, VideoSourceErrorEventArgs eventArgs)
        {
            Debug.WriteLine(eventArgs.Description);
        }

        private void _comboBoxCapability_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool existAvailableDevice = _videoDevices != null && _videoDevices.Count != 0;
            if (!existAvailableDevice) return;

            if (_videoSource.IsRunning)
            {
                Stop(true);
                _videoSource.VideoResolution = ((VideoCapabilitiesItem)_comboBoxCapability.SelectedItem).Capabilities;
                Start();
            }
            else
            {
                _videoSource.VideoResolution = ((VideoCapabilitiesItem)_comboBoxCapability.SelectedItem).Capabilities;
            }
        }

        private void UpdateConnectingStatus(bool isStart)
        {
            _labelStatusIndicator.Text = isStart ? "Running.." : "Stopped.";
            _comboBoxDeviceList.Enabled = !isStart;
            _buttonConnect.Enabled = !isStart && _comboBoxDeviceList.SelectedIndex >= 0;
            _buttonDisconnect.Enabled = isStart;
            _buttonConnect.Enabled = _comboBoxCapability.SelectedIndex >= 0;
        }

        private void _buttonProperty_Click(object sender, EventArgs e)
        {
            _videoSource?.DisplayPropertyPage(this.Handle);
        }
    }
}
