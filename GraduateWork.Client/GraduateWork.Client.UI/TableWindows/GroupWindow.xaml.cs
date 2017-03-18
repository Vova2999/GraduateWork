using System.Windows;
using GraduateWork.Common.Tables.Proxies;

namespace GraduateWork.Client.UI.TableWindows {
	public partial class GroupWindow {
		public GroupProxy Group { get; private set; }

		public GroupWindow(GroupProxy group = null) {
			InitializeComponent();

			SetGroup(group);
		}
		private void SetGroup(GroupProxy group) {
			if (group == null)
				return;

			TextBoxNameOfGroup.Text = group.NameOfGroup;
		}

		private void ButtonOk_OnClick(object sender, RoutedEventArgs e) {
			Group = new GroupProxy {
				NameOfGroup = TextBoxNameOfGroup.Text
			};
			Close();
		}
	}
}