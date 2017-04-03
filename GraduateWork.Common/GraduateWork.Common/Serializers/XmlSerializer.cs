using System;
using System.Collections.Concurrent;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using SystemXmlSerializer = System.Xml.Serialization.XmlSerializer;

namespace GraduateWork.Common.Serializers {
	internal static class XmlSerializer {
		private static readonly XmlWriterSettings settings;
		private static readonly XmlSerializerNamespaces emptyNamespaces;
		private static readonly ConcurrentDictionary<Type, SystemXmlSerializer> xmlSerializers;

		static XmlSerializer() {
			settings = new XmlWriterSettings {
				Indent = true,
				IndentChars = "\t",
				OmitXmlDeclaration = false,
				Encoding = GlobalSettings.Encoding
			};

			emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
			xmlSerializers = new ConcurrentDictionary<Type, SystemXmlSerializer>();
		}

		public static byte[] Serializing<TKey>(TKey obj) {
			var xmlSerializer = GetXmlSerializer(typeof(TKey));

			using (var memoryStream = new MemoryStream())
			using (var xmlWriter = XmlWriter.Create(memoryStream, settings)) {
				xmlSerializer.Serialize(xmlWriter, obj, emptyNamespaces);
				return memoryStream.ToArray();
			}
		}

		public static TKey Deserializing<TKey>(byte[] bytes) {
			var xmlSerializer = GetXmlSerializer(typeof(TKey));

			using (var stream = new MemoryStream(bytes))
				return (TKey)xmlSerializer.Deserialize(stream);
		}

		private static SystemXmlSerializer GetXmlSerializer(Type currentType) {
			return xmlSerializers.GetOrAdd(currentType, type => new SystemXmlSerializer(type));
		}
	}
}