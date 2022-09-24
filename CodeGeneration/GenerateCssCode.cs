using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualStudio.TextTemplating.VSHost;

namespace WpfCssControlLibrary.CodeGeneration
{
    [Guid("89DD8265-2ED4-442C-AF34-1E115C561955")]
    public sealed class GenerateCssCode : BaseCodeGenerator
    {
        public override string GetDefaultExtension()
        {
            return(".css");
        }

        protected override byte[] GenerateCode(string inputFileName, string inputFileContent)
        {
            var result = inputFileContent;

            if (string.IsNullOrEmpty(result))
                return null;

            // return as bytes:
            return Encoding.UTF8.GetBytes(result);
        }

        public const string GeneratorName = "CssClassFromDbGenerator";

        public const string GeneratorDescription =
            "Generates a .css file from css classes in the CssScriptClassesExtension database";
    }
}
