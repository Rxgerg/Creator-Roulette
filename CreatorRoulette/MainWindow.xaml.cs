using System.Windows;
using CreatorRoulette.Application.Services;
using CreatorRoulette.Core.Models;
using CreatorRoulette.Views;

namespace CreatorRoulette;

public partial class MainWindow : Window
{
    private readonly SettingsService _settingsService;
    private AppSettings _settings;

    public MainWindow()
    {
        InitializeComponent();

        _settingsService = new SettingsService();
        _settings = _settingsService.Load();

        ApplySettings();
    }

    private void ApplySettings()
    {
        Title = _settings.AppTitle;
        TitleText.Text = _settings.AppTitle;
        CommunityText.Text = _settings.CommunityName;
    }

    private void SettingsButton_Click(object sender, RoutedEventArgs e)
    {
        SettingsWindow settingsWindow = new()
        {
            Owner = this
        };

        settingsWindow.ShowDialog();

        _settings = _settingsService.Load();
        ApplySettings();
    }
}