using KP_Lab2.ViewModels;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;

namespace KP_Lab2.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var viewModel = new MainViewModel();
            Assert.Equal("Welcome to.NET MAUI", viewModel.Title);
        }
    }
}



