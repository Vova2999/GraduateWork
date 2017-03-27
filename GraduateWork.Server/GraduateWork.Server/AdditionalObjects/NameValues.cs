using System;
using System.Collections.Generic;

namespace GraduateWork.Server.AdditionalObjects {
	public class NameValues {
		private readonly Dictionary<string, string> nameValues;
		public string this[string key] {
			get {
				if (!nameValues.ContainsKey(key))
					throw new ArgumentException($"Укажите параметр '{key}'");
				return nameValues[key];
			}
		}

		public NameValues() : this(new Dictionary<string, string>()) {
		}
		public NameValues(Dictionary<string, string> nameValues) {
			this.nameValues = nameValues;
		}
	}
}