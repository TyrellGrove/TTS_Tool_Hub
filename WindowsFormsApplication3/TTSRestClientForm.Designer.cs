namespace TTS_Tool_Hub
{
  partial class TTSRestClientFrame
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TTSRestClientFrame));
      this.Servicelabel = new System.Windows.Forms.Label();
      this.ServiceDropDown = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.myInputUser = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.GetInputsButton = new System.Windows.Forms.Button();
      this.CloseButton = new System.Windows.Forms.Button();
      this.ClearButton = new System.Windows.Forms.Button();
      this.RunRequest = new System.Windows.Forms.Button();
      this.SaveRun = new System.Windows.Forms.Button();
      this.ChooseFileButton = new System.Windows.Forms.Button();
      this.tbFilePath = new System.Windows.Forms.TextBox();
      this.LoadButton = new System.Windows.Forms.Button();
      this.CustomURLBox = new System.Windows.Forms.TextBox();
      this.CustomURLLabel = new System.Windows.Forms.Label();
      this.copyServiceButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // Servicelabel
      // 
      this.Servicelabel.AutoSize = true;
      this.Servicelabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Servicelabel.Location = new System.Drawing.Point(12, 2);
      this.Servicelabel.Name = "Servicelabel";
      this.Servicelabel.Size = new System.Drawing.Size(63, 16);
      this.Servicelabel.TabIndex = 0;
      this.Servicelabel.Text = "Service:";
      // 
      // ServiceDropDown
      // 
      this.ServiceDropDown.FormattingEnabled = true;
      this.ServiceDropDown.Items.AddRange(new object[] {
            "http://localhost:6247/APhA/Services/CreateUser",
            "http://localhost:6247/APhA/Services/VerifyEmail",
            "http://localhost:6247/APhA/Services/ResetPassword",
            "http://localhost:6247/APhA/Services/VerifyResetPassword",
            "http://localhost:6247/APhA/Services/Login",
            "http://localhost:6247/APhA/Services/ChangePassword",
            "http://localhost:6247/APhA/Services/RenewSession",
            "http://localhost:6247/APhA/Services/ChangeRole",
            "http://localhost:6247/APhA/Services/ChangeCoverage",
            "http://localhost:6247/APhA/Services/GetUsers",
            "http://localhost:6247/APhA/Services/GetUsersCoverage",
            "http://localhost:6247/APhA/Services/DeleteAccount",
            "http://localhost:6711/APhA/Services/ServerMap",
            "http://localhost:6711/APhA/Services/IntersectionMap",
            "http://localhost:6441/APhA/Services/SupplierMap",
            "http://localhost:6317/APhA/Services/Coverage",
            "http://localhost:6317/APhA/Services/Topology",
            "http://localhost:6317/APhA/Services/TopologyDate",
            "http://localhost:6317/APhA/Services/NextIntersection",
            "http://localhost:6317/APhA/Services/IntersectionStatus",
            "http://localhost:6250/APhA/Services/ReadProtPermQuarantine",
            "http://localhost:6250/APhA/Services/ReadProtPermOverride",
            "http://localhost:5942/APhA/Services/GetRegionSCDBDataRequest",
            "http://localhost:5942/APhA/Services/GetStatusDBDataRequest",
            "http://localhost:5942/APhA/Services/GetPredictionsDBDataRequest",
            "http://localhost:5942/APhA/Services/GetControllerInputDataRequest",
            "http://localhost:5942/APhA/Services/GetLogicDBDataRequest",
            "http://localhost:5942/APhA/Services/GetQuarantineDataRequest",
            "http://localhost:5942/APhA/Services/GetCurrentVersionRequest",
            "http://localhost:5942/APhA/Services/GetConfidenceDBDataRequest",
            "http://localhost:5942/APhA/Services/GetTimingPlanDBDataRequest",
            "http://localhost:5942/APhA/Services/GetRelevantPhasesDataRequest",
            "http://localhost:6240/APhA/Services/LatestStatus",
            "http://localhost:6240/APhA/Services/Predictions",
            "http://localhost:6240/APhA/Services/LatestTimingPlan",
            "http://localhost:6240/APhA/Services/LatestTimingPlanInfo",
            "http://localhost:6260/APhA/Services/LatestStatus",
            "http://localhost:6260/APhA/Services/LatestTimingPlan",
            "http://localhost:6260/APhA/Services/LatestTimingPlanInfo",
            "http://localhost:6260/APhA/Services/RecentSwitchEvents",
            "http://localhost:6260/APhA/Services/StatusHistory",
            "http://localhost:6416/APhA/Services/LatestStatus",
            "http://localhost:5831/APhA/Services/Predictions",
            "http://localhost:5831/APhA/Services/LatencyCorrection",
            "http://localhost:5831/APhA/Services/ControllerStatus",
            "http://localhost:5601/APhA/Services/GetAlerts",
            "http://localhost:5601/APhA/Services/GetUnsentAlerts",
            "http://localhost:5602/APhA/Services/GetAlerts",
            "http://localhost:6711/APhA/Services/UpdateCoverage",
            "http://localhost:6711/APhA/Services/CreateHosts",
            "http://localhost:6711/APhA/Services/UpdateHosts",
            "http://localhost:6711/APhA/Services/DeleteHosts",
            "http://localhost:6711/APhA/Services/CreateServerCoverage",
            "http://localhost:6711/APhA/Services/CreateServerConnections",
            "http://localhost:6711/APhA/Services/UpdateServerConnections",
            "http://localhost:6711/APhA/Services/DeleteServerConnections",
            "http://localhost:6711/APhA/Services/GetIntersectionMap",
            "http://localhost:5601/APhA/Services/RaiseAlerts",
            "http://localhost:5601/APhA/Services/UpdateSent",
            "http://localhost:5602/APhA/Services/RelayAlerts",
            "http://localhost:6317/APhA/Services/IntersectionTopology",
            "http://localhost:6317/APhA/Services/CreateIntersections",
            "http://localhost:6317/APhA/Services/UpdateIntersections",
            "http://localhost:6317/APhA/Services/DeleteIntersections",
            "http://localhost:6317/APhA/Services/CreateRegions",
            "http://localhost:6317/APhA/Services/UpdateRegions",
            "http://localhost:6317/APhA/Services/DeleteRegions",
            "http://localhost:6317/APhA/Services/UpdateIntersectionTopology",
            "http://localhost:6317/APhA/Services/DeleteIntersectionTopology",
            "http://localhost:6317/APhA/Services/ReadIntersections",
            "http://localhost:6317/APhA/Services/PostTopologyJSON",
            "http://localhost:6317/APhA/Services/PostD4",
            "http://localhost:6317/APhA/Services/UpdateIntersectionType",
            "http://localhost:6250/APhA/Services/TopologyCorrection",
            "http://localhost:6250/APhA/Services/CreateProtPermQuarantine",
            "http://localhost:6250/APhA/Services/UpdateProtPermQuarantine",
            "http://localhost:6250/APhA/Services/DeleteProtPermQuarantine",
            "http://localhost:6250/APhA/Services/CreateProtPermOverride",
            "http://localhost:6250/APhA/Services/UpdateProtPermOverride",
            "http://localhost:6250/APhA/Services/DeleteProtPermOverride",
            "http://localhost:6240/APhA/Services/FixedTimeStatusImporter",
            "http://localhost:6240/APhA/Services/FixedTimePlanImporter",
            "http://localhost:6260/APhA/Services/StatusImporter",
            "http://localhost:6260/APhA/Services/TimingPlanImporter",
            "http://localhost:6416/APhA/Services/GevasStatusImporter",
            "http://localhost:5831/APhA/Services/UpdateIntersectionType",
            "http://localhost:5831/APhA/Services/SubmitPredictions",
            "http://localhost:6777/APhA/Services/ReadConfidence"});
      this.ServiceDropDown.Location = new System.Drawing.Point(81, 1);
      this.ServiceDropDown.Name = "ServiceDropDown";
      this.ServiceDropDown.Size = new System.Drawing.Size(636, 21);
      this.ServiceDropDown.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(12, 32);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(43, 16);
      this.label2.TabIndex = 2;
      this.label2.Text = "User:";
      // 
      // myInputUser
      // 
      this.myInputUser.Location = new System.Drawing.Point(81, 32);
      this.myInputUser.Name = "myInputUser";
      this.myInputUser.Size = new System.Drawing.Size(636, 20);
      this.myInputUser.TabIndex = 3;
      // 
      // label3
      // 
      this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(78, 59);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(584, 80);
      this.label3.TabIndex = 4;
      this.label3.Text = resources.GetString("label3.Text");
      this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // GetInputsButton
      // 
      this.GetInputsButton.Location = new System.Drawing.Point(321, 165);
      this.GetInputsButton.Name = "GetInputsButton";
      this.GetInputsButton.Size = new System.Drawing.Size(75, 23);
      this.GetInputsButton.TabIndex = 5;
      this.GetInputsButton.Text = "Get Inputs";
      this.GetInputsButton.UseVisualStyleBackColor = true;
      this.GetInputsButton.Click += new System.EventHandler(this.GetInputsButton_Click);
      // 
      // CloseButton
      // 
      this.CloseButton.Location = new System.Drawing.Point(321, 194);
      this.CloseButton.Name = "CloseButton";
      this.CloseButton.Size = new System.Drawing.Size(75, 23);
      this.CloseButton.TabIndex = 6;
      this.CloseButton.Text = "Close";
      this.CloseButton.UseVisualStyleBackColor = true;
      this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
      // 
      // ClearButton
      // 
      this.ClearButton.Location = new System.Drawing.Point(321, 226);
      this.ClearButton.Name = "ClearButton";
      this.ClearButton.Size = new System.Drawing.Size(75, 23);
      this.ClearButton.TabIndex = 7;
      this.ClearButton.Text = "Clear";
      this.ClearButton.UseVisualStyleBackColor = true;
      this.ClearButton.Visible = false;
      this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
      // 
      // RunRequest
      // 
      this.RunRequest.Location = new System.Drawing.Point(306, 255);
      this.RunRequest.Name = "RunRequest";
      this.RunRequest.Size = new System.Drawing.Size(101, 23);
      this.RunRequest.TabIndex = 8;
      this.RunRequest.Text = "Run Request";
      this.RunRequest.UseVisualStyleBackColor = true;
      this.RunRequest.Visible = false;
      this.RunRequest.Click += new System.EventHandler(this.RunRequest_Click);
      // 
      // SaveRun
      // 
      this.SaveRun.Location = new System.Drawing.Point(413, 255);
      this.SaveRun.Name = "SaveRun";
      this.SaveRun.Size = new System.Drawing.Size(75, 23);
      this.SaveRun.TabIndex = 9;
      this.SaveRun.Text = "Save Run";
      this.SaveRun.UseVisualStyleBackColor = true;
      this.SaveRun.Visible = false;
      this.SaveRun.Click += new System.EventHandler(this.SaveRun_Click);
      // 
      // ChooseFileButton
      // 
      this.ChooseFileButton.Location = new System.Drawing.Point(225, 255);
      this.ChooseFileButton.Name = "ChooseFileButton";
      this.ChooseFileButton.Size = new System.Drawing.Size(75, 23);
      this.ChooseFileButton.TabIndex = 10;
      this.ChooseFileButton.Text = "Choose File";
      this.ChooseFileButton.UseVisualStyleBackColor = true;
      this.ChooseFileButton.Visible = false;
      this.ChooseFileButton.Click += new System.EventHandler(this.ChooseFileButton_Click);
      // 
      // tbFilePath
      // 
      this.tbFilePath.Location = new System.Drawing.Point(225, 286);
      this.tbFilePath.Name = "tbFilePath";
      this.tbFilePath.Size = new System.Drawing.Size(263, 20);
      this.tbFilePath.TabIndex = 11;
      this.tbFilePath.Visible = false;
      // 
      // LoadButton
      // 
      this.LoadButton.Location = new System.Drawing.Point(494, 286);
      this.LoadButton.Name = "LoadButton";
      this.LoadButton.Size = new System.Drawing.Size(75, 23);
      this.LoadButton.TabIndex = 12;
      this.LoadButton.Text = "Load";
      this.LoadButton.UseVisualStyleBackColor = true;
      this.LoadButton.Visible = false;
      this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
      // 
      // CustomURLBox
      // 
      this.CustomURLBox.Location = new System.Drawing.Point(104, 142);
      this.CustomURLBox.Name = "CustomURLBox";
      this.CustomURLBox.Size = new System.Drawing.Size(498, 20);
      this.CustomURLBox.TabIndex = 13;
      this.CustomURLBox.Visible = false;
      // 
      // CustomURLLabel
      // 
      this.CustomURLLabel.AutoSize = true;
      this.CustomURLLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.CustomURLLabel.Location = new System.Drawing.Point(12, 143);
      this.CustomURLLabel.Name = "CustomURLLabel";
      this.CustomURLLabel.Size = new System.Drawing.Size(92, 16);
      this.CustomURLLabel.TabIndex = 14;
      this.CustomURLLabel.Text = "Custom URL:";
      this.CustomURLLabel.Visible = false;
      // 
      // copyServiceButton
      // 
      this.copyServiceButton.Location = new System.Drawing.Point(608, 140);
      this.copyServiceButton.Name = "copyServiceButton";
      this.copyServiceButton.Size = new System.Drawing.Size(109, 23);
      this.copyServiceButton.TabIndex = 15;
      this.copyServiceButton.Text = "Copy Service Text";
      this.copyServiceButton.UseVisualStyleBackColor = true;
      this.copyServiceButton.Visible = false;
      this.copyServiceButton.Click += new System.EventHandler(this.copyServiceButton_Click);
      // 
      // TTSRestClientFrame
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
      this.ClientSize = new System.Drawing.Size(719, 348);
      this.Controls.Add(this.copyServiceButton);
      this.Controls.Add(this.CustomURLLabel);
      this.Controls.Add(this.CustomURLBox);
      this.Controls.Add(this.LoadButton);
      this.Controls.Add(this.tbFilePath);
      this.Controls.Add(this.ChooseFileButton);
      this.Controls.Add(this.SaveRun);
      this.Controls.Add(this.RunRequest);
      this.Controls.Add(this.ClearButton);
      this.Controls.Add(this.CloseButton);
      this.Controls.Add(this.GetInputsButton);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.myInputUser);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.ServiceDropDown);
      this.Controls.Add(this.Servicelabel);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "TTSRestClientFrame";
      this.Text = "TTS Rest Client";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label Servicelabel;
    private System.Windows.Forms.ComboBox ServiceDropDown;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox myInputUser;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button GetInputsButton;
    private System.Windows.Forms.Button CloseButton;
    private System.Windows.Forms.Button ClearButton;
    private System.Windows.Forms.Button RunRequest;
    private System.Windows.Forms.Button SaveRun;
    private System.Windows.Forms.Button ChooseFileButton;
    private System.Windows.Forms.TextBox tbFilePath;
    private System.Windows.Forms.Button LoadButton;
    private System.Windows.Forms.TextBox CustomURLBox;
    private System.Windows.Forms.Label CustomURLLabel;
    private System.Windows.Forms.Button copyServiceButton;
  }
}