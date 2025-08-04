using System;

namespace MiniDetour;

public static class Utils
{
    public static IntPtr PageRoundUp(IntPtr address, UIntPtr pageSize)
        => MiniDetourLoader.Utils_PageRoundUp(address, pageSize);

    public static IntPtr PageRound(IntPtr address, UIntPtr pageSize)
        => MiniDetourLoader.Utils_PageRound(address, pageSize);

    public static UIntPtr PageSize()
        => MiniDetourLoader.Utils_PageSize();
}