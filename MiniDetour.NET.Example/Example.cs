using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using MiniDetour;

public class Program
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool CanHookDelegate(IntPtr handle, IntPtr functionToHook);

    public static void Main(string[] _)
    {
        IntPtr detour = NativeLibrary.Load(getLibName());
        IntPtr canHookPtr = NativeLibrary.GetExport(detour, "MiniDetourHookTCanHook");
        Hook testHook = new();
        IntPtr hookedFuncPtr = testHook.HookFunction(canHookPtr, new CanHookDelegate(CanHook));
        testHook.CanHook(IntPtr.Zero);
    }

    static bool CanHook(IntPtr handle, IntPtr functionToHook)
    {
        Console.WriteLine("yeys");
        return true;
    }

    static string getLibName()
    {
        string platform = RuntimeInformation.RuntimeIdentifier;
        string path = Path.Combine(platform, "mini_detour");
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            path += ".so";
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            path += ".dll";
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            path += ".dylib";
        return path;
    }
}