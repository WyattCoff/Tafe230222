using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Background;
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
	public sealed partial class CurrencyConversionCalculator : Page
	{
		// define conversion rates
		private const double usdToEuro = 0.85189982;
		private const double usdToBritishPound = 0.72872436;
		private const double usdToIndian = 74.257327;
		private const double euroToUsd = 1.1739732;
		private const double euroToBritishPound = 0.8556672;
		private const double euroToIndian = 87.00755;
		private const double britishPoundToUsd = 1.371907;
		private const double britishPoundToEuro = 1.1686692;
		private const double britishPoundToIndian = 101.68635;
		private const double indianToUsd = 0.011492628;
		private const double indianToEuro = 0.013492774;
		private const double indianToBritishPound = 0.0098339397;

		public CurrencyConversionCalculator()
		{
			this.InitializeComponent();
		}

		private void CurrencyConversionBtn_Click(object sender, RoutedEventArgs e)
		{
			convertCurrency();
		}

		private async void convertCurrency()
		{
			string fromCurrency;
			string toCurrency;
			double conversionRate = 0;
			double reverseConversionRate = 0;
			double convertedOutput = 0;
			double inputAmount;

			// catch if the amount inputted is not a number
			try
			{
				inputAmount = double.Parse(AmountTxtBox.Text);
			}
			catch (Exception)
			{
				var dialogMessage = new MessageDialog("Error! Amount must be a number.");
				await dialogMessage.ShowAsync();
				AmountTxtBox.Focus(FocusState.Programmatic);
				AmountTxtBox.SelectAll();
				return;
			}

			// get which currency is selected for the from and to combo boxes, catch if none selected or if currencies are the same
			if (FromCombo.SelectedItem == null)
			{
				var dialogMessage = new MessageDialog("Error! You must select a 'from' currency.");
				await dialogMessage.ShowAsync();
				FromCombo.Focus(FocusState.Programmatic);
				return;
			}
			else
			{
				fromCurrency = FromCombo.SelectedItem.ToString();
			}

			if (ToCombo.SelectedItem == null)
			{
				var dialogMessage = new MessageDialog("Error! You must select a 'to' currency.");
				await dialogMessage.ShowAsync();
				ToCombo.Focus(FocusState.Programmatic);
				return;
			}
			else
			{
				toCurrency = ToCombo.SelectedItem.ToString();
			}

			if (fromCurrency.Equals(toCurrency))
			{
				var dialogMessage = new MessageDialog("Error! Currencies cannot be the same.");
				await dialogMessage.ShowAsync();
				ToCombo.Focus(FocusState.Programmatic);
				return;
			}

			// switch currency based on combo box choice
			switch (fromCurrency)
			{
				case "US Dollar":
					switch (toCurrency)
					{
						case "Euro":
							conversionRate = usdToEuro;
							reverseConversionRate = euroToUsd;
							convertedOutput = inputAmount * conversionRate;
							break;
						case "British Pound":
							conversionRate = usdToBritishPound;
							reverseConversionRate = britishPoundToUsd;
							convertedOutput = inputAmount * conversionRate;
							break;
						case "Indian Rupee":
							conversionRate = usdToIndian;
							reverseConversionRate = indianToUsd;
							convertedOutput = inputAmount * conversionRate;
							break;
					}
					break;

				case "Euro":
					switch (toCurrency)
					{
						case "US Dollar":
							conversionRate = euroToUsd;
							reverseConversionRate = usdToEuro;
							convertedOutput = inputAmount * conversionRate;
							break;
						case "British Pound":
							conversionRate = usdToBritishPound;
							reverseConversionRate = britishPoundToEuro;
							convertedOutput = inputAmount * conversionRate;
							break;
						case "Indian Rupee":
							conversionRate = usdToIndian;
							reverseConversionRate = indianToEuro;
							convertedOutput = inputAmount * conversionRate;
							break;
					}
					break;

				case "BritishPound":
					switch (toCurrency)
					{
						case "US Dollar":
							conversionRate = britishPoundToUsd;
							reverseConversionRate = usdToBritishPound;
							convertedOutput = inputAmount * conversionRate;
							break;
						case "Euro":
							conversionRate = britishPoundToEuro;
							reverseConversionRate = euroToBritishPound;
							convertedOutput = inputAmount * conversionRate;
							break;
						case "Indian Rupee":
							conversionRate = britishPoundToIndian;
							reverseConversionRate = indianToBritishPound;
							convertedOutput = inputAmount * conversionRate;
							break;
					}
					break;

				case "Indian":
					switch (toCurrency)
					{
						case "US Dollar":
							conversionRate = indianToUsd;
							reverseConversionRate = usdToIndian;
							convertedOutput = inputAmount * conversionRate;
							break;
						case "Euro":
							conversionRate = indianToEuro;
							reverseConversionRate = euroToIndian;
							convertedOutput = inputAmount * conversionRate;
							break;
						case "British Pound":
							conversionRate = indianToBritishPound;
							reverseConversionRate = britishPoundToIndian;
							convertedOutput = inputAmount * conversionRate;
							break;
					}
					break;
			}

			AmountOutput.Text = "$" + inputAmount.ToString() + " " + fromCurrency + " =";
			ConvertedOutput.Text = "$" + convertedOutput.ToString() + " " + toCurrency;
			ConversionRate.Text = "1 " + fromCurrency + " = " + conversionRate.ToString() + " " + toCurrency;
			ReverseConversionRate.Text = "1 " + toCurrency + " = " + reverseConversionRate.ToString() + " " + fromCurrency;
		}

		private void ExitBtn_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(UniversalCalculatorMainPage));
		}
	}
}
