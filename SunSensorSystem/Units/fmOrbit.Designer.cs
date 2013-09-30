namespace SunSensorSystem
{
  partial class fmOrbit
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
      this.pnBtns = new System.Windows.Forms.Panel();
      this.btOK = new System.Windows.Forms.Button();
      this.btClose = new System.Windows.Forms.Button();
      this.ColorDlg = new System.Windows.Forms.ColorDialog();
      this.TabControl = new System.Windows.Forms.TabControl();
      this.tbpCommon = new System.Windows.Forms.TabPage();
      this.lblForeColor = new System.Windows.Forms.Label();
      this.btColorDlg = new System.Windows.Forms.Button();
      this.pnOrbitColor = new System.Windows.Forms.Panel();
      this.gbOrbitParams = new System.Windows.Forms.GroupBox();
      this.tbxLongitudeOfAscendingNode = new System.Windows.Forms.TextBox();
      this.tbxArgumentOfPeriapsis = new System.Windows.Forms.TextBox();
      this.tbxlInclination = new System.Windows.Forms.TextBox();
      this.tbxEccentricity = new System.Windows.Forms.TextBox();
      this.tbxSemimajorAxis = new System.Windows.Forms.TextBox();
      this.lblLongitudeOfAscendingNode = new System.Windows.Forms.Label();
      this.lblArgumentOfPeriapsis = new System.Windows.Forms.Label();
      this.lblInclination = new System.Windows.Forms.Label();
      this.lblEccentricity = new System.Windows.Forms.Label();
      this.lblSemimajorAxis = new System.Windows.Forms.Label();
      this.gbGraphElements = new System.Windows.Forms.GroupBox();
      this.cbOrbitVisible = new System.Windows.Forms.CheckBox();
      this.cbShowBoundsContour = new System.Windows.Forms.CheckBox();
      this.cbShowGrid = new System.Windows.Forms.CheckBox();
      this.cbShowBaseOrbitAxes = new System.Windows.Forms.CheckBox();
      this.cbShowAxes = new System.Windows.Forms.CheckBox();
      this.cbShowBaseOrbit = new System.Windows.Forms.CheckBox();
      this.tpb = new System.Windows.Forms.TabPage();
      this.pnBtns.SuspendLayout();
      this.TabControl.SuspendLayout();
      this.tbpCommon.SuspendLayout();
      this.gbOrbitParams.SuspendLayout();
      this.gbGraphElements.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnBtns
      // 
      this.pnBtns.Controls.Add(this.btOK);
      this.pnBtns.Controls.Add(this.btClose);
      this.pnBtns.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnBtns.Location = new System.Drawing.Point(0, 276);
      this.pnBtns.Name = "pnBtns";
      this.pnBtns.Size = new System.Drawing.Size(610, 40);
      this.pnBtns.TabIndex = 7;
      // 
      // btOK
      // 
      this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btOK.Location = new System.Drawing.Point(440, 8);
      this.btOK.Name = "btOK";
      this.btOK.Size = new System.Drawing.Size(75, 23);
      this.btOK.TabIndex = 5;
      this.btOK.Text = "&ОК";
      this.btOK.UseVisualStyleBackColor = true;
      this.btOK.Click += new System.EventHandler(this.btOK_Click);
      // 
      // btClose
      // 
      this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btClose.Location = new System.Drawing.Point(520, 8);
      this.btClose.Name = "btClose";
      this.btClose.Size = new System.Drawing.Size(75, 23);
      this.btClose.TabIndex = 1;
      this.btClose.Text = "О&тмена";
      this.btClose.UseVisualStyleBackColor = true;
      // 
      // ColorDlg
      // 
      this.ColorDlg.AnyColor = true;
      this.ColorDlg.FullOpen = true;
      // 
      // TabControl
      // 
      this.TabControl.Controls.Add(this.tbpCommon);
      this.TabControl.Controls.Add(this.tpb);
      this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TabControl.Location = new System.Drawing.Point(0, 0);
      this.TabControl.Name = "TabControl";
      this.TabControl.SelectedIndex = 0;
      this.TabControl.Size = new System.Drawing.Size(610, 276);
      this.TabControl.TabIndex = 8;
      // 
      // tbpCommon
      // 
      this.tbpCommon.BackColor = System.Drawing.Color.Transparent;
      this.tbpCommon.Controls.Add(this.lblForeColor);
      this.tbpCommon.Controls.Add(this.btColorDlg);
      this.tbpCommon.Controls.Add(this.pnOrbitColor);
      this.tbpCommon.Controls.Add(this.gbOrbitParams);
      this.tbpCommon.Controls.Add(this.gbGraphElements);
      this.tbpCommon.Location = new System.Drawing.Point(4, 22);
      this.tbpCommon.Name = "tbpCommon";
      this.tbpCommon.Padding = new System.Windows.Forms.Padding(8);
      this.tbpCommon.Size = new System.Drawing.Size(602, 250);
      this.tbpCommon.TabIndex = 0;
      this.tbpCommon.Text = "Общие";
      // 
      // lblForeColor
      // 
      this.lblForeColor.AutoSize = true;
      this.lblForeColor.Location = new System.Drawing.Point(16, 212);
      this.lblForeColor.Name = "lblForeColor";
      this.lblForeColor.Size = new System.Drawing.Size(32, 13);
      this.lblForeColor.TabIndex = 17;
      this.lblForeColor.Text = "Цвет";
      // 
      // btColorDlg
      // 
      this.btColorDlg.Location = new System.Drawing.Point(168, 208);
      this.btColorDlg.Name = "btColorDlg";
      this.btColorDlg.Size = new System.Drawing.Size(24, 24);
      this.btColorDlg.TabIndex = 15;
      this.btColorDlg.Text = "...";
      this.btColorDlg.UseVisualStyleBackColor = true;
      this.btColorDlg.Click += new System.EventHandler(this.btColorDlg_Click);
      // 
      // pnOrbitColor
      // 
      this.pnOrbitColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnOrbitColor.Location = new System.Drawing.Point(48, 208);
      this.pnOrbitColor.Name = "pnOrbitColor";
      this.pnOrbitColor.Size = new System.Drawing.Size(120, 23);
      this.pnOrbitColor.TabIndex = 16;
      // 
      // gbOrbitParams
      // 
      this.gbOrbitParams.Controls.Add(this.tbxLongitudeOfAscendingNode);
      this.gbOrbitParams.Controls.Add(this.tbxArgumentOfPeriapsis);
      this.gbOrbitParams.Controls.Add(this.tbxlInclination);
      this.gbOrbitParams.Controls.Add(this.tbxEccentricity);
      this.gbOrbitParams.Controls.Add(this.tbxSemimajorAxis);
      this.gbOrbitParams.Controls.Add(this.lblLongitudeOfAscendingNode);
      this.gbOrbitParams.Controls.Add(this.lblArgumentOfPeriapsis);
      this.gbOrbitParams.Controls.Add(this.lblInclination);
      this.gbOrbitParams.Controls.Add(this.lblEccentricity);
      this.gbOrbitParams.Controls.Add(this.lblSemimajorAxis);
      this.gbOrbitParams.Location = new System.Drawing.Point(16, 8);
      this.gbOrbitParams.Name = "gbOrbitParams";
      this.gbOrbitParams.Size = new System.Drawing.Size(320, 184);
      this.gbOrbitParams.TabIndex = 14;
      this.gbOrbitParams.TabStop = false;
      this.gbOrbitParams.Text = "Параметры орбиты движения";
      // 
      // tbxLongitudeOfAscendingNode
      // 
      this.tbxLongitudeOfAscendingNode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxLongitudeOfAscendingNode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxLongitudeOfAscendingNode.Location = new System.Drawing.Point(232, 152);
      this.tbxLongitudeOfAscendingNode.Name = "tbxLongitudeOfAscendingNode";
      this.tbxLongitudeOfAscendingNode.Size = new System.Drawing.Size(72, 20);
      this.tbxLongitudeOfAscendingNode.TabIndex = 11;
      this.tbxLongitudeOfAscendingNode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxLongitudeOfAscendingNode_KeyPress);
      // 
      // tbxArgumentOfPeriapsis
      // 
      this.tbxArgumentOfPeriapsis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxArgumentOfPeriapsis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxArgumentOfPeriapsis.Location = new System.Drawing.Point(232, 120);
      this.tbxArgumentOfPeriapsis.Name = "tbxArgumentOfPeriapsis";
      this.tbxArgumentOfPeriapsis.Size = new System.Drawing.Size(72, 20);
      this.tbxArgumentOfPeriapsis.TabIndex = 10;
      this.tbxArgumentOfPeriapsis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxArgumentOfPeriapsis_KeyPress);
      // 
      // tbxlInclination
      // 
      this.tbxlInclination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxlInclination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxlInclination.Location = new System.Drawing.Point(232, 88);
      this.tbxlInclination.Name = "tbxlInclination";
      this.tbxlInclination.Size = new System.Drawing.Size(72, 20);
      this.tbxlInclination.TabIndex = 7;
      this.tbxlInclination.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxlInclination_KeyPress);
      // 
      // tbxEccentricity
      // 
      this.tbxEccentricity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxEccentricity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxEccentricity.Location = new System.Drawing.Point(232, 56);
      this.tbxEccentricity.Name = "tbxEccentricity";
      this.tbxEccentricity.Size = new System.Drawing.Size(72, 20);
      this.tbxEccentricity.TabIndex = 6;
      this.tbxEccentricity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxEccentricity_KeyPress);
      // 
      // tbxSemimajorAxis
      // 
      this.tbxSemimajorAxis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxSemimajorAxis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxSemimajorAxis.Location = new System.Drawing.Point(232, 24);
      this.tbxSemimajorAxis.Name = "tbxSemimajorAxis";
      this.tbxSemimajorAxis.Size = new System.Drawing.Size(72, 20);
      this.tbxSemimajorAxis.TabIndex = 5;
      this.tbxSemimajorAxis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxSemimajorAxis_KeyPress);
      // 
      // lblLongitudeOfAscendingNode
      // 
      this.lblLongitudeOfAscendingNode.AutoSize = true;
      this.lblLongitudeOfAscendingNode.Location = new System.Drawing.Point(16, 152);
      this.lblLongitudeOfAscendingNode.Name = "lblLongitudeOfAscendingNode";
      this.lblLongitudeOfAscendingNode.Size = new System.Drawing.Size(178, 13);
      this.lblLongitudeOfAscendingNode.TabIndex = 4;
      this.lblLongitudeOfAscendingNode.Text = "Долгота восходящего узла, град ";
      // 
      // lblArgumentOfPeriapsis
      // 
      this.lblArgumentOfPeriapsis.AutoSize = true;
      this.lblArgumentOfPeriapsis.Location = new System.Drawing.Point(16, 120);
      this.lblArgumentOfPeriapsis.Name = "lblArgumentOfPeriapsis";
      this.lblArgumentOfPeriapsis.Size = new System.Drawing.Size(152, 13);
      this.lblArgumentOfPeriapsis.TabIndex = 3;
      this.lblArgumentOfPeriapsis.Text = "Аргумент перицентра,  град ";
      // 
      // lblInclination
      // 
      this.lblInclination.AutoSize = true;
      this.lblInclination.Location = new System.Drawing.Point(16, 88);
      this.lblInclination.Name = "lblInclination";
      this.lblInclination.Size = new System.Drawing.Size(98, 13);
      this.lblInclination.TabIndex = 2;
      this.lblInclination.Text = "Наклонение, град";
      // 
      // lblEccentricity
      // 
      this.lblEccentricity.AutoSize = true;
      this.lblEccentricity.Location = new System.Drawing.Point(16, 56);
      this.lblEccentricity.Name = "lblEccentricity";
      this.lblEccentricity.Size = new System.Drawing.Size(89, 13);
      this.lblEccentricity.TabIndex = 1;
      this.lblEccentricity.Text = "Эксцентриситет";
      // 
      // lblSemimajorAxis
      // 
      this.lblSemimajorAxis.AutoSize = true;
      this.lblSemimajorAxis.Location = new System.Drawing.Point(16, 24);
      this.lblSemimajorAxis.Name = "lblSemimajorAxis";
      this.lblSemimajorAxis.Size = new System.Drawing.Size(116, 13);
      this.lblSemimajorAxis.TabIndex = 0;
      this.lblSemimajorAxis.Text = "Большая полуось, км";
      // 
      // gbGraphElements
      // 
      this.gbGraphElements.Controls.Add(this.cbOrbitVisible);
      this.gbGraphElements.Controls.Add(this.cbShowBoundsContour);
      this.gbGraphElements.Controls.Add(this.cbShowGrid);
      this.gbGraphElements.Controls.Add(this.cbShowBaseOrbitAxes);
      this.gbGraphElements.Controls.Add(this.cbShowAxes);
      this.gbGraphElements.Controls.Add(this.cbShowBaseOrbit);
      this.gbGraphElements.Location = new System.Drawing.Point(352, 8);
      this.gbGraphElements.Name = "gbGraphElements";
      this.gbGraphElements.Size = new System.Drawing.Size(232, 184);
      this.gbGraphElements.TabIndex = 13;
      this.gbGraphElements.TabStop = false;
      this.gbGraphElements.Text = "Отображение";
      // 
      // cbOrbitVisible
      // 
      this.cbOrbitVisible.AutoSize = true;
      this.cbOrbitVisible.Location = new System.Drawing.Point(16, 24);
      this.cbOrbitVisible.Name = "cbOrbitVisible";
      this.cbOrbitVisible.Size = new System.Drawing.Size(125, 17);
      this.cbOrbitVisible.TabIndex = 7;
      this.cbOrbitVisible.Text = "Отображать о&рбиту";
      this.cbOrbitVisible.UseVisualStyleBackColor = true;
      this.cbOrbitVisible.CheckedChanged += new System.EventHandler(this.cbOrbitVisible_CheckedChanged);
      // 
      // cbShowBoundsContour
      // 
      this.cbShowBoundsContour.AutoSize = true;
      this.cbShowBoundsContour.Location = new System.Drawing.Point(16, 152);
      this.cbShowBoundsContour.Name = "cbShowBoundsContour";
      this.cbShowBoundsContour.Size = new System.Drawing.Size(125, 17);
      this.cbShowBoundsContour.TabIndex = 6;
      this.cbShowBoundsContour.Text = "Отображать &контур";
      this.cbShowBoundsContour.UseVisualStyleBackColor = true;
      this.cbShowBoundsContour.CheckedChanged += new System.EventHandler(this.cbShowBoundsContour_CheckedChanged);
      // 
      // cbShowGrid
      // 
      this.cbShowGrid.AutoSize = true;
      this.cbShowGrid.Location = new System.Drawing.Point(16, 128);
      this.cbShowGrid.Name = "cbShowGrid";
      this.cbShowGrid.Size = new System.Drawing.Size(144, 17);
      this.cbShowGrid.TabIndex = 5;
      this.cbShowGrid.Text = "Отображать &плоскость";
      this.cbShowGrid.UseVisualStyleBackColor = true;
      this.cbShowGrid.CheckedChanged += new System.EventHandler(this.cbShowGrid_CheckedChanged);
      // 
      // cbShowBaseOrbitAxes
      // 
      this.cbShowBaseOrbitAxes.AutoSize = true;
      this.cbShowBaseOrbitAxes.Location = new System.Drawing.Point(16, 104);
      this.cbShowBaseOrbitAxes.Name = "cbShowBaseOrbitAxes";
      this.cbShowBaseOrbitAxes.Size = new System.Drawing.Size(194, 17);
      this.cbShowBaseOrbitAxes.TabIndex = 4;
      this.cbShowBaseOrbitAxes.Text = "Отобр&ажать оси базовой орбиты";
      this.cbShowBaseOrbitAxes.UseVisualStyleBackColor = true;
      this.cbShowBaseOrbitAxes.CheckedChanged += new System.EventHandler(this.cbShowBaseOrbitAxes_CheckedChanged);
      // 
      // cbShowAxes
      // 
      this.cbShowAxes.AutoSize = true;
      this.cbShowAxes.Location = new System.Drawing.Point(16, 80);
      this.cbShowAxes.Name = "cbShowAxes";
      this.cbShowAxes.Size = new System.Drawing.Size(195, 17);
      this.cbShowAxes.TabIndex = 3;
      this.cbShowAxes.Text = "Отображать о&си текущей орбиты";
      this.cbShowAxes.UseVisualStyleBackColor = true;
      this.cbShowAxes.CheckedChanged += new System.EventHandler(this.cbShowAxes_CheckedChanged);
      // 
      // cbShowBaseOrbit
      // 
      this.cbShowBaseOrbit.AutoSize = true;
      this.cbShowBaseOrbit.Location = new System.Drawing.Point(16, 56);
      this.cbShowBaseOrbit.Name = "cbShowBaseOrbit";
      this.cbShowBaseOrbit.Size = new System.Drawing.Size(171, 17);
      this.cbShowBaseOrbit.TabIndex = 2;
      this.cbShowBaseOrbit.Text = "Отображать &базовую орбиту";
      this.cbShowBaseOrbit.UseVisualStyleBackColor = true;
      this.cbShowBaseOrbit.CheckedChanged += new System.EventHandler(this.cbShowBaseOrbit_CheckedChanged);
      // 
      // tpb
      // 
      this.tpb.BackColor = System.Drawing.Color.Transparent;
      this.tpb.Location = new System.Drawing.Point(4, 22);
      this.tpb.Margin = new System.Windows.Forms.Padding(8);
      this.tpb.Name = "tpb";
      this.tpb.Padding = new System.Windows.Forms.Padding(3);
      this.tpb.Size = new System.Drawing.Size(602, 250);
      this.tpb.TabIndex = 1;
      this.tpb.Text = "Дополнительно";
      // 
      // fmOrbit
      // 
      this.AcceptButton = this.btOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btClose;
      this.ClientSize = new System.Drawing.Size(610, 316);
      this.Controls.Add(this.TabControl);
      this.Controls.Add(this.pnBtns);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.HelpButton = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(100, 100);
      this.Name = "fmOrbit";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Орбита движения";
      this.Load += new System.EventHandler(this.fmOrbit_Load);
      this.pnBtns.ResumeLayout(false);
      this.TabControl.ResumeLayout(false);
      this.tbpCommon.ResumeLayout(false);
      this.tbpCommon.PerformLayout();
      this.gbOrbitParams.ResumeLayout(false);
      this.gbOrbitParams.PerformLayout();
      this.gbGraphElements.ResumeLayout(false);
      this.gbGraphElements.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnBtns;
    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.ColorDialog ColorDlg;
    private System.Windows.Forms.TabControl TabControl;
    private System.Windows.Forms.TabPage tbpCommon;
    private System.Windows.Forms.TabPage tpb;
    private System.Windows.Forms.Panel pnOrbitColor;
    private System.Windows.Forms.Button btColorDlg;
    private System.Windows.Forms.GroupBox gbOrbitParams;
    private System.Windows.Forms.TextBox tbxLongitudeOfAscendingNode;
    private System.Windows.Forms.TextBox tbxArgumentOfPeriapsis;
    private System.Windows.Forms.TextBox tbxlInclination;
    private System.Windows.Forms.TextBox tbxEccentricity;
    private System.Windows.Forms.TextBox tbxSemimajorAxis;
    private System.Windows.Forms.Label lblLongitudeOfAscendingNode;
    private System.Windows.Forms.Label lblArgumentOfPeriapsis;
    private System.Windows.Forms.Label lblInclination;
    private System.Windows.Forms.Label lblEccentricity;
    private System.Windows.Forms.Label lblSemimajorAxis;
    private System.Windows.Forms.GroupBox gbGraphElements;
    private System.Windows.Forms.CheckBox cbOrbitVisible;
    private System.Windows.Forms.CheckBox cbShowBoundsContour;
    private System.Windows.Forms.CheckBox cbShowGrid;
    private System.Windows.Forms.CheckBox cbShowBaseOrbitAxes;
    private System.Windows.Forms.CheckBox cbShowAxes;
    private System.Windows.Forms.CheckBox cbShowBaseOrbit;
    private System.Windows.Forms.Button btClose;
    private System.Windows.Forms.Label lblForeColor;
  }
}