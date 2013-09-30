/*
Каратаев А.А.
aibek_karataeff@mail.ru
8-777-237-00-10
ДТОО "ИКТТ" 
-------------------------------------
Главная форма
-прорисовка графической сцены
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

namespace SunSensorSystem
{
  //Главная форма ----------------------------------------------------------------------------------
  public partial class MainForm : Form
  {
    // Функции WinAPI
    [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
    public static extern int GetSystemMetrics(int Which);
    [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
    public static extern void SetWindowPos(IntPtr HWnd, IntPtr HWndInsertAfter, int X, int Y, int Width, int Height, uint Flags);

    // Private fields
    private int CursorPosX { get; set; }         // Координата курсора мыши x, пиксел
    private int CursorPosY { get; set; }         // Координата курсора мыши y, пиксел
    private bool MousePressed { get; set; }      // Состояние нажатия кнопки мыши 
    private bool FullScreenMode { get; set; }    // Полноэкранный режим
    private Scene Scene { get; set; }            // Графическая сцена
    private Orbit Orbit1 { get; set; }           // Орбита движения #1
    private Orbit Orbit2 { get; set; }           // Орбита движения #2
    private Orbit Orbit3 { get; set; }           // Орбита движения #3
    
    // Constructor
    public MainForm()
    {
      // Инициализация компонентов формы
      InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      // Полноэкранный режим
      this.FullScreenMode = false;
      // Сцена
      this.Scene = new Scene(this.glWindow);
      Scene.ChangeEvent += SceneChangeHandler;
      // Событие движения колесика мыши
      this.MouseWheel += MainForm_MouseWheel;
      // Орбита движения 1
      this.Orbit1 = new Orbit();
      this.Scene.GraphObjects.Add(Orbit1);
      this.Orbit1.BoundsChangeEvent += BoundsChangeHandler;
      this.Orbit1.Position.MoveTo(2000.0, 3000.0, 4000.0);
      this.Orbit1.Inclination = 15.0;
      this.Orbit1.SetColor(0.9, 0.3, 0.2);
      // Орбита движения 2
      this.Orbit2 = new Orbit();
      this.Scene.GraphObjects.Add(Orbit2);
      this.Orbit2.BoundsChangeEvent += BoundsChangeHandler;
      this.Orbit2.Position.MoveTo(-2000.0, -2000.0, -4000.0);
      this.Orbit2.SemimajorAxis = 1500.0;
      this.Orbit2.LongitudeOfAscendingNode = 25.0;
      // Орбита движения 3
      this.Orbit3 = new Orbit();
      this.Scene.GraphObjects.Add(Orbit3);
      this.Orbit3.BoundsChangeEvent += BoundsChangeHandler;
      this.Orbit3.Position.MoveTo(-1000.0, 7000.0, 8000.0);
      this.Orbit3.Inclination = 60.0;
      // Центрировать камеру
      this.Scene.CameraCentered();
      // Таймер
      this.Cadencer.Start();     
    }// MainForm_Load

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Cadencer.Stop();
      Cadencer.Dispose();
    }// MainForm_FormClosed

    private void MainForm_Resize(object sender, EventArgs e)
    {
      if (Scene != null)
        Scene.SetScreenSize(glWindow.Width, glWindow.Height);
    }// MainForm_Resize

    // Private methods 
    /// <summary>
    /// Обработчик события изменения положения камеры
    /// </summary>
    private void SceneChangeHandler(object sender, EventArgs arg)
    {
      lblCameraAzimuthAngle.Text = string.Format("Азимут, град: {0:#.##}", Scene.Camera.SphericalCoords.Azimuth);
      lblCameraZenithAngle.Text  = string.Format("Зенит, град: {0:#.##}", Scene.Camera.SphericalCoords.Zenith);
      lblCameraZoom.Text         = string.Format("x: {0:#.#}", 20000 / Scene.Camera.SphericalCoords.Radius);
    }// SceneChangeHandler

    /// <summary>
    /// Обработчик события изменения размерности сцены
    /// </summary>
    private void BoundsChangeHandler(object sender, EventArgs arg)
    {
      if (Scene != null)
        Scene.DefineCubeBounds();
    }// BoundsChangeHandler

    /// <summary>
    /// Полноэкранный режим
    /// </summary>
    private void SetFullScreenMode(bool fullScreenMode)
    {
      FullScreenMode = !fullScreenMode;
      if (fullScreenMode)
      {
        // Скрыть рамку окна;
        FormBorderStyle = FormBorderStyle.None;
        // Скрыть меню
        MainMenu.Visible = false;
        // Скрыть статусное меню
        StatusBar.Visible = false;
        // Переход в полноэкранный режим
        SetWindowPos(this.Handle, IntPtr.Zero, 0, 0, GetSystemMetrics(0), GetSystemMetrics(1), 64);
      }// if
      else
      {
        // Показать рамку окна;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        // Показать меню
        MainMenu.Visible = true;
        // Показать статусное меню
        StatusBar.Visible = true;
      }// else
    }// SetFullScreenMode

    /// <summary>
    /// Обработчик события движения колеса мыши
    /// </summary>
    private void MainForm_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
    {
      Scene.Camera.AdjustDistanceToTarget(e.Delta);
    }// MainForm_MouseWheel

    private void MainForm_MouseDown(object sender, MouseEventArgs e)
    {
      // Левая кнопка мыши
      if (e.Button == MouseButtons.Left)
      {
        MousePressed = true;
        // Смена вида курсора
        Scene.Cursor = Cursors.Cross;
        // Координаты курсора в момент нажатия кнопки мыши
        CursorPosX = e.X;
        CursorPosY = e.Y;
        // Выделение графического объекта
        Scene.SelectGraphObject(e.X, (glWindow.Height - e.Y));
      }// if
    }// MainForm_MouseDown

    private void MainForm_MouseMove(object sender, MouseEventArgs e)
    {
      if (MousePressed)
      {
        // Вращение камеры
        Scene.Camera.MoveAroundTarget((CursorPosY - e.Y), (CursorPosX - e.X));
        // Сохранение последних координат курсора 
        CursorPosX = e.X;
        CursorPosY = e.Y;      
      }// if    
    }// MainForm_MouseMove

    private void MainForm_MouseUp(object sender, MouseEventArgs e)
    {
      if (MousePressed)
      {
        MousePressed = false;
        // Cмена вида курсора
        Scene.Cursor = Cursors.Default;     
      }// if
    }// MainForm_MouseUp

    private void MainForm_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == (Keys.Enter) && (e.Alt))
        SetFullScreenMode(FullScreenMode);
    }// MainForm_KeyDown 

    private void Cadencer_Tick(object sender, EventArgs e)
    {
      try
      {
        if (Scene != null)
          Scene.Draw();
      }// try
      catch(Exception ex)
      {
        MessageBox.Show(ex.Message);
        Application.Exit();
      }// catch
    }// Cadencer_Tick

    private void mmiFile_DropDownOpening(object sender, EventArgs e)
    {
      mmiFileExit.Enabled = true;
    }// mmiFile_DropDownOpening

    private void mmiFileExit_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }// mmiFileExit_Click

    private void mmiEdit_DropDownOpening(object sender, EventArgs e)
    {
      mmiEditSelectAllObjects.Enabled = true;
      mmiEditRemoveSelection.Enabled  = false;
    }// mmiEdit_DropDownOpening

    private void mmiView_DropDownOpening(object sender, EventArgs e)
    {
      mmiViewFullScreen.Enabled = true;
    }// mmiView_DropDownOpening

    private void mmiViewFullScreen_Click(object sender, EventArgs e)
    {
      // Полноэкранный режим
      SetFullScreenMode(FullScreenMode);
    }// mmiViewFullScreen_Click

    private void mmiGraphics_DropDownOpening(object sender, EventArgs e)
    {
      mmiGraphicsCameraToDown.Enabled  = true;
      mmiGraphicsCameraToLeft.Enabled  = true;
      mmiGraphicsCameraToRight.Enabled = true;
      mmiGraphicsCameraToUp.Enabled    = true;
      mmiGraphicsCameraZoomIn.Enabled  = true;
      mmiGraphicsCameraZoomOut.Enabled = true;
      mmiGraphicsCenterCamera.Enabled  = true;
      mmiGraphicsParameters.Enabled    = true;      
    }// mmiGraphics_DropDownOpening

    private void mmiGraphicsCenterCamera_Click(object sender, EventArgs e)
    {
      Scene.CameraCentered();
    }// mmiCenterCamera_Click

    private void mmiGraphicsCameraToLeft_Click(object sender, EventArgs e)
    {
      Scene.Camera.MoveAroundTarget(0.0, 1.0);
    }// mmiGraphicsCameraToLeft_Click

    private void mmiGraphicsCameraToRight_Click(object sender, EventArgs e)
    {
      Scene.Camera.MoveAroundTarget(0.0, -1.0);
    }// mmiGraphicsCameraToRight_Click

    private void mmiGraphicsCameraToUp_Click(object sender, EventArgs e)
    {
      Scene.Camera.MoveAroundTarget(1.0, 0.0);
    }// mmiGraphicsCameraToUp_Click

    private void mmiGraphicsCameraToDown_Click(object sender, EventArgs e)
    {
      Scene.Camera.MoveAroundTarget(-1.0, 0.0);
    }// mmiGraphicsCameraToDown_Click

    private void mmiGraphicsCameraZoomIn_Click(object sender, EventArgs e)
    {
      Scene.Camera.AdjustDistanceToTarget(0.99);
    }// mmiGraphicsCameraZoomIn_Click

    private void mmiGraphicsCameraZoomOut_Click(object sender, EventArgs e)
    {
      Scene.Camera.AdjustDistanceToTarget(1.01);
    }// mmiGraphicsCameraZoomOut_Click

    private void mmiGraphicsParameters_Click(object sender, EventArgs e)
    {
      Scene.ParamsDlg();
    }// mmiGraphicsParameters_Click

    private void mmiObjects_DropDownOpening(object sender, EventArgs e)
    {
      mmiObjectsParams.Enabled = Scene.GraphObjects.Selected;
    }// mmiObjects_DropDownOpening

    private void mmiObjectsParams_Click(object sender, EventArgs e)
    {
      Scene.GraphObjects.SelectedItem.ParamsDlg();
    }// mmiObjectsOrbit_Click

    private void mmiHelp_DropDownOpening(object sender, EventArgs e)
    {
      mmiHelpReference.Enabled    = true;
      mmiHelpAboutProgram.Enabled = true;
    }// mmiHelp_DropDownOpening

    private void PopUpMenu_Opening(object sender, CancelEventArgs e)
    {
      pmiObjectParams.Enabled = Scene.GraphObjects.Selected;
    }// PopUpMenu_Opening

    private void pmiObjectParams_Click(object sender, EventArgs e)
    {
      mmiObjectsParams_Click(sender, e);
    }// pmiObjectParams_Click

    private void pmiScene_DropDownOpening(object sender, EventArgs e)
    {
      pmiSceneShowContour.Enabled = true;
      pmiSceneShowAxes.Enabled    = true;
      pmiSceneShowContour.Checked = Scene.ShowCube;
      pmiSceneShowAxes.Checked    = Scene.ShowCubeAxes;
    }// pmiScene_DropDownOpening

    private void pmiSceneShowContour_Click(object sender, EventArgs e)
    {
      Scene.ShowCube = !Scene.ShowCube;
    }// pmiSceneShowContour

    private void pmiSceneShowAxes_Click(object sender, EventArgs e)
    {
      Scene.ShowCubeAxes = !Scene.ShowCubeAxes;
    }// pmiSceneShowAxes

    private void mmiObjectsParams_MouseHover(object sender, EventArgs e)
    {
      lblHint.Text = mmiObjectsParams.ToolTipText.ToString();
    }// mmiObjectsParams_MouseHover

    private void mmiObjectsParams_MouseLeave(object sender, EventArgs e)
    {
      lblHint.Text = "";
    }// mmiObjectsParams_MouseLeave

  }// MainForm
}// namespace SunSensorSystem
