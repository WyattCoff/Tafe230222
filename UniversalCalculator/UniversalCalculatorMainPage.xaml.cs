using Calculator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class UniversalCalculatorMainPage : Page
	{
		public UniversalCalculatorMainPage()
		{
			this.InitializeComponent();
		}

		private void mathsCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainPage));
		}

		private void Mortgage_Calculator_Page(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Mortgage_Calculator_Page));
		}

		private void Currency_Conversion_Page(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(CurrencyConversionCalculator));
		}

		private void ExitBtn_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Exit();
		}

		private async void Click_Trip_Calculator(object sender, RoutedEventArgs e)
		{
			var dialogMessage = new MessageDialog("Trip Calculator C# code will be developed later.");
			await dialogMessage.ShowAsync();
		}
    }

}




