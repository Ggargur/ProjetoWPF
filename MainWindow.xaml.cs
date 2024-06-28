using LiveCharts.Wpf;
using LiveCharts;
using ProjetoWPF.API;
using ProjetoWPF.Model;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjetoWPF
{

    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            InitializeDataGrid();
            DatePickerInitial.SelectedDate = DateTime.Today.AddDays(-7);
            DatePickerFinal.SelectedDate = DateTime.Today;
            FillTimeSeries(Array.Empty<ExpectativaMensalMercado>());
            DataHandler.Instance.OnValuesGot += FillDataGrid;
            DataHandler.Instance.OnValuesGot += FillTimeSeries;
        }
        /// <summary>
        /// Preenche as series temporais com novos dados de expectativa mensal.
        /// </summary>
        /// <param name="expectativas"></param>
        private void FillTimeSeries(ExpectativaMensalMercado[] expectativas)
        {
            var medias = new ChartValues<float>();
            var medianas = new ChartValues<float>();
            var maximos = new ChartValues<float>();
            var minimos = new ChartValues<float>();
            String []XLabels = new String[expectativas.Length];
            IndicatorXLabel.Labels= XLabels;
            for (int i = 0; i < expectativas.Length; i++)
            {
                ExpectativaMensalMercado? expectativa = expectativas[i];
                medias.Add(expectativa.Media);
                medianas.Add(expectativa.Mediana);
                maximos.Add(expectativa.Maximo);
                minimos.Add(expectativa.Minimo);
                XLabels[i] = expectativa.Data;
            }
            IndicatorSeriesCharts.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = medias,
                    Name = "Média",
                    Title = "Média"
                },
                new LineSeries
                {
                    Values = medianas,
                    Name = "Mediana",
                    Title = "Mediana"
                },
                new LineSeries
                {
                    Values = maximos,
                    Name = "Máximo",
                    Title = "Máximo"
                },
                new LineSeries
                {
                    Values = minimos,
                    Name = "Mínimo",
                    Title = "Mínimo"
                },

            };
        }

        /// <summary>
        /// Inicializa a data grid.
        /// </summary>
        private void InitializeDataGrid()
        {
            IndicatorDataGrid.CanUserAddRows = false;
            IndicatorDataGrid.AllowDrop = false;
            IndicatorDataGrid.CanUserDeleteRows = false;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataHandler.Instance.Indicator = IndicatorSelector.SelectedValue.ToString();
        }

        private void DateSelected_Initial(object sender, SelectionChangedEventArgs e)
        {
            DataHandler.Instance.StartDate = FormatDate(DatePickerInitial.SelectedDate);
        }


        private void DateSelected_Final(object sender, SelectionChangedEventArgs e)
        {
            DataHandler.Instance.EndDate = FormatDate(DatePickerFinal.SelectedDate);
        }
        /// <summary>
        /// Formata as datas em padrão comum para yyyy-MM-dd, que é o formato usado na query http.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static string? FormatDate(DateTime? date) => date?.ToString("yyyy-MM-dd");

        /// <summary>
        /// Callback para quando o botão de exportar como csv é clickado. Este chama um diálogo de seleção
        /// de arquivo para a criação do arquivo csv.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportCSV_Clicked(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = $"Tabela de Expectativas {DataHandler.Instance.Indicator} - {DataHandler.Instance.StartDate} até {DataHandler.Instance.EndDate}";
            dialog.DefaultExt = ".csv";
            dialog.Filter = "Arquivos de dados (*.csv)| *.csv";

            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                string filename = dialog.FileName;
                WriteCSV(filename);
            }
            else
            {
                MessageBox.Show("Processo de exportação cancelado.", "Erro em exportação", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        /// <summary>
        /// Escreve os dados de expectativa selecionados como csv.
        /// </summary>
        /// <param name="filename"></param>
        private async void WriteCSV(String filename)
        {
            IndicatorDataGrid.SelectAllCells();
            IndicatorDataGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, IndicatorDataGrid);
            IndicatorDataGrid.UnselectAllCells();
            var LivePreviewText = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);

            var wr = new StreamWriter(filename);
            await wr.WriteLineAsync(LivePreviewText);
            wr.Flush();
        }

        /// <summary>
        /// Preenche o data grid.
        /// </summary>
        /// <param name="expectativas"></param>
        private void FillDataGrid(ExpectativaMensalMercado[] expectativas)
        {
            IndicatorDataGrid.ItemsSource = expectativas;
        }
    }
}