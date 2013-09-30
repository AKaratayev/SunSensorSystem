/*
Каратаев А.А.
aibek_karataeff@mail.ru
8-777-237-00-10
ДТОО "ИКТТ" 
---------------------------------------------------------
Орбита движения
-основные элементы эллиптической орбиты
-прорисовка орбиты
-прорисовка дополнительных графических элементов орбиты
*/
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

namespace SunSensorSystem
{
  // Орбита движения --------------------------------------------------------------------------------------
  class Orbit : GraphObject
  {
    // Private fields     
    // Элементы орбиты   
    private double _semimajorAxis;                      // Большая полуось орбиты a, мировые координаты
    private double _semiminorAxis;                      // Малая полуось орбиты b, мировые координаты
    private double _inclination;                        // Наклонение орбиты i, град (0 - 180)
    private double _longitudeOfAscendingNode;           // Долгота восходящего узла Омега, град (0 - 360) 
    private double _eccentricity;                       // Эксцентриситет e, (0 - 1)
    private double _argumentOfPeriapsis;                // Аргумент перицентра омега, град (0 - 360)
    private double _meanAnomaly;                        // Средняя аномалия M, град (0 - 360) 
    //Параметры дополнительных графических элементов
    private bool _showGrid;                             // Видимость сетки
    private bool _showAxes;                             // Видимость осей орбиты
    private bool _showBaseOrbit;                        // Видимость базовой траектории орбиты
    private bool _showBaseOrbitAxes;                    // Видимость осей базовой орбиты
    private bool _showBoundsContour;                    // Видимость контура границ
             
    // Constructor
    public Orbit()
    {     
      // Параметры орбиты
      this._semimajorAxis            = 1000.0;
      this._inclination              = 45.0;
      this._longitudeOfAscendingNode = 0.0;
      this._eccentricity             = 0.2;
      this._argumentOfPeriapsis      = 0.0;
      this._meanAnomaly              = 0.0;   
      // Параметры дополнительных графических элементов
      this._showGrid          = false;
      this._showAxes          = false;
      this._showBaseOrbit     = false;
      this._showBaseOrbitAxes = false;
      this._showBoundsContour = true;
      // Цвет орбиты RGB
      this.SetColor(0.3, 0.5, 0.7);
      // Вычисление дополнительных параметров
      this.DefineAdditionalOrbitElements();
    }// Constructor

    // Protected methods
    /// <summary>
    /// Метод, генерирующий событие изменения положения объекта
    /// </summary>
    protected override void OnPositionChangeEvent()
    {
      DefineBounds();
      Invalidate();
    }// OnPositionChangeEvent

    /// <summary>
    /// Расчет границ орбиты
    /// </summary>
    protected override void DefineBounds()
    {
      double contourHeight = SemiminorAxis * Math.Sin(Math.PI * Inclination / 180.0);
      double minX = (Position.Vector.X - SemimajorAxis);
      double maxX = (Position.Vector.X + SemimajorAxis);
      double minY = (Position.Vector.Y - SemimajorAxis);
      double maxY = (Position.Vector.Y + SemimajorAxis);
      double minZ = (Position.Vector.Z - contourHeight);
      double maxZ = (Position.Vector.Z + contourHeight);
      Bounds.SetBounds(minX, maxX, minY, maxY, minZ, maxZ);
    }// DefineBounds

    // Private methods
    /// <summary>
    /// Расчет дополнительных параметров
    /// </summary>
    private void DefineAdditionalOrbitElements()
    {
      SemiminorAxis = SemimajorAxis * Math.Sqrt(1 - Eccentricity * Eccentricity);
    }// _DefineAdditionalOrbitElements

    /// <summary>
    /// Корректировка угла
    /// </summary>
    private double EnsureAngle(double angle, double minAngle, double maxAngle)
    {
      while (angle > maxAngle)
        angle -= maxAngle;
      while (angle < minAngle)
        angle += maxAngle;
      return angle;
    }// _EnsureAngle

