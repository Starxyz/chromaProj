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
using MathNet.Numerics.LinearAlgebra;

namespace chromaProcess
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public DataIO inputData = new DataIO();
		Formulas test = new Formulas();
		
		bool isOpen = false;
		bool isSample = false;
		public MainWindow()
		{
			InitializeComponent();
			
		}

		private void MenuOutput_Click(object sender, RoutedEventArgs e)
		{
			inputData.SaveData(inputData);
		}
		private void MenuInput_Click(object sender, RoutedEventArgs e)
		{
			
			var flag = inputData.ChooseInputDir();
			if (flag == true)
			{
				isOpen = true;
				inputData.wave_intensity.Clear();
				inputData.AddData();
				spectrumList.ItemsSource = inputData.wave_intensity;//显示导入的数据
			}
			
		}

		private void MenuExit_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void MenuTristimulus_Click(object sender, RoutedEventArgs e)
		{
			Window1 window1 = new Window1(inputData);
			window1.Show();
		}

		private void MenuPlot_Click(object sender, RoutedEventArgs e)
		{
			PlotWindow plotWindow = new PlotWindow();
			plotWindow.PlotCurve(inputData.wave_intensity);
			plotWindow.Show();

			//var M = Matrix<double>.Build;
			//var m = M.DenseOfRowArrays(inputData.BasicR, inputData.BasicG, inputData.BasicB);
			//var unit = M.DenseOfDiagonalArray(3, 3, new double[3]{ 1, 1, 1});
			//var res = m.Inverse(); ;
			//MessageBox.Show(res.ToString());
			
		}

		private void menuSample1_Click(object sender, RoutedEventArgs e)
		{
			if (isOpen == true)
			{
				inputData.SampleBy1nm();
				isSample = true;
				spectrumList.ItemsSource = inputData.sample_1nm;
				MessageBox.Show("1nm采样成功");
				inputData.Calculate(inputData); //提前计算结果，为显示作准备
			}
		}
		
		private void menuSample5_Click(object sender, RoutedEventArgs e)
		{
			if (isOpen == true)
			{
				inputData.SampleBy5nm();
				spectrumList.ItemsSource = inputData.sample_5nm;
				MessageBox.Show("5nm采样成功");
			}
		}

		private void menuMetadata_Click(object sender, RoutedEventArgs e)
		{
			if (isOpen == true)
			{
				spectrumList.ItemsSource = inputData.wave_intensity;
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			inputData.GetTriData();
		}

		private void menuAdjCoef_Click(object sender, RoutedEventArgs e)
		{
			//txtTemp.Text = @"L = \int_a^b \sqrt[4]{ \left| \sum_{i,j=1}^ng_{ij}\left(\gamma(t)\right) \left[\frac{d}{dt}x^i\circ\gamma(t) \right] \left{\frac{d}{dt}x^j\circ\gamma(t) \right} \right|}dt";
			txtTemp.Text = test.adjCoef;
			txtTempY.Text = null;
			txtTempZ.Text = null;
		}

		private void menuPropCoef_Click(object sender, RoutedEventArgs e)
		{
			txtTemp.Text = test.trisMulusX;
			txtTempY.Text = test.trisMulusY;
			txtTempZ.Text = test.trisMulusZ;
		}

		private void menuChroma_Click(object sender, RoutedEventArgs e)
		{
			txtTemp.Text = test.coordx;
			txtTempY.Text = test.coordy;
			txtTempZ.Text = test.coordz;
		}

		private void menuLm_Click(object sender, RoutedEventArgs e)
		{
			txtTemp.Text = test.flux;
			txtTempY.Text = null;
			txtTempZ.Text = null;
		}

		private void menuColorTemp_Click(object sender, RoutedEventArgs e)
		{
			txtTemp.Text = test.colorT;
			txtTempY.Text = test.colorN;
			txtTempZ.Text = null;
		}

		private void btnK_Click(object sender, RoutedEventArgs e)
		{
			if (isOpen && isSample)
			{
				//inputData.CalCoef(inputData);
				dispLabel.Text = "调整系数：K=" + inputData.dispNum[0].ToString();
			}
			else
				MessageBox.Show("请导入数据并进行抽样！");
		}

		private void btnXYZ_Click(object sender, RoutedEventArgs e)
		{
			if (isOpen && isSample)
			{
				//inputData.CalXYZ(inputData);
				string s = "X = " + inputData.dispNum[1].ToString("F6") + '\n' + "Y = " + 
								inputData.dispNum[2].ToString("F6") + '\n' + "Z = " + inputData.dispNum[3].ToString("F6");
				dispLabel.Text = s;
			}
			else
				MessageBox.Show("请导入数据并进行抽样！");
		}

		private void btn_xyz_Click(object sender, RoutedEventArgs e)
		{
			if (isOpen && isSample)
			{
				dispLabel.Text = "(" + inputData.dispNum[4].ToString("F6") + ", " + inputData.dispNum[5].ToString("F6")
									+ ", " + inputData.dispNum[6].ToString("F6") + ')';
			}
			else
				MessageBox.Show("请导入数据并进行抽样！");
		}

		private void btnNT_Click(object sender, RoutedEventArgs e)
		{
			if (isOpen && isSample)
			{
				dispLabel.Text = "n = " + inputData.dispNum[7].ToString() + '\n'
									+ "T = " + inputData.dispNum[8].ToString();
			}
			else
				MessageBox.Show("请导入数据并进行抽样！");
		}

		private void menuTrisBasic_Click(object sender, RoutedEventArgs e)
		{
			TrisBasic trisBasic = new TrisBasic(inputData);
			trisBasic.Show();
		}

		private void btnBrightness_Click(object sender, RoutedEventArgs e)
		{
			//MessageBox.Show(inputData.BasicB[0].ToString());
			//double L = inputData.Lr + inputData.Lg + inputData.Lb;
			//MessageBox.Show("亮度是： " + L.ToString() + '\n' + "Lr = " + inputData.Lr.ToString()
			//				+ '\n' + "Lg = " + inputData.Lg.ToString() + '\n' + "Lb = " + inputData.Lb.ToString());
			var test = inputData.CalBrightness(inputData);
			dispLabel.Text = test;
		}
	}
}
