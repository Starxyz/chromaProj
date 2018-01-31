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
		public PlotModel plot { get; private set; }
		public Plot()
		{
			this.plot = new PlotModel { Title = "Test!" };
			this.plot.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.01, "cos(x)"));
		}
		
    }
}
