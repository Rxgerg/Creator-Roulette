using System.Windows;
using CreatorRoulette.Models;
using CreatorRoulette.Services;

namespace CreatorRoulette.Views;

public partial class SettingsWindow : Window
{
    private readonly SettingsService _settingsService;
    private AppSettings _settings;

    public SettingsWindow()
    {
        InitializeComponent();

        _settingsService = new SettingsService();
        _settings = _settingsService.Load();

        LoadSettingsIntoForm();
    }

    private void LoadSettingsIntoForm()
    {
        AppTitleTextBox.Text = _settings.AppTitle;
        CommunityNameTextBox.Text = _settings.CommunityName;
        SpinRoleButtonTextBox.Text = _settings.SpinRoleButtonText;
        SpinCharacterButtonTextBox.Text = _settings.SpinCharacterButtonText;
        SpinChallengeButtonTextBox.Text = _settings.SpinChallengeButtonText;
        EnableSoundsCheckBox.IsChecked = _settings.EnableSounds;
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        _settings.AppTitle = AppTitleTextBox.Text;
        _settings.CommunityName = CommunityNameTextBox.Text;
        _settings.SpinRoleButtonText = SpinRoleButtonTextBox.Text;
        _settings.SpinCharacterButtonText = SpinCharacterButtonTextBox.Text;
        _settings.SpinChallengeButtonText = SpinChallengeButtonTextBox.Text;
        _settings.EnableSounds = EnableSoundsCheckBox.IsChecked == true;

        _settingsService.Save(_settings);

        MessageBox.Show("Configuración guardada correctamente.", "Creator Roulette");
        Close();
    }
}