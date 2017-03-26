namespace GraduateWork.Common.Reports {
	public class FileWithContent {
		public readonly string FileName;
		public readonly byte[] Content;

		public FileWithContent(string fileName, byte[] content) {
			FileName = fileName;
			Content = content;
		}
	}
}