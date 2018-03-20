using System;
using System.IO;
using System.Text;


namespace AutomatedUserExport.HelperClasses
{

    class ExportFileWriter
    {
        string path = "Export.csv";
        SecretDetailsReader sdr;

        public ExportFileWriter(string path, SecretDetailsReader sdr)
        {
            this.path = path;
            this.sdr = sdr;
        }

        public void AddNewRecord(string record)
        {
            if (!File.Exists(path)) WriteNewLine(sdr.GetSecretValue("exportFileHeader").Replace(';', ','));
            else WriteNewLine(record);
        }
        private void WriteNewLine(string record)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Append))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                    {
                        sw.WriteLine(record);
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

