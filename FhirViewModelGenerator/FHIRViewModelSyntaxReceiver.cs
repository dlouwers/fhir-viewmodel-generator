using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FhirViewModelGenerator
{
    [Generator]
    public class FHIRTransformerGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var receiver = (FHIRViewModelSyntaxReceiver)context.SyntaxReceiver;
            foreach (var classDeclarationSyntax in receiver.Declarations)
            {
                var symbol = context.Compilation
                    .GetSemanticModel(classDeclarationSyntax.SyntaxTree)
                    .GetDeclaredSymbol(classDeclarationSyntax);
                var typ = symbol.GetAttributes().First().NamedArguments[0].Value.Value as Type;
            }
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new FHIRViewModelSyntaxReceiver());
        }
    }
    
    public class FHIRViewModelSyntaxReceiver : ISyntaxReceiver
    {
        public readonly IEnumerable<ClassDeclarationSyntax> Declarations = new List<ClassDeclarationSyntax>();
        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            // If is a class
            if (syntaxNode is ClassDeclarationSyntax)
            {
                var classDeclarationSyntax = syntaxNode as ClassDeclarationSyntax;
                // If has FHIRViewModel attribute
                var annotation = classDeclarationSyntax.GetAnnotations(nameof(FHIRViewModel)).FirstOrDefault();
                if (annotation != null)
                {
                    // Register the class declaration
                    Declarations.Append(classDeclarationSyntax);
                }
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class FHIRViewModel : Attribute
    {
        private Type _fhirResourceType;

        public FHIRViewModel(Type fhirResourceType)
        {
            if (fhirResourceType == null) throw new ArgumentNullException(nameof(fhirResourceType));
            _fhirResourceType = fhirResourceType;
        }
    }
}