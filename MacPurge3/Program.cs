using System;
using System.Windows.Forms;

namespace MacPurge3
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			string text = Environment.CommandLine;
			text = text.Replace("\" \"", "|");
			text = text.Replace('"', ' ');
			text = text.Trim();
			string[] array = text.Split(new char[]
			{
				'|'
			});
			if (array.Length > 1)
			{
				string a;
				if ((a = array[1]) != null)
				{
					if (a == "--reg-insere")
					{
						ProcStat.ReitereRegistre();
						return;
					}
					if (a == "--silent")
					{
						ProcStat.PurgeSilence(ProcStat.GetOnlyPath(array));
						return;
					}
					if (a == "--unistall")
					{
						ProcStat.Unistall();
						return;
					}
				}
				Application.Run(new FEN_Purge(ProcStat.GetOnlyPath(array)));
			}
		}
	}
}
