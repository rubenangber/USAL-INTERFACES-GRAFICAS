using System;
using System.Windows;
using System.Windows.Controls;
namespace Proyectos.ElSegundo {
    class Basica {
        [STAThread]
        public static void Main() {
            Window win = new Window();
            win.Title = "Primer Programa";
            win.Show();
            Label etiqueta = new Label();
            etiqueta.Content = "Hola Mundo C#";
            win.Content = etiqueta;
            Application app = new Application();
            Console.WriteLine("Empezando");
            app.Run();
            Console.WriteLine("Terminando");
        }
    }
}