using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using MiniDetour;

public class Program
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool CanHookDelegate(IntPtr handle, IntPtr functionToHook);

    public static void Main(string[] _)
    {
        IntPtr detour = GetBaseAddressFrom("mini_detour");
        Console.WriteLine("loaded lib");
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

    static List<ProcessModule> ProcessModules { get; } = [];
    static Process CachedProcess { get; }

    static IntPtr GetBaseAddressFrom(string moduleName)
    {
        CachedProcess = Process.GetCurrentProcess();
        CachedProcess.Refresh();
        ProcessModules.Clear();
        ProcessModuleCollection myProcessModuleCollection = CachedProcess.Modules;
        for (int i = 0; i < myProcessModuleCollection.Count; i++)
        {
            ProcessModules.Add(myProcessModuleCollection[i]);
        }
        ProcessModule? module = ProcessModules.FirstOrDefault(x => x.ModuleName.Contains(moduleName, StringComparison.InvariantCultureIgnoreCase));
        if (module == null)
            return IntPtr.Zero;
        return module.BaseAddress;
    }
}