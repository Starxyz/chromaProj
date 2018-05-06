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
		private int password = 0;
		private int keyValue = 0;
		bool isOpen = false;
		bool isSample = false;
		public static string title1 = "波长/nm";
		

		public MainWindow()
		{
			InitializeComponent();
			hints.Visibility = Visibility.Visible;
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
				inputData.sample_1nm.Clear();
				inputData.sample_5nm.Clear();

				inputData.AddData();
				spectrumList.ItemsSource = inputData.wave_intensity;//显示导入的数据
				if (inputData.wave_intensity.Count < 20)
				{
					gcv1.Header = "电流";
					gcv2.Header = "光通量";
				}
				else
				{
					gcv1.Header = "波长";
					gcv2.Header = "强度";
				}
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
			List<DataList> plotData = new List<DataList>();

			foreach (DataList element in spectrumList.Items)
			{
				plotData.Add(element);
			}
			plotWindow.PlotCurve(plotData);
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
			inputData.GetVision();
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
			keyValue = 1;
			if (password == 1)
			{
				txtTemp.Text = test.adjCoef;
				txtTempY.Text = null;
				txtTempZ.Text = null;
			}
			else
			{
				txtTemp.Text = test._adjCoef;
				txtTempY.Text = null;
				txtTempZ.Text = null;
			}
			
			if (isOpen && isSample)
			{
				if (password == 1)
				{
					inputData.CalCoef(inputData);
					dispLabel.Text = "调整系数：K=" + inputData.dispNum[0].ToString();
				}
				btnS_lambda.Visibility = Visibility.Visible;
			}
			else
				MessageBox.Show("请导入数据并进行抽样！");
		}

		private void btnXYZ_Click(object sender, RoutedEventArgs e)
		{
			txtTemp.Text = test.trisMulusX;
			txtTempY.Text = test.trisMulusY;
			txtTempZ.Text = test.trisMulusZ;
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
			keyValue = 2;
			if (password == 2)
			{
				txtTemp.Text = test.coordx;
				txtTempY.Text = test.coordy;
				txtTempZ.Text = test.coordz;
			}
			else
			{
				txtTemp.Text = test._coordx;
				txtTempY.Text = test._coordy;
				txtTempZ.Text = test._coordz;
			}
			if (isOpen && isSample)
			{
				if (password == 2)
				{
					dispLabel.Text = "(" + inputData.dispNum[4].ToString("F6") + ", " + inputData.dispNum[5].ToString("F6")
									+ ", " + inputData.dispNum[6].ToString("F6") + ')';
				}	
			}
			else
				MessageBox.Show("请导入数据并进行抽样！");
		}

		private void btnNT_Click(object sender, RoutedEventArgs e)
		{
			keyValue = 3;
			if (password == 3)
			{
				txtTemp.Text = test.colorT;
				txtTempY.Text = test.colorN;
				txtTempZ.Text = null;
			}
			else
			{
				txtTemp.Text = test._colorT;
				txtTempY.Text = test._colorN;
				txtTempZ.Text = null;
			}
			if (isOpen && isSample)
			{
				if (password == 3)
				{
					dispLabel.Text = "n = " + inputData.dispNum[7].ToString() + '\n'
									+ "T = " + inputData.dispNum[8].ToString();
				}	
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

		private void btnLm_Click(object sender, RoutedEventArgs e)
		{
			keyValue = 4;
			if (password == 4)
			{
				txtTemp.Text = test.flux;
				txtTempY.Text = null;
				txtTempZ.Text = null; ;

				var res = inputData.CalLm();
				dispLabel.Text = "光通量：" + res;
			}
			else
			{
				txtTemp.Text = test._flux;
				txtTempY.Text = null;
				txtTempZ.Text = null;
			}
		}

		private void btnS_lambda_Click(object sender, RoutedEventArgs e)
		{
			if (keyValue == 1)
			{
				txtTemp.Text = test.adjCoef;
				txtTempY.Text = null;
				txtTempZ.Text = null;
				password = 1;
			}
			else
			{
				MessageBox.Show("选择的参数不正确，请重新选择");
			}
			
			//dispLabel.Text = "调整系数：K=" + inputData.dispNum[0].ToString();
			//btnS_lambda.Visibility = Visibility.Visible;
		}

		private void btnIn_X_Click(object sender, RoutedEventArgs e)
		{
			if (keyValue == 2)
			{
				txtTemp.Text = test._coordx_;
				txtTempY.Text = test._coordxy;
				txtTempZ.Text = test._coordxyz;
				password = 2;
			}
			else
			{
				MessageBox.Show("选择的参数不正确，请重新选择");
			}
		}

		private void btnIn_Y_Click(object sender, RoutedEventArgs e)
		{
			if (keyValue == 2)
			{
				txtTemp.Text = test._coordyx;
				txtTempY.Text = test._coordy_;
				txtTempZ.Text = test._coordyxz;
				password = 2;
			}
			else
			{
				MessageBox.Show("选择的参数不正确，请重新选择");
			}
		}

		private void btnIn_Z_Click(object sender, RoutedEventArgs e)
		{
			if (keyValue == 2)
			{
				txtTemp.Text = test._coordzx;
				txtTempY.Text = test._coordzxy;
				txtTempZ.Text = test._coordz_;
				password = 2;
			}
			else
			{
				MessageBox.Show("选择的参数不正确，请重新选择");
			}
		}

		private void btnIn_x_Click(object sender, RoutedEventArgs e)
		{
			if (keyValue == 3)
			{
				txtTemp.Text = test.colorT;
				txtTempY.Text = test._colorN1;
				txtTempZ.Text = null;
				password = 3;
			}
			else
			{
				MessageBox.Show("选择的参数不正确，请重新选择");
			}
		}

		private void btnIn_y_Click(object sender, RoutedEventArgs e)
		{
			if (keyValue == 3)
			{
				txtTemp.Text = test.colorT;
				txtTempY.Text = test.colorN;
				txtTempZ.Text = null;
				password = 3;
			}
			else
			{
				MessageBox.Show("选择的参数不正确，请重新选择");
			}
		}

		private void btnPhi_Click(object sender, RoutedEventArgs e)
		{
			if (keyValue == 4)
			{
				txtTemp.Text = test.flux;
				txtTempY.Text = null;
				txtTempZ.Text = null;
				password = 4;
			}
			else
			{
				MessageBox.Show("选择的参数不正确，请重新选择");
			}
		}
	}
}
