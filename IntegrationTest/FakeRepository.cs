using OMSZ.App;
namespace IntegrationTest
{
    using System;
    using System.IO;

    public class FakeRepository : IRepository
    {
        public string _fileName;

        public FakeRepository(string fileName)
        {
            _fileName = fileName;
        }

        public string GetWebContent()
        {
            if (string.IsNullOrEmpty(_fileName))
            {
                throw new ArgumentException("Filename should be set up");
            }

            string html = string.Empty;
            using (StreamReader sr = new StreamReader(_fileName, System.Text.Encoding.UTF8))
            {
                html = sr.ReadToEnd();
                sr.Close();
            }
            if (html == string.Empty)
            {
                Console.WriteLine("Nothing in the file");
            }
            return html;
        }
    }
}
