public class LocalizationService
{
    public string CurrentLanguage { get; set; } = "en-US";

    public event Action OnLanguageChanged = default!;

    public void SetLanguage(string language)
    {
        CurrentLanguage = language;
        OnLanguageChanged?.Invoke();
    }
}