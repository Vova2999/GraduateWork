using System.Collections.Generic;
using System.Windows;
using GraduateWork.Client.UI.Extensions;
using GraduateWork.Common.Tables.Enums;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.UI.Windows.Tables {
	public partial class UserWindow : IProxyWindowWithExtendedProxy<UserExtendedProxy> {
		public UserExtendedProxy ExtendedProxy { get; private set; }
		public bool IsReadOnly { get; }

		public UserWindow(UserExtendedProxy user, bool isReadOnly) {
			InitializeComponent();

			ExtendedProxy = user?.GetExtendedClone() ?? new UserExtendedProxy();
			IsReadOnly = isReadOnly;

			SetUserFields();
			SetReadOnly();
		}
		private void SetUserFields() {
			if (ExtendedProxy == null)
				return;

			TextBoxUserLogin.Text = ExtendedProxy.Login;
			TextBoxUserPassword.Text = ExtendedProxy.Password;
			CheckBoxUserRead.IsChecked = ExtendedProxy.IsHaveAccess(AccessType.UserRead);
			CheckBoxUserWrite.IsChecked = ExtendedProxy.IsHaveAccess(AccessType.UserWrite);
			CheckBoxAdminRead.IsChecked = ExtendedProxy.IsHaveAccess(AccessType.AdminRead);
			CheckBoxAdminWrite.IsChecked = ExtendedProxy.IsHaveAccess(AccessType.AdminWrite);
			CheckBoxCreateReport.IsChecked = ExtendedProxy.IsHaveAccess(AccessType.CreateReport);
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
			ExtendedProxy.Login = TextBoxUserLogin.Text;
			ExtendedProxy.Password = TextBoxUserPassword.Text;

			ExtendedProxy.AccessType = 0;
			if (CheckBoxUserRead.IsChecked == true)
				ExtendedProxy.AddAccess(AccessType.UserRead);
			if (CheckBoxUserWrite.IsChecked == true)
				ExtendedProxy.AddAccess(AccessType.UserWrite);
			if (CheckBoxAdminRead.IsChecked == true)
				ExtendedProxy.AddAccess(AccessType.AdminRead);
			if (CheckBoxAdminWrite.IsChecked == true)
				ExtendedProxy.AddAccess(AccessType.AdminWrite);
			if (CheckBoxCreateReport.IsChecked == true)
				ExtendedProxy.AddAccess(AccessType.CreateReport);
		}
	}
}