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
using InspectionBoard.Windows;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using Word = Microsoft.Office.Interop.Word;

namespace InspectionBoard.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Show_StudentWindow(object sender, RoutedEventArgs e)
        {
            StudentWindow student_window = new StudentWindow();
            student_window.ShowDialog();
            Show();
        }

        private void Button_Download_Excel(object sender, RoutedEventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet) workbook.ActiveSheet;

            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    worksheet.Cells[i, j] = i;
                }
            }
            workbook.SaveAs(@"..\..\..\InspectionBoard\Reports\Excel\Report.xlsx");
            excelApp.Quit();

            MessageBox.Show("Отчет успешно сохранен");

            // Освободить все ресурсы COM объектов
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            worksheet = null;
            workbook = null;
            excelApp = null;

            GC.Collect();
        }

        private void Button_Download_Word(object sender, RoutedEventArgs e)
        {
            Word.Application wordApp = new Word.Application();
            Word.Document document = wordApp.Documents.Add();
            Word.Range range = document.Paragraphs.First.Range;
            document.Content.Text = "Привет, мир!";
            document.Tables.Add(range, 7, 7);

            object fileName = @"C:\Users\Zver\source\repos\InspectionBoard\InspectionBoard\Reports\Word\Report.docx";
            document.SaveAs2(ref fileName);

            // Закрываем документ и приложение Word
            document.Close();
            wordApp.Quit();
        }
    }
}
