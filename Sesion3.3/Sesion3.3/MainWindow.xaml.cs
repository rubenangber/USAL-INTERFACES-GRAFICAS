using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sesion3._3
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() {

            InitializeComponent();

            UIElement[] elementos = { this, grid, boton, cabecera, panel, textoboton };

            string strFormat = "{0,-30} {1,-15} {2,-15} {3,-15}";

            void gestorglobal(Object sender, RoutedEventArgs e) {
                TextBlock linea = new TextBlock();
                linea.Text = String.Format(strFormat,
                e.RoutedEvent.Name,
                nombreobjeto(sender),
                nombreobjeto(e.Source),
                nombreobjeto(e.OriginalSource));
                panel.Children.Add(linea);
                scroll.ScrollToBottom();
            }

            string nombreobjeto(Object obj) {
                string[] parseada = obj.GetType().ToString().Split('.');
                return parseada[parseada.Length - 1];
            }

            foreach (UIElement i in elementos)
            {
                i.PreviewKeyDown += gestorglobal;
                i.PreviewKeyUp += gestorglobal;
                i.PreviewTextInput += gestorglobal;
                i.KeyDown += gestorglobal;
                i.KeyUp += gestorglobal;
                i.TextInput += gestorglobal;
                i.PreviewMouseDown += gestorglobal;
                i.PreviewMouseUp += gestorglobal;
                i.MouseDown += gestorglobal;
                i.MouseUp += gestorglobal;
            }
            boton.Click += gestorglobal;

            cabecera.Text = string.Format(strFormat, "Evento", "Sender", "Fuente", "Fuente Original");
        }
    }
}