    /// <summary>
    /// Прорисовка контура границ 
    /// </summary>
    private void DrawBoundsContour()
    {
      if (ShowBoundsContour)
      {
        Gl.glPushMatrix();
          Gl.glColor3d(ContourColor.R, ContourColor.G, ContourColor.B);
          Gl.glLineWidth(1);
          Gl.glBegin(Gl.GL_LINES);
            // Верхняя грань
            Gl.glVertex3d(Bounds.MaxX, Bounds.MaxY, Bounds.MaxZ);
            Gl.glVertex3d(Bounds.MinX, Bounds.MaxY, Bounds.MaxZ);
            Gl.glVertex3d(Bounds.MinX, Bounds.MaxY, Bounds.MaxZ);
            Gl.glVertex3d(Bounds.MinX, Bounds.MinY, Bounds.MaxZ);
            Gl.glVertex3d(Bounds.MinX, Bounds.MinY, Bounds.MaxZ);
            Gl.glVertex3d(Bounds.MaxX, Bounds.MinY, Bounds.MaxZ);
            Gl.glVertex3d(Bounds.MaxX, Bounds.MinY, Bounds.MaxZ);
            Gl.glVertex3d(Bounds.MaxX, Bounds.MaxY, Bounds.MaxZ);
          Gl.glEnd();
          Gl.glBegin(Gl.GL_LINES);
            // Нижняя грань
            Gl.glVertex3d(Bounds.MaxX, Bounds.MaxY, Bounds.MinZ);
            Gl.glVertex3d(Bounds.MinX, Bounds.MaxY, Bounds.MinZ);
            Gl.glVertex3d(Bounds.MinX, Bounds.MaxY, Bounds.MinZ);
            Gl.glVertex3d(Bounds.MinX, Bounds.MinY, Bounds.MinZ);
            Gl.glVertex3d(Bounds.MinX, Bounds.MinY, Bounds.MinZ);
            Gl.glVertex3d(Bounds.MaxX, Bounds.MinY, Bounds.MinZ);
            Gl.glVertex3d(Bounds.MaxX, Bounds.MinY, Bounds.MinZ);
            Gl.glVertex3d(Bounds.MaxX, Bounds.MaxY, Bounds.MinZ);
          Gl.glEnd();
          Gl.glBegin(Gl.GL_LINES);
            // Боковые ребра
            Gl.glVertex3d(Bounds.MaxX, Bounds.MaxY, Bounds.MaxZ);
            Gl.glVertex3d(Bounds.MaxX, Bounds.MaxY, Bounds.MinZ);
            Gl.glVertex3d(Bounds.MinX, Bounds.MaxY, Bounds.MaxZ);
            Gl.glVertex3d(Bounds.MinX, Bounds.MaxY, Bounds.MinZ);
            Gl.glVertex3d(Bounds.MinX, Bounds.MinY, Bounds.MaxZ);
            Gl.glVertex3d(Bounds.MinX, Bounds.MinY, Bounds.MinZ);
            Gl.glVertex3d(Bounds.MaxX, Bounds.MinY, Bounds.MaxZ);
            Gl.glVertex3d(Bounds.MaxX, Bounds.MinY, Bounds.MinZ);
          Gl.glEnd();
        Gl.glPopMatrix();
      }// if
    }// _DrawBoundsContour

