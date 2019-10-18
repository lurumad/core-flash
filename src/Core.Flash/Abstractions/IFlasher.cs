namespace Core.Flash.Abstractions
{
    public interface IFlasher
    {
        void Flash(string type, string message, bool dismissable = false);

        bool Any();
    }
}
