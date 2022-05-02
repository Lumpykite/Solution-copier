namespace SolutionCopier.Console;

public static class Program
{
    [STAThread]
    public static void Main(params string[] args)
    {
        switch (args.Length)
        {
            case 1:
                SolutionCopier.Common.CopyHelper.CopyBySource(args[0]);
                break;
        }


        System.Console.ReadKey();
    }
}