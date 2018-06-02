using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using JsonBenchmark.TestDTOs;
using LitJson;

namespace JsonBenchmark
{
    [ClrJob(isBaseline: true)]
    [RPlotExporter, RankColumn]
    [HtmlExporter]
    public class LitJsonDeserializersBenchmarks : JsonBenchmarkBase
    {
        [Benchmark]
        public Root LitJson_Deserialize_ChuckNorris()
        {
            return JsonMapper.ToObject<Root>(JsonSampleString);
        }
    }
}
