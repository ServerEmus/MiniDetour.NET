using HexaGen.Runtime;
using System.Diagnostics;

namespace MiniDetour;

public static class MiniDetourLoaderConfig
{
    public static bool AotStaticLink;
}

public static unsafe partial class MiniDetourLoader
{
    static MiniDetourLoader()
    {
        if (MiniDetourLoaderConfig.AotStaticLink)
        {
            InitApi(new NativeLibraryContext(Process.GetCurrentProcess().MainModule!.BaseAddress));
        }
        else
        {
            InitApi(new NativeLibraryContext(LibraryLoader.LoadLibrary(GetLibraryName, null)));
        }
    }

    public static string GetLibraryName()
    {
        return "mini_detour";
    }
}