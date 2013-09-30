namespace SunSensorSystem
{
  partial class fmParams
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
      if (disposing && (components != null))
      {
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
      this.btClose = new System.Windows.Forms.Button();
      this.btOK = new System.Windows.Forms.Button();
      this.pnBtns = new System.Windows.Forms.Panel();
      this.TabControl = new System.Windows.Forms.TabControl();
      this.tbpCommon = new System.Windows.Forms.TabPage();
      this.gbCamera = new System.Windows.Forms.GroupBox();
      this.tbxCameraRadius = new System.Windows.Forms.TextBox();
      this.tbxCameraZenith = new System.Windows.Forms.TextBox();
      this.tbxCameraAzimuth = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.lblForeColor = new System.Windows.Forms.Label();
      this.pnForeColor = new System.Windows.Forms.Panel();
      this.gbScene = new System.Windows.Forms.GroupBox();
      this.cbShowSceneAxes = new System.Windows.Forms.CheckBox();
      this.cbShowSceneContour = new System.Windows.Forms.CheckBox();
      this.btColorDlg = new System.Windows.Forms.Button();
      this.tbpAdditionalOptions = new System.Windows.Forms.TabPage();
      this.ColorDlg = new System.Windows.Forms.ColorDialog();
      this.pnBtns.SuspendLayout();
      this.TabControl.SuspendLayout();
      this.tbpCommon.SuspendLayout();
      this.gbCamera.SuspendLayout();
      this.gbScene.SuspendLayout();
      this.SuspendLayout();
      // 
      // btClose
      // 
      this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btClose.Location = new System.Drawing.Point(176, 8);
      this.btClose.Name = "btClose";
      this.btClose.Size = new System.Drawing.Size(75, 23);
      this.btClose.TabIndex = 1;
      this.btClose.Text = "О&тмена";
      this.btClose.UseVisualStyleBackColor = true;
      // 
      // btOK
      // 
      this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btOK.Location = new System.Drawing.Point(96, 8);
      this.btOK.Name = "btOK";
      this.btOK.Size = new System.Drawing.Size(75, 23);
      this.btOK.TabIndex = 5;
      this.btOK.Text = "&ОК";
      this.btOK.UseVisualStyleBackColor = true;
      this.btOK.Click += new System.EventHandler(this.btOK_Click);
      // 
      // pnBtns
      // 
      this.pnBtns.Controls.Add(this.btOK);
      this.pnBtns.Controls.Add(this.btClose);
      this.pnBtns.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnBtns.Location = new System.Drawing.Point(0, 324);
      this.pnBtns.Name = "pnBtns";
      this.pnBtns.Size = new System.Drawing.Size(266, 40);
      this.pnBtns.TabIndex = 6;
      // 
      // TabControl
      // 
      this.TabControl.Controls.Add(this.tbpCommon);
      this.TabControl.Controls.Add(this.tbpAdditionalOptions);
      this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TabControl.Location = new System.Drawing.Point(0, 0);
      this.TabControl.Name = "TabControl";
      this.TabControl.SelectedIndex = 0;
      this.TabControl.Size = new System.Drawing.Size(266, 324);
      this.TabControl.TabIndex = 7;
      // 
      // tbpCommon
      // 
      this.tbpCommon.BackColor = System.Drawing.Color.Transparent;
      this.tbpCommon.Controls.Add(this.gbCamera);
      this.tbpCommon.Controls.Add(this.lblForeColor);
      this.tbpCommon.Controls.Add(this.pnForeColor);
      this.tbpCommon.Controls.Add(this.gbScene);
      this.tbpCommon.Controls.Add(this.btColorDlg);
      this.tbpCommon.ForeColor = System.Drawing.SystemColors.ControlText;
      this.tbpCommon.Location = new System.Drawing.Point(4, 22);
      this.tbpCommon.Name = "tbpCommon";
      this.tbpCommon.Padding = new System.Windows.Forms.Padding(3);
      this.tbpCommon.Size = new System.Drawing.Size(258, 298);
      this.tbpCommon.TabIndex = 0;
      this.tbpCommon.Text = "Общие";
      // 
      // gbCamera
      // 
      this.gbCamera.Controls.Add(this.tbxCameraRadius);
      this.gbCamera.Controls.Add(this.tbxCameraZenith);
      this.gbCamera.Controls.Add(this.tbxCameraAzimuth);
      this.gbCamera.Controls.Add(this.label3);
      this.gbCamera.Controls.Add(this.label2);
      this.gbCamera.Controls.Add(this.label1);
      this.gbCamera.Location = new System.Drawing.Point(16, 152);
      this.gbCamera.Name = "gbCamera";
      this.gbCamera.Size = new System.Drawing.Size(224, 128);
      this.gbCamera.TabIndex = 4;
      this.gbCamera.TabStop = false;
      this.gbCamera.Text = "Камера";
      // 
      // tbxCameraRadius
      // 
      this.tbxCameraRadius.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxCameraRadius.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxCameraRadius.Location = new System.Drawing.Point(104, 88);
      this.tbxCameraRadius.Name = "tbxCameraRadius";
      this.tbxCameraRadius.Size = new System.Drawing.Size(104, 20);
      this.tbxCameraRadius.TabIndex = 8;
      // 
      // tbxCameraZenith
      // 
      this.tbxCameraZenith.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxCameraZenith.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxCameraZenith.Location = new System.Drawing.Point(104, 56);
      this.tbxCameraZenith.Name = "tbxCameraZenith";
      this.tbxCameraZenith.Size = new System.Drawing.Size(104, 20);
      this.tbxCameraZenith.TabIndex = 7;
      // 
      // tbxCameraAzimuth
      // 
      this.tbxCameraAzimuth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxCameraAzimuth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxCameraAzimuth.Location = new System.Drawing.Point(104, 24);
      this.tbxCameraAzimuth.Name = "tbxCameraAzimuth";
      this.tbxCameraAzimuth.Size = new System.Drawing.Size(104, 20);
      this.tbxCameraAzimuth.TabIndex = 6;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(16, 92);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(63, 13);
      this.label3.TabIndex = 2;
      this.label3.Text = "Радиус, км";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(16, 60);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(66, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Зенит, град";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(16, 28);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(73, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Азимут, град";
      // 
      // lblForeColor
      // 
      this.lblForeColor.AutoSize = true;
      this.lblForeColor.Location = new System.Drawing.Point(16, 28);
      this.lblForeColor.Name = "lblForeColor";
      this.lblForeColor.Size = new System.Drawing.Size(61, 13);
      this.lblForeColor.TabIndex = 14;
      this.lblForeColor.Text = "Цвет фона";
      // 
      // pnForeColor
      // 
      this.pnForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnForeColor.Location = new System.Drawing.Point(80, 24);
      this.pnForeColor.Name = "pnForeColor";
      this.pnForeColor.Size = new System.Drawing.Size(136, 23);
      this.pnForeColor.TabIndex = 13;
      // 
      // gbScene
      // 
      this.gbScene.Controls.Add(this.cbShowSceneAxes);
      this.gbScene.Controls.Add(this.cbShowSceneContour);
      this.gbScene.Location = new System.Drawing.Point(16, 64);
      this.gbScene.Name = "gbScene";
      this.gbScene.Size = new System.Drawing.Size(224, 80);
      this.gbScene.TabIndex = 3;
      this.gbScene.TabStop = false;
      this.gbScene.Text = "Контур сцены";
      // 
      // cbShowSceneAxes
      // 
      this.cbShowSceneAxes.AutoSize = true;
      this.cbShowSceneAxes.Location = new System.Drawing.Point(16, 48);
      this.cbShowSceneAxes.Name = "cbShowSceneAxes";
      this.cbShowSceneAxes.Size = new System.Drawing.Size(185, 17);
      this.cbShowSceneAxes.TabIndex = 1;
      this.cbShowSceneAxes.Text = "Ото&бражать координатные оси";
      this.cbShowSceneAxes.UseVisualStyleBackColor = true;
      this.cbShowSceneAxes.CheckedChanged += new System.EventHandler(this.cbShowSceneAxes_CheckedChanged);
      // 
      // cbShowSceneContour
      // 
      this.cbShowSceneContour.AutoSize = true;
      this.cbShowSceneContour.Location = new System.Drawing.Point(16, 24);
      this.cbShowSceneContour.Name = "cbShowSceneContour";
      this.cbShowSceneContour.Size = new System.Drawing.Size(160, 17);
      this.cbShowSceneContour.TabIndex = 0;
      this.cbShowSceneContour.Text = "Отображать &контур сцены";
      this.cbShowSceneContour.UseVisualStyleBackColor = true;
      this.cbShowSceneContour.CheckedChanged += new System.EventHandler(this.cbShowSceneContour_CheckedChanged);
      // 
      // btColorDlg
      // 
      this.btColorDlg.Location = new System.Drawing.Point(216, 24);
      this.btColorDlg.Name = "btColorDlg";
      this.btColorDlg.Size = new System.Drawing.Size(24, 24);
      this.btColorDlg.TabIndex = 12;
      this.btColorDlg.Text = "...";
      this.btColorDlg.UseVisualStyleBackColor = true;
      this.btColorDlg.Click += new System.EventHandler(this.btColorDlg_Click);
      // 
      // tbpAdditionalOptions
      // 
      this.tbpAdditionalOptions.BackColor = System.Drawing.Color.Transparent;
      this.tbpAdditionalOptions.Location = new System.Drawing.Point(4, 22);
      this.tbpAdditionalOptions.Name = "tbpAdditionalOptions";
      this.tbpAdditionalOptions.Padding = new System.Windows.Forms.Padding(3);
      this.tbpAdditionalOptions.Size = new System.Drawing.Size(258, 298);
      this.tbpAdditionalOptions.TabIndex = 1;
      this.tbpAdditionalOptions.Text = "Дополнительно";
      // 
      // ColorDlg
      // 
      this.ColorDlg.AnyColor = true;
      this.ColorDlg.FullOpen = true;
      // 
      // fmParams
      // 
      this.AcceptButton = this.btOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btClose;
      this.ClientSize = new System.Drawing.Size(266, 364);
      this.Controls.Add(this.TabControl);
      this.Controls.Add(this.pnBtns);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.HelpButton = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(200, 200);
      this.Name = "fmParams";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Настройки";
      this.Load += new System.EventHandler(this.fmParams_Load);
      this.pnBtns.ResumeLayout(false);
      this.TabControl.ResumeLayout(false);
      this.tbpCommon.ResumeLayout(false);
      this.tbpCommon.PerformLayout();
      this.gbCamera.ResumeLayout(false);
      this.gbCamera.PerformLayout();
      this.gbScene.ResumeLayout(false);
      this.gbScene.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btClose;
    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.Panel pnBtns;
    private System.Windows.Forms.TabControl TabControl;
    private System.Windows.Forms.TabPage tbpCommon;
    private System.Windows.Forms.TabPage tbpAdditionalOptions;
    private System.Windows.Forms.CheckBox cbShowSceneContour;
    private System.Windows.Forms.GroupBox gbScene;
    private System.Windows.Forms.CheckBox cbShowSceneAxes;
    private System.Windows.Forms.ColorDialog ColorDlg;
    private System.Windows.Forms.Panel pnForeColor;
    private System.Windows.Forms.Button btColorDlg;
    private System.Windows.Forms.Label lblForeColor;
    private System.Windows.Forms.GroupBox gbCamera;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox tbxCameraAzimuth;
    private System.Windows.Forms.TextBox tbxCameraRadius;
    private System.Windows.Forms.TextBox tbxCameraZenith;
  }
}