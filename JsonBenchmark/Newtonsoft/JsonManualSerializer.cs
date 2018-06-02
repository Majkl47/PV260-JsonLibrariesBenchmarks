using JsonBenchmark.TestDTOs;
using Newtonsoft.Json;

namespace JsonBenchmark
{
    public class JsonManualSerializer
    {
        public void SerializeRootManually(JsonWriter jw, Root rootObject)
        {
            jw.Formatting = Formatting.Indented;
            jw.WriteStartObject();

            jw.WritePropertyName("total");
            jw.WriteValue(rootObject.total);

            jw.WritePropertyName("result");
            jw.WriteStartArray();
            SerializeResultObject(jw, rootObject.result);
            jw.WriteEndArray();

            jw.WriteEndObject();
        }

        private void SerializeResultObject(JsonWriter jw, Result[] result)
        {
            if (result == null)
            {
                return;
            }

            for (int i = 0; i < result.Length; i++)
            {
                jw.WriteStartObject();

                SerializeCategory(jw, result[i].category);

                jw.WritePropertyName("icon_url");
                jw.WriteValue(result[i].icon_url);
                jw.WritePropertyName("id");
                jw.WriteValue(result[i].id);
                jw.WritePropertyName("url");
                jw.WriteValue(result[i].url);
                jw.WriteEndObject();
            }
        }

        private void SerializeCategory(JsonWriter jw, string[] category)
        {
            if (category == null)
            {
                return;
            }

            jw.WritePropertyName("category");
            jw.WriteStartArray();

            for (int j = 0; j < category.Length; j++)
            {
                jw.WriteValue(category[j]);
            }

            jw.WriteEndArray();
        }
    }
}
