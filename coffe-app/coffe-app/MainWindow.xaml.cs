using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

namespace coffe_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            test();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        { // Ваш код обработки нажатия кнопки здесь 
        }
        private void OpenProfile_Click(object sender, RoutedEventArgs e)
        {
            Profile profileWindow = new Profile(this);
            profileWindow.Show();
            this.Hide();
        }
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            Menu menuWindow = new Menu(this);
            menuWindow.Show();
            this.Hide();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private const string ServerIp = "127.0.0.1"; // Замените на IP-адрес вашего сервера
        private static int PORT = 11000;
        private void test()
        {
            Socket s1 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Parse(ServerIp), PORT);

          //  Console.WriteLine("Введите команду (register/login):");
            string command = "login";
         //   Console.WriteLine("Введите имя пользователя:");
            string username = "youlchikk";
            string phone = "3863055";
            string email = "yulia@mail.ru";
            string birthdate = "06-05-2004";
         //   Console.WriteLine("Введите пароль:");
            string password = "password";

          //   string message = $"{command}|{username}|{phone}|{email}|{birthdate}|{password}";
            string message = $"{command}|{username}|{password}";
            byte[] data = Encoding.UTF8.GetBytes(message);

            s1.SendTo(data, data.Length, SocketFlags.None, serverEndpoint);

            byte[] byteRec = new byte[512];
            EndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 0);
            int response = s1.ReceiveFrom(byteRec, byteRec.Length, SocketFlags.None, ref serverEndPoint);
            MessageBox.Show(Encoding.UTF8.GetString(byteRec, 0, byteRec.Length));
          //  Console.WriteLine($"Ответ сервера: {response}");
        }
    }
}