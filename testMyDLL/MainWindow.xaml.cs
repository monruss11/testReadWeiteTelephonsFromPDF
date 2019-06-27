using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using IronOcr;
using System.Windows.Media.Animation;
//..

namespace testMyDLL
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		SearchDigits cls_PhoneNum = new SearchDigits();  OpenFileDialog cls_OpenFile = new OpenFileDialog();
		public string path_File; public string s; 
		public MainWindow() {
			InitializeComponent();  this.Top = 150; this.Left = 150;
			}
		private void Process_Button_Click(object sender, RoutedEventArgs e)
		{
			string str_Selected_Language;
			if (path_File == null || path_File == "" || cmb_SelectLanguage.SelectedIndex == 0) MessageBox.Show(" File or Langauge not selected ");
			else
			{	ComboBoxItem Selected_Language = (ComboBoxItem)cmb_SelectLanguage.SelectedItem;
				str_Selected_Language = Selected_Language.Content.ToString();
				//Duration duration = new Duration(TimeSpan.FromSeconds(20));
				//DoubleAnimation doubleanimation = new DoubleAnimation(150.0, duration);
				//PBar.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
				
				switch (str_Selected_Language)
				{
					case "Hebrew":
				   {
							var Ocr_Hebrew = new AdvancedOcr()
							{
								CleanBackgroundNoise = true,
								EnhanceContrast = true,
								EnhanceResolution = true,
								Language = IronOcr.Languages.Hebrew.OcrLanguagePack,
								//Language = IronOcr.Languages.English.OcrLanguagePack,
								Strategy = IronOcr.AdvancedOcr.OcrStrategy.Advanced,
								ColorSpace = AdvancedOcr.OcrColorSpace.Color,
								DetectWhiteTextOnDarkBackgrounds = true,
								InputImageType = AdvancedOcr.InputTypes.AutoDetect,
								RotateAndStraighten = false,
								ReadBarCodes = false,
								ColorDepth = 4
				
							}; var Result = Ocr_Hebrew.Read(path_File); txtBigText.TextAlignment=TextAlignment .Right; cls_PhoneNum.ProgressBar(PBar); txtBigText.Text = Result.Text; 
				   }
					break;
    				case "English":
					{
							var Ocr_English = new AutoOcr() { Language = IronOcr.Languages.English.OcrLanguagePack, };
							var Result = Ocr_English.Read(path_File);
							txtBigText.TextAlignment = TextAlignment.Left ; txtBigText.Text = Result.Text; 
					}
					break;
				}
				cls_PhoneNum.text = txtBigText.Text;  	txtPhones.Text =  cls_PhoneNum.Digits(txtBigText.Text);
				
			}
		}
		private void Load_Button_Click(object sender, RoutedEventArgs e) {
			path_File = cls_OpenFile.GetFilePath();
			if (path_File != "") { txtFilePath.Text = path_File; }	else MessageBox.Show(" File not choised ");
		}

		private void SavetoFile_Button_Click(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.SaveFileDialog sf_dlg = new Microsoft.Win32.SaveFileDialog();
			sf_dlg.DefaultExt = ".txt"; sf_dlg.Filter = "Text documents (.txt)|*.txt";
			if (sf_dlg.ShowDialog() == true)
			{
				string filename = sf_dlg.FileName; StreamWriter sw = new StreamWriter(@filename, false); sw.Write(txtBigText.Text);  sw.Close();
			}
		}		
	}
	
}
