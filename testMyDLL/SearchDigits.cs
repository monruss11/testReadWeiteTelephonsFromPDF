using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
using Microsoft.Win32;
using IronOcr;
using System.Windows.Media.Animation;

namespace testMyDLL
{
	public class SearchDigits
	{
		
		string strPoolNum = "";  public string text = "";  int ListLentgh = 0;
	    List<string> strPoolNumArray = new List<string> { }; public List<string> strPhoneNumArray = new List<string> { };
		public string Digits(string text)
		{
			strPoolNum = "";
			for (int i = 0; i < text.Length; i++)
			{	if (text[i] >'/' & text[i] < ':' || text[i]=='-'|| text[i] == '.' || text[i]=='+')	{ 
					strPoolNum = strPoolNum + text[i].ToString(); 
				}
				else  if (strPoolNum!="" ) { strPoolNumArray.Add(strPoolNum); strPoolNum = ""; ListLentgh = ListLentgh + 1; 
				}
			}
			for (int i = 0; i < strPoolNumArray.Count; i++) { 	
				if (strPoolNumArray.ElementAt(i).Length > 10 & strPoolNumArray.ElementAt(i).Length <= 17)
				{
					strPhoneNumArray.Add(strPoolNumArray.ElementAt(i));
				}
			}
			ListLentgh = strPhoneNumArray.Count; 
			
			for (int i = 0; i < ListLentgh; i++) { strPoolNum = strPoolNum + strPhoneNumArray.ElementAt(i) + " , "; }
				if ( ListLentgh ==0 ) strPhoneNumArray.Add("Not number is found");
			strPoolNumArray.Clear(); strPhoneNumArray.Clear();
			return  strPoolNum;
		}
		public void ProgressBar(ProgressBar PBr) {
			DispatcherTimer dt = new DispatcherTimer();
			PBr.Value = 0;
			Task.Run(() =>
			{
				for (int i = 0; i < 100; i++)
				{
					Thread.Sleep(50);
					dt.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
					{
						PBr.Value = i;  			//lbl_CountDownTimer.Text = i.ToString();
				     });
				}
			});
			//Duration duration = new Duration(TimeSpan.FromSeconds(20));
			//DoubleAnimation doubleanimation = new DoubleAnimation(150.0, duration);
			//PBr.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
		}
     }  // class
}  // namespace  
