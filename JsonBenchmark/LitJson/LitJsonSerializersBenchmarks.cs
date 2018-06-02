using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using LitJson;

namespace JsonBenchmark
{
    [ClrJob(isBaseline: true)]
    [RPlotExporter, RankColumn]
    [HtmlExporter]
    public class LitJsonSerializersBenchmarks : JsonBenchmarkBase
    {
        [Benchmark]
        public string LitJson_Serialize()
        {
            return JsonMapper.ToJson(SampleRootObject);
        }
    }
}
