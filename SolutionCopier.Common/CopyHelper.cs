namespace SolutionCopier.Common;

public class CopyHelper
{
    public static void CopyBySource(string source, IEnumerable<string>? filter = null)
    {
        var target = source + " - copy";
        var files = new DirectoryInfo(source).EnumerateFiles();
        filter ??= new List<string>() { "bin", "obj", "packages" };
        IEnumerable<(string SourcePath, string TargetPath)> filteredFiles = files
            .Where(x => filter.Any(f => !x.FullName.Contains(f)))
            .Select(x => (x.FullName, x.FullName.Replace(source, target)));
        foreach (var file in filteredFiles)
        {
            var dir = Path.GetDirectoryName(file.TargetPath);
            if (dir is not null && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            File.Copy(file.SourcePath, file.TargetPath, true);
            Console.WriteLine(file.TargetPath);
        }
    }
}