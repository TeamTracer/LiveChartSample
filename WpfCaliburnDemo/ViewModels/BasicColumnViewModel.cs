using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using LiveCharts;
using LiveCharts.Wpf;

namespace WpfCaliburnDemo.ViewModels
{
    public class BasicColumnViewModel: Conductor<Object>
    {
        public void BasicColumn2()
        {
            //CUSTOMER CHARTS
            PointLabel = chartPoint =>
                     string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);



            //BASIC COLUMN CHARTS
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Daily",
                    Values = new ChartValues<double> { 10, 50, 39,50 }
                }
            };

            //adding series will update and animate the chart automatically
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Weekly",
                Values = new ChartValues<double> { 11, 56, 42, 60 }
            });
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Monthly",
                Values = new ChartValues<double> { 30, 50, 80, 60 }
            });

            //also adding values updates and animates the chart automatically
            //SeriesCollection[0].Values.Add(48d);

            Labels = new[] { "Ang Probinsyano", "La Luna Sangre", "Showtime", "Pusong Ligaw" };
            Formatter = value => value.ToString("N");



            //BASIC LINE CHARTS
            SeriesCollection1 = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Daily",
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,4 }
                },
                new LineSeries
                {
                    Title = "Weekly",
                    Values = new ChartValues<double> { 6, 7, 3, 4 ,6 },
                    PointGeometry = null
                },
                new LineSeries
                {
                    Title = "Monthly",
                    Values = new ChartValues<double> { 4,2,7,2,7 },
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 15
                }
            };

            Labels1 = new[] { "January", "Febrary", "March", "April", "May" };
            YFormatter = value => value.ToString("C");

            //modifying the series collection will animate and update the chart
            //SeriesCollection1.Add(new LineSeries
            //{
            //    Title = "Series 4",
            //    Values = new ChartValues<double> { 5, 3, 2, 4 },
            //    LineSmoothness = 0, //0: straight lines, 1: really smooth lines
            //    PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
            //    PointGeometrySize = 50,
            //    PointForeground = Brushes.Gray
            //});

            ////modifying any series values will also animate and update the chart
            //SeriesCollection1[3].Values.Add(5d);

            DataContext = this;
        }
        public Func<ChartPoint, string> PointLabel { get; set; }

        public BasicColumnViewModel DataContext { get; set; }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public SeriesCollection SeriesCollection1 { get; set; }
        public string[] Labels1 { get; set; }
        public Func<double, string> YFormatter { get; set; }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }

        public static implicit operator BasicColumnViewModel(HomeViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
