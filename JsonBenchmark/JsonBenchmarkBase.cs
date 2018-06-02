using JsonBenchmark.TestDTOs;
using System;
using System.IO;

namespace JsonBenchmark
{
    public abstract class JsonBenchmarkBase
    {
        private const string TestFilesFolder = "TestFiles";
        protected string JsonSampleString;
        protected string JsonSampleNotFunnyString;
        protected Root SampleRootObject;

        protected JsonBenchmarkBase()
        {
            JsonSampleString = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, TestFilesFolder, "chucknorris.json"));

            JsonSampleNotFunnyString = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, TestFilesFolder, "testfile.json"));

            SampleRootObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(JsonSampleString);
        }
    }
}
