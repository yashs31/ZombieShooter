using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [Header("CONFIG")]
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _sliderText;
    [SerializeField] private Image _fillImage;
    [SerializeField] private float _timeToLerp = 2;

    //local vars
    private bool lerpingHealth = false;
    private float timeScale = 0;
    private string PREFIX = "";
    private void Start()
    {
        _slider.interactable = false;
    }

    /// <summary>
    /// configure the slider for max and min values
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="wholeNumbers"></param>
    /// <param name="sliderPrefix"></param>
    public void ConfigureSlider(float min, float max, bool wholeNumbers, string sliderPrefix = "")
    {
        _slider.minValue = min;
        _slider.maxValue = max;
        _slider.wholeNumbers = wholeNumbers;
        _sliderText.text = sliderPrefix + " " + _slider.value;
        PREFIX = sliderPrefix;

    }

    /// <summary>
    /// set the initial slider value
    /// </summary>
    /// <param name="progress"></param>
    /// <param name="sliderText"></param>
    public void SetInitialSliderValue(float progress, string sliderText = "")
    {
        _slider.value = progress;
        _sliderText.text = sliderText;
    }

    /// <summary>
    /// lerp the slider value to new value
    /// </summary>
    /// <param name="progress"></param>
    /// <param name="instant"></param>
    /// <param name="setText"></param>
    public void ChangeUIValue(float progress)
    {
        if (progress == float.NaN)
            progress = 0;
        timeScale = 0;
        try
        {
            if (!lerpingHealth)
                StartCoroutine(LerpProgress(progress));
        }
        catch
        {
            Debug.LogError("Slider elrp failed");
            _slider.value = progress;
        }
    }

    /// <summary>
    /// slider lerp coroutine
    /// </summary>
    /// <param name="progress"></param>
    /// <returns></returns>
    private IEnumerator LerpProgress(float progress)
    {
        float currentProgress = _slider.value;
        lerpingHealth = true;

        while (timeScale < _timeToLerp)
        {
            timeScale += Time.unscaledDeltaTime;
            _slider.value = Mathf.Lerp(currentProgress, progress, timeScale / _timeToLerp);
            yield return null;
        }
        lerpingHealth = false;
        _sliderText.text = PREFIX + ((progress * 100) / _slider.maxValue).ToString("F0") + "%";
    }
}
