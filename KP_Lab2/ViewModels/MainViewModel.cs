using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;
using System.Net.Http;
using System.Text.Json;


namespace KP_Lab2.ViewModels
{

    public class MainViewModel : INotifyPropertyChanged
    {
        private string currentDateTime;
        private Color backgroundColor;
        private Random random;

        public Color BackgroundColor
        {
            get => backgroundColor;
            set
            {
                backgroundColor = value;
                OnPropertyChanged();
            }
        }

        public string CurrentDateTime
        {
            get => currentDateTime;
            set
            {
                currentDateTime = value;
                OnPropertyChanged();
            }
        }


        public string Title => "Welcome to.NET MAUI";

        public TodoItem Info { get; set; }
        
        public string DeviceInfo
        {
            get
            {
                var deviceInfo = new StringBuilder()
                    .AppendLine($"Model: {Microsoft.Maui.Devices.DeviceInfo.Model}")
                    .AppendLine($"Manufacturer: {Microsoft.Maui.Devices.DeviceInfo.Manufacturer}")
                    .AppendLine($"Platform: {Microsoft.Maui.Devices.DeviceInfo.Platform}")
                    .AppendLine($"OS Version: {Microsoft.Maui.Devices.DeviceInfo.VersionString}");

                return deviceInfo.ToString();
            }
        }

        public ICommand UpdateTimeCommand { get; }
        public ICommand UpdateColorCommand { get; }

        public MainViewModel()
        {
            random = new Random();
            BackgroundColor = new Color(255, 255, 255);
            UpdateTimeCommand = new Command(UpdateTime);
            UpdateColorCommand = new Command(ChangeBGColor);
            CurrentDateTime = DateTime.Now.ToString("F");
        }

        private void UpdateTime()
        {
            CurrentDateTime = DateTime.Now.ToString("F");
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ChangeBGColor()
        {
            BackgroundColor = new Color(random.Next(256), random.Next(256), random.Next(256));

        }

        private async Task FetchDataFromApiAsync()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos/1");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                Info = JsonSerializer.Deserialize<TodoItem>(json);
            }
        }

    }

    public class TodoItem
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }

}


