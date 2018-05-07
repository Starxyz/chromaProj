using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using OxyPlot;
using System.Windows.Controls;
using MathNet.Numerics.LinearAlgebra;
using System.ComponentModel;

namespace chromaProcess
{
	public class DataIO
	{
		public double[] BasicR = new double[3];
		public double[] BasicG = new double[3];
		public double[] BasicB = new double[3];
		public double[] BasicC = new double[3];
		public double[] TargetMatrix = new double[3];
		public double Lr, Lg, Lb;
		public double[] BasicCrgb = new double[3];
		public double[] TargetColour = new double[3];
		public static double[] VisionFunc = new double[81];
		public static string inputPath; //所有类共用一个路径
		//public List<DataList> wave_intensity = new List<DataList>();
		//public List<Tristimulus> tri_values = new List<Tristimulus>();
		//public List<SampleList> sample_1nm = new List<SampleList>();
		//public List<SampleList> sample_5nm = new List<SampleList>();
		public BindingList<DataList> wave_intensity = new BindingList<DataList>();
		public List<Tristimulus> tri_values = new List<Tristimulus>();
		public BindingList<SampleList> sample_1nm = new BindingList<SampleList>();
		public BindingList<SampleList5> sample_5nm = new BindingList<SampleList5>();
		public double[] dispNum = new double[9];
		private double Lm = 0;
		private string brightness = null;
		public bool ChooseInputDir()
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.InitialDirectory = Environment.CurrentDirectory;
			fileDialog.Filter = "txt files(*.txt)|*.txt|All files(*.*)|*.*";
			fileDialog.FilterIndex = 2;
			fileDialog.RestoreDirectory = true;
			if (fileDialog.ShowDialog() == true)
			{
				if (fileDialog.FileName != "")
				{

					inputPath = fileDialog.FileName;
					//MessageBox.Show(inputPath);
					return true;
				}
			}
			return false;
		}

		public void AddData()
		{
			var str = File.ReadAllLines(inputPath);
			string[] split = new string[2];
			char[] delimiterChars = { ',','\t',' ' };
			double wave, intensity;
			foreach (var element in str)
			{
				split = element.Split(delimiterChars);
				try
				{
					wave = Double.Parse(split[0]);
					intensity = Double.Parse(split[1]);
					wave_intensity.Add(new DataList() { Wave = wave, Intensity = intensity });
				}
				catch {
					MessageBox.Show("数据格式错误");
					break;
				}
			}
			MessageBox.Show("本次一共导入了" + wave_intensity.Count.ToString() + " 个点。");
		}

