using System;
using System.Threading;
using lab1.Kind_of_activity;
using lab2.Enumerations;
using lab2.Interfaces;

namespace lab2.Persons
{
    public sealed class Swimmer : Sportsman, ISportsmanProperties, ISwimmerActions, ISwimmerEvents
    {
        private int _swimmingSpeed;
        private static int _overcomeDistance;
        private const int MaximalDistanceCanBeSwumAtOnce = 1000;

        public Swimmer(int stamina, string kindOfSport, int swimmingSpeed) : base(stamina, kindOfSport)
        {
            SwimmingSpeed = swimmingSpeed;
        }

        // Property implementation
        public int OvercomeDistance => _overcomeDistance;

        public int SwimmingSpeed
        {
            get
            {
                Console.WriteLine("Getting swimming speed of the swimmer...");
                return _swimmingSpeed;
            }
            set
            {
                if (value >= 0 && value < 100)
                {
                    Console.WriteLine("Setting swimming speed to the swimmer...");
                    _swimmingSpeed = value;
                }

                else
                {
                    throw new InvalidSwimSpeedExc("The value should be >= 0! && < 100");
                }
            }
        }

        public string KindOfSport
        {
            get
            {
                Console.WriteLine("Getting kind of sport of the swimmer...");
                return base.KindOfSport;
            }
            set
            {
                Console.WriteLine("Setting kind of sport to the swimmer...");
                base.KindOfSport = value;
            }
        }

        public event ActionPerformedHandler ActionPerformed;
        public event EventHandler ActionCompleted;

        public void OnActionPerformed(int seconds, EAction action)
        {
            ActionPerformed?.Invoke(this, new ActionPerformedEventArgs(seconds, action));
        }

        public void OnActionCompleted()
        {
            ActionCompleted?.Invoke(this, EventArgs.Empty);
        }

        public void DoAction(int seconds, EAction action)
        {
            if (_overcomeDistance < MaximalDistanceCanBeSwumAtOnce)
            {
                if (action != EAction.StayAfloat)
                {
                    _overcomeDistance = _overcomeDistance + _swimmingSpeed * seconds;
                }

                Console.WriteLine("Performing action: " + action + "...");
                Thread.Sleep(seconds * 1000);
                Console.WriteLine("Done: overcome distance at the moment equals: " + _overcomeDistance);
                OnActionPerformed(seconds, action);
            }

            else
            {
                Console.WriteLine("Nothing can be performed. The swimmer is over.");
                OnActionCompleted();
            }
        }

        public void CheckWorking(object sender, ActionPerformedEventArgs e)
        {
            Console.WriteLine("Someone do action {0} during {1} seconds! NOW ", e.Action, e.Seconds);
        }
    }
}

// focus solely on - фокусуватись виключно на
// digestible - той, який можна легко засвоїти
// inference - висновок
// tin - банка (e.g. з-під кока-коли)
// there is got to be some glue though - має бути якийсь зв'язок
// amplify - посилювати
// trigger - викликати
// bullhorn - рупор
// enhance - посилювати
// in essence - по суті
// delegate - доручати
// arrow - стріла
// reminder - нагадування
// instantiate - ілюструвати прикладами; підтверджувати
// hook up - змонтувати