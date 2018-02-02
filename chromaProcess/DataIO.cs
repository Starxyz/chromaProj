using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using OxyPlot;
using System.Windows.Controls;

namespace chromaProcess
{
	public class DataIO
	{
		public string inputPath;
		public List<DataList> wave_intensity = new List<DataList>();
		public List<Tristimulus> tri_values = new List<Tristimulus>();
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
			MessageBox.Show(wave_intensity.Count.ToString());
		}

		public void SaveData()
		{
			SaveFileDialog sfd = new SaveFileDialog();
			var result = sfd.ShowDialog();
			if (result == true)
			{
				
			}
		}

		public void inputTriData(ListView listView)
		{
			if (true)
			{
				string[] split = new string[4];
				var str = File.ReadAllLines("三刺激值.txt");
				char[] delimiterChars = { ',' };
				foreach (var element in str)
				{
					var deleteSpace = element.Replace(" ", "");
					split = deleteSpace.Split(delimiterChars);
					try
					{
						tri_values.Add(new Tristimulus()
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
						break;
					}
				}
				listView.ItemsSource = tri_values;
			}
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
}
