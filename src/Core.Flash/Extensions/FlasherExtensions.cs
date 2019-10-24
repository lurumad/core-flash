namespace Core.Flash
{
    public static class FlasherExtensions
    {
        public static void Primary(this IFlasher flasher, string message, bool dismissable = false)
        {
            flasher.Flash(Types.Primary, message, dismissable);
        }

        public static void Secondary(this IFlasher flasher, string message, bool dismissable = false)
        {
            flasher.Flash(Types.Secondary, message, dismissable);
        }

        public static void Success(this IFlasher flasher, string message, bool dismissable = false)
        {
            flasher.Flash(Types.Success, message, dismissable);
        }

        public static void Danger(this IFlasher flasher, string message, bool dismissable = false)
        {
            flasher.Flash(Types.Danger, message, dismissable);
        }

        public static void Warning(this IFlasher flasher, string message, bool dismissable = false)
        {
            flasher.Flash(Types.Warning, message, dismissable);
        }

        public static void Info(this IFlasher flasher, string message, bool dismissable = false)
        {
            flasher.Flash(Types.Info, message, dismissable);
        }

        public static void Light(this IFlasher flasher, string message, bool dismissable = false)
        {
            flasher.Flash(Types.Light, message, dismissable);
        }

        public static void Dark(this IFlasher flasher, string message, bool dismissable = false)
        {
            flasher.Flash(Types.Dark, message, dismissable);
        }
    }
}
