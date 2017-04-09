using System.Collections.Generic;
using System.Windows;
using GraduateWork.Client.UI.Extensions;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.UI.TableWindows {
	public partial class UserWindow : IProxyWindow {
		public readonly UserExtendedProxy User;
		public bool IsReadOnly { get; }

		public UserWindow(UserExtendedProxy user, bool isReadOnly) {
			InitializeComponent();

			User = user?.GetExtendedClone() ?? new UserExtendedProxy();
			IsReadOnly = isReadOnly;

			SetUserFields();
			SetReadOnly();
		}
		private void SetUserFields() {
			if (User == null)
				return;

			TextBoxUserLogin.Text = User.Login;
			TextBoxUserPassword.Text = User.Password;
			CheckBoxUserRead.IsChecked = User.IsHaveAccess(AccessType.UserRead);
			CheckBoxUserWrite.IsChecked = User.IsHaveAccess(AccessType.UserWrite);
			CheckBoxAdminRead.IsChecked = User.IsHaveAccess(AccessType.AdminRead);
			CheckBoxAdminWrite.IsChecked = User.IsHaveAccess(AccessType.AdminWrite);
			CheckBoxCreateReport.IsChecked = User.IsHaveAccess(AccessType.CreateReport);
		}
		private void SetReadOnly() {
			CommonMethods.Set.ReadOnly(TextBoxUserLogin, IsReadOnly);
			CommonMethods.Set.ReadOnly(TextBoxUserPassword, IsReadOnly);
			CommonMethods.Set.ReadOnly(CheckBoxUserRead, IsReadOnly);
			CommonMethods.Set.ReadOnly(CheckBoxUserWrite, IsReadOnly);
			CommonMethods.Set.ReadOnly(CheckBoxAdminRead, IsReadOnly);
			CommonMethods.Set.ReadOnly(CheckBoxAdminWrite, IsReadOnly);
			CommonMethods.Set.ReadOnly(CheckBoxCreateReport, IsReadOnly);
		}

		private void ButtonOk_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.CloseWindow.TrueDialogResult(this);
		}
		private void ButtonCancel_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.CloseWindow.FalseDialogResult(this);
		}

		public IEnumerable<string> GetErrors() {
			if (CommonMethods.Check.FieldIsEmpty(TextBoxUserLogin))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelUserLogin);

			if (CommonMethods.Check.FieldIsEmpty(TextBoxUserPassword))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelUserPassword);
		}
		public void WriteProxy() {
			User.Login = TextBoxUserLogin.Text;
			User.Password = TextBoxUserPassword.Text;

			User.AccessType = 0;
			if (CheckBoxUserRead.IsChecked == true)
				User.AddAccess(AccessType.UserRead);
			if (CheckBoxUserWrite.IsChecked == true)
				User.AddAccess(AccessType.UserWrite);
			if (CheckBoxAdminRead.IsChecked == true)
				User.AddAccess(AccessType.AdminRead);
			if (CheckBoxAdminWrite.IsChecked == true)
				User.AddAccess(AccessType.AdminWrite);
			if (CheckBoxCreateReport.IsChecked == true)
				User.AddAccess(AccessType.CreateReport);
		}
	}
}