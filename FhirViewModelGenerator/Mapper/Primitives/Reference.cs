namespace FhirViewModelGenerator.Mapper.Primitives
{
    public record Reference
    {
        public string Display { get; init; }
        public string Identifier { get; init; }
        public string ReferenceType { get; init; }
        public string Role { get; init; }
        public Reference PractitionerRoleReference { get; init; }
    }
}
