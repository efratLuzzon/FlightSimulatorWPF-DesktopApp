﻿using flight.Model;
using flight.ViewModel;
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

namespace flight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FlightViewModel flightViewModel;
        
        public MainWindow()
        {
            InitializeComponent();
            flightViewModel = new FlightViewModel(new FlightModel(new TelnetClient()));
            DataContext = flightViewModel;
            ThrottleLabal.Content = Throttle.Name.ToString() + ": 0";
            AileronLabal.Content = Aileron.Name.ToString() + ": 0";
            MyJoystick.setWindow(this);

        }
        public FlightViewModel GetFlightViewModel()
        {
            return flightViewModel;
        }




        private void SliderThrottle_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
            double value = Math.Round(Throttle.Value, 2);
            ThrottleLabal.Content = Throttle.Name.ToString() + ": " + value.ToString();
        }

        private void SliderAileron_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double value = Math.Round(Aileron.Value, 2);
            AileronLabal.Content = Aileron.Name.ToString() + ": " + value.ToString();
        }

        
    }
}