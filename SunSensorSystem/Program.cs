using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.IO.Compression;
using SunSensorSystem.Properties;

namespace SunSensorSystem
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            AppDomain.CurrentDomain.AssemblyResolve += Platform_Windows_Assembly;
            AppDomain.CurrentDomain.AssemblyResolve += Glut_Assembly;
            AppDomain.CurrentDomain.AssemblyResolve += OpenGl_Assembly;
        }//Main

        private static Assembly Platform_Windows_Assembly(object sender, ResolveEventArgs args)
        {
          if (args.Name.Contains("Tao.Platform.Windows"))
          {
            // Загрузка запакованной сборки из ресурсов, ее распаковка и подстановка
            using (var resource = new MemoryStream(Resources.Tao_Platform_Windows))
            using (var deflated = new DeflateStream(resource, CompressionMode.Decompress))
            using (var reader = new BinaryReader(deflated))
            {
              var memory = 2048 * 2048;
              var buffer = reader.ReadBytes(memory);
              return Assembly.Load(buffer);
            }
          }//if
          return null;
        }//Tao_Platform_Windows_Assembly

        private static Assembly Glut_Assembly(object sender, ResolveEventArgs args)
        {
          if (args.Name.Contains("Tao.FreeGlut"))
          {
            // Загрузка запакованной сборки из ресурсов, ее распаковка и подстановка
            using (var resource = new MemoryStream(Resources.Tao_FreeGlut))
            using (var deflated = new DeflateStream(resource, CompressionMode.Decompress))
            using (var reader = new BinaryReader(deflated))
            {
              var memory = 2048 * 2048;
              var buffer = reader.ReadBytes(memory);
              return Assembly.Load(buffer);
            }
          }//if
          return null;
        }//Glut_Assembly

        private static Assembly OpenGl_Assembly(object sender, ResolveEventArgs args)
        {
          if (args.Name.Contains("Tao.OpenGl"))
          {
            // Загрузка запакованной сборки из ресурсов, ее распаковка и подстановка
            using (var resource = new MemoryStream(Resources.Tao_OpenGl))
            using (var deflated = new DeflateStream(resource, CompressionMode.Decompress))
            using (var reader = new BinaryReader(deflated))
            {
              var memory = 2048 * 2048;
              var buffer = reader.ReadBytes(memory);
              return Assembly.Load(buffer);
            }
          }//if
          return null;
        }//OpenGl_Assembly

    }//Program  
}//SunSensorSystem
