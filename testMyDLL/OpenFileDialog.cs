using System;
using System.Collections.Generic;
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
using System.IO;
using Microsoft.Win32;

namespace testMyDLL
{
	public class OpenFileDialog
	{
		static Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
		public string Path_File;
		public string GetFilePath()
		{
			ofd.Filter = "Pdf Files (*.pdf)|*.pdf|Jpg(*.jpg)|*.jpg|All files (*.*)|*.*";
			Nullable<bool> result = false; ofd.ShowDialog(); result = ofd.ValidateNames;
			// Get the selected file name and display in a TextBox.
			// Load content of file in a TextBlock
			
			if(	result == true)  Path_File=ofd.FileName; 
			else MessageBox.Show(" File not choised ");
			return ofd.FileName;
		}
		
	}
}
