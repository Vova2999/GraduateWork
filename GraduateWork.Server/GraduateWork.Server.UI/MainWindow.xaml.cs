using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Http;

namespace GraduateWork.Server.UI {
	public partial class MainWindow {
		private string serverAddress;

		public MainWindow() {
			InitializeComponent();
		}
		private async void ButtonRunServer_OnClick(object sender, RoutedEventArgs e) {
			ButtonRunServer.IsEnabled = false;
			ButtonStopServer.IsEnabled = true;

			try {
				serverAddress = new UriBuilder(TextBoxServerAddress.Text).ToString();
				await Task.Run(() => Program.Main(serverAddress));
			}
			catch (Exception exception) {
				MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}

			ButtonRunServer.IsEnabled = true;
			ButtonStopServer.IsEnabled = false;
		}
		private void ButtonStopServer_OnClick(object sender, RoutedEventArgs e) {
			try {
				var webRequest = (HttpWebRequest)WebRequest.Create($"{serverAddress}Stop?{GetParametersForStop()}");
				webRequest.Method = "GET";
				webRequest.Timeout = 5000;
				webRequest.GetResponse();
			}
			catch (WebException exception) {
				var exceptionMessage = string.Join("\n",
					new[] { exception.Message, exception.Response?.GetResponseStream().ReadAndDispose().FromJson<string>() }
						.Where(message => !string.IsNullOrEmpty(message)));

				MessageBox.Show(exceptionMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			catch (Exception exception) {
				MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		private string GetParametersForStop() {
			return $"{HttpParameters.Login}={TextBoxUserLogin.Text}&{HttpParameters.Password}={TextBoxUserPassword.Text}";
		}
	}
}