
namespace MiniDetour;

public static class Utils
{
    public static IntPtr PageRoundUp(IntPtr address, UIntPtr pageSize)
        => UtilsNative.PageRoundUp(address, pageSize);

    public static IntPtr PageRound(IntPtr address, UIntPtr pageSize)
        => UtilsNative.PageRound(address, pageSize);

    public static UIntPtr PageSize()
        => UtilsNative.PageSize();
}