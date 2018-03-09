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

namespace chromaProcess
{
	/// <summary>
	/// Interaction logic for TrisBasic.xaml
	/// </summary>
	public partial class TrisBasic : Window
	{

		public static string red = "0.6844,0.3016,0.0139";
		public static string green = "0.2286,0.7037,0.0676";
		public static string blue = "0.1413,0.0503,0.8083";
		DataIO tmp;
		
		public TrisBasic(DataIO setBasic)
		{
			InitializeComponent();
			BasicRed.Text = red;
			BasicGreen.Text = green;
			BasicBlue.Text = blue;

			tmp = setBasic;
			SetBasicValue(tmp);
		}

		public void SetBasicValue(DataIO dataIO)
		{
			var tmpR = BasicRed.Text.Split(',');
			var tmpG = BasicGreen.Text.Split(',');
			var tmpB = BasicBlue.Text.Split(',');
			var tmpTarget = TargetColor.Text.Split(',');
			try
			{
				for (int i = 0; i < 3; i++)
				{
					dataIO.BasicR[i] = Double.Parse(tmpR[i]);
				}
				for (int i = 0; i < 3; i++)
				{
					dataIO.BasicG[i] = Double.Parse(tmpG[i]);
				}
				for (int i = 0; i < 3; i++)
				{
					dataIO.BasicB[i] = Double.Parse(tmpB[i]);
				}
				for (int i = 0; i < 3; i++)
				{
					dataIO.TargetMatrix[i] = Double.Parse(tmpTarget[i]);
				}
			}
			catch
			{
				MessageBox.Show("请根据目标色上面的格式输入目标色坐标！");
			}
			dataIO.BasicC[0] = dataIO.BasicR[0] + dataIO.BasicG[0] + dataIO.BasicB[0];
			dataIO.BasicC[1] = dataIO.BasicR[1] + dataIO.BasicG[1] + dataIO.BasicB[1];
			dataIO.BasicC[2] = dataIO.BasicR[2] + dataIO.BasicG[2] + dataIO.BasicB[2];
		}


		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void btnConfirm_Click(object sender, RoutedEventArgs e)
		{
			red = BasicRed.Text;
			green = BasicGreen.Text;
			blue = BasicBlue.Text;
			MessageBox.Show("设置成功！");
			SetBasicValue(tmp);
			this.Close();
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			this.Hide();
		}
	}
}
