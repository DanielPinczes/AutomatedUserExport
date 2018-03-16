using System;
using System.IO;
using System.Collections.Generic;

namespace AutomatedUserExport.HelperClasses
{
	class SecretDetailsReader
	{
		string path;
		char separator = ',';
		Dictionary<string, string> secretDetails = new Dictionary<string, string>();
		
		public SecretDetailsReader(string path)
		{
			this.path = path;

			ReadSecretDetails();
		}

		public char Separator { set => separator = value; }
		public string GetSecretValue(string key) => secretDetails[key];

		void ReadSecretDetails()
		{
			try
			{
				using (FileStream fs = new FileStream(path, FileMode.Open))
				{
					using (StreamReader sr = new StreamReader(fs))
					{
						while (sr.Peek() >= 0)
						{
							string[] row = sr.ReadLine().Split(',');
							string dataDenomination = row[0], dataValue = row[1];

							secretDetails.Add(dataDenomination, dataValue);

						}
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("The process failed: {0}", e.ToString());
			}
		}
	}
}
