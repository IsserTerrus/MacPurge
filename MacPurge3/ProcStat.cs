using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MacPurge3
{
	internal class ProcStat
	{
		public static void ReitereRegistre()
		{
			RegistryKey registryKey = Registry.ClassesRoot.CreateSubKey("Folder").CreateSubKey("shell").CreateSubKey("MacPurge");
			registryKey.SetValue("", ".:[Examiner avec MacPurge V3]:.");
			registryKey = Registry.ClassesRoot.CreateSubKey("Folder").CreateSubKey("shell").CreateSubKey("MacPurge").CreateSubKey("command");
			registryKey.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"");
			registryKey = Registry.ClassesRoot.CreateSubKey("Folder").CreateSubKey("shell").CreateSubKey("MacPurgeS");
			registryKey.SetValue("", ".:[Examiner avec MacPurge V3 (Silencieux)]:.");
			registryKey = Registry.ClassesRoot.CreateSubKey("Folder").CreateSubKey("shell").CreateSubKey("MacPurgeS").CreateSubKey("command");
			registryKey.SetValue("", "\"" + Application.ExecutablePath + "\" \"--silent\" \"%1\"");
		}

		public static void PurgeSilence(string[] paths)
		{
			for (int i = 0; i < paths.Length; i++)
			{
				string path = paths[i];
				if (Directory.Exists(path))
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(path);
					ProcStat.DelMacFiles(directoryInfo);
					ProcStat.DelMacFiles(directoryInfo.GetDirectories());
				}
			}
		}

		private static void DelMacFiles(DirectoryInfo[] dirinf)
		{
			for (int i = 0; i < dirinf.Length; i++)
			{
				DirectoryInfo directoryInfo = dirinf[i];
				try
				{
					if (directoryInfo.Name == ".Spotlight-V100" || directoryInfo.Name == ".AppleDouble")
					{
						directoryInfo.Delete(true);
					}
					else if (directoryInfo.Name == ".Trashes")
					{
						directoryInfo.Delete(true);
					}
					else
					{
						ProcStat.DelMacFiles(directoryInfo);
						ProcStat.DelMacFiles(directoryInfo.GetDirectories());
					}
				}
				catch (Exception)
				{
				}
			}
		}

		private static void DelMacFiles(DirectoryInfo dir)
		{
			try
			{
				FileInfo[] files = dir.GetFiles();
				int num = files.Length;
				for (int i = 0; i < num; i++)
				{
					if (files[i].Name.Substring(0, 2) == "._")
					{
						if (ProcStat.IsMacFile(files[i]))
						{
							files[i].Delete();
						}
					}
					else if (files[i].Name == ".DS_Store")
					{
						files[i].Delete();
					}
				}
			}
			catch (Exception)
			{
			}
		}

		public static string[] GetOnlyPath(string[] paths)
		{
			List<string> list = new List<string>();
			for (int i = 0; i < paths.Length; i++)
			{
				if (Directory.Exists(paths[i]))
				{
					list.Add(paths[i]);
				}
			}
			return list.ToArray();
		}

		public static bool IsMacFile(FileInfo f)
		{
			string b = "Mac OS X";
			bool flag = false;
			FileStream fileStream = f.OpenRead();
			byte[] array = new byte[8];
			byte[] array2 = new byte[4];
			fileStream.Position = 0L;
			fileStream.Read(array2, 0, 4);
			fileStream.Position = 8L;
			fileStream.Read(array, 0, 8);
			fileStream.Flush();
			fileStream.Close();
			if (array2[0] == 0 && array2[1] == 5 && array2[2] == 22 && array2[3] == 7)
			{
				flag = true;
			}
			return Encoding.Default.GetString(array) == b || flag;
		}

		public static void Unistall()
		{
			try
			{
				Registry.ClassesRoot.CreateSubKey("Folder").CreateSubKey("shell").CreateSubKey("MacPurge").DeleteSubKey("command");
				Registry.ClassesRoot.CreateSubKey("Folder").CreateSubKey("shell").DeleteSubKey("MacPurge");
				Registry.ClassesRoot.CreateSubKey("Folder").CreateSubKey("shell").CreateSubKey("MacPurgeS").DeleteSubKey("command");
				Registry.ClassesRoot.CreateSubKey("Folder").CreateSubKey("shell").DeleteSubKey("MacPurgeS");
			}
			catch (Exception)
			{
			}
		}
	}
}
