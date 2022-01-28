using System;
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
            // TODO - actual source generator goes here!
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new FHIRViewModelSyntaxReceiver());
        }
    }
    
    public class FHIRViewModelSyntaxReceiver : ISyntaxReceiver
    {
        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            // If is a class
            if (syntaxNode is ClassDeclarationSyntax)
            {
                var classDeclarationSyntax = (ClassDeclarationSyntax)syntaxNode;
                // If has FHIRViewModel attribute
                var annotation = classDeclarationSyntax.GetAnnotations(nameof(FHIRViewModel)).FirstOrDefault();
                if (annotation != null && annotation.Data != null)
                {
                    // Compile the annotation
                    Console.Out.WriteLine(annotation.Data);
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
            if (fhirResourceType == null) throw new ArgumentNullException(nameof(fhirResourceType))
            _fhirResourceType = fhirResourceType;
        }
    }
}