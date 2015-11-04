using UnityEngine;
using System.Collections;
using System.IO;

namespace ComLib
{
	public static class ComSystemIO
	{
		public static void Delete ( string fullPath )
		{
			File.Delete (fullPath);
		}

		public static bool Exists ( string fullPath )
		{
			return File.Exists (fullPath);
		}

		public static void MakeDirectory ( string fullPath )
		{
			string directoryPath = Path.GetDirectoryName (fullPath);

			if (Directory.Exists (directoryPath) == false) 
			{
				Directory.CreateDirectory(directoryPath);
			}
		}

		public static void Create ( string fullPath, string data )
		{
			MakeDirectory (fullPath);

			using (FileStream fs = new FileInfo(fullPath).Open(FileMode.Create, FileAccess.ReadWrite)) 
			{

				byte[] byteData = System.Text.Encoding.ASCII.GetBytes(data);

				fs.Write(byteData, 0, byteData.Length);

			}
		}
	}
}