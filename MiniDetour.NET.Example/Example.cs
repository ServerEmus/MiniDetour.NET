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
        Hook testHook = new();
        IntPtr canHookPtr = (IntPtr)MiniDetourLoader.funcTable[(int)MiniDetourLoader.FuncTableFunction.MiniDetourHookTCanHook];
        CanHookDelegate d = new CanHookDelegate(CanHook);
        if (TryGetFunctionPointer(d, out IntPtr ptr))
        {
            Console.WriteLine(canHookPtr);
            if (!testHook.CanHook(canHookPtr))
            {
                Console.WriteLine("Cannot hook the original CanHook!");
                return;
            }
            if (!testHook.CanHook(ptr))
            {
                Console.WriteLine("Cannot hook the CanHook Delegate!");
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
        else
        {
            Console.WriteLine("we are sad");
        }
        testHook.RestoreFunction();
        Console.WriteLine(testHook.Handle);
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
}