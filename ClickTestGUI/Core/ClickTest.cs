using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ClickTestGUI.Core
{
    public class ClickTest
    {
        public int Score { get; set; }
        public int LastScore { get; set; }
        public double Counts;
        public int chosenTime = 5;
        public bool isTimerRunning;
        public DispatcherTimer timer {get; set;}
       


        public ClickTest()
        {
            timer = new DispatcherTimer(DispatcherPriority.Send);
            Debug.Print("ClickTest object initiated!");
        }

        public void startTimer(object _buttonClicked)
        {
            bool buttonClicked = (bool)_buttonClicked;

            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0,1);

            if (buttonClicked && !isTimerRunning)
            {
                isTimerRunning = true;
                timer.Start();
                Debug.Print("Timer has started!");

            }

        }

        public void Restart()
        {
            isTimerRunning = false;
            Debug.Print("Restarting...");
        }

        public void EndTest()
        {
            timer.Stop();
            Counts = 0;
            LastScore = Score;
            Score = 0;

            Debug.Print("Test ended!");
            //throw new NotImplementedException();
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            Counts ++;
            Debug.Print(chosenTime - Counts + " Seconds");

            if (Counts == chosenTime)
            {
                EndTest();
            }
        }
    }
}
