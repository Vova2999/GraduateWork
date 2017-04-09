using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using GraduateWork.Common;
using GraduateWork.Common.Extensions;
using GraduateWork.Common.Http;

namespace GraduateWork.Server.UI {
	public partial class MainWindow {
		private readonly ServerUiSettings serverUiSettings;
		private readonly ServerSettings serverSettings;

		public MainWindow() {
			InitializeComponent();
			serverUiSettings = LoadServerUiSettings();
			serverSettings = LoadServerSettings();
		}
		private ServerSettings LoadServerSettings() {
			var settings = FileSettings.ReadSettings<ServerSettings>(ServerSettings.FileName);
			TextBoxServerAddress.Text = settings.ServerAddress;

			return settings;
		}
		private ServerUiSettings LoadServerUiSettings() {
			var settings = FileSettings.ReadSettings<ServerUiSettings>(ServerUiSettings.FileName);
			TextBoxUserLogin.Text = settings.UserLogin;
			PasswordBoxUserPassword.Password = settings.UserPassword;
			CheckBoxSaveLoginAndPassword.IsChecked = settings.SaveLoginAndPassword;

			return settings;
		}

		private void MainWindow_OnClosing(object sender, CancelEventArgs e) {
			var saveLoginAndPassword = CheckBoxSaveLoginAndPassword.IsChecked == true;

			serverUiSettings.UserLogin = saveLoginAndPassword ? TextBoxUserLogin.Text : string.Empty;
			serverUiSettings.UserPassword = saveLoginAndPassword ? PasswordBoxUserPassword.Password : string.Empty;
			serverUiSettings.SaveLoginAndPassword = saveLoginAndPassword;

			FileSettings.WriteSettings(serverUiSettings, ServerUiSettings.FileName);
		}

		private async void ButtonRunServer_OnClick(object sender, RoutedEventArgs e) {
			SetEnabledControls(true);

			try {
				serverSettings.ServerAddress = new UriBuilder(TextBoxServerAddress.Text).ToString();
				FileSettings.WriteSettings(serverSettings, ServerSettings.FileName);
				await Task.Run(() => Program.RunServer());
			}
			catch (Exception exception) {
				MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}

			SetEnabledControls(false);
		}
		private void ButtonStopServer_OnClick(object sender, RoutedEventArgs e) {
			try {
				var webRequest = (HttpWebRequest)WebRequest.Create($"{serverSettings.ServerAddress}Stop?{GetParametersForStop()}");
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
			return $"{HttpParameters.Login}={TextBoxUserLogin.Text}&{HttpParameters.Password}={PasswordBoxUserPassword.Password}";
		}

		private void SetEnabledControls(bool serverIsRun) {
			LabelServerAddress.Foreground = serverIsRun ? Brushes.Silver : Brushes.DodgerBlue;
			TextBoxServerAddress.IsEnabled = !serverIsRun;
			ButtonRunServer.IsEnabled = !serverIsRun;
			ButtonStopServer.IsEnabled = serverIsRun;
		}
	}
}