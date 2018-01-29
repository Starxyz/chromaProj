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
		
		public MainWindow()
		{
			InitializeComponent();
			
		}

		private void menuOutput_Click(object sender, RoutedEventArgs e)
		{
			//dataIO.ChooseOutputDir();

		}
		private void menuInput_Click(object sender, RoutedEventArgs e)
		{
			DataIO dataIO = new DataIO();
			var flag = dataIO.ChooseInputDir();
			if (flag == true)
			{
				dataIO.AddData();
				spectrumList.ItemsSource = dataIO.items;
			}
			else
				MessageBox.Show("数据导入失败，请重试！");
		}

		private void menuExit_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void MenuEdit_Click(object sender, RoutedEventArgs e)
		{
			
		}

		private void menuTristimulus_Click(object sender, RoutedEventArgs e)
		{
			Window1 window1 = new Window1();
			window1.Show();
		}
	}
}
