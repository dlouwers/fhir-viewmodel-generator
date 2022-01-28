using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Xunit;

namespace FhirViewModelGeneratorTests
{
    public class ExampleTests
    {
        [Fact(Skip = "")]
        public void FhirClient_Should_ConvertToAst()
        {
            var patient = CreateResourceFromJson<Patient>("Resources/01-Patient.json");

            var jsonText = JsonConvert.SerializeObject(patient, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new List<JsonConverter> { new StringEnumConverter() },
                NullValueHandling = NullValueHandling.Ignore,
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
            });
            Assert.NotNull(jsonText);
        }

        // Please note that JSON files are always UTF-8 and a BOM marker is forbidden (https://tools.ietf.org/html/rfc8259#section-8.1).
        // Rider creates such UTF-8 files without BOM. Visual Studio creates UTF-16LE text files with little endian byte mark by default. 
        private static T CreateResourceFromJson<T>(string filePath) where T : Resource, new()
        {
            var resource = new T();

            if (!File.Exists(filePath)) throw new Exception($"Resource file {filePath} does not exist");

            using (var r = new StreamReader(filePath, Encoding.UTF8, false))
            {
                var json = r.ReadToEnd();
                var fhirJsonParser = new FhirJsonParser();
                resource = fhirJsonParser.Parse<T>(json);
            }

            return resource;
        }
    }
}