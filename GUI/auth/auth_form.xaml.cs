using KVANT_Scada.Data;
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

namespace KVANT_Scada.GUI.auth
{
    /// <summary>
    /// Логика взаимодействия для auth_form.xaml
    /// </summary>
    public partial class auth_form : Window
    {
        private Real_Tag_Entitys rte { get; set; }
        users lUser;
        MainWindow mw;
        public auth_form(Real_Tag_Entitys rte, MainWindow mainWindow)
        {
            InitializeComponent();
            this.rte = rte;
            mw = mainWindow;
            
           //rte.Database.CreateIfNotExists();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string strLogin = login.Text.ToString();
            string strPass = pass.Password.ToString();

            try
            {
                lUser = this.rte.users.Find(strLogin);
                if (lUser.PassWord == strPass)
                {
                     MainWindow.User = lUser;
                     mw.ConnectToPlc();
                     this.Close();
                   
                }
                else
                {
                    MessageBox.Show("Неверный Логин или Пароль");
                };
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());

            }
            
            


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            rte.Database.Delete();
            rte.Database.CreateIfNotExists();
        }

        private void create_root_Click(object sender, RoutedEventArgs e)
        {
            if (rte.users.Find("root") == null)
            {
                users adm = new users
                {
                    Login = "root",
                    PassWord = "root",
                    Policy = 9,
                    Name = "Root"
                };
                rte.users.Add(adm);
                rte.SaveChanges();
            }

        }
    }
}
