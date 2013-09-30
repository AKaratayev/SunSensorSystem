/*
Каратаев А.А.
aibek_karataeff@mail.ru
8-777-237-00-10
ДТОО "ИКТТ" 
-------------------------------------------------------
Модуль графической сцены
-Графическая сцена
-Камера графичесой сцены

1.Графическая сцена
-настройка параметров отображения
-прорисовка графических объектов
2.Камера графической сцены
-расчет положения и точки наблюдения камеры
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
  // Графическая сцена -----------------------------------------------------------------------------
  class Scene : CustomObject
  {
    // Private fields     
    // Дескриптор окна                    
    private SimpleOpenGlControl _HWnd;     // Дескриптор окна
    //Размеры экрана
    private ScreenSize _screenSize;        // Размеры экрана, пиксел
    //Куб данных 
    private Bounds _cubeBounds;            // Границы куба данных, мировые координаты
    //Дальняя плоскость отсечения
    private double _frustumFarPlane;       // Дальняя плоскость отсечения
    //Цвет фона
    private ColorRGB _foreColor;           // Цвет фона RGB
    //Контур куба данных
    private bool _showCube;                // Видимость контура куба данных
    private bool _showCubeAxes;            // Видимость осей куба данных
    //Массив объектов
    private GraphObjects _graphObjects;    // Список графическких объектов
    //Камера  
    private  Camera _сamera;               // Камера            
  
    // Constructor
    public Scene(SimpleOpenGlControl openGLControl)
    {
      // Инициализация графического окна
      this._HWnd = openGLControl;
      this.HWnd.InitializeContexts();
      // Размер области прорисовки в экранных координатах
      this._screenSize.Width = HWnd.Width;
      this._screenSize.Height = HWnd.Height;
      // Куб данных
      this._cubeBounds.MinX = 0.0;
      this._cubeBounds.MaxY = 0.0;
      this._cubeBounds.MinY = 0.0;
      this._cubeBounds.MaxY = 0.0;
      this._cubeBounds.MinZ = 0.0;
      this._cubeBounds.MaxZ = 0.0;
      // Дальняя плоскость отсечения
      this._frustumFarPlane = 0.0;
      // Цвет фона RGB
      this._foreColor = new ColorRGB();
      this._showCube = true;
      this._showCubeAxes = true;
      // Графические Объекты
      this._graphObjects = new GraphObjects();
      this.GraphObjects.ChangeEvent += ObjectsChangeHandler;
      // Камера
      this._сamera = new Camera();
      this.Camera.RenderEvent += CameraRenderHandler;
      this.Camera.ChangeEvent += CameraChangeHandler;
      // Системные функции сцены
      this.glInit();
      this.glRender();
    }// Constructor

    // Protected methods
    /// <summary>
    /// Установка начальных параметров визуализации
    /// </summary>
    protected void glInit()
    {
      // Инициализация графической библиотеки
      Glut.glutInit();
      Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
      // Параметры OpenGL для визуализации
      Gl.glEnable(Gl.GL_COLOR_MATERIAL);
      Gl.glEnable(Gl.GL_DEPTH_TEST);
      Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);  // Улучшение вывода перспективы
      Gl.glClearDepth(1.0);	   	                                   // Разрешить очистку буфера глубины
      Gl.glDepthFunc(Gl.GL_LESS);	                                 // Тип теста глубины
      Gl.glShadeModel(Gl.GL_SMOOTH);                               // разрешить плавное цветовое сглаживание
      // Инициализация шрифта
      glBitmapFont();
    }// glInit

    /// <summary>
    /// Рендеринг сцены
    /// </summary>
    protected void glRender()
    {
      // Расчет дальней плоскости отсечения
      double ADistance1 = Math.Sqrt(Math.Pow((CubeBounds.MaxX - CubeBounds.MinX), 2)
                                  + Math.Pow((CubeBounds.MaxY - CubeBounds.MinY), 2)
                                  + Math.Pow((CubeBounds.MaxZ - CubeBounds.MinZ), 2)) * 2;

      double ADistance2 = Math.Sqrt((Camera.Position.X * Camera.Position.X) 
                                  + (Camera.Position.Y * Camera.Position.Y)
                                  + (Camera.Position.Z * Camera.Position.Z)) + ADistance1 * 0.5;

      if (ADistance1 > ADistance2)
        _frustumFarPlane = 2 * ADistance1;
      else
        _frustumFarPlane = 2 * ADistance2;
      // Порта вывода в соотвествии с размерами окна
      Gl.glViewport(0, 0, ScreenSize.Width, ScreenSize.Height);
      // Матрица проекции   
      Gl.glMatrixMode(Gl.GL_PROJECTION);
      Gl.glLoadIdentity();
      // Установка параметров перспективы
      Glu.gluPerspective(Camera.FieldOfView, ScreenSize.Width / ScreenSize.Height, 0.1, FrustumFarPlane);
      // Видовая матрица
      Gl.glMatrixMode(Gl.GL_MODELVIEW);
      Gl.glLoadIdentity();
    }// glRender

    /// <summary>
    /// Инициализация шрифта
    /// </summary>
    protected void glBitmapFont()
    {
    }// glBitmapFont

    // Private methods
    /// <summary>
    /// Обработчик события изменения параметров камеры
    /// </summary>
    private void CameraRenderHandler(object sender, EventArgs arg)
    {
      glRender();
    }// CameraRenderHandler

    /// <summary>
    /// Обработчик события изменения положения и точки наблюдения камеры
    /// </summary>
    private void CameraChangeHandler(object sender, EventArgs arg)
    {
      Draw();
      OnChangeEvent();
    }// CameraChangeHandler

    /// <summary>
    ///  Обработчик события изменения состояния графических объектов
    /// </summary>
    private void ObjectsChangeHandler(object sender, EventArgs arg)
    {
      DrawObjects();
    }// ObjectsChangeHandler

    // Protected methods
    /// <summary>
    /// Прорисовка всех графических объектов
    /// </summary>
    protected void DrawObjects()
    {
      foreach (GraphObject item in GraphObjects.Items)
      {
        // Загрузка ID объектов в буфер
        Gl.glLoadName(GraphObjects.Items.IndexOf(item));
        item.Draw();    
      }// foreach
    }// _DrawObjects

    /// <summary>
    /// Прорисовка границ сцены
    /// </summary>
    protected void DrawCubeContour()
    {
      if (ShowCube)
      {
        Gl.glPushMatrix();
          Gl.glColor3d(0.5, 0.5, 0.5);
          Gl.glLineWidth(1);
          Gl.glBegin(Gl.GL_LINES);
            // Верхняя грань        
            Gl.glVertex3d(CubeBounds.MaxX, CubeBounds.MaxY, CubeBounds.MaxZ);
            Gl.glVertex3d(CubeBounds.MinX, CubeBounds.MaxY, CubeBounds.MaxZ);
            Gl.glVertex3d(CubeBounds.MinX, CubeBounds.MaxY, CubeBounds.MaxZ);
            Gl.glVertex3d(CubeBounds.MinX, CubeBounds.MinY, CubeBounds.MaxZ);
            Gl.glVertex3d(CubeBounds.MinX, CubeBounds.MinY, CubeBounds.MaxZ);
            Gl.glVertex3d(CubeBounds.MaxX, CubeBounds.MinY, CubeBounds.MaxZ);
            Gl.glVertex3d(CubeBounds.MaxX, CubeBounds.MinY, CubeBounds.MaxZ);
            Gl.glVertex3d(CubeBounds.MaxX, CubeBounds.MaxY, CubeBounds.MaxZ);
          Gl.glEnd();
          Gl.glBegin(Gl.GL_LINES);
            // Нижняя грань
            Gl.glVertex3d(CubeBounds.MaxX, CubeBounds.MaxY, CubeBounds.MinZ);
            Gl.glVertex3d(CubeBounds.MinX, CubeBounds.MaxY, CubeBounds.MinZ);
            Gl.glVertex3d(CubeBounds.MinX, CubeBounds.MaxY, CubeBounds.MinZ);
            Gl.glVertex3d(CubeBounds.MinX, CubeBounds.MinY, CubeBounds.MinZ);
            Gl.glVertex3d(CubeBounds.MinX, CubeBounds.MinY, CubeBounds.MinZ);
            Gl.glVertex3d(CubeBounds.MaxX, CubeBounds.MinY, CubeBounds.MinZ);
            Gl.glVertex3d(CubeBounds.MaxX, CubeBounds.MinY, CubeBounds.MinZ);
            Gl.glVertex3d(CubeBounds.MaxX, CubeBounds.MaxY, CubeBounds.MinZ);
          Gl.glEnd();
          Gl.glBegin(Gl.GL_LINES);
            // Боковые ребра
            Gl.glVertex3d(CubeBounds.MaxX, CubeBounds.MaxY, CubeBounds.MaxZ);
            Gl.glVertex3d(CubeBounds.MaxX, CubeBounds.MaxY, CubeBounds.MinZ);
            Gl.glVertex3d(CubeBounds.MinX, CubeBounds.MaxY, CubeBounds.MaxZ);
            Gl.glVertex3d(CubeBounds.MinX, CubeBounds.MaxY, CubeBounds.MinZ);
            Gl.glVertex3d(CubeBounds.MinX, CubeBounds.MinY, CubeBounds.MaxZ);
            Gl.glVertex3d(CubeBounds.MinX, CubeBounds.MinY, CubeBounds.MinZ);
            Gl.glVertex3d(CubeBounds.MaxX, CubeBounds.MinY, CubeBounds.MaxZ);
            Gl.glVertex3d(CubeBounds.MaxX, CubeBounds.MinY, CubeBounds.MinZ);
          Gl.glEnd();
        Gl.glPopMatrix();
      }// if
      // Координатные оси
      if (ShowCubeAxes)
      {
        Gl.glPushMatrix();
          // Координатные оси
          Gl.glTranslated(((CubeBounds.MaxX + CubeBounds.MinX) * 0.5), ((CubeBounds.MaxY + CubeBounds.MinY) * 0.5), ((CubeBounds.MaxZ + CubeBounds.MinZ) * 0.5));
          // Ось x
          Gl.glColor3d(1.0, 0.0, 0.0);
          Gl.glLineWidth(2);
          Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex3d(0.0, 0.0, 0.0);
            Gl.glVertex3d(CubeBounds.MaxX * 0.5, 0.0, 0.0);
          Gl.glEnd();
          // Ось y
          Gl.glColor3d(0.0, 1.0, 0.0);
          Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex3d(0.0, 0.0, 0.0);
            Gl.glVertex3d(0.0, CubeBounds.MaxY * 0.5, 0.0);
          Gl.glEnd();
          // Ось z
          Gl.glColor3d(0.0, 0.0, 1.0);
          Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex3d(0.0, 0.0, 0.0);
            Gl.glVertex3d(0.0, 0.0, CubeBounds.MaxZ * 0.5);
          Gl.glEnd();
          // Метка оси x
          Gl.glColor3d(1.0, 0.0, 0.0);
          Gl.glRasterPos3d(CubeBounds.MaxX * 0.5, (CubeBounds.MaxY * 0.5) * 0.1, 0.0);
          Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_HELVETICA_18, 'x');
          // Метка оси y
          Gl.glColor3d(0.0, 1.0, 0.0);
          Gl.glRasterPos3d((CubeBounds.MaxX * 0.5) * 0.1, CubeBounds.MaxY * 0.5, 0.0);
          Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_HELVETICA_18, 'y');
          // Метка оси z
          Gl.glColor3d(0.0, 0.0, 1.0);
          Gl.glRasterPos3d(0.0, (CubeBounds.MaxY * 0.5) * 0.1, CubeBounds.MaxZ * 0.5);
          Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_HELVETICA_18, 'z');
          // Центр куба       
          Gl.glColor3d(0.5, 0.3, 0.7);
          Glut.glutSolidSphere(CubeBounds.MaxX * 0.01, 30, 30);
        Gl.glPopMatrix();
      }// if      
    }// _DrawCubeContour 

    // Public methods
    /// <summary>
    /// Установка границ сцены
    /// </summary>
    public void SetCubeBounds(double minX, double maxX, double minY, double maxY, double minZ, double maxZ)
    {
      if ( (minX <= maxX) && (minY <= maxY) && (minZ <= maxZ)
      && ( (CubeBounds.MinX != minX) || (CubeBounds.MaxX != maxX) || (CubeBounds.MinY != minY) || (CubeBounds.MaxY != maxY) || (CubeBounds.MinZ != minZ) || (CubeBounds.MaxZ != maxZ) ) )
      {
        _cubeBounds.MinX = minX;
        _cubeBounds.MaxX = maxX;
        _cubeBounds.MinY = minY;
        _cubeBounds.MaxY = maxY;
        _cubeBounds.MinZ = minZ;
        _cubeBounds.MaxZ = maxZ;
        glRender();
      }// if
    }// SetCubeBounds

    /// <summary>
    /// Установка границ экранных координат
    /// </summary>
    public void SetScreenSize(int screenWidth, int screenHeight)
    {
      if ( (screenWidth > 0 && screenHeight > 0) && ( (ScreenSize.Width != screenWidth) || (ScreenSize.Height != screenHeight) ) )
      {
        _screenSize.Width = screenWidth;
        _screenSize.Height = screenHeight;
        glRender();
      }// if
    }// SetScreenSize

    /// <summary>
    /// Прорисовка сцены
    /// </summary>
    public void Draw()
    {
      try
      {
        Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
        // Цвет фона  
        Gl.glClearColor((float)ForeColor.R, (float)ForeColor.G, (float)ForeColor.B, 1.0f);
        Gl.glLoadIdentity();
        // Камера
        Glu.gluLookAt(Camera.Position.X, Camera.Position.Y, Camera.Position.Z,
                      Camera.ViewPoint.X, Camera.ViewPoint.Y, Camera.ViewPoint.Z,
                      0, 0, 1);
        // Прорисовка границ сцены
        DrawCubeContour();
        // Прорисовка всех графических объектов
        DrawObjects();
        // Перерисовка кадра
        HWnd.Invalidate();
      }// try
      catch
      {
        throw new Exception();
      }// catch
    }// Draw

    /// <summary>
    /// Диалоговое окно параметров сцены
    /// </summary>
    public void ParamsDlg()
    {
      using(fmParams fmParamsDlg = new fmParams())
      {
        bool showCube, showCubeAxes;
        ColorRGB foreColor = new ColorRGB();
        SphericalCoordinates sphericalCoords;
        //Параметры сцены
        showCube     = ShowCube;
        showCubeAxes = ShowCubeAxes;
        foreColor    = ForeColor;
        //Параметры камеры
        sphericalCoords.Azimuth = Camera.SphericalCoords.Azimuth;
        sphericalCoords.Zenith  = Camera.SphericalCoords.Zenith;
        sphericalCoords.Radius  = Camera.SphericalCoords.Radius;
        //Инициализация элементов управления
        fmParamsDlg.SetParams(showCube, showCubeAxes, foreColor, sphericalCoords.Azimuth, sphericalCoords.Zenith, sphericalCoords.Radius);
        if (fmParamsDlg.ShowDialog() == DialogResult.OK)
        {
          //Параметры сцены
          fmParamsDlg.GetParams(out _showCube, out _showCubeAxes, out _foreColor, out sphericalCoords.Azimuth, out sphericalCoords.Zenith, out sphericalCoords.Radius);
          // Параметры камеры
          Camera.SetPositionBySphericalCoords(sphericalCoords.Azimuth, sphericalCoords.Zenith, sphericalCoords.Radius);
        }// if
      }// using  
    }// ParamsDlg

    /// <summary>
    /// Центрировать камеру относительно сцены
    /// </summary>
    public void CameraCentered()
    {
      Vector3D position, viewpoint;
      // Установка положения камеры
      position.X = (CubeBounds.MaxX - CubeBounds.MinX) * 1.2;
      position.Y = (CubeBounds.MaxY - CubeBounds.MinY) * 1.2;
      position.Z = (CubeBounds.MaxZ - CubeBounds.MinZ) * 1.2;
      // Установка взгляда камеры в центр сцены
      viewpoint.X = (CubeBounds.MaxX + CubeBounds.MinX) * 0.5;
      viewpoint.Y = (CubeBounds.MaxY + CubeBounds.MinY) * 0.5;
      viewpoint.Z = (CubeBounds.MaxZ + CubeBounds.MinZ) * 0.5;
      Camera.Position = position;
      Camera.ViewPoint = viewpoint;
    }// CameraCentered

    /// <summary>
    /// Расчет границ сцены
    /// </summary>
    public void DefineCubeBounds()
    {
      // Границы первого объекта
      double boundMinX = GraphObjects.Items[0].Bounds.MinX;
      double boundMaxX = GraphObjects.Items[0].Bounds.MaxX;
      double boundMinY = GraphObjects.Items[0].Bounds.MinY;
      double boundMaxY = GraphObjects.Items[0].Bounds.MaxY;
      double boundMinZ = GraphObjects.Items[0].Bounds.MinZ;
      double boundMaxZ = GraphObjects.Items[0].Bounds.MaxZ;
      // Сравнивание с границами всех графических объектов
      foreach (GraphObject go in GraphObjects.Items)
      {
        if (boundMinX > go.Bounds.MinX)
          boundMinX = go.Bounds.MinX;
        if (boundMaxX < go.Bounds.MaxX)
          boundMaxX = go.Bounds.MaxX;
        if (boundMinY > go.Bounds.MinY)
          boundMinY = go.Bounds.MinY;
        if (boundMaxY < go.Bounds.MaxY)
          boundMaxY = go.Bounds.MaxY;
        if (boundMinZ > go.Bounds.MinZ)
          boundMinZ = go.Bounds.MinZ;
        if (boundMaxZ < go.Bounds.MaxZ)
          boundMaxZ = go.Bounds.MaxZ;
      }// foreach
      // Пересчет границ куба данных
      SetCubeBounds(boundMinX, boundMaxX, boundMinY, boundMaxY, boundMinZ, boundMaxZ);
      // Центрировать камеру
      CameraCentered();
    }// DefineCubeBounds

    /// <summary>
    /// Выделение графических объектов мышью
    /// </summary>
    public void SelectGraphObject(int cursorPosX, int cursorPosY)
    {
      GraphObjects.Select(cursorPosX, cursorPosY, ScreenSize.Width, ScreenSize.Height, Camera.FieldOfView, FrustumFarPlane);
    }// SelectObject

    // Public properties 
    public SimpleOpenGlControl HWnd
    {
      get { return _HWnd; }
    }// HWnd

    public ScreenSize ScreenSize
    {
      get { return _screenSize; }
      set { SetScreenSize(value.Width, value.Height); }
    }// ScreenSize

    public Bounds CubeBounds
    {
      get { return _cubeBounds; }
      set { SetCubeBounds(value.MinX, value.MaxX, value.MinY, value.MaxY, value.MinZ, value.MaxZ); }
    }// CubeBounds

    public double FrustumFarPlane
    {
      get { return _frustumFarPlane; }
      set
      {
        if (_frustumFarPlane != value)
          _frustumFarPlane = value;
      }// set
    }// FrustumFarPlane

    public ColorRGB ForeColor
    {
      get { return _foreColor; }
      set
      {
        if ( ( (ForeColor.R != value.R) || (ForeColor.G != value.G) || (ForeColor.B != value.B) ) && ( ((value.R >= 0.0) && (value.R <= 1.0)) || ((value.G >= 0.0) && (value.G <= 1.0)) || ((value.B >= 0.0) && (value.B <= 1.0)) ) )
          _foreColor = value;
      }// set
    }// ForeColor

    public bool ShowCube
    {
      get { return _showCube; }
      set
      {
        if (ShowCube != value)
          _showCube = value;
      }// set
    }// ShowCube

    public bool ShowCubeAxes
    {
      get { return _showCubeAxes; }
      set
      {
        if (ShowCubeAxes != value)
          _showCubeAxes = value;
      }// set
    }// ShowCubeAxes

    public GraphObjects GraphObjects
    {
      get { return _graphObjects; }
    }// GraphObjects

    public Camera Camera
    {
      get { return _сamera; }
    }// Camera

    public System.Windows.Forms.Cursor Cursor
    {
      get { return _HWnd.Cursor; }
      set
      {
        if (_HWnd.Cursor != value)
          _HWnd.Cursor = value;
      }// set
    }// Cursor
  }// Scene

  //Камера ----------------------------------------------------------------------------------------
  class Camera : CustomObject
  {
    // Private fields
    // Основные параметры камеры
    private Vector3D _position;                           // Положение в пространстве     
    private Vector3D _viewPoint;                          // Точка взгляда 
    private double _fieldOfView;                          // Угол обзора, град
    // Сферические координаты камеры             
    private SphericalCoordinates _sphericalCoords;        // Сферические координаты камеры       
    // Константные значения
    private const double MIN_FOV    = 45.0;          
    private const double MAX_FOV    = 120.0;
    private const double RAD_TO_DEG = 180.0 / Math.PI;    
    // Events
    public event EventHandler RenderEvent;                // Событие параметрирования графической сцены

    // Constructor
    public Camera()
    {
      // Начальная точка положения
      _position = VectorOperations.SetValue(0.0, 0.0, 0.0);
      // Начальная точка наблюдения
      _viewPoint = VectorOperations.SetValue(0.0, 0.0, 0.0);
      // Угол обзора
      _fieldOfView = 60.0;
      // Сферические координаты
      _sphericalCoords.Azimuth = 0.0;
      _sphericalCoords.Zenith  = 0.0;
      _sphericalCoords.Radius  = 0.0;
      RenderEvent = null;
    }// Constructor

    //Protected methods
    /// <summary>
    /// Метод, генерирующий событие перерисовки сцены 
    /// </summary>
    protected void OnRenderEvent()
    {
      if (RenderEvent != null)
        RenderEvent(this, EventArgs.Empty);
    }// OnRenderEvent

    /// <summary>
    /// Определение сферических координат камеры из декартовых
    /// </summary>
    protected void DefineSphericalCoordsFromPosition()
    {
      _sphericalCoords.Radius = VectorOperations.VectorLength(Position);
      _sphericalCoords.Zenith  = Math.Acos(Position.Z / SphericalCoords.Radius) * RAD_TO_DEG;
      _sphericalCoords.Azimuth = Math.Atan2(Position.Y, Position.X) * RAD_TO_DEG;
    }// DefineSphericalCoordsFromPosition

    // Public methods
    /// <summary>
    /// Установка положения камеры с помощью сферических координат
    /// </summary>
    public void SetPositionBySphericalCoords(double azimuth, double zenith, double radius)
    {

      Position = VectorOperations.SetValue(radius * Math.Sin(zenith * Math.PI / 180) * Math.Cos(azimuth * Math.PI / 180),
                                           radius * Math.Sin(zenith * Math.PI / 180) * Math.Sin(azimuth * Math.PI / 180),
                                           radius * Math.Cos(zenith * Math.PI / 180));
    }// SetPositionBySphericalCoords

    /// <summary>
    /// Масштабирование
    /// </summary>
    public void AdjustDistanceToTarget(double distanceRatio)
    {
      Position = VectorOperations.AdjustDistanceToTarget(Position, ViewPoint, Math.Pow(1.1, distanceRatio / 120.0));
    }// AdjustDistanceToTarget

    /// <summary>
    /// Вращение камеры вокруг объекта
    /// </summary>
    public void MoveAroundTarget(double pitchDelta, double turnDelta)
    {
      Position = VectorOperations.MoveAroundTarget(Position, ViewPoint, pitchDelta, turnDelta);
    }// MoveAroundTarget

    // Public properties
    public Vector3D Position
    {
      get { return _position; }
      set
      {
        _position = value;
        DefineSphericalCoordsFromPosition();
        OnChangeEvent();
      }// set
    }// Position

    public Vector3D ViewPoint
    {
      get { return _viewPoint; }
      set
      {
        _viewPoint = value;
        OnChangeEvent();
      }
    }//ViewPoint

    //public properties 
    public double FieldOfView
    {
      get { return _fieldOfView; }
      set
      {
        if ((FieldOfView != value) && (value >= MIN_FOV && value <= MAX_FOV))
        {
          _fieldOfView = value;
          OnRenderEvent();
        }// if
      }// if
    }// FieldOfView

    public SphericalCoordinates SphericalCoords
    {
      get { return _sphericalCoords; }
    }//SphericalCoords

  }//TkaaCamera
      
  //Объекты ---------------------------------------------------------------------------------------
  class GraphObjects : CustomObject
  {
    // Private fields
    private List<GraphObject> _items;    // Список объектов
    private int _selectIndex;            // Индекс выбранного объекта

    // Constructor
    public GraphObjects()
    {
      // Список объектов
      _items = new List<GraphObject>();
      // Индекс выбранного объекта
      _selectIndex = -1;
    }// Constructor

    // Public methods
    /// <summary>
    /// Добавление объекта в список
    /// </summary>
    public void Add(GraphObject graphObj)
    {
      _items.Add(graphObj);
    }// Add

    /// <summary>
    /// Очистка списка объектов
    /// </summary>
    public void Clear()
    {
      _items.Clear();
    }// Clear

    /// <summary>
    /// Выделение графического объекта мышью
    /// </summary>
    public void Select(int cursorPosX, int cursorPosY, int screenWidth, int screenHeight, double fieldOfView, double frustumFarPlane)
    {
      int[] bufferSize = new int[1024];    //Размер буфера 
      int[] viewPort = new int[4];         //Параметры видового порта
      int foundObject;                     //Выбранный объект
      // Определение буфера, содержащего объекты
      Gl.glSelectBuffer(1024, bufferSize);
      // Получение параметров видового порта
      Gl.glGetIntegerv(Gl.GL_VIEWPORT, viewPort);
      // Переход в режим выбора
      Gl.glRenderMode(Gl.GL_SELECT);
      // Очищение стека имен объектов
      // Данный стек содержит всю информацию об объектах
      Gl.glInitNames();
      // Инициализация стека имен
      Gl.glPushName(0);
      // Матрица проекции
      Gl.glMatrixMode(Gl.GL_PROJECTION);
      Gl.glPushMatrix();
      Gl.glLoadIdentity();
      // Определение области выбора вокруг курсора мыши
      Glu.gluPickMatrix(cursorPosX, cursorPosY, 15.0, 15.0, viewPort);
      // Определение параметров перспективы
      Glu.gluPerspective(fieldOfView, screenWidth / screenHeight, 0.1, frustumFarPlane);
      // Видовая матрица
      Gl.glMatrixMode(Gl.GL_MODELVIEW);
      // Прорисока объектов сцены
      OnChangeEvent();
      // Матрица проекции
      Gl.glMatrixMode(Gl.GL_PROJECTION);
      Gl.glPopMatrix();
      // Найденный объект
      foundObject = Gl.glRenderMode(Gl.GL_RENDER);
      // Видовая матрица
      Gl.glMatrixMode(Gl.GL_MODELVIEW);

      if (foundObject > 0)
      {
        int depth = bufferSize[1];       // Глубина буфера
        _selectIndex = bufferSize[3];    // Выбранный объект
        for (int i = 1; i < foundObject; i++)
        {
          if (bufferSize[(i * 4) + 1] < depth)
          {
            depth = bufferSize[(i * 4) + 1];
            _selectIndex = bufferSize[(i * 4) + 3];
          }// if
        }// for
      }// if
      else
        _selectIndex = -1;
    }// Select

    //public properties
    public List<GraphObject> Items
    {
      get { return _items; }
    }// Items

    public int SelectIndex
    {
      get { return _selectIndex; }
      set
      {
        if (_selectIndex != value)
          _selectIndex = value;
      }
    }// SelectIndex

    public GraphObject SelectedItem
    {
      get { return Items[SelectIndex]; }
    }// SelectedItem

    public bool Selected
    {
      get { return (SelectIndex >= 0); }
    }// Selected

  }// GraphObjects
}// Scene

