using System;
using GraduateWork.Common.Tables.Proxies;

namespace GraduateWork.Client.UI.TableWindows {
	public partial class GroupWindow {
		public GroupProxy Group { get; private set; }

		public GroupWindow(GroupProxy group = null) {
			InitializeComponent();
			Closed += GroupWindow_Closed;

			SetGroup(group);
		}
		private void SetGroup(GroupProxy group) {
			if (group == null)
				return;

			TextBoxNameOfGroup.Text = group.NameOfGroup;
		}

		private void GroupWindow_Closed(object sender, EventArgs e) {
			Group = new GroupProxy {
				NameOfGroup = TextBoxNameOfGroup.Text
			};
		}
	}
}