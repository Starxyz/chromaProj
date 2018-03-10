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
using OxyPlot;
using OxyPlot.Series;

namespace chromaProcess
{
    /// <summary>
    /// Interaction logic for PlotWindow.xaml
    /// </summary>
    public partial class PlotWindow : Window
    {
        public PlotWindow()
        {
            InitializeComponent();
        }

		public void PlotCurve(List<DataList> list)
		{
			var te = new Plot(list);
			this.DataContext = te;
		}
	}
}
