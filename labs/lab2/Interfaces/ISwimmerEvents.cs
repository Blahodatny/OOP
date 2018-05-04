using System;
using lab2.Persons;

namespace lab2.Interfaces
{
    public interface ISwimmerEvents
    {
        event ActionPerformedHandler ActionPerformed;
        event EventHandler ActionCompleted;
    }
}