		public void SaveData(DataIO data)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
			var result = sfd.ShowDialog();
			if (result == true)
			{
				string localFilePath = sfd.FileName.ToString();
				//string header = "波长\t强度\tx\ty\tz";
				StreamWriter file = new StreamWriter(localFilePath);
				//file.WriteLine(header);
				//MessageBox.Show(data.sample_5nm.Count.ToString());
				//foreach (var item in data.sample_5nm)
				//{
				//	string line = item.Wave.ToString() + '\t' + item.Intensity.ToString() + '\t'
				//					+ item.x1.ToString() + '\t' + item.y1.ToString() + '\t' + item.z1.ToString();
				//	file.WriteLine(line);
				//}
				file.WriteLine("色品坐标：" + data.dispNum[4].ToString("F6") + "\t"+ data.dispNum[5].ToString("F6") + "\t" + data.dispNum[6].ToString("F6"));
				file.WriteLine("色温：" + data.dispNum[7].ToString("F6") + "\t" + data.dispNum[8].ToString("F6"));
				file.WriteLine("光通量：" + Lm.ToString("F6") );
				file.WriteLine("亮度：" + "\n" + brightness);
				
				file.Close();
			}
		}

		//public void SavaData(int i)
		//{
		//	SaveFileDialog sfd = new SaveFileDialog();
		//	sfd.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
		//	var result = sfd.ShowDialog();
		//	if (result == true)
		//	{
		//		string localFilePath = sfd.FileName.ToString();
		//		string header = "波长\t强度";
		//		StreamWriter file = new StreamWriter(localFilePath);
		//		file.WriteLine(header);
		//		//MessageBox.Show(data.sample_1nm.Count.ToString());
		//		foreach (var item in data.sample_1nm)
		//		{
		//			string line = item.Wave.ToString() + '\t' + item.Intensity.ToString() + '\t'
		//							+ item.x1.ToString() + '\t' + item.y1.ToString() + '\t' + item.z1.ToString();
		//			file.WriteLine(line);
		//		}
		//		file.Close();
		//	}
		//}

		public void DispTriData(ListView listView)
		{
			listView.ItemsSource = tri_values;
		}

		public void GetTriData()
		{
			string[] split = new string[4];
			var str = File.ReadAllLines("三刺激值.txt");
			char[] delimiterChars = { '\t'};
			foreach (var element in str)
			{
				var deleteSpace = element.Replace(" ", "");
				split = deleteSpace.Split(delimiterChars);
				try
				{
					tri_values.Add(new Tristimulus()
					{
						tri_wave = Double.Parse(split[0]),
						tri_x = Double.Parse(split[1]),
						tri_y = Double.Parse(split[2]),
						tri_z = Double.Parse(split[3])
					});
				}
				catch (Exception)
				{
					MessageBox.Show("数据格式错误！");
					break;
				}
			}
			//MessageBox.Show(tri_values.Count.ToString());
		}
		public void GetVision()
		{
			var str = File.ReadAllLines("vision.txt");
			int i = 0;
			try
			{
				foreach (var element in str)
				{
					VisionFunc[i++] = Double.Parse(element);
				}
			}		
			catch (Exception)
			{
				MessageBox.Show("引用视见函数出错!");
			}
		}
		public void SampleBy1nm()
		{
			sample_1nm.Clear();
			int i = 0;
			int j = 0;
			double tmpSum = 0;
			foreach (var item in wave_intensity)
			{
				if ((item.Wave >= 380) && (item.Wave < tri_values[i].tri_wave + 1))
				{
					tmpSum += item.Intensity;
					j++;
				}
				try
				{
					if (item.Wave > tri_values[i].tri_wave + 1)
					{
						sample_1nm.Add(new SampleList()
						{
							Wave = tri_values[i].tri_wave,
							Intensity = tmpSum / 1.0 / j,
							x1 = tri_values[i].tri_x,
							y1 = tri_values[i].tri_y,
							z1 = tri_values[i].tri_z,
						});
						tmpSum = 0;
						j = 0;
						if (tri_values[i].tri_wave == 780 || i >= 400)
						{
							//MessageBox.Show(sample_1nm.Count.ToString() + "个采样点");
							break;
						}
						i++;
					}
				}
				catch
				{
					MessageBox.Show("unknown error!");
				}	
			}
			//MessageBox.Show(i.ToString());

		}
		public void SampleBy5nm()
		{
			sample_1nm.Clear();
			SampleBy1nm();
			int i = 0;
			foreach (var item in sample_1nm)
			{
				if (item.Wave % 5 == 0)
				{
					sample_5nm.Add(new SampleList5 { x1 = item.x1, y1 = item.y1, z1 = item.z1,
						Intensity = item.Intensity, Wave = item.Wave,
						vision = VisionFunc[i++]});
				}
			}
		}
		public void CalCoef(DataIO data)  //为了结果可复制，使用txtbox
		{
			double sum = 0;
			foreach (var item in data.sample_1nm)
			{
				sum += item.Intensity * item.y1;
			}
			dispNum[0] = 100.0 / sum; //K
		}
		public void CalXYZ(DataIO data)
		{
			double sumx = 0;
			double sumy = 0;
			double sumz = 0;
			foreach (var item in data.sample_1nm)
			{
				sumx += item.Intensity * item.x1; //* item.Wave;
				sumy += item.Intensity * item.y1; //* item.Wave;
				sumz += item.Intensity * item.z1; //* item.Wave;
			}
			var k = dispNum[0];
			sumx *= k;
			sumy *= k;
			sumz *= k;
			dispNum[1] = sumx;
			dispNum[2] = sumy;
			dispNum[3] = sumz;
		}
		public void Calxyz()
		{
			dispNum[4] = dispNum[1] / (dispNum[1] + dispNum[2] + dispNum[3]);
			dispNum[5] = dispNum[2] / (dispNum[1] + dispNum[2] + dispNum[3]);
			dispNum[6] = dispNum[3] / (dispNum[1] + dispNum[2] + dispNum[3]);
		}
		public void Caln()
		{
			dispNum[7] = (dispNum[4] - 0.332) / (dispNum[5] - 0.1858);
		}
		public void CalT()
		{
			dispNum[8] = -437 * Math.Pow(dispNum[7], 3) + 3601 * Math.Pow(dispNum[7], 2)  
						-6861 * dispNum[7] + 5514.31;
		}

		public string CalLm()
		{
			SampleBy5nm();
			double sum = 0;
			int i = 0;
			foreach (var element in sample_5nm)
			{
				sum += element.Intensity * element.vision * 5;
				i++;
			}
			var res = sum * 683;
			Lm = res;
			//MessageBox.Show("光通量是:" + res);
			return res.ToString();
		}

		public string CalBrightness(DataIO data)
		{
			var M = Matrix<double>.Build;
			var trisValueMatrix = M.DenseOfRowArrays(data.BasicR, data.BasicG, data.BasicB);
			//var unit = M.DenseOfDiagonalArray(3, 3, new double[3] { 1, 1, 1 });
			double[] bArray = new double[3];
			bArray[0] = data.BasicR[1];
			bArray[1] = data.BasicG[1];
			bArray[2] = data.BasicB[1];
			var bMatrix = M.DenseOfDiagonalArray(3, 3, bArray);
			var cMatrix = M.DenseOfRowArrays(data.TargetMatrix);
			var res = cMatrix * trisValueMatrix.Inverse() * bMatrix * 1000000;
			var res1 = res * bMatrix;
			brightness = res.ToString();
			//var cMatrix = M.DenseOfRowArrays(data.BasicC);
			//MessageBox.Show(res.ToString());
			return res.ToString();
		}

		public void Calculate(DataIO data)
		{
			data.CalCoef(data);
			data.CalXYZ(data);
			data.Calxyz();
			data.Caln();
			data.CalT();
			data.CalBrightness(data);
		}
	}

	public class DataList
	{
		public double Wave { get; set; }
		public double Intensity { get; set; }
	}

	public class Tristimulus
	{
		public double tri_wave { get; set; }
		public double tri_x { get; set; }
		public double tri_y { get; set; }
		public double tri_z { get; set; }
	}

	public class SampleList : DataList
	{
		public double x1 { get; set; }
		public double y1 { get; set; }
		public double z1 { get; set; }
	}

	public class SampleList5 : SampleList
	{
		public double vision = 0;
	}

	public class Formulas
	{
		public string adjCoef = @"K=\frac{100}{\sum_{380}^{780} s(\lambda)\bar{y}(\lambda)\Delta\lambda }";
		public string trisMulusX = @"X=k\sum \psi(\lambda)\bar{x}(\lambda)\Delta\lambda ";
		public string trisMulusY = @"Y=k\sum \psi(\lambda)\bar{y}(\lambda)\Delta\lambda ";
		public string trisMulusZ = @"Z=k\sum \psi(\lambda)\bar{z}(\lambda)\Delta\lambda ";
		public string coordx = @"x=\frac{X}{X+Y+Z}";
		public string coordy = @"y=\frac{Y}{X+Y+Z}";
		public string coordz = @"z=\frac{Z}{X+Y+Z}";
		public string flux = @"\Phi_v=Km\cdot\int_0^{\infty} \Phi_{e\cdot\lambda}\cdot V(\lambda) d\lambda";
		public string colorT = @"T=-437n^3+3601n^2-6861n+5514.31";
		public string colorN = @"n=\frac{x-0.3320}{y-0.1858}";

		public string _coordx_ = @"x=\frac{X}{X+(*)+(*)}";
		public string _coordxy = @"y=\frac{Y}{X+(*)+(*)}";
		public string _coordxyz = @"z=\frac{Z}{X+(*)+(*)}";

		public string _coordy_ = @"y=\frac{Y}{X+Y+(*)}";
		public string _coordyx = @"x=\frac{X}{X+Y+(*)}";
		public string _coordyxz = @"z=\frac{Z}{X+Y+(*)}";

		public string _coordz_ = @"z=\frac{Z}{X+Y+Z}";
		public string _coordzx = @"x=\frac{X}{X+Y+Z}";
		public string _coordzxy = @"y=\frac{Y}{X+Y+Z}";

		// "_" profix means default value
		public string _adjCoef = @"K=\frac{100}{\sum_{380}^{780} (*) \bar{y}(\lambda)\Delta\lambda }";
		public string _trisMulusX = @"X=k\sum \psi(\lambda)\bar{x}(\lambda)\Delta\lambda ";
		public string _trisMulusY = @"Y=k\sum \psi(\lambda)\bar{y}(\lambda)\Delta\lambda ";
		public string _trisMulusZ = @"Z=k\sum \psi(\lambda)\bar{z}(\lambda)\Delta\lambda ";
		public string _coordx = @"x=\frac{X}{(*)+(*)+(*)}";
		public string _coordy = @"y=\frac{Y}{(*)+(*)+(*)}";
		public string _coordz = @"z=\frac{Z}{(*)+(*)+(*)}";
		public string _flux = @"\Phi_v=Km\cdot\int_0^{\infty} (*) V(\lambda) d\lambda";
		public string _colorT = @"T=-437n^3+3601n^2-6861n+5514.31";
		public string _colorN = @"n=\frac{(*)-0.3320}{(*)-0.1858}";
		public string _colorN1 = @"n=\frac{x-0.3320}{(*)-0.1858}";
		public string _colorN2 = @"n=\frac{(*)-0.3320}{(*)-0.1858}";
	}
}
