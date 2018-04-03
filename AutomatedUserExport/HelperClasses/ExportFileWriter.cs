using System;
using System.IO;
using System.Text;


namespace AutomatedUserExport.HelperClasses
{

    class ExportFileWriter
    {
        string path = "Export.csv";
        SecretDetailsReader fileHeader;

        public ExportFileWriter(string path)
        {
            this.path = path;
            this.fileHeader = new SecretDetailsReader("ExportedFileHeader.csv");
        }

        public void AddNewRecord(string record)
        {
            if (!File.Exists(path)) WriteNewLine(fileHeader.AllValueInSeperatedLine);
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

