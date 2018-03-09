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
		public static string inputPath;	//所有类共用一个路径
		public List<DataList> wave_intensity = new List<DataList>();
		public List<Tristimulus> tri_values = new List<Tristimulus>();
		public List<SampleList> sample_1nm = new List<SampleList>();
		public List<SampleList> sample_5nm = new List<SampleList>();
		public double[] dispNum = new double[9];
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
				string header = "波长\t强度\tx\ty\tz";
				StreamWriter file = new StreamWriter(localFilePath);
				file.WriteLine(header);
				MessageBox.Show(data.sample_1nm.Count.ToString());
				foreach (var item in data.sample_1nm)
				{
					string line = item.Wave.ToString() + '\t' + item.Intensity.ToString() + '\t'
									+ item.x1.ToString() + '\t' + item.y1.ToString() + '\t' + item.z1.ToString();
					file.WriteLine(line);
				}
				file.Close();
			}
		}

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
			foreach (var item in sample_1nm)
			{
				if (item.Wave % 5 == 0)
				{
					sample_5nm.Add(item);
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
			var res = cMatrix * trisValueMatrix.Inverse() * bMatrix;
			var res1 = res * bMatrix;
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
	}
}
