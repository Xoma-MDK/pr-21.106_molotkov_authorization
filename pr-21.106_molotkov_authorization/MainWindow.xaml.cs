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

namespace pr_21._106_molotkov_authorization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Конструктор класс главного окна
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод обработки нажатия на кнопку "Войти"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            using(var db = new KR_BaseEntities())
            {
                //Получение пользователя из базы данных
                var user = db.Users.Where(u => u.Login == TbLogin.Text && u.Password == PbPassword.Password).FirstOrDefault();
                //Найден ли пользователь
                if (user != null)
                {
                    //Отображение сообщения об успехе авторизации и роли пользователя
                    MessageBox.Show($"Добро пожаловать! Ваша роль: {user.Roles.Title}", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    //Отображение сообщения об ошибки авторизации
                    MessageBox.Show("Неверно введены логин или пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
