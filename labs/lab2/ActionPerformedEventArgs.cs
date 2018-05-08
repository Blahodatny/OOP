using System;
using lab2.Enumerations;

namespace lab2
{
    public class ActionPerformedEventArgs : EventArgs
    {
        public ActionPerformedEventArgs(int seconds, EAction action)
        {
            Seconds = seconds;
            Action = action;
        }

        public int Seconds { get; }

        public EAction Action { get; }
    }
}