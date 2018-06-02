using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using JsonBenchmark.TestDTOs;
using Newtonsoft.Json;
using System;
using System.IO;

namespace JsonBenchmark
{
    [ClrJob(isBaseline: true)]
    [RPlotExporter, RankColumn]
    [HtmlExporter]
    public class JsonDeserializersBenchmarks : JsonBenchmarkBase
    {
        [Benchmark]
        public Root NewtonsoftJson_Deserialize_ChuckNorris()
        {
            return JsonConvert.DeserializeObject<Root>(JsonSampleString);
        }

        [Benchmark]
        public Root NewtonsoftJson_Deserialize_TestFile()
        {
            return JsonConvert.DeserializeObject<Root>(JsonSampleNotFunnyString);
        }

        [Benchmark]
        public Root NewtonsoftJson_Deserialize_ChuckNorris_Optimized()
        {
            StringReader stringReader = new StringReader(JsonSampleString);

            using (JsonReader jsonReader = new JsonTextReader(stringReader))
            {
                JsonSerializer serializer = new JsonSerializer();
                return serializer.Deserialize<Root>(jsonReader);
            }
        }

        [Benchmark]
        public Root NewtonsoftJson_Deserialize_ChuckNorris_Stream()
        {
            using (FileStream file = 
                   File.OpenRead(Path.Combine(AppContext.BaseDirectory, "TestFiles", "chucknorris.json")))
            using (StreamReader streamReader = new StreamReader(file))
            using (JsonReader jsonReader = new JsonTextReader(streamReader))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                return jsonSerializer.Deserialize<Root>(jsonReader);
            }
        }
    }
}
