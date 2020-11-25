//by Ulysses, wdwxy12345@gmail.com
using DE.Robv.Android.Xposed.Callbacks;

namespace DE.Robv.Android.Xposed.Callbacks
{
    public abstract partial class XC_LayoutInflated
    {
        public partial class Unhook
        {
            void IXUnhook.Unhook()
            {
                InvokeUnhook();
            }
        }
    }
}

namespace DE.Robv.Android.Xposed
{
    public abstract partial class XC_MethodHook
    {
        public partial class Unhook
        {
            void IXUnhook.Unhook()
            {
                InvokeUnhook();
            }
        }
    }
}