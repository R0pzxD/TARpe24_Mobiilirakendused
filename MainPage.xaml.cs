namespace TARpe24_Mobiilirakendused
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;
            BotImage.Scale += 0.1;
            BotImage.Opacity -= 1;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
           

            else if(count == 10)
            {
                BotImage.IsVisible = false;
                CounterBtn.Text = "Pilt kadus ära";
            }
            else if(count >= 5)
            {
                CounterBtn.Text = $"Clicked {count} times";
                BotImage.Rotation += 100;
                CounterBtn.BackgroundColor = Colors.Red;
                CounterBtn.TextColor = Colors.White;
            }
            else
                CounterBtn.Text = $"Clicked {count} times";
            BotImage.Rotation += 20;

            var rnd = new Random();
            var rndColor = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            BackgroundColor = rndColor;
            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void ResetBtn_Clicked(object sender, EventArgs e)
        {
            BotImage.Scale = 1;
            BotImage.Opacity = 1;
            if (count >= 10)
            {
                BotImage.IsVisible = true;
                CounterBtn.Text = "Pilt on tagasi?!";
            }
            count = 0;
            CounterBtn.Text = "Alustame uuesti!";
            BotImage.Rotation = 0;
            BackgroundColor = Colors.White;
            ResetBtn.ClearValue(BackgroundColorProperty);
            if(BotImage.HorizontalOptions == LayoutOptions.Start)
            {
                BotImage.HorizontalOptions = LayoutOptions.End;
            }
            else
            {
                BotImage.HorizontalOptions = LayoutOptions.Start;
            }
            
        }
    }
}
