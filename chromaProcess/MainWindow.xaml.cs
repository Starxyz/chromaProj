using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace chromaProcess
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		DataIO inputData = new DataIO();
		public MainWindow()
		{
			InitializeComponent();
			
		}

		private void MenuOutput_Click(object sender, RoutedEventArgs e)
		{
			
		}
		private void MenuInput_Click(object sender, RoutedEventArgs e)
		{
			
			var flag = inputData.ChooseInputDir();
			if (flag == true)
			{
				inputData.wave_intensity.Clear();
				inputData.AddData();
				spectrumList.ItemsSource = inputData.wave_intensity;
			}
			
		}

		private void MenuExit_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void MenuEdit_Click(object sender, RoutedEventArgs e)
		{
			

		}

		private void MenuTristimulus_Click(object sender, RoutedEventArgs e)
		{
			Window1 window1 = new Window1(inputData);
			window1.Show();
		}

		private void MenuPlot_Click(object sender, RoutedEventArgs e)
		{
			PlotWindow plotWindow = new PlotWindow();
			plotWindow.test(inputData.wave_intensity);
			plotWindow.Show();
		}

		
	}
}
