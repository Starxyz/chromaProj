using System;
using System.Collections.Generic;
using System.IO;
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
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
			inputData();
		}

		private void inputData()
		{
			List<Tristimulus> items = new List<Tristimulus>();
			DataIO dataIO = new DataIO();
			var flag = dataIO.ChooseInputDir();
			//MessageBox.Show(dataIO.inputPath);
			if (flag == true)
			{
				string[] split = new string[4];
				var str = File.ReadAllLines(dataIO.inputPath);
				MessageBox.Show(str[0]);
				char[] delimiterChars = { ','};
				foreach (var element in str)
				{
					var deleteSpace = element.Replace(" ", "");
					split = deleteSpace.Split(delimiterChars);
					try
					{
						items.Add(new Tristimulus()
						{
							tri_wave = Int16.Parse(split[0]),
							tri_x = Double.Parse(split[1]),
							tri_y = Double.Parse(split[2]),
							tri_z = Double.Parse(split[3])
						});
					}
					catch (Exception)
					{

						MessageBox.Show("数据格式错误！");
					}
				}
				tristimulusList.ItemsSource = items;
			}
			/*
			string[] split = new string[2];
			foreach (var element in str)
			{
				split = element.Split(' ');
				try
				{

					items.Add(new DataList() { Wave = Double.Parse(split[0]), Intensity = Double.Parse(split[1]) });
				}
				catch
				{
					MessageBox.Show("数据格式错误");
				}
			}
			MessageBox.Show(items.Count.ToString());*/
		}
	}

	class Tristimulus
	{
		public double tri_wave { get; set; }
		public double tri_x { get; set; }
		public double tri_y { get; set; }
		public double tri_z { get; set; }
	}
}
