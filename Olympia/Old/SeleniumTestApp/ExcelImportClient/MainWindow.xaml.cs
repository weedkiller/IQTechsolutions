using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using ExcelImportClient.Entities;
using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace ExcelImportClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> FilesToImport { get; set; } = new List<string>();
        public List<ExcelWorkbook> Workbooks { get; set; } = new List<ExcelWorkbook>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = true };
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (var fileName in openFileDialog.FileNames)
                {
                    txtResults.Text += $" {fileName}" + System.Environment.NewLine;
                    FilesToImport.Add(fileName);
                }
                btnImportFiles.IsEnabled = true;
            }
        }

        private void btnSearchGoogle_Click(object sender, RoutedEventArgs e)
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            FirefoxDriver fireFox = new FirefoxDriver();
            fireFox.Navigate().GoToUrl("https://www.google.com/");

            Thread.Sleep(2000);

            var searchBox = fireFox.FindElement(By.Name("q"));
            searchBox.SendKeys(txtGoogleSearchText.Text);

            Thread.Sleep(2000);

            IWebElement submitButton = fireFox.FindElement(By.Name("btnK"));
            OpenQA.Selenium.Interactions.Actions act = new OpenQA.Selenium.Interactions.Actions(fireFox);
            act.MoveToElement(submitButton).Click().Perform();

            Console.WriteLine("The html on this page is :");
            Console.WriteLine(fireFox.PageSource);

            fireFox.Close();
        }

        private void btnImportFiles_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ExcellApp = new Microsoft.Office.Interop.Excel.Application();
            txtResults.Text += $"{System.Environment.NewLine} Import Result : {System.Environment.NewLine}";

            foreach (var fileToImport in FilesToImport)
            {
                var workbook = ExcellApp.Workbooks.Open(fileToImport);
                var importedWorkBook = new ExcelWorkbook(workbook.Name, workbook.Name, fileToImport);

                foreach (Microsoft.Office.Interop.Excel.Worksheet workbookSheet in workbook.Sheets)
                {
                    var importedSheet = new ExcelSheet(workbookSheet.Name);
                    Microsoft.Office.Interop.Excel.Range range = workbookSheet.UsedRange;

                    for (int i = 1; i <= range.Rows.Count; i++)
                    {
                        var importedRow = new ExcelRow($"Row {i}");
                        for (int o = 1; o <= range.Columns.Count; o++)
                        {
                            dynamic value;
                            if (range.Cells[i, o] != null && range.Cells[i, o].Value2 != null)
                            {
                                value = range.Cells[i, o].Value2;
                            }; 
                            var newcell = new ExcelCell($"{o}-{i}".ToUpper(), range.Cells[i, o].Value2?.ToString());

                            txtResults.Text +=
                                $"The value {range.Cells[i, o].Value2?.ToString()} was added to cell {$"{o}-{i}".ToUpper()}. {System.Environment.NewLine}";

                            importedRow.Cells.Add(newcell);
                        }
                        importedSheet.Rows.Add(importedRow);
                    }
                    importedWorkBook.Sheets.Add(importedSheet);
                }
                Workbooks.Add(importedWorkBook);

                txtResults.Text +=
                    $@"{System.Environment.NewLine} Workbook - {importedWorkBook.Name} with ({importedWorkBook.Sheets.Count}) sheets was imported was completed on {DateTime.Now} from {importedWorkBook.FilePath} {System.Environment.NewLine}";

            }

            txtResults.Text += System.Environment.NewLine;
        }
    }
}
