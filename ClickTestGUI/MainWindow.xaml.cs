
using ClickTestGUI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClickTestGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClickTest clickTest = new ClickTest();
        bool buttonClicked = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clickTest.Score++;
            buttonClicked = true;

            if (clickTest.Score == 1)
            {
                clickTest.startTimer(buttonClicked);
            }

            clickTest.timer.Tick += Timer_Tick;
            TestButton.Content = "Clicks: " + clickTest.Score;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeLable.Content = "Time left: " + (clickTest.chosenTime - clickTest.Counts) + " Seconds";

            if (clickTest.Counts + clickTest.chosenTime == clickTest.chosenTime)
            {
                TimeLable.Content = "Test ended!";
                TestButton.IsEnabled = false;
            }
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (!clickTest.timer.IsEnabled)
            {
                clickTest.Restart();
                TestButton.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Cannot restart while running!");
            }
            
        }
    }
}
