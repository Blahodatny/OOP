using lab2.Enumerations;

namespace lab2.Interfaces
{
    public interface ISwimmerActions
    {
        void OnActionPerformed(int seconds, EAction action);
        void OnActionCompleted();
        void DoAction(int seconds, EAction action);
        void CheckWorking(object sender, ActionPerformedEventArgs e);
    }
}