using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MiniDetour;

internal static class UtilsNative
{
    [DllImport(Consts.DllName, EntryPoint = "MiniDetourUtilsPageRoundUp", CallingConvention = CallingConvention.Cdecl)]
    internal static extern IntPtr PageRoundUp(IntPtr address, UIntPtr pageSize);

    [DllImport(Consts.DllName, EntryPoint = "MiniDetourUtilsPageRound", CallingConvention = CallingConvention.Cdecl)]
    internal static extern IntPtr PageRound(IntPtr address, UIntPtr pageSize);

    [DllImport(Consts.DllName, EntryPoint = "MiniDetourUtilsPageSize", CallingConvention = CallingConvention.Cdecl)]
    internal static extern UIntPtr PageSize();
}