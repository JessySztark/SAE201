﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Gestion_Medicament
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void lancementApplication(object sender, StartupEventArgs args)
        {
            ApplicationData.loadApplicationData();
        }
    }
}
