using System.Collections.Generic;

namespace GraduateWork.Server.AdditionalObjects {
	public class NameValues {
		private readonly Dictionary<string, string> nameValues;
		public string this[string key] {
			get { return nameValues[key]; }
		}

		public NameValues() : this(new Dictionary<string, string>()) {
		}
		public NameValues(Dictionary<string, string> nameValues) {
			this.nameValues = nameValues;
		}

		public bool NotContains(string key) {
			return !nameValues.ContainsKey(key);
		}
	}
}