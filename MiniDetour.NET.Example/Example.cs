using System;
using System.Runtime.InteropServices;

namespace MiniDetour.NET.Example;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate bool CanHookDelegate(IntPtr handle, IntPtr functionToHook);

public unsafe class Program
{
    public static void Main(string[] _)
    {
        using Hook testHook = new(true);
        IntPtr canHookPtr = (IntPtr)MiniDetourLoader.funcTable[(int)MiniDetourLoader.FuncTableFunction.MiniDetourHookTCanHook];
        CanHookDelegate d = new(CanHook);
        IntPtr ptr = Marshal.GetFunctionPointerForDelegate(d);
        if (ptr != IntPtr.Zero)
        {
            Console.WriteLine(testHook.CanHook(canHookPtr));
            Console.WriteLine(testHook.CanHook(ptr));
            if (!testHook.CanHook(canHookPtr))
            {
                Console.WriteLine("Cannot hook the original CanHook!");
                return;
            }
            IntPtr hookedFuncPtr = testHook.HookFunction(canHookPtr, ptr);
            if (hookedFuncPtr == IntPtr.Zero)
            {
                Console.WriteLine("Could not hook this!");
                testHook.RestoreFunction();
                return;
            }
            Console.WriteLine(testHook.CanHook(ptr));
        }
        testHook.Dispose();
        using Hook testHook2 = new(true);
        Console.WriteLine(testHook2.CanHook(canHookPtr));
        Console.ReadLine();
    }

    static bool CanHook(IntPtr handle, IntPtr functionToHook)
    {
        Console.WriteLine("CanHook Detour!");
        return true;
    }
}