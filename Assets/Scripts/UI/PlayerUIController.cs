using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;

    public void SetUp(float HealthValue)
    {
        _healthSlider.maxValue = HealthValue;
        _healthSlider.value = HealthValue;
    }

    public void ChangeHealtSliderValue(float newValue)
    {
        _healthSlider.value = newValue;
    }
}
