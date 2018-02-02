using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Series;
namespace chromaProcess
{
	class Plot
	{
		public PlotModel testModel { get; private set; }
		public Plot(List<DataList> list)
		{
			DrawLine1(list);
		}
		
		public void DrawLine1(List<DataList> list)
		{
			testModel = new PlotModel();
			var lineSerial = new LineSeries();
			foreach (var elm in list)
			{
				lineSerial.Points.Add(new DataPoint(elm.Wave, elm.Intensity));
			}
			testModel.Series.Add(lineSerial);
		}
    }
}