    /// <summary>
    /// Прорисовка осей
    /// </summary>
    private void DrawAxes(double size, double posX, double posY, double posZ)
    {
      Gl.glPushMatrix();
        // Ось x
        Gl.glColor3d(1.0, 0.0, 0.0);
        Gl.glLineWidth(3);
        Gl.glBegin(Gl.GL_LINES);
          Gl.glVertex3d(posX, posY, posZ);
          Gl.glVertex3d(size, 0.0, 0.0);
        Gl.glEnd();
        // Ось y
        Gl.glColor3d(0.0, 1.0, 0.0);
        Gl.glBegin(Gl.GL_LINES);
          Gl.glVertex3d(posX, posY, posZ);
          Gl.glVertex3d(0.0, size, 0.0);
        Gl.glEnd();
        // Ось z
        Gl.glColor3d(0.0, 0.0, 1.0);
        Gl.glBegin(Gl.GL_LINES);
          Gl.glVertex3d(posX, posY, posZ);
          Gl.glVertex3d(0.0, 0.0, size);
        Gl.glEnd();
        // Метка оси x
        Gl.glColor3d(1.0, 0.0, 0.0);
        Gl.glRasterPos3d(size, posY + (size * 0.1), posZ);
        Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_HELVETICA_18, 'x');
        // Метка оси y
        Gl.glColor3d(0.0, 1.0, 0.0);
        Gl.glRasterPos3d(posX + (size * 0.1), size, posZ);
        Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_HELVETICA_18, 'y');
        // Метка оси z
        Gl.glColor3d(0.0, 0.0, 1.0);
        Gl.glRasterPos3d(posX, posY + (size * 0.1), size);
        Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_HELVETICA_18, 'z');
        // Центр орбиты
        Gl.glColor3d(1.0, 0.0, 0.0);
        Glut.glutSolidSphere(size * 0.01, 30, 30);
      Gl.glPopMatrix();
    }// _DrawAxes   
   
    /// <summary>
    /// Прорисовка орбиты 
    /// </summary>
    private void DrawOrbit(double semimajorAxis, double semiminorAxis)
    {
      Gl.glPushMatrix();
        // Вращение орбиты 
        Gl.glRotated(LongitudeOfAscendingNode, 0, 0, 1);
        Gl.glRotated(Inclination, 0, 1, 0);
        Gl.glRotated(-ArgumentOfPeriapsis, 0, 0, 1);
        // Оси орбиты
        if (ShowAxes)
        {
          Gl.glPushAttrib(Gl.GL_ENABLE_BIT);
            Gl.glLineStipple(1, 0xAAAA);
            Gl.glEnable(Gl.GL_LINE_STIPPLE);
            DrawAxes(semimajorAxis * 0.5, 0, 0, 0);
          Gl.glPopAttrib();
        }// if
        // Прорисовка орбиты
        Gl.glColor3d(Color.R, Color.G, Color.B);
        Gl.glLineWidth(3);
        Gl.glBegin(Gl.GL_LINE_STRIP);
          for (double d = 0; d <= 2 * Math.PI; d += 0.001)   
            Gl.glVertex3d(semiminorAxis * Math.Sin(d), semimajorAxis * Math.Cos(d), 0);
        Gl.glEnd();  
      Gl.glPopMatrix();
    }// _DrawOrbit

    /// <summary>
    /// Прорисовка базовой орбиты
    /// </summary>
    private void DrawBaseOrbit(double semimajorAxis, double semiminorAxis)
    {
      if (ShowBaseOrbit)
      {
        Gl.glPushMatrix();
          //Прорисовка осей
          if (ShowBaseOrbitAxes)
            DrawAxes(SemimajorAxis * 0.5, 0, 0, 0);
          //Прорисовка базовой орбиты
          Gl.glColor3d(0.5, 0.5, 0.5);
          Gl.glLineWidth(2);
          Gl.glBegin(Gl.GL_LINE_STRIP);
            for (double d = 0; d <= 2 * Math.PI; d += 0.01)
              Gl.glVertex3d(semiminorAxis * Math.Sin(d), semimajorAxis * Math.Cos(d), 0);
          Gl.glEnd();   
        Gl.glPopMatrix();
      }// if
    }// _DrawBaseOrbit

    /// <summary>
    /// Прорисовка плоскости
    /// </summary>
    private void DrawGrid(double gridSize)
    {   
      if (ShowGrid)
      {
        gridSize *= 0.025;
        double AStep = 40.0;
        Gl.glColor3d(0.5, 0.5, 0.5);
        Gl.glLineWidth(1);
        for (double i = -gridSize; i <= gridSize; i++)
        {
          Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex3d(-gridSize * AStep, i * AStep, 0);
            Gl.glVertex3d(gridSize * AStep, i * AStep, 0);
          Gl.glEnd();
        }//for
        for (double i = -gridSize; i <= gridSize; i++)
        {
          Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex3d(i * AStep, -gridSize * AStep, 0);
            Gl.glVertex3d(i * AStep, gridSize * AStep, 0);
          Gl.glEnd();
        }// for
      }// if
    }// _DrawGrid

    // Public methods 
    /// <summary>
    /// Диалоговое окно параметров
    /// </summary>
    public override void ParamsDlg()
    {
      using(fmOrbit fmOrbitDlg = new fmOrbit())
      {
        //Параметры орбиты
        fmOrbitDlg.SemimajorAxis            = SemimajorAxis;
        fmOrbitDlg.Eccentricity             = Eccentricity;
        fmOrbitDlg.Inclination              = Inclination;
        fmOrbitDlg.ArgumentOfPeriapsis      = ArgumentOfPeriapsis;
        fmOrbitDlg.LongitudeOfAscendingNode = LongitudeOfAscendingNode;
        //Видимость орбиты и дополнительных элементов
        fmOrbitDlg.OrbitVisible      = Visible;
        fmOrbitDlg.ShowBaseOrbit     = ShowBaseOrbit;
        fmOrbitDlg.ShowBaseOrbitAxes = ShowBaseOrbitAxes;
        fmOrbitDlg.ShowAxes          = ShowAxes;
        fmOrbitDlg.ShowBoundsContour = ShowBoundsContour;
        fmOrbitDlg.ShowGrid          = ShowGrid;
        //Цвет орбиты
        fmOrbitDlg.OrbitColor        = Color;
        if (fmOrbitDlg.ShowDialog() == DialogResult.OK)
        {
          // Параметры орбиты
          SemimajorAxis            = fmOrbitDlg.SemimajorAxis;
          Eccentricity             = fmOrbitDlg.Eccentricity;
          Inclination              = fmOrbitDlg.Inclination;
          ArgumentOfPeriapsis      = fmOrbitDlg.ArgumentOfPeriapsis;
          LongitudeOfAscendingNode = fmOrbitDlg.LongitudeOfAscendingNode;
          // Видимость орбиты и дополнительных элементов
          Visible                  = fmOrbitDlg.OrbitVisible;
          ShowBaseOrbit            = fmOrbitDlg.ShowBaseOrbit;
          ShowBaseOrbitAxes        = fmOrbitDlg.ShowBaseOrbitAxes;
          ShowAxes                 = fmOrbitDlg.ShowAxes;
          ShowBoundsContour        = fmOrbitDlg.ShowBoundsContour;
          ShowGrid                 = fmOrbitDlg.ShowGrid;
          // Цвет орбиты
          Color                    = fmOrbitDlg.OrbitColor;
        }// if
      }// using
    }// ParamsDlg

    /// <summary>
    /// Общая прорисовка
    /// </summary>
    public override void Draw()
    {
      if (Visible)
      {
        Gl.glPushMatrix();
          DrawBoundsContour();
          Gl.glTranslated(Position.Vector.X, Position.Vector.Y, Position.Vector.Z);
          DrawGrid(SemimajorAxis);
          DrawBaseOrbit(SemimajorAxis, SemiminorAxis);
          DrawOrbit(SemimajorAxis, SemiminorAxis);
        Gl.glPopMatrix();
      }// if
    }// Draw

    // Public properties
    public double SemimajorAxis
    {
      get { return _semimajorAxis; }
      set
      {
        if (SemimajorAxis != value)
        {
          _semimajorAxis = value;
          DefineAdditionalOrbitElements();
          DefineBounds();
          Invalidate();
        }// if
      }// set
    }// SemimajorAxis

    public double SemiminorAxis
    {
      get { return _semiminorAxis; }
      set
      {
        if (SemiminorAxis != value)
        {
          _semiminorAxis = value;
          Invalidate();
        }// if
      }// set
    }// SemiminorAxis

    public double Inclination
    {
      get { return _inclination; }
      set
      {
        if (Inclination != value)
        {
          _inclination = EnsureAngle(value, 0.0, 180.0);
          DefineBounds();
          Invalidate();      
        }// if
      }// set
    }// Inclination

    public double LongitudeOfAscendingNode
    {
      get { return _longitudeOfAscendingNode; }
      set
      {
        if (LongitudeOfAscendingNode != value)
        {
          _longitudeOfAscendingNode = EnsureAngle(value, 0.0, 360.0);
          DefineBounds();
          Invalidate();
        }// if
      }// set
    }// LongitudeOfAscendingNode

    public double Eccentricity
    {
      get { return _eccentricity; }
      set
      {
        if ((Eccentricity != value) && (value >= 0.0 && value < 1.0))
        {
          _eccentricity = value;
          DefineAdditionalOrbitElements();
          DefineBounds();
          Invalidate();
        }// if
      }// set
    }// Eccentricity

    public double ArgumentOfPeriapsis
    {
      get { return _argumentOfPeriapsis; }
      set
      {
        if (ArgumentOfPeriapsis != value)
        {
          _argumentOfPeriapsis = EnsureAngle(value, 0.0, 360.0);
          DefineBounds();
          Invalidate();
        }// if
      }// set
    }// ArgumentOfPeriapsis

    public double MeanAnomaly
    {
      get { return _meanAnomaly; }
      set
      {
        if (MeanAnomaly != value)
        {
          _meanAnomaly = EnsureAngle(value, 0.0, 360.0);  
          DefineAdditionalOrbitElements();
          Invalidate();
        }// if
      }// set
    }// MeanAnomaly

    public bool ShowGrid
    {
      get { return _showGrid; }
      set
      {
        if (ShowGrid != value)
        {
          _showGrid = value;
          Invalidate();
        }// if
      }// set
    }// ShowGrid

    public bool ShowAxes
    {
      get { return _showAxes; }
      set
      {
        if (ShowAxes != value)
        {
          _showAxes = value;
          Invalidate();
        }// if
      }// set
    }// ShowAxes

    public bool ShowBaseOrbit
    {
      get { return _showBaseOrbit; }
      set
      {
        if (ShowBaseOrbit != value)
        {
          _showBaseOrbit = value;
          Invalidate();
        }// if
      }// set
    }// ShowBaseOrbit

    public bool ShowBaseOrbitAxes
    {
      get { return _showBaseOrbitAxes; }
      set
      {
        if (ShowBaseOrbitAxes != value)
        {
          _showBaseOrbitAxes = value;
          Invalidate();
        }// if
      }// set
    }// ShowBaseOrbitAxes

    public bool ShowBoundsContour
    {
      get { return _showBoundsContour; }
      set
      {
        if (ShowBoundsContour != value)
        {
          _showBoundsContour = value;
          Invalidate();
        }// if
      }// set
    }// ShowBoundsContour

  }// Orbit
}// namespace SunSensorSystem
