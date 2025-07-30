
namespace MiniDetour;

public unsafe partial class Hook
{
    [DllImport("mini_detour", EntryPoint = "MiniDetourHookTAlloc", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr TAlloc();

    [DllImport("mini_detour", EntryPoint = "MiniDetourHookTFree", CallingConvention = CallingConvention.Cdecl)]
    private static extern void TFee(IntPtr ptr);

    [DllImport("mini_detour", EntryPoint = "MiniDetourHookTCanHook", CallingConvention = CallingConvention.Cdecl)]
    private static extern bool TCanHook(IntPtr ptr, IntPtr functionToHook);
}