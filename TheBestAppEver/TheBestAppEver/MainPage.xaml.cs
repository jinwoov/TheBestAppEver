using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TheBestAppEver
{
    //[DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TheBestAppEver.txt");
        public MainPage()
        {
            InitializeComponent();
            if (File.Exists(_fileName))
            {
                editor.Text = File.ReadAllText(_fileName);
            }
        }
        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            File.WriteAllText(_fileName, editor.Text);
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
            editor.Text = String.Empty;
        }

        int count = 0;
        public void Button_Clicked(object sender, System.EventArgs e, Command<string> url)
        {
            count++;
            ((Button)sender).Text = $"You clicked {count} times.";
            Launcher.OpenAsync(url.ToString());
        }
        int counter = 0;
        public void clicky(object sender, EventArgs e)
        {
            counter++;

            if (counter % 2 == 0)
            {
                ((Button)sender).BackgroundColor = Color.Red;
            }
            else
            {
                ((Button)sender).BackgroundColor = Color.Green;
            }
        }
    }
}
