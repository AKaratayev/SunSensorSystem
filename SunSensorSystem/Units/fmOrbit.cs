using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunSensorSystem
{
  // Диалоговое окно "Орбита движения" ------------------------------------------
  public partial class fmOrbit : Form
  {
    // Private fields
    private double _semimajorAxis;               //Большая полуось орбиты a, мировые координаты                     
    private double _inclination;                 //Наклонение орбиты i, град (0 - 180)
    private double _longitudeOfAscendingNode;    //Долгота восходящего узла Омега, град (0 - 360) 
    private double _eccentricity;                //Эксцентриситет e, (0 - 1)
    private double _argumentOfPeriapsis;         //Аргумент перицентра омега, град (0 - 360)   
    private bool _orbitVisible;                  //Видимость орбиты
    // Параметры дополнительных графических элементов
    private bool _showGrid;                      //Видимость сетки
    private bool _showAxes;                      //Видимость осей орбиты
    private bool _showBaseOrbit;                 //Видимость базовой траектории орбиты
    private bool _showBaseOrbitAxes;             //Видимость осей базовой орбиты
    private bool _showBoundsContour;             //Видимость контура границ    
    private ColorRGB _orbitColor;                //Цвет орбиты, RGB
     
    // Constructor
    public fmOrbit()
    {
      InitializeComponent();
    }// fmOrbit

    private void fmOrbit_Load(object sender, EventArgs e)
    {
      // Параметры орбиты
      tbxSemimajorAxis.Text            = SemimajorAxis.ToString();
      tbxEccentricity.Text             = Eccentricity.ToString();
      tbxlInclination.Text             = Inclination.ToString();
      tbxArgumentOfPeriapsis.Text      = ArgumentOfPeriapsis.ToString();
      tbxLongitudeOfAscendingNode.Text = LongitudeOfAscendingNode.ToString();
      // Видимость орбиты и дополнительных элементов
      cbOrbitVisible.Checked           = OrbitVisible;
      cbShowBaseOrbit.Checked          = ShowBaseOrbit;
      cbShowBaseOrbitAxes.Checked      = ShowBaseOrbitAxes;
      cbShowAxes.Checked               = ShowAxes;
      cbShowGrid.Checked               = ShowGrid;
      cbShowBoundsContour.Checked      = ShowBoundsContour;
 
      cbShowBaseOrbit.Enabled          = OrbitVisible;
      cbShowBaseOrbitAxes.Enabled      = OrbitVisible;
      cbShowAxes.Enabled               = OrbitVisible;
      cbShowGrid.Enabled               = OrbitVisible;
      cbShowBoundsContour.Enabled      = OrbitVisible;
      // Цвет орбиты
      pnOrbitColor.BackColor = Color.FromArgb((int)(OrbitColor.R * 255.0), (int)(OrbitColor.G * 255.0), (int)(OrbitColor.B * 255.0));
    }// fmOrbit_Load

    // Private methods 
    private void cbOrbitVisible_CheckedChanged(object sender, EventArgs e)
    {
      _orbitVisible               = cbOrbitVisible.Checked;
      cbShowBaseOrbit.Enabled     = OrbitVisible;
      cbShowBaseOrbitAxes.Enabled = OrbitVisible;
      cbShowAxes.Enabled          = OrbitVisible;
      cbShowGrid.Enabled          = OrbitVisible;
      cbShowBoundsContour.Enabled = OrbitVisible;
    }// сbOrbitVisible_CheckedChanged
   
    private void cbShowBaseOrbit_CheckedChanged(object sender, EventArgs e)
    {
      _showBaseOrbit = cbShowBaseOrbit.Checked;
    }// cbShowBaseOrbit_CheckedChanged

    private void cbShowAxes_CheckedChanged(object sender, EventArgs e)
    {
      _showAxes = cbShowAxes.Checked;
    }// cbShowOrbitAxes_CheckedChange

    private void cbShowBaseOrbitAxes_CheckedChanged(object sender, EventArgs e)
    {
      _showBaseOrbitAxes = cbShowBaseOrbitAxes.Checked;
    }// cbShowBaseOrbitAxes_CheckedChanged

    private void cbShowGrid_CheckedChanged(object sender, EventArgs e)
    {
      _showGrid = cbShowGrid.Checked;
    }// cbShowGrid_CheckedChanged
    
    private void cbShowBoundsContour_CheckedChanged(object sender, EventArgs e)
    {
      _showBoundsContour = cbShowBoundsContour.Checked;
    }// cbShowOrbitContour_CheckedChanged

    private void tbxSemimajorAxis_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!(Char.IsDigit(e.KeyChar)))
        if ((e.KeyChar != (char)Keys.Back) && (e.KeyChar != ','))
          e.Handled = true;
    }// tbxSemimajorAxis_KeyPress

    private void tbxEccentricity_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!(Char.IsDigit(e.KeyChar)))
        if ((e.KeyChar != (char)Keys.Back) && (e.KeyChar != ','))
          e.Handled = true;
    }// tbxEccentricity_KeyPress

    private void tbxlInclination_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!(Char.IsDigit(e.KeyChar)))
        if ((e.KeyChar != (char)Keys.Back) && (e.KeyChar != ','))
          e.Handled = true;
    }// tbxlInclination_KeyPress

    private void tbxArgumentOfPeriapsis_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!(Char.IsDigit(e.KeyChar)))
        if ((e.KeyChar != (char)Keys.Back) && (e.KeyChar != ','))
          e.Handled = true;
    }// tbxArgumentOfPeriapsis_KeyPress

    private void tbxLongitudeOfAscendingNode_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!(Char.IsDigit(e.KeyChar)))
        if ((e.KeyChar != (char)Keys.Back) && (e.KeyChar != ','))
          e.Handled = true;
    }// tbxLongitudeOfAscendingNode_KeyPress

    private void btOK_Click(object sender, EventArgs e)
    {
      double.TryParse(tbxSemimajorAxis.Text, out _semimajorAxis);
      double.TryParse(tbxEccentricity.Text, out _eccentricity);
      double.TryParse(tbxlInclination.Text, out _inclination);
      double.TryParse(tbxArgumentOfPeriapsis.Text, out _argumentOfPeriapsis);
      double.TryParse(tbxLongitudeOfAscendingNode.Text, out _longitudeOfAscendingNode);
    }// btOK_Click

    private void btColorDlg_Click(object sender, EventArgs e)
    {
      ColorDlg.Color = pnOrbitColor.BackColor;
      if (ColorDlg.ShowDialog() == DialogResult.OK)
      {
        _orbitColor.R = (double)(ColorDlg.Color.R / 255.0);
        _orbitColor.G = (double)(ColorDlg.Color.G / 255.0);
        _orbitColor.B = (double)(ColorDlg.Color.B / 255.0);
        pnOrbitColor.BackColor = ColorDlg.Color;
      }// if
    }// btColorDlg_Click

    // Public properties
    public double SemimajorAxis
    {
      get { return _semimajorAxis; }
      set
      {
        if (_semimajorAxis != value)
          _semimajorAxis = value;
      }
    }// SemiMajorAxis

    public double Inclination
    {
      get { return _inclination; }
      set
      {
        if (_inclination != value)
          _inclination = value;
      }
    }// Inclination

    public double LongitudeOfAscendingNode
    {
      get { return _longitudeOfAscendingNode; }
      set
      {
        if (_longitudeOfAscendingNode != value)
          _longitudeOfAscendingNode = value;
      }
    }// LongitudeOfAscendingNode

    public double Eccentricity
    {
      get { return _eccentricity; }
      set
      {
        if (_eccentricity != value)
          _eccentricity = value;
      }
    }// Eccentricity

    public double ArgumentOfPeriapsis
    {
      get { return _argumentOfPeriapsis; }
      set
      {
        if (_argumentOfPeriapsis != value)
          _argumentOfPeriapsis = value;
      }
    }// ArgumentOfPeriapsis

    public bool OrbitVisible
    {
      get { return _orbitVisible; }
      set
      {
        if (_orbitVisible != value)
          _orbitVisible = value;
      }
    }// OrbitVisible

    public bool ShowGrid
    {
      get { return _showGrid; }
      set
      {
        if (_showGrid != value)
          _showGrid = value;
      }
    }// ShowGrid

    public bool ShowAxes
    {
      get { return _showAxes; }
      set
      {
        if (_showAxes != value)
          _showAxes = value;
      }
    }// ShowAxes

    public bool ShowBaseOrbit
    {
      get { return _showBaseOrbit; }
      set
      {
        if (_showBaseOrbit != value)
          _showBaseOrbit = value;
      }
    }// ShowBaseOrbit

    public bool ShowBaseOrbitAxes
    {
      get { return _showBaseOrbitAxes; }
      set
      {
        if (_showBaseOrbitAxes != value)
          _showBaseOrbitAxes = value;
      }
    }// ShowBaseOrbitAxes

    public bool ShowBoundsContour
    {
      get { return _showBoundsContour; }
      set
      {
        if (_showBoundsContour != value)
          _showBoundsContour = value;
      }
    }// ShowBoundsContour

    public ColorRGB OrbitColor
    {
      get { return _orbitColor; }
      set { _orbitColor = value; }
    }// OrbitColor

  }// fmOrbit
}// SunSensorSystem
