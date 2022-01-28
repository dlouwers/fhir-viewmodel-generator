namespace FhirViewModelGenerator.Maps
{
    public record PatientViewModelMap
    {
        public string Id { get; init; }
        public string OriginDisplayName { get; init; }
        public string LastUpdated { get; init; }
        public string[] Identifiers { get; init; }
        public bool IsInactive { get; init; }
        public string[] Names { get; init; }
        public string[] ContactDetails { get; init; }
        public string Gender { get; init; }
        public string BirthDate { get; init; }
        public string DeceasedDate { get; init; }
        public bool? IsDeceased { get; init; }
        public string[] Addresses { get; init; }
        public string MaritalStatus { get; init; }
        public int? MultipleBirthIndicator { get; init; }
        public bool? IsMultipleBirth { get; init; }
        public string[] Photo { get; init; }
        public string[] Contacts { get; init; }
        public bool IsAnimal { get; init; }
        public string[] Languages { get; init; }
        public string GeneralPractitionerReference { get; init; }
        public string ManagingOrganizationReference { get; init; }
        public string PreferredPharamacyReference { get; init; }
        public string[] Nationalities { get; init; }
        public string[] LegalStatuses { get; init; }
        public string[] LifeStances { get; init; }
        public string[] Links { get; init; }
    }
}
