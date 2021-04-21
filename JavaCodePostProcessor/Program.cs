//by Ulysses, wdwxy12345@gmail.com
using System;
using System.IO;
using System.Threading.Tasks;

namespace XamarinPosed.JavaCodePostProcessor
{
    class Program
    {
        private const string LoaderFileName = "UlyssesLoader.java";
        private const string FullLoaderFileName = "UlyssesFullLoader.java";
        private const string FinalFileName = "XamarinPosedLoader.java";

        static async Task<int> Main(string[] args)
        {
            Console.WriteLine($"PostProcessor - args count: {args.Length}");
            if (args.Length < 2)
            {
                return -2; // missing args 
            }
            var configuration = args[0];
            var projectDir = args[1];
            var defines = "";
            if (args.Length >= 3)
            {
                defines = args[2];
            }
            
            Console.WriteLine($"ProjectDir: {projectDir}");
            Console.WriteLine($"Configuration: {configuration}");
            Console.WriteLine($"DefineConstants: {defines}");
            var verDirs = Directory.GetDirectories(Path.Combine(projectDir, "obj", configuration));

            if (verDirs.Length == 0)
            {
                return -1; // built obj not found
            }

            var disableResourceHook = defines.Contains("VXP;");
            Console.WriteLine($"VXP mode: {disableResourceHook}");

            foreach (var verDir in verDirs)
            {
                var targetDir = Path.Combine(verDir, "android", "src", "xamarin", "posed");

                Directory.CreateDirectory(targetDir);
                var target = Path.Combine(targetDir, FinalFileName);

                var sourceFileName = disableResourceHook ? LoaderFileName : FullLoaderFileName;
                File.Copy(Path.Combine(projectDir, "..", "java", sourceFileName), target, true);

                Console.WriteLine($"Output {target}");
            }

            return 0;
        }
    }
}
