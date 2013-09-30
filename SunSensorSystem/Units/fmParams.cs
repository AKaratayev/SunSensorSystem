using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunSensorSystem
{
  // Диалоговое окно "Настройки" ------------------------------------------------
  public partial class fmParams : Form
  {
    // Private fields
    private bool _showSceneContour;    // Видимость контура куба данных
    private bool _showSceneAxes;       // Видимость координатных осей
    private ColorRGB _foreColor;       // Цвет фона
    // Сферические координаты камеры        
    private double _cameraAzimuth;     // Азимут, град
    private double _cameraZenith;      // Зенит, град
    private double _cameraRadius;      // Радиус, мировые координаты

    // Constructor
    public fmParams()
    {
      InitializeComponent();
    }// fmParams

    private void fmParams_Load(object sender, EventArgs e)
    {
      // Сцена
      tbxCameraAzimuth.Text = _cameraAzimuth.ToString();
      tbxCameraZenith.Text = _cameraZenith.ToString();
      tbxCameraRadius.Text = _cameraRadius.ToString();
      cbShowSceneContour.Checked = _showSceneContour;
      cbShowSceneAxes.Checked = _showSceneAxes;
      pnForeColor.BackColor = Color.FromArgb((int)(ForeColor.R * 255.0), (int)(ForeColor.G * 255.0), (int)(ForeColor.B * 255.0));
    }// fmParams_Load

    // Private methods
    private void cbShowSceneContour_CheckedChanged(object sender, EventArgs e)
    {
      _showSceneContour = cbShowSceneContour.Checked;
    }// cbShowSceneContour_CheckedChanged

    private void cbShowSceneAxes_CheckedChanged(object sender, EventArgs e)
    {
      _showSceneAxes = cbShowSceneAxes.Checked;
    }// cbShowSceneAxes_CheckedChanged

    private void btOK_Click(object sender, EventArgs e)
    {
      double.TryParse(tbxCameraAzimuth.Text, out _cameraAzimuth);
      double.TryParse(tbxCameraZenith.Text, out _cameraZenith);
      double.TryParse(tbxCameraRadius.Text, out _cameraRadius);
    }// btOK_Click

    private void btColorDlg_Click(object sender, EventArgs e)
    {
      ColorDlg.Color = pnForeColor.BackColor;
      if (ColorDlg.ShowDialog() == DialogResult.OK)
      {
        _foreColor.R = (float)(ColorDlg.Color.R / 255.0);
        _foreColor.G = (float)(ColorDlg.Color.G / 255.0);
        _foreColor.B = (float)(ColorDlg.Color.B / 255.0);
        pnForeColor.BackColor = ColorDlg.Color;
      }// if
    }// btColorDlg_Click

    // Public methods
    /// <summary>
    /// Задать параметры диалогового окна
    /// </summary>
    public void SetParams(bool showCube, bool showCubeAxes, ColorRGB foreColor, double cameraAzimuth, double cameraZenith, double cameraRadius)
    {
      _showSceneContour = showCube;
      _showSceneAxes    = showCubeAxes;
      _foreColor        = foreColor;
      _cameraAzimuth    = cameraAzimuth;
      _cameraZenith     = cameraZenith;
      _cameraRadius     = cameraRadius;
    }// SetParams

    /// <summary>
    /// Сохранить пользовательские настройки
    /// </summary>
    public void GetParams(out bool showCube, out bool showCubeAxes, out ColorRGB foreColor, out double cameraAzimuth, out double cameraZenith, out double cameraRadius)
    {
      showCube      = _showSceneContour;
      showCubeAxes  = _showSceneAxes;
      foreColor     = _foreColor;
      cameraAzimuth = _cameraAzimuth;
      cameraZenith  = _cameraZenith;
      cameraRadius  = _cameraRadius;
    }// GetParams

  }// fmParams
}// namespace SunSensorSystem
