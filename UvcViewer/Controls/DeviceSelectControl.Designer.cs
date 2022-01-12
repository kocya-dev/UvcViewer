namespace UvcViewer.Controls
{
    partial class DeviceSelectControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this._comboBoxDeviceList = new System.Windows.Forms.ComboBox();
            this._labelDevice = new System.Windows.Forms.Label();
            this._labelStatus = new System.Windows.Forms.Label();
            this._labelStatusIndicator = new System.Windows.Forms.Label();
            this._buttonDisconnect = new System.Windows.Forms.Button();
            this._buttonConnect = new System.Windows.Forms.Button();
            this._comboBoxCapability = new System.Windows.Forms.ComboBox();
            this._labelCapability = new System.Windows.Forms.Label();
            this._buttonProperty = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _comboBoxDeviceList
            // 
            this._comboBoxDeviceList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._comboBoxDeviceList.FormattingEnabled = true;
            this._comboBoxDeviceList.Location = new System.Drawing.Point(71, 6);
            this._comboBoxDeviceList.Name = "_comboBoxDeviceList";
            this._comboBoxDeviceList.Size = new System.Drawing.Size(366, 23);
            this._comboBoxDeviceList.TabIndex = 0;
            this._comboBoxDeviceList.SelectedIndexChanged += new System.EventHandler(this._deviceListComboBox_SelectedIndexChanged);
            // 
            // _labelDevice
            // 
            this._labelDevice.AutoSize = true;
            this._labelDevice.Location = new System.Drawing.Point(3, 9);
            this._labelDevice.Name = "_labelDevice";
            this._labelDevice.Size = new System.Drawing.Size(45, 15);
            this._labelDevice.TabIndex = 1;
            this._labelDevice.Text = "Device:";
            // 
            // _labelStatus
            // 
            this._labelStatus.AutoSize = true;
            this._labelStatus.Location = new System.Drawing.Point(3, 40);
            this._labelStatus.Name = "_labelStatus";
            this._labelStatus.Size = new System.Drawing.Size(42, 15);
            this._labelStatus.TabIndex = 1;
            this._labelStatus.Text = "Status:";
            // 
            // _labelStatusIndicator
            // 
            this._labelStatusIndicator.AutoSize = true;
            this._labelStatusIndicator.Location = new System.Drawing.Point(71, 40);
            this._labelStatusIndicator.Name = "_labelStatusIndicator";
            this._labelStatusIndicator.Size = new System.Drawing.Size(32, 15);
            this._labelStatusIndicator.TabIndex = 1;
            this._labelStatusIndicator.Text = "-----";
            // 
            // _buttonDisconnect
            // 
            this._buttonDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonDisconnect.Location = new System.Drawing.Point(362, 36);
            this._buttonDisconnect.Name = "_buttonDisconnect";
            this._buttonDisconnect.Size = new System.Drawing.Size(75, 23);
            this._buttonDisconnect.TabIndex = 2;
            this._buttonDisconnect.Text = "Disconnect";
            this._buttonDisconnect.UseVisualStyleBackColor = true;
            this._buttonDisconnect.Click += new System.EventHandler(this._buttonDisconnect_Click);
            // 
            // _buttonConnect
            // 
            this._buttonConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonConnect.Location = new System.Drawing.Point(281, 36);
            this._buttonConnect.Name = "_buttonConnect";
            this._buttonConnect.Size = new System.Drawing.Size(75, 23);
            this._buttonConnect.TabIndex = 2;
            this._buttonConnect.Text = "Connect";
            this._buttonConnect.UseVisualStyleBackColor = true;
            this._buttonConnect.Click += new System.EventHandler(this._buttonConnect_Click);
            // 
            // _comboBoxCapability
            // 
            this._comboBoxCapability.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._comboBoxCapability.FormattingEnabled = true;
            this._comboBoxCapability.Location = new System.Drawing.Point(71, 65);
            this._comboBoxCapability.Name = "_comboBoxCapability";
            this._comboBoxCapability.Size = new System.Drawing.Size(366, 23);
            this._comboBoxCapability.TabIndex = 3;
            this._comboBoxCapability.SelectedIndexChanged += new System.EventHandler(this._comboBoxCapability_SelectedIndexChanged);
            // 
            // _labelCapability
            // 
            this._labelCapability.AutoSize = true;
            this._labelCapability.Location = new System.Drawing.Point(3, 68);
            this._labelCapability.Name = "_labelCapability";
            this._labelCapability.Size = new System.Drawing.Size(62, 15);
            this._labelCapability.TabIndex = 1;
            this._labelCapability.Text = "Capability:";
            // 
            // _buttonProperty
            // 
            this._buttonProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonProperty.Location = new System.Drawing.Point(362, 94);
            this._buttonProperty.Name = "_buttonProperty";
            this._buttonProperty.Size = new System.Drawing.Size(75, 23);
            this._buttonProperty.TabIndex = 2;
            this._buttonProperty.Text = "Property";
            this._buttonProperty.UseVisualStyleBackColor = true;
            this._buttonProperty.Click += new System.EventHandler(this._buttonProperty_Click);
            // 
            // DeviceSelectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._comboBoxCapability);
            this.Controls.Add(this._buttonProperty);
            this.Controls.Add(this._buttonConnect);
            this.Controls.Add(this._buttonDisconnect);
            this.Controls.Add(this._labelStatusIndicator);
            this.Controls.Add(this._labelCapability);
            this.Controls.Add(this._labelStatus);
            this.Controls.Add(this._labelDevice);
            this.Controls.Add(this._comboBoxDeviceList);
            this.MinimumSize = new System.Drawing.Size(440, 121);
            this.Name = "DeviceSelectControl";
            this.Size = new System.Drawing.Size(440, 121);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox _comboBoxDeviceList;
        private Label _labelDevice;
        private Label _labelStatus;
        private Label _labelStatusIndicator;
        private Button _buttonDisconnect;
        private Button _buttonConnect;
        private ComboBox _comboBoxCapability;
        private Label _labelCapability;
        private Button _buttonProperty;
    }
}
