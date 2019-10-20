namespace Core.Flash.Abstractions
{
    public interface IFlasher
    {
        void Flash(string type, string message, bool dismissable = false);
        void FlashPrimary(string message, bool dismissable = false);
        void FlashSecondary(string message, bool dismissable = false);
        void FlashSuccess(string message, bool dismissable = false);
        void FlashDanger(string message, bool dismissable = false);
        void FlashWarning(string message, bool dismissable = false);
        void FlashInfo(string message, bool dismissable = false);
        void FlashLight(string message, bool dismissable = false);
        void FlashDark(string message, bool dismissable = false);

        bool Any();
    }
}
