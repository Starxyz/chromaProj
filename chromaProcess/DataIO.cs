using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace chromaProcess
{
	class DataIO
	{
		private string inputPath;
		public List<DataList> items = new List<DataList>();
 		public void ChooseInputDir()
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.InitialDirectory = "G:\\star\\new_race\\data\\1-16\\normal";
			fileDialog.Filter = "txt files(*.txt)|*.txt|All files(*.*)|*.*";
			fileDialog.FilterIndex = 2;
			fileDialog.RestoreDirectory = true;
			if (fileDialog.ShowDialog() == true)
			{
				if (fileDialog.FileName != "")
				{

					inputPath = fileDialog.FileName;
					//MessageBox.Show(inputPath);
					AddData();
				}
			}
		}

		public void AddData()
		{
			var str = File.ReadAllLines(inputPath);
			string[] split = new string[2];
			foreach (var element in str)
			{
				split = element.Split(' ');
				try
				{

					items.Add(new DataList() { Wave = Double.Parse(split[0]), Intensity = Double.Parse(split[1]) });
				}
				catch {
					MessageBox.Show("数据格式错误");
				}
			}
			MessageBox.Show(items.Count.ToString());
		}
		private string outputPath;
		public void ChooseOutputDir()
		{
			System.Windows.Forms.FolderBrowserDialog folder = new System.Windows.Forms.FolderBrowserDialog();
			if (folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				outputPath = folder.SelectedPath;
				MessageBox.Show(outputPath);
			}
		}
	}

	class DataList
	{
		public double Wave { get; set; }
		public double Intensity { get; set; }
	}
}
