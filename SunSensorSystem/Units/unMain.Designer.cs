namespace SunSensorSystem
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
          this.components = new System.ComponentModel.Container();
          this.glWindow = new Tao.Platform.Windows.SimpleOpenGlControl();
          this.PopUpMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
          this.pmiScene = new System.Windows.Forms.ToolStripMenuItem();
          this.pmiSceneShowContour = new System.Windows.Forms.ToolStripMenuItem();
          this.pmiSceneShowAxes = new System.Windows.Forms.ToolStripMenuItem();
          this.pmiObjectParams = new System.Windows.Forms.ToolStripMenuItem();
          this.Cadencer = new System.Windows.Forms.Timer(this.components);
          this.MainMenu = new System.Windows.Forms.MenuStrip();
          this.mmiFile = new System.Windows.Forms.ToolStripMenuItem();
          this.mmiFileExit = new System.Windows.Forms.ToolStripMenuItem();
          this.mmiEdit = new System.Windows.Forms.ToolStripMenuItem();
          this.mmiEditSelectAllObjects = new System.Windows.Forms.ToolStripMenuItem();
          this.mmiEditRemoveSelection = new System.Windows.Forms.ToolStripMenuItem();
          this.mmiView = new System.Windows.Forms.ToolStripMenuItem();
          this.mmiViewFullScreen = new System.Windows.Forms.ToolStripMenuItem();
          this.mmiGraphics = new System.Windows.Forms.ToolStripMenuItem();
          this.mmiGraphicsCenterCamera = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
          this.mmiGraphicsCameraToLeft = new System.Windows.Forms.ToolStripMenuItem();
          this.mmiGraphicsCameraToRight = new System.Windows.Forms.ToolStripMenuItem();
          this.mmiGraphicsCameraToUp = new System.Windows.Forms.ToolStripMenuItem();
          this.mmiGraphicsCameraToDown = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
          this.mmiGraphicsCameraZoomIn = new System.Windows.Forms.ToolStripMenuItem();
          this.mmiGraphicsCameraZoomOut = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
          this.mmiGraphicsParameters = new System.Windows.Forms.ToolStripMenuItem();
          this.mmiObjects = new System.Windows.Forms.ToolStripMenuItem();
          this.mmiObjectsParams = new System.Windows.Forms.ToolStripMenuItem();
          this.mmiHelp = new System.Windows.Forms.ToolStripMenuItem();
          this.mmiHelpReference = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
          this.mmiHelpAboutProgram = new System.Windows.Forms.ToolStripMenuItem();
          this.StatusBar = new System.Windows.Forms.StatusStrip();
          this.lblCameraAzimuthAngle = new System.Windows.Forms.ToolStripStatusLabel();
          this.lblCameraZenithAngle = new System.Windows.Forms.ToolStripStatusLabel();
          this.HintLabel = new System.Windows.Forms.ToolStripStatusLabel();
          this.lblCameraZoom = new System.Windows.Forms.ToolStripStatusLabel();
          this.lblHint = new System.Windows.Forms.ToolStripStatusLabel();
          this.lblHint1 = new System.Windows.Forms.ToolStripStatusLabel();
          this.Hint = new System.Windows.Forms.ToolTip(this.components);
          this.PopUpMenu.SuspendLayout();
          this.MainMenu.SuspendLayout();
          this.StatusBar.SuspendLayout();
          this.SuspendLayout();
          // 
          // glWindow
          // 
          this.glWindow.AccumBits = ((byte)(0));
          this.glWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.glWindow.AutoCheckErrors = false;
          this.glWindow.AutoFinish = false;
          this.glWindow.AutoMakeCurrent = true;
          this.glWindow.AutoSwapBuffers = true;
          this.glWindow.BackColor = System.Drawing.Color.Black;
          this.glWindow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          this.glWindow.ColorBits = ((byte)(32));
          this.glWindow.ContextMenuStrip = this.PopUpMenu;
          this.glWindow.DepthBits = ((byte)(16));
          this.glWindow.Location = new System.Drawing.Point(-3, -2);
          this.glWindow.Name = "glWindow";
          this.glWindow.Size = new System.Drawing.Size(600, 384);
          this.glWindow.StencilBits = ((byte)(0));
          this.glWindow.TabIndex = 0;
          this.glWindow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
          this.glWindow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
          this.glWindow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
          this.glWindow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
          // 
          // PopUpMenu
          // 
          this.PopUpMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pmiScene,
            this.pmiObjectParams});
          this.PopUpMenu.Name = "ContextMenu";
          this.PopUpMenu.Size = new System.Drawing.Size(126, 48);
          this.PopUpMenu.Opening += new System.ComponentModel.CancelEventHandler(this.PopUpMenu_Opening);
          // 
          // pmiScene
          // 
          this.pmiScene.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pmiSceneShowContour,
            this.pmiSceneShowAxes});
          this.pmiScene.Name = "pmiScene";
          this.pmiScene.Size = new System.Drawing.Size(125, 22);
          this.pmiScene.Text = "Сцена";
          this.pmiScene.DropDownOpening += new System.EventHandler(this.pmiScene_DropDownOpening);
          // 
          // pmiSceneShowContour
          // 
          this.pmiSceneShowContour.Checked = true;
          this.pmiSceneShowContour.CheckOnClick = true;
          this.pmiSceneShowContour.CheckState = System.Windows.Forms.CheckState.Checked;
          this.pmiSceneShowContour.Name = "pmiSceneShowContour";
          this.pmiSceneShowContour.Size = new System.Drawing.Size(183, 22);
          this.pmiSceneShowContour.Text = "Показывать контур ";
          this.pmiSceneShowContour.Click += new System.EventHandler(this.pmiSceneShowContour_Click);
          // 
          // pmiSceneShowAxes
          // 
          this.pmiSceneShowAxes.Checked = true;
          this.pmiSceneShowAxes.CheckOnClick = true;
          this.pmiSceneShowAxes.CheckState = System.Windows.Forms.CheckState.Checked;
          this.pmiSceneShowAxes.Name = "pmiSceneShowAxes";
          this.pmiSceneShowAxes.Size = new System.Drawing.Size(183, 22);
          this.pmiSceneShowAxes.Text = "Показывать оси ";
          this.pmiSceneShowAxes.Click += new System.EventHandler(this.pmiSceneShowAxes_Click);
          // 
          // pmiObjectParams
          // 
          this.pmiObjectParams.Name = "pmiObjectParams";
          this.pmiObjectParams.Size = new System.Drawing.Size(125, 22);
          this.pmiObjectParams.Text = "Свойства";
          this.pmiObjectParams.Click += new System.EventHandler(this.pmiObjectParams_Click);
          // 
          // Cadencer
          // 
          this.Cadencer.Interval = 30;
          this.Cadencer.Tick += new System.EventHandler(this.Cadencer_Tick);
          // 
          // MainMenu
          // 
          this.MainMenu.BackColor = System.Drawing.SystemColors.Control;
          this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmiFile,
            this.mmiEdit,
            this.mmiView,
            this.mmiGraphics,
            this.mmiObjects,
            this.mmiHelp});
          this.MainMenu.Location = new System.Drawing.Point(0, 0);
          this.MainMenu.Name = "MainMenu";
          this.MainMenu.Size = new System.Drawing.Size(594, 24);
          this.MainMenu.TabIndex = 1;
          this.MainMenu.Text = "menuStrip1";
          // 
          // mmiFile
          // 
          this.mmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmiFileExit});
          this.mmiFile.Name = "mmiFile";
          this.mmiFile.Size = new System.Drawing.Size(48, 20);
          this.mmiFile.Text = "&Файл";
          this.mmiFile.DropDownOpening += new System.EventHandler(this.mmiFile_DropDownOpening);
          // 
          // mmiFileExit
          // 
          this.mmiFileExit.Name = "mmiFileExit";
          this.mmiFileExit.ShortcutKeyDisplayString = "Alt+ F4";
          this.mmiFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
          this.mmiFileExit.Size = new System.Drawing.Size(153, 22);
          this.mmiFileExit.Text = "&Выход";
          this.mmiFileExit.Click += new System.EventHandler(this.mmiFileExit_Click);
          // 
          // mmiEdit
          // 
          this.mmiEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmiEditSelectAllObjects,
            this.mmiEditRemoveSelection});
          this.mmiEdit.Name = "mmiEdit";
          this.mmiEdit.Size = new System.Drawing.Size(59, 20);
          this.mmiEdit.Text = "&Правка";
          this.mmiEdit.DropDownOpening += new System.EventHandler(this.mmiEdit_DropDownOpening);
          // 
          // mmiEditSelectAllObjects
          // 
          this.mmiEditSelectAllObjects.Name = "mmiEditSelectAllObjects";
          this.mmiEditSelectAllObjects.ShortcutKeyDisplayString = "Ctrl+A";
          this.mmiEditSelectAllObjects.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
          this.mmiEditSelectAllObjects.Size = new System.Drawing.Size(240, 22);
          this.mmiEditSelectAllObjects.Text = "&Выделить все объекты";
          // 
          // mmiEditRemoveSelection
          // 
          this.mmiEditRemoveSelection.Name = "mmiEditRemoveSelection";
          this.mmiEditRemoveSelection.Size = new System.Drawing.Size(240, 22);
          this.mmiEditRemoveSelection.Text = "&Снять выделение";
          // 
          // mmiView
          // 
          this.mmiView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmiViewFullScreen});
          this.mmiView.Name = "mmiView";
          this.mmiView.Size = new System.Drawing.Size(39, 20);
          this.mmiView.Text = "&Вид";
          this.mmiView.DropDownOpening += new System.EventHandler(this.mmiView_DropDownOpening);
          // 
          // mmiViewFullScreen
          // 
          this.mmiViewFullScreen.Name = "mmiViewFullScreen";
          this.mmiViewFullScreen.ShortcutKeyDisplayString = "Alt+Enter";
          this.mmiViewFullScreen.Size = new System.Drawing.Size(264, 22);
          this.mmiViewFullScreen.Text = "&Полноэкранный режим";
          this.mmiViewFullScreen.Click += new System.EventHandler(this.mmiViewFullScreen_Click);
          // 
          // mmiGraphics
          // 
          this.mmiGraphics.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmiGraphicsCenterCamera,
            this.toolStripSeparator1,
            this.mmiGraphicsCameraToLeft,
            this.mmiGraphicsCameraToRight,
            this.mmiGraphicsCameraToUp,
            this.mmiGraphicsCameraToDown,
            this.toolStripSeparator2,
            this.mmiGraphicsCameraZoomIn,
            this.mmiGraphicsCameraZoomOut,
            this.toolStripSeparator3,
            this.mmiGraphicsParameters});
          this.mmiGraphics.Name = "mmiGraphics";
          this.mmiGraphics.Size = new System.Drawing.Size(66, 20);
          this.mmiGraphics.Text = "&Графика";
          this.mmiGraphics.DropDownOpening += new System.EventHandler(this.mmiGraphics_DropDownOpening);
          // 
          // mmiGraphicsCenterCamera
          // 
          this.mmiGraphicsCenterCamera.Name = "mmiGraphicsCenterCamera";
          this.mmiGraphicsCenterCamera.ShortcutKeyDisplayString = "Ctrl+C";
          this.mmiGraphicsCenterCamera.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
          this.mmiGraphicsCenterCamera.Size = new System.Drawing.Size(258, 22);
          this.mmiGraphicsCenterCamera.Text = "&Центрировать";
          this.mmiGraphicsCenterCamera.Click += new System.EventHandler(this.mmiGraphicsCenterCamera_Click);
          // 
          // toolStripSeparator1
          // 
          this.toolStripSeparator1.Name = "toolStripSeparator1";
          this.toolStripSeparator1.Size = new System.Drawing.Size(255, 6);
          // 
          // mmiGraphicsCameraToLeft
          // 
          this.mmiGraphicsCameraToLeft.Name = "mmiGraphicsCameraToLeft";
          this.mmiGraphicsCameraToLeft.ShortcutKeyDisplayString = "Ctrl+Left";
          this.mmiGraphicsCameraToLeft.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
          this.mmiGraphicsCameraToLeft.Size = new System.Drawing.Size(258, 22);
          this.mmiGraphicsCameraToLeft.Text = "Повернуть на&лево";
          this.mmiGraphicsCameraToLeft.Click += new System.EventHandler(this.mmiGraphicsCameraToLeft_Click);
          // 
          // mmiGraphicsCameraToRight
          // 
          this.mmiGraphicsCameraToRight.Name = "mmiGraphicsCameraToRight";
          this.mmiGraphicsCameraToRight.ShortcutKeyDisplayString = "Ctrl+Right";
          this.mmiGraphicsCameraToRight.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
          this.mmiGraphicsCameraToRight.Size = new System.Drawing.Size(258, 22);
          this.mmiGraphicsCameraToRight.Text = "Повернуть на&право";
          this.mmiGraphicsCameraToRight.Click += new System.EventHandler(this.mmiGraphicsCameraToRight_Click);
          // 
          // mmiGraphicsCameraToUp
          // 
          this.mmiGraphicsCameraToUp.Name = "mmiGraphicsCameraToUp";
          this.mmiGraphicsCameraToUp.ShortcutKeyDisplayString = "Ctrl+Up";
          this.mmiGraphicsCameraToUp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
          this.mmiGraphicsCameraToUp.Size = new System.Drawing.Size(258, 22);
          this.mmiGraphicsCameraToUp.Text = "Повернуть &вверх";
          this.mmiGraphicsCameraToUp.Click += new System.EventHandler(this.mmiGraphicsCameraToUp_Click);
          // 
          // mmiGraphicsCameraToDown
          // 
          this.mmiGraphicsCameraToDown.Name = "mmiGraphicsCameraToDown";
          this.mmiGraphicsCameraToDown.ShortcutKeyDisplayString = "Ctrl+Down";
          this.mmiGraphicsCameraToDown.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
          this.mmiGraphicsCameraToDown.Size = new System.Drawing.Size(258, 22);
          this.mmiGraphicsCameraToDown.Text = "Повернуть в&низ";
          this.mmiGraphicsCameraToDown.Click += new System.EventHandler(this.mmiGraphicsCameraToDown_Click);
          // 
          // toolStripSeparator2
          // 
          this.toolStripSeparator2.Name = "toolStripSeparator2";
          this.toolStripSeparator2.Size = new System.Drawing.Size(255, 6);
          // 
          // mmiGraphicsCameraZoomIn
          // 
          this.mmiGraphicsCameraZoomIn.Name = "mmiGraphicsCameraZoomIn";
          this.mmiGraphicsCameraZoomIn.ShortcutKeyDisplayString = "Ctrl+Plus";
          this.mmiGraphicsCameraZoomIn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
          this.mmiGraphicsCameraZoomIn.Size = new System.Drawing.Size(258, 22);
          this.mmiGraphicsCameraZoomIn.Text = "Увеличить масшта&б";
          this.mmiGraphicsCameraZoomIn.Click += new System.EventHandler(this.mmiGraphicsCameraZoomIn_Click);
          // 
          // mmiGraphicsCameraZoomOut
          // 
          this.mmiGraphicsCameraZoomOut.Name = "mmiGraphicsCameraZoomOut";
          this.mmiGraphicsCameraZoomOut.ShortcutKeyDisplayString = "Ctrl+Minus";
          this.mmiGraphicsCameraZoomOut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
          this.mmiGraphicsCameraZoomOut.Size = new System.Drawing.Size(258, 22);
          this.mmiGraphicsCameraZoomOut.Text = "У&меньшить масштаб";
          this.mmiGraphicsCameraZoomOut.Click += new System.EventHandler(this.mmiGraphicsCameraZoomOut_Click);
          // 
          // toolStripSeparator3
          // 
          this.toolStripSeparator3.Name = "toolStripSeparator3";
          this.toolStripSeparator3.Size = new System.Drawing.Size(255, 6);
          // 
          // mmiGraphicsParameters
          // 
          this.mmiGraphicsParameters.Name = "mmiGraphicsParameters";
          this.mmiGraphicsParameters.Size = new System.Drawing.Size(258, 22);
          this.mmiGraphicsParameters.Text = "&Свойства...";
          this.mmiGraphicsParameters.Click += new System.EventHandler(this.mmiGraphicsParameters_Click);
          // 
          // mmiObjects
          // 
          this.mmiObjects.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmiObjectsParams});
          this.mmiObjects.Name = "mmiObjects";
          this.mmiObjects.Size = new System.Drawing.Size(68, 20);
          this.mmiObjects.Text = "О&бъекты";
          this.mmiObjects.DropDownOpening += new System.EventHandler(this.mmiObjects_DropDownOpening);
          // 
          // mmiObjectsParams
          // 
          this.mmiObjectsParams.Name = "mmiObjectsParams";
          this.mmiObjectsParams.Size = new System.Drawing.Size(134, 22);
          this.mmiObjectsParams.Text = "&Свойства...";
          this.mmiObjectsParams.ToolTipText = "Настройка свойств графического объекта";
          this.mmiObjectsParams.Click += new System.EventHandler(this.mmiObjectsParams_Click);
          this.mmiObjectsParams.MouseLeave += new System.EventHandler(this.mmiObjectsParams_MouseLeave);
          this.mmiObjectsParams.MouseHover += new System.EventHandler(this.mmiObjectsParams_MouseHover);
          // 
          // mmiHelp
          // 
          this.mmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmiHelpReference,
            this.toolStripSeparator4,
            this.mmiHelpAboutProgram});
          this.mmiHelp.Name = "mmiHelp";
          this.mmiHelp.Size = new System.Drawing.Size(68, 20);
          this.mmiHelp.Text = "П&омощь";
          this.mmiHelp.DropDownOpening += new System.EventHandler(this.mmiHelp_DropDownOpening);
          // 
          // mmiHelpReference
          // 
          this.mmiHelpReference.Name = "mmiHelpReference";
          this.mmiHelpReference.ShortcutKeyDisplayString = "F1";
          this.mmiHelpReference.ShortcutKeys = System.Windows.Forms.Keys.F1;
          this.mmiHelpReference.Size = new System.Drawing.Size(158, 22);
          this.mmiHelpReference.Text = "&Справка...";
          // 
          // toolStripSeparator4
          // 
          this.toolStripSeparator4.Name = "toolStripSeparator4";
          this.toolStripSeparator4.Size = new System.Drawing.Size(155, 6);
          // 
          // mmiHelpAboutProgram
          // 
          this.mmiHelpAboutProgram.Name = "mmiHelpAboutProgram";
          this.mmiHelpAboutProgram.Size = new System.Drawing.Size(158, 22);
          this.mmiHelpAboutProgram.Text = "&О программе...";
          // 
          // StatusBar
          // 
          this.StatusBar.BackColor = System.Drawing.SystemColors.Control;
          this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCameraAzimuthAngle,
            this.lblCameraZenithAngle,
            this.HintLabel,
            this.lblCameraZoom,
            this.lblHint,
            this.lblHint1});
          this.StatusBar.Location = new System.Drawing.Point(0, 350);
          this.StatusBar.Name = "StatusBar";
          this.StatusBar.Size = new System.Drawing.Size(594, 22);
          this.StatusBar.TabIndex = 2;
          this.StatusBar.Text = "StatusBar";
          // 
          // lblCameraAzimuthAngle
          // 
          this.lblCameraAzimuthAngle.AutoSize = false;
          this.lblCameraAzimuthAngle.BackColor = System.Drawing.SystemColors.Control;
          this.lblCameraAzimuthAngle.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                      | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                      | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
          this.lblCameraAzimuthAngle.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
          this.lblCameraAzimuthAngle.Name = "lblCameraAzimuthAngle";
          this.lblCameraAzimuthAngle.Size = new System.Drawing.Size(120, 17);
          this.lblCameraAzimuthAngle.Text = "Азимут, град: ";
          this.lblCameraAzimuthAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // lblCameraZenithAngle
          // 
          this.lblCameraZenithAngle.AutoSize = false;
          this.lblCameraZenithAngle.BackColor = System.Drawing.SystemColors.Control;
          this.lblCameraZenithAngle.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                      | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                      | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
          this.lblCameraZenithAngle.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
          this.lblCameraZenithAngle.Name = "lblCameraZenithAngle";
          this.lblCameraZenithAngle.Size = new System.Drawing.Size(120, 17);
          this.lblCameraZenithAngle.Text = "Зенит, град:";
          this.lblCameraZenithAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // HintLabel
          // 
          this.HintLabel.BackColor = System.Drawing.SystemColors.Control;
          this.HintLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
          this.HintLabel.Name = "HintLabel";
          this.HintLabel.Size = new System.Drawing.Size(0, 17);
          // 
          // lblCameraZoom
          // 
          this.lblCameraZoom.AutoSize = false;
          this.lblCameraZoom.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                      | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                      | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
          this.lblCameraZoom.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
          this.lblCameraZoom.Name = "lblCameraZoom";
          this.lblCameraZoom.Size = new System.Drawing.Size(50, 17);
          this.lblCameraZoom.Text = "x1";
          this.lblCameraZoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // lblHint
          // 
          this.lblHint.Name = "lblHint";
          this.lblHint.Size = new System.Drawing.Size(0, 17);
          // 
          // lblHint1
          // 
          this.lblHint1.Name = "lblHint1";
          this.lblHint1.Size = new System.Drawing.Size(0, 17);
          // 
          // Hint
          // 
          this.Hint.AutoPopDelay = 5000;
          this.Hint.InitialDelay = 0;
          this.Hint.ReshowDelay = 100;
          // 
          // MainForm
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.AutoSize = true;
          this.ClientSize = new System.Drawing.Size(594, 372);
          this.Controls.Add(this.StatusBar);
          this.Controls.Add(this.MainMenu);
          this.Controls.Add(this.glWindow);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.KeyPreview = true;
          this.MainMenuStrip = this.MainMenu;
          this.MinimumSize = new System.Drawing.Size(600, 400);
          this.Name = "MainForm";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "Солнечный датчик";
          this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
          this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
          this.Load += new System.EventHandler(this.MainForm_Load);
          this.Resize += new System.EventHandler(this.MainForm_Resize);
          this.PopUpMenu.ResumeLayout(false);
          this.MainMenu.ResumeLayout(false);
          this.MainMenu.PerformLayout();
          this.StatusBar.ResumeLayout(false);
          this.StatusBar.PerformLayout();
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl glWindow;
        private System.Windows.Forms.Timer Cadencer;
        private System.Windows.Forms.ContextMenuStrip PopUpMenu;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem mmiFile;
        private System.Windows.Forms.ToolStripMenuItem mmiFileExit;
        private System.Windows.Forms.ToolStripMenuItem mmiView;
        private System.Windows.Forms.ToolStripMenuItem mmiViewFullScreen;
        private System.Windows.Forms.ToolStripMenuItem mmiHelp;
        private System.Windows.Forms.ToolStripMenuItem mmiHelpReference;
        private System.Windows.Forms.ToolStripMenuItem mmiHelpAboutProgram;
        private System.Windows.Forms.ToolStripMenuItem mmiGraphics;
        private System.Windows.Forms.ToolStripMenuItem pmiScene;
        private System.Windows.Forms.ToolStripMenuItem pmiSceneShowContour;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel lblCameraAzimuthAngle;
        private System.Windows.Forms.ToolTip Hint;
        private System.Windows.Forms.ToolStripMenuItem mmiEdit;
        private System.Windows.Forms.ToolStripMenuItem mmiEditSelectAllObjects;
        private System.Windows.Forms.ToolStripMenuItem mmiGraphicsCenterCamera;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mmiGraphicsCameraToLeft;
        private System.Windows.Forms.ToolStripMenuItem mmiGraphicsCameraToRight;
        private System.Windows.Forms.ToolStripMenuItem mmiGraphicsCameraToUp;
        private System.Windows.Forms.ToolStripMenuItem mmiGraphicsCameraToDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mmiGraphicsCameraZoomIn;
        private System.Windows.Forms.ToolStripMenuItem mmiGraphicsCameraZoomOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mmiGraphicsParameters;
        private System.Windows.Forms.ToolStripMenuItem mmiObjects;
        private System.Windows.Forms.ToolStripMenuItem mmiObjectsParams;
        private System.Windows.Forms.ToolStripStatusLabel lblCameraZenithAngle;
        private System.Windows.Forms.ToolStripStatusLabel HintLabel;
        private System.Windows.Forms.ToolStripMenuItem pmiObjectParams;
        private System.Windows.Forms.ToolStripMenuItem pmiSceneShowAxes;
        private System.Windows.Forms.ToolStripStatusLabel lblCameraZoom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripStatusLabel lblHint;
        private System.Windows.Forms.ToolStripMenuItem mmiEditRemoveSelection;
        private System.Windows.Forms.ToolStripStatusLabel lblHint1;
    }
}

