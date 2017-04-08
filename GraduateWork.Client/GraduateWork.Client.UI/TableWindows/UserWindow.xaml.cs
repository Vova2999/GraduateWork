using System.Collections.Generic;
using System.Windows;
using GraduateWork.Client.UI.Extensions;
using GraduateWork.Common;
using GraduateWork.Common.Tables.Proxies.Extendeds;

namespace GraduateWork.Client.UI.TableWindows {
	public partial class UserWindow {
		public readonly UserExtendedProxy User;
		private readonly bool isReadOnly;

		public UserWindow(UserExtendedProxy user, bool isReadOnly) {
			InitializeComponent();
			User = user?.GetExtendedClone() ?? new UserExtendedProxy();
			this.isReadOnly = isReadOnly;

			SetUserFields();
			SetReadOnly();
		}
		private UserExtendedProxy GetClone(UserExtendedProxy user) {
			return new UserExtendedProxy {
				Login = user.Login,
				Password = user.Password,
				AccessType = user.AccessType
			};
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
			CommonMethods.Set.ReadOnly(TextBoxUserLogin, isReadOnly);
			CommonMethods.Set.ReadOnly(TextBoxUserPassword, isReadOnly);
			CommonMethods.Set.ReadOnly(CheckBoxUserRead, isReadOnly);
			CommonMethods.Set.ReadOnly(CheckBoxUserWrite, isReadOnly);
			CommonMethods.Set.ReadOnly(CheckBoxAdminRead, isReadOnly);
			CommonMethods.Set.ReadOnly(CheckBoxAdminWrite, isReadOnly);
			CommonMethods.Set.ReadOnly(CheckBoxCreateReport, isReadOnly);
		}

		private void ButtonOk_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.CloseWindow.TrueDialogResult(this, isReadOnly, GetErrors(), WriteUser);
		}
		private void ButtonCancel_OnClick(object sender, RoutedEventArgs e) {
			CommonMethods.CloseWindow.FalseDialogResult(this);
		}

		private IEnumerable<string> GetErrors() {
			if (CommonMethods.Check.FieldIsEmpty(TextBoxUserLogin))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelUserLogin);
			if (CommonMethods.Check.FieldIsEmpty(TextBoxUserPassword))
				yield return CommonMethods.GenerateMessage.FieldIsEmpty(LabelUserPassword);
		}
		private void WriteUser() {
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