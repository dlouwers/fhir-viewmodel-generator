using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFhirViewModelGenerator.Mapper.Primitives
{
    /// <summary>
    /// https://simplifier.net/packages/hl7.fhir.r3.core/3.0.2/files/62003
    /// </summary>
    public record Attachment
    {
        public string ContentType { get; init; }
        public string Language { get; init; }
        public string Base64Data { get; init; }
        public string AlternativeUrl { get; init; }
        public int Size { get; init; }
        public string Title { get; init; }
        public string Creation { get; init; }
        public bool IsHashVerificationFailed { get; init; }
    }
}
