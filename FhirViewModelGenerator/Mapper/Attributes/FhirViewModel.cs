using FhirViewModelGenerator.Mapper.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FhirViewModelGenerator.Mapper.Attributes
{
    public class FhirViewModel: Attribute
    {
        public FhirResourceType ResourceType { get; set; }
    }
}
