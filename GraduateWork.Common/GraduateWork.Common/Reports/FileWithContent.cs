namespace GraduateWork.Common.Reports {
	// ReSharper disable ClassNeverInstantiated.Global
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable NotAccessedField.Global

	public class FileWithContent {
		public readonly string FileName;
		public readonly byte[] Content;

		public FileWithContent(string fileName, byte[] content) {
			FileName = fileName;
			Content = content;
		}
	}
}