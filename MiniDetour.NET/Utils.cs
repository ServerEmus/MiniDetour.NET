using System;

namespace MiniDetour.NET;

public static class Utils
{
    /// <summary>
    /// Round the address to the upper value aligned with <paramref name="pageSize"/>.<br/>
    /// If <paramref name="pageSize"/> = 0x1000:<br/>
    ///     <paramref name="address"/> = 0x17ff -> 0x2000
    /// </summary>
    /// <param name="address"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    public static IntPtr PageRoundUp(IntPtr address, UIntPtr pageSize)
        => MiniDetourLoader.Utils_PageRoundUp(address, pageSize);

    /// <summary>
    /// Round the address to the upper value aligned with <paramref name="pageSize"/>.<br/>
    /// If <paramref name="pageSize"/> = 0x1000:<br/>
    ///     <paramref name="address"/> = 0x17ff -> 0x1000
    /// </summary>
    /// <param name="address"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    public static IntPtr PageRound(IntPtr address, UIntPtr pageSize)
        => MiniDetourLoader.Utils_PageRound(address, pageSize);

    /// <summary>
    /// Return the page size of the current system.
    /// </summary>
    /// <returns></returns>
    public static UIntPtr PageSize()
        => MiniDetourLoader.Utils_PageSize();
}