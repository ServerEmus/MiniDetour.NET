using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using MiniDetour;

public unsafe class Program
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool CanHookDelegate(IntPtr handle, IntPtr functionToHook);

    public static void Main(string[] _)
    {
        PrintModules();
        Console.WriteLine("testHook");
        Hook testHook = new();
        Console.WriteLine(testHook.Handle);
        PrintModules();
        IntPtr canHookPtr = (IntPtr)MiniDetourLoader.funcTable[(int)MiniDetourLoader.FuncTableFunction.MiniDetourHookTCanHook];
        Console.WriteLine("GetExport");
        Console.WriteLine(canHookPtr);
        CanHookDelegate d = new CanHookDelegate(CanHook);
        if (TryGetFunctionPointer(d, out IntPtr ptr))
        {
            Console.WriteLine("GetFunctionPointerForDelegate");
            Console.WriteLine(ptr);
            Console.WriteLine("CanHookToCanHookPtr");
            Console.WriteLine(testHook.CanHook(canHookPtr)); 
            Console.WriteLine("CanHookToPtr");
            Console.WriteLine(testHook.CanHook(ptr));
            IntPtr hookedFuncPtr = testHook.HookFunction(canHookPtr, ptr);
            Console.WriteLine("hookedFuncPtr");
            Console.WriteLine(hookedFuncPtr);
            testHook.CanHook(IntPtr.Zero);
        }
        else
        {
            Console.WriteLine("we are sad");
        }
    }

    static bool TryGetFunctionPointer(Delegate d, out IntPtr pointer)
    {
        ArgumentNullException.ThrowIfNull(d);
        var method = d.Method;

        if (d.Target is {} || !method.IsStatic || method is DynamicMethod)
        {
            pointer = IntPtr.Zero;
            return false;
        }

        pointer = method.MethodHandle.GetFunctionPointer();
        return true;
    }

    static bool CanHook(IntPtr handle, IntPtr functionToHook)
    {
        Console.WriteLine("yeys");
        return true;
    }

    static IntPtr GetBaseAddressFrom(string moduleName)
    {
        Process CachedProcess = Process.GetCurrentProcess();
        CachedProcess.Refresh();
        List<ProcessModule> ProcessModules = [];
        ProcessModuleCollection myProcessModuleCollection = CachedProcess.Modules;
        for (int i = 0; i < myProcessModuleCollection.Count; i++)
        {
            Console.WriteLine(myProcessModuleCollection[i].ModuleName);
            ProcessModules.Add(myProcessModuleCollection[i]);
        }
        ProcessModule? module = ProcessModules.FirstOrDefault(x => x.ModuleName.Contains(moduleName, StringComparison.InvariantCultureIgnoreCase));
        if (module == null)
            return IntPtr.Zero;
        return module.BaseAddress;
    }

    static void PrintModules()
    {
        Process CachedProcess = Process.GetCurrentProcess();
        ProcessModuleCollection myProcessModuleCollection = CachedProcess.Modules;
        for (int i = 0; i < myProcessModuleCollection.Count; i++)
        {
            Console.WriteLine(myProcessModuleCollection[i].FileName);
            Console.WriteLine(myProcessModuleCollection[i].ModuleName);
        }
        CachedProcess.Refresh();
        myProcessModuleCollection = CachedProcess.Modules;
        for (int i = 0; i < myProcessModuleCollection.Count; i++)
        {
            Console.WriteLine(myProcessModuleCollection[i].ModuleName);
        }
    }
}