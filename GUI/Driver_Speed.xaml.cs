using KVANT_Scada.UDT;
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
using System.Windows.Shapes;

namespace KVANT_Scada.GUI
{
    /// <summary>
    /// Логика взаимодействия для Driver_Speed.xaml
    /// </summary>
    public partial class Driver_Speed : Window
    {
        Installing_Tags tags;
        public Driver_Speed(Installing_Tags i_t)
        {
            InitializeComponent();
            tags = i_t;
            txtDriverSpeed.Text = tags.get_Driver_Speed().ToString();
        }

        private void DriverSpeedSave_Click(object sender, RoutedEventArgs e)
        {
            tags.set_Driver_Speed(Convert.ToDouble(txtDriverSpeed.Text.Replace(".", ",")));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDriverStart_Click(object sender, RoutedEventArgs e)
        {
            tags.set_Driver_Start(true);
        }

        private void btnDriverStop_Click(object sender, RoutedEventArgs e)
        {
            tags.set_Driver_Start(false);
        }

        private void Remote_Control_Click(object sender, RoutedEventArgs e)
        {
            tags.set_Driver_Remote_Control(false);
        }

        private void Remote_Control_Rev_Click(object sender, RoutedEventArgs e)
        {
            tags.set_Driver_Remote_Control(true);
        }
    }
}
