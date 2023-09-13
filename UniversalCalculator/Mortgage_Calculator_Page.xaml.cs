using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Calculator
{
	public sealed partial class Mortgage_Calculator_Page : Page
	{
		public Mortgage_Calculator_Page()
		{
			this.InitializeComponent();
		}

		private void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			// Parsing user inputs
			if (double.TryParse(principalBorrowTextBox.Text, out double principal) &&
				int.TryParse(yearsTextBox.Text, out int years) &&
				int.TryParse(andMonthsTextBox.Text, out int months) &&
				double.TryParse(yearlyIntrestRateTextBox.Text, out double yearlyRate))
			{
				// Convert the yearly interest rate to a monthly interest rate in decimal form
				double monthlyRate = yearlyRate / 100.0 / 12.0;

				// Auto-fill the monthly interest rate TextBox
				MonthlyIntrestRateTextBox.Text = (monthlyRate * 100.0).ToString("F2");

				// Calculate the total number of monthly payments
				int totalMonths = (years * 12) + months;

				// Mortgage calculation using the formula
				double numerator = monthlyRate * Math.Pow(1 + monthlyRate, totalMonths);
				double denominator = Math.Pow(1 + monthlyRate, totalMonths) - 1;
				double monthlyRepayment = principal * (numerator / denominator);

				// Update the TextBox to show the calculated monthly repayment
				monthlyRepaymentTextBox.Text = monthlyRepayment.ToString("F2");
			}
			else
			{
				// Show an error message if input values are incorrect
				monthlyRepaymentTextBox.Text = "Invalid Input";
			}
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(UniversalCalculatorMainPage));
		}
	}
}
