/*
Каратаев А.А.
aibek_karataeff@mail.ru
8-777-237-00-10
ДТОО "ИКТТ"
-----------------------------------------------------------
Модуль глобальных объектов - предков
-Общий предок
-Векторные операции
-Пользовательское положение
-Положение центра масс объекта
-Угловое положение объекта
-Пользовательский графический объект

1.Общий предок
2.Векторные операции
-Сложение и вычитание
-Векторное произведение, скалярное произведение
-Масштабирование
-Создание матрицы поворота
3.Пользовательское положение
-общий предок положения объекта
-событие изменения значений
4.Положение центра масс объекта
-перемещение в заданное положение
-перемещение на заданное расстояние 
5.Угловое положение объекта
-вращение в заданное положение
-вращение на заданный угол
6.Пользовательский графический объект
-цвет объекта
-видимость объекта
-прорисовка объекта
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

namespace SunSensorSystem
{
  // Вектор 3D ------------------------------------------------------------------
  public struct Vector3D
  {
    public double X, Y, Z;
  }// Vector3D

  // Цвет RGB
  public struct ColorRGB
  {
    public double R, G, B;
    // Constructor
    public ColorRGB(double red, double green, double blue)
    {
      this.R = red;
      this.G = green;
      this.B = blue;
    }
  }// ColorRGB

  // Сферические координаты -----------------------------------------------------
  public struct SphericalCoordinates
  {
    public double Azimuth, Zenith, Radius;
  }// SphericalCoordinates

  // Границы --------------------------------------------------------------------
  public struct Bounds
  {
    public double MinX, MaxX, MinY, MaxY, MinZ, MaxZ;
  }// Bounds

  // Размер экрана --------------------------------------------------------------
  public struct ScreenSize
  {
    public int Width, Height;
  }// ScreenSize
                          
  // Векторные операции ---------------------------------------------------------
  static class VectorOperations
  {
    // Public methods

    /// <summary>
    /// Установка значения трехмерного вектора
    /// </summary>
    public static Vector3D SetValue(double x, double y, double z)  // overload
    {
      Vector3D Result;
      Result.X = x;
      Result.Y = y;
      Result.Z = z;
      return Result;
    }// SetValue
    public static Vector3D SetValue()  // overload
    {
      return SetValue(0.0, 0.0, 0.0);
    }// SetValue
    public static Vector3D SetValue(Vector3D vector)  // overload
    {
      return SetValue(vector.X, vector.Y, vector.Z);
    }// SetValue

    /// <summary>
    /// Определение длины вектора
    /// </summary>
    public static double VectorLength(Vector3D vector)
    {
      return Math.Sqrt((vector.X * vector.X) + (vector.Y * vector.Y) + (vector.Z * vector.Z));
    }// VectorLength

    /// <summary>
    /// Нормализация вектора
    /// </summary>
    public static Vector3D NormalizeVector(Vector3D vector)
    {
      double vectorLength = VectorLength(vector);
      if (vectorLength != 0)
      {
        vectorLength = 1 / vectorLength;
        return SetValue(vector.X * vectorLength, vector.Y * vectorLength, vector.Z * vectorLength);
      }// if
      return SetValue(0.0, 0.0, 0.0);
    }// NormalizeVector

    /// <summary>
    /// Скалярное вычитание векторов
    /// </summary>
    public static Vector3D VectorSubstract(Vector3D vector1, Vector3D vector2)
    {           
      return SetValue(vector1.X - vector2.X, vector1.Y - vector2.Y, vector1.Z - vector2.Z);
    }// VectorSubstract

    /// <summary>
    /// Скалярное сложение векторов
    /// </summary>
    public static Vector3D VectorSum(Vector3D vector1, Vector3D vector2)
    {     
      return SetValue(vector1.X + vector2.X, vector1.Y + vector2.Y, vector1.Z + vector2.Z);
    }// VectorSum

    /// <summary>
    /// Векторное произведение векторов
    /// </summary>
    public static Vector3D VectorCrossProduct(Vector3D vector1, Vector3D vector2)
    {
      return SetValue(vector1.Y * vector2.Z - vector1.Z * vector2.Y,
                      vector1.Z * vector2.X - vector1.X * vector2.Z,
                      vector1.X * vector2.Y - vector1.Y * vector2.X);
    }// VectorCrossProduct
    
    /// <summary>
    /// Cкалярное произведение векторов
    /// </summary>
    public static double VectorDotProduct(Vector3D vector1, Vector3D vector2)
    {
      return ((vector1.X * vector2.X) + (vector1.Y * vector2.Y) + (vector1.Z * vector2.Z));
    }// VectorDotProduct

    /// <summary>
    /// Масштабирование вектора
    /// </summary>
    public static Vector3D ScaleVector(Vector3D vector, double factor)
    {
      return SetValue(vector.X * factor, vector.Y * factor, vector.Z * factor);
    }// ScaleVector

    /// <summary>
    /// Создание матрицы вращения
    /// </summary>
    public static double[,] CreateRotationMatrix(Vector3D axis, double angle)
    {
      double[,] result = new double[3, 3];
      double degToRad = Math.PI * angle / 180.0;
      double sin = Math.Sin(degToRad);                          
      double cos = Math.Cos(degToRad);
      axis = NormalizeVector(axis);
      // Первая строка
      result[0, 0] = ((1 - cos) * axis.X * axis.X) + cos;
      result[0, 1] = ((1 - cos) * axis.X * axis.Y) - (axis.Z * sin);
      result[0, 2] = ((1 - cos) * axis.Z * axis.X) + (axis.Y * sin);
      // Вторая строка
      result[1, 0] = ((1 - cos) * axis.X * axis.Y) + (axis.Z * sin);
      result[1, 1] = ((1 - cos) * axis.Y * axis.Y) + cos;
      result[1, 2] = ((1 - cos) * axis.Y * axis.Z) - (axis.X * sin);
      // Третья строка
      result[2, 0] = ((1 - cos) * axis.Z * axis.X) - (axis.Y * sin);
      result[2, 1] = ((1 - cos) * axis.Y * axis.Z) + (axis.X * sin);
      result[2, 2] = ((1 - cos) * axis.Z * axis.Z) + cos;
      return result;
    }// CreateRotationMatrix

    /// <summary>
    /// Умножение вектора на матрицу
    /// </summary>
    public static Vector3D VectorTransform(Vector3D vector, double[,] matrix)
    {
      return SetValue(vector.X * matrix[0, 0] + vector.Y * matrix[1, 0] + vector.Z * matrix[2, 0],
                      vector.X * matrix[0, 1] + vector.Y * matrix[1, 1] + vector.Z * matrix[2, 1],
                      vector.X * matrix[0, 2] + vector.Y * matrix[1, 2] + vector.Z * matrix[2, 2]);
    }// VectorTransform

    /// <summary>
    /// Вращение вектора вокруг заданной оси
    /// </summary>
    public static Vector3D RotateVector(Vector3D vector, Vector3D axis, double angle)
    {
      double[,] rotationMatrix = new double[3, 3];
      rotationMatrix = CreateRotationMatrix(axis, angle);   
      return VectorTransform(vector, rotationMatrix);
    }// RotateVector

    /// <summary>
    /// Вращение камеры вокруг объекта
    /// </summary>
    public static Vector3D MoveAroundTarget(Vector3D position, Vector3D viewPoint, double pitchDelta, double turnDelta)
    {
      double distance;
      Vector3D originalTargetToCamera, normalTargetToCamera, normalCameraRight, vectorZ, vectorX, newPosition;
      // Начальные значения для вектора взгляда
      normalTargetToCamera = SetValue();
      vectorX = SetValue(1, 0, 0);
      // Нормаль к плоскости XY
      vectorZ = SetValue(0, 0, 1);
      // Вектор взгляда
      originalTargetToCamera = VectorSubstract(position, viewPoint);
      normalTargetToCamera = SetValue(originalTargetToCamera);
      // Дистанция от точки наблюдения до точки положения камеры
      distance = VectorLength(normalTargetToCamera);
      // Нормализация вектора взгляда
      normalTargetToCamera = NormalizeVector(normalTargetToCamera);
      // Горизонтальная ось вращения 
      normalCameraRight = VectorCrossProduct(vectorZ, normalTargetToCamera);
      if (VectorLength(normalCameraRight) < 0.001)
        normalCameraRight = SetValue(vectorX);
      else
        normalCameraRight = NormalizeVector(normalCameraRight);
      // Вращение 
      normalTargetToCamera = RotateVector(normalTargetToCamera, normalCameraRight, -pitchDelta * 0.1);
      normalTargetToCamera = RotateVector(normalTargetToCamera, vectorZ, -turnDelta * 0.1);
      // Расстояние от точки наблюдения до точки положения камеры
      normalTargetToCamera = ScaleVector(normalTargetToCamera, distance);
      newPosition = VectorSum(position, VectorSubstract(normalTargetToCamera, originalTargetToCamera));
      return newPosition;
    }// MoveObjectAround

    /// <summary>
    /// Масштабирование вектора наблюдения камеры
    /// </summary>
    public static Vector3D AdjustDistanceToTarget(Vector3D position, Vector3D viewPoint, double distanceRatio)
    {
      Vector3D vector;
      vector = VectorSubstract(position, viewPoint);
      vector = ScaleVector(vector, -(1 - distanceRatio));
      vector = VectorSum(vector, position);
      return vector;
    }// AdjustDistanceFromObject
  }// VectorOperations

  // Пользовательский объект ----------------------------------------------------
  abstract class CustomObject
  {
    // Events
    public event EventHandler ChangeEvent;    // Событие изменения значения объекта

    // Constructor
    public CustomObject()
      : base()
    {
      this.ChangeEvent = null;
    }

    // Protected methods
    /// <summary>
    /// Метод, генерирующий событие изменения объекта
    /// </summary>
    protected void OnChangeEvent()
    {
      if (ChangeEvent != null)
        ChangeEvent(this, EventArgs.Empty);
    }// OnChangeEvent 
  }// CustomObject

  // Границы графического объекта -----------------------------------------------
  class ObjectBounds : CustomObject
  {
    // Private fields
    // Границы графического объекта
    private double _minX;    // Минимальное  значение границы по оси X, мировые координаты
    private double _maxX;    // Максимальное значение границы по оси X, мировые координаты
    private double _minY;    // Минимальное  значение границы по оси Y, мировые координаты
    private double _maxY;    // Максимальное значение границы по оси Y, мировые координаты
    private double _minZ;    // Минимальное  значение границы по оси Z, мировые координаты
    private double _maxZ;    // Максимальное значение границы по оси Z, мировые координаты

    // Constructor
    public ObjectBounds()
      : base()
    {
      this._minX = 0.0;
      this._maxX = 0.0;
      this._minY = 0.0;
      this._maxY = 0.0;
      this._minZ = 0.0;
      this._maxZ = 0.0;
    }

    // Public methods 
    /// <summary>
    /// Изменение границ графического объекта
    /// </summary>
    public void SetBounds(double minX, double maxX, double minY, double maxY, double minZ, double maxZ)
    {
      if ( (minX <= maxX) && (minY <= maxY) && (minZ <= maxZ)
      && ( (MinX != minX) || (MaxX != maxX) || (MinY != minY) || (MaxY != maxY) || (MinZ != minZ) || (MaxZ != maxZ) ) )
      {
        _minX = minX;
        _maxX = maxX;
        _minY = minY;
        _maxY = maxY;
        _minZ = minZ;
        _maxZ = maxZ;
        OnChangeEvent();
      }// if
    }// SetBounds

    // Public properties
    public double MinX
    {
      get { return _minX; }
      set { SetBounds(value, MaxX, MinY, MaxY, MinZ, MaxZ); }
    }// MinX

    public double MaxX
    {
      get { return _maxX; }
      set { SetBounds(MinX, value, MinY, MaxY, MinZ, MaxZ); }
    }// MaxX

    public double MinY
    {
      get { return _minY; }
      set { SetBounds(MinX, MaxX, value, MaxY, MinZ, MaxZ); }
    }// MinY

    public double MaxY
    {
      get { return _maxY; }
      set { SetBounds(MinX, MaxX, MinY, value, MinZ, MaxZ); }
    }// MaxY

    public double MinZ
    {
      get { return _minZ; }
      set { SetBounds(MinX, MaxX, MinY, MaxY, value, MaxZ); }
    }// MinZ

    public double MaxZ
    {
      get { return _maxZ; }
      set { SetBounds(MinX, MaxX, MinY, MaxY, MinZ, value); }
    }// MaxZ
  }// ObjectBounds

  // Пользовательское положение -------------------------------------------------
  abstract class CustomPosition3D : CustomObject
  {
    // Private fields 
    private Vector3D _vector;    // Вектор 3D  

    // Constructor 
    public CustomPosition3D()
      : base()
    {
      this._vector = new Vector3D();
    }
   
    // Public properties 
    public Vector3D Vector
    {
      get { return _vector; }
      set
      {
        _vector = value;
        OnChangeEvent();
      }// set
    }// Vector
  }// CustomPosition3D

  // Положение центра масс объекта ----------------------------------------------
  class Position3D : CustomPosition3D
  {
    // Constructor
    public Position3D() 
      : base() { }

    // Public methods 
    // Перемещение в заданное положение
    public void MoveTo(double x, double y, double z)
    {
      Vector = VectorOperations.SetValue(x, y, z);
    }// MoveTo

    // Перемещение на заданное расстояние
    public void MoveBy(double deltaX, double deltaY, double deltaZ)
    {
      Vector = VectorOperations.SetValue(Vector.X + deltaX, Vector.Y + deltaY, Vector.Z + deltaZ);
    }// MoveBy                        
  }// Position3D

  // Угловое положение объекта --------------------------------------------------
  class AngularPosition3D : CustomPosition3D
  {
    // Constructor
    public AngularPosition3D() 
      : base() { }

    // Public methods
    // Вращение объекта в заданное угловое положение
    public void RotateTo(double x, double y, double z)
    {
      Vector = VectorOperations.SetValue(x, y, z);
    }// RotateTo

    // Вращение объекта на заданный угол
    public void RotateBy(double deltaX, double deltaY, double deltaZ)
    {
      Vector = VectorOperations.SetValue(Vector.X + deltaX, Vector.Y + deltaY, Vector.Z + deltaZ);
    }// RotateBy
  }// AngularPosition3D

  // Пользовательский графический объект ----------------------------------------
  abstract class CustomGraphObject : CustomObject
  {
    // Private fields
    private ColorRGB _color;                        // Цвет графического объекта RGB
    private ColorRGB _contourColor;                 // Цвет контура графического объекта RGB
    private bool _visible;                          // Видимость объекта
    private ObjectBounds _bounds;                   // Границы графического объекта
    private Position3D _position;                   // Положение графического объекта  
    // Events
    public event EventHandler BoundsChangeEvent;    // Событие изменения границ объекта

    // Constructor
    public CustomGraphObject()
      : base()
    {
      // Цвет графического объекта
      this._color = new ColorRGB();
      // Цвет контура графического объекта
      this._contourColor = new ColorRGB(0.5, 0.5, 0.5);
      // Видимость объекта            
      this._visible = true;
      // Границы графического объекта
      this._bounds = new ObjectBounds();
      this.Bounds.ChangeEvent += BoundsChangeHandler;
      // Положение графического объекта
      this._position = new Position3D();
      this.Position.ChangeEvent += PositionChangeHandler;
    }// Constructor

    // Private methods
    /// <summary>
    /// Обработчик события изменения границ графического объекта
    /// </summary>
    private void BoundsChangeHandler(object sender, EventArgs arg)
    {
      OnBoundsChangeEvent();
    }// BoundsChangeHandler

    /// <summary>
    /// Обработчик события изменения положения графического объекта
    /// </summary>
    private void PositionChangeHandler(object sender, EventArgs arg)
    {
      OnPositionChangeEvent();
    }// PositionChangeHandler

    // Protected methods
    /// <summary>
    /// Метод, генерирующий событие изменения границ объекта
    /// </summary>
    protected virtual void OnBoundsChangeEvent()
    {
      if (BoundsChangeEvent != null)
        BoundsChangeEvent(this, EventArgs.Empty);
    }// OnBoundsChangeEvent

    /// <summary>
    /// Перерисовка сцены (на случай, если таймер отключен)
    /// </summary>
    protected virtual void Invalidate()
    {
    }

    /// <summary>
    /// Метод, генерирующий событие изменения положения объекта
    /// </summary>
    protected abstract void OnPositionChangeEvent();
    
    // Public methods
    /// <summary>
    /// Прорисовка объекта
    /// </summary>
    public abstract void Draw();

    /// <summary>
    /// Установка цвета графического объекта
    /// </summary>
    public void SetColor(double red, double green, double blue)
    {
      if ( ( (Color.R != red) || Color.G != green || (Color.B != blue) ) && ( ((red >= 0.0) && (red <= 1.0)) || ((green >= 0.0) && (green <= 1.0)) || ((blue >= 0.0) && (blue <= 1.0)) ) )
      {
        _color.R = red;
        _color.G = green;
        _color.B = blue;
        Invalidate();
      }// if
    }// SetColor

    // Public properties
    public ColorRGB Color
    {
      get { return _color; }
      set { SetColor(value.R, value.G, value.B); }
    }// Color

    public ColorRGB ContourColor
    {
      get { return _contourColor; }
      set
      {
        if ( ( (ContourColor.R != value.R) || (ContourColor.G != value.G) || (ContourColor.B != value.B) ) && ( ((value.R >= 0.0) && (value.R <= 1.0)) || ((value.G >= 0.0) && (value.G <= 1.0)) || ((value.B >= 0.0) && (value.B <= 1.0)) ) )
        {
          _contourColor = value;
          Invalidate();
        }// if
      }// set
    }// ContourColor

    public bool Visible
    {
      get { return _visible; }
      set
      {
        if (Visible != value)
        {
          _visible = value;
          Invalidate();
        }// if
      }// set
    }// Visible

    public ObjectBounds Bounds
    {
      get { return _bounds; }
    }// Bounds

    public Position3D Position
    {
      get { return _position; }
    }// Position
  }// CustomGraphObject

  // Графический объект ---------------------------------------------------------
  abstract class GraphObject : CustomGraphObject
  {
    // Constructor
    public GraphObject() 
      : base() { }

    // Protected methods
    /// <summary>
    /// Определение контура графического объекта
    /// </summary>
    protected abstract void DefineBounds();

    // Public methods
    /// <summary>
    /// Диалоговое окно параметров графического объекта
    /// </summary>
    public abstract void ParamsDlg();

  }// GraphObject
}// namespace SunSensorSystem
