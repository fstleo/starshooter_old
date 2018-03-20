using UnityEngine;
using UnityEngine.UI;
using Menu;

public class OptionsStateView : MenuStateView
{
    [SerializeField]
    Slider musicSlider;

    [SerializeField]
    Slider soundSlider;

    public override void Show()
    {
        base.Show();
        musicSlider.value = UserSettings.MusicVolume;
        soundSlider.value = UserSettings.SoundsVolume;
    }

    public void _MusicSliderChange(float value)
    {
        UserSettings.MusicVolume = value;
    }

    public void _SoundSliderChange(float value)
    {
        UserSettings.SoundsVolume = value;
    }

    public void _BackButtonClick()
    {
        ReturnToPrevious();
    }
}
