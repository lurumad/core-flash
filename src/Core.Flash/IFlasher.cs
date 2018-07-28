using System;

namespace Core.Flash
{
    public interface IFlasher
    {
        void Flash(string type, string message, bool dismissable = false);
    }
}
