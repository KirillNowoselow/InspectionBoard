using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
using InspectionBoard.Windows;
using System.IO;
using System.Windows.Controls.Primitives;
using System.Data;
using DocumentFormat.OpenXml.Spreadsheet;
using InspectionBoard.ViewModels.Base;
using InspectionBoard.Models;

namespace InspectionBoard.Windows
{
    /// <summary>
    /// Логика взаимодействия для Student.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public StudentWindow()
        {
            InitializeComponent();
        }

        #region Команды для загрузки фото
        private void Download_Photo_Disabled_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.PNG;*.JPG)|*.PNG;*.JPG";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);
                Photo_Disabled.Text = fileName;
            }
        }

        private void Download_Photo_Orphanage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.PNG;*.JPG)|*.PNG;*.JPG";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);
                Photo_Orphanage.Text = fileName;
            }
        }

        private void Download_Attestat_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.PNG;*.JPG)|*.PNG;*.JPG";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);
                Photo_Attestat.Text = fileName;
            }
        }
        #endregion

        #region Команда для подсчета лет
        private void DateOfBirth_TextChanged(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine(DateTime.Now.Year);

            if (DateOfBirth.Text.Length == 10)
            {
                string date = DateOfBirth.Text;
                String[] date_arr = date.Split('.');
                int year = int.Parse(date_arr[2]);
                int month = int.Parse(date_arr[1]);
                int day = int.Parse(date_arr[0]);
                DateTime year_of_birth = new DateTime(year, month, day);
                TimeSpan diff = DateTime.Now - year_of_birth;
                int age = diff.Days / 365;
                Console.WriteLine(year_of_birth);
                Console.WriteLine(diff);
                Age.Content = age.ToString() + " лет";
            }
        }
        #endregion

        #region Команды для radiobutton
        private void radio_button_yes1_Checked(object sender, RoutedEventArgs e)
        {
            Photo_Disabled.Visibility = Visibility.Visible;
            Button_Download_Photo_Disabled.Visibility = Visibility.Visible;
        }
        private void radio_button_no1_Checked(object sender, RoutedEventArgs e)
        {
            Photo_Disabled.Visibility = Visibility.Hidden;
            Button_Download_Photo_Disabled.Visibility = Visibility.Hidden;
        }

        private void radio_button_yes2_Checked(object sender, RoutedEventArgs e)
        {
            Photo_Orphanage.Visibility = Visibility.Visible;
            Button_Download_Photo_Orphanage.Visibility = Visibility.Visible;
        }
        private void radio_button_no2_Checked(object sender, RoutedEventArgs e)
        {
            Photo_Orphanage.Visibility = Visibility.Hidden;
            Button_Download_Photo_Orphanage.Visibility = Visibility.Hidden;
        }

        private void radio_button_yes3_Checked(object sender, RoutedEventArgs e)
        {
            Year_of_admission.Content = DateTime.Now.Year + " год";
        }

        private void radio_button_no3_Checked(object sender, RoutedEventArgs e)
        {
            Year_of_admission.Content = "";
        }

        #endregion

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }


        private void Button_Add_Student(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationContext())
            {
                var student = new Student()
                {
                    first_name = first_name.Text,
                    last_name = last_name.Text
                };
                db.Students.Add(student);
                db.SaveChanges();
                Console.WriteLine(first_name);
            }
        }
    }
}
