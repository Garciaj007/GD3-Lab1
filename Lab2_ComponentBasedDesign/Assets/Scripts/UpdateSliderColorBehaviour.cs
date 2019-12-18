using UnityEngine;
using UnityEngine.UI;

public class UpdateSliderColorBehaviour : MonoBehaviour
{
    [SerializeField] private Image image = null;
    [SerializeField] private Slider slider = null;
    [SerializeField] private Color colorA = Color.white;
    [SerializeField] private Color colorB = Color.white;

    private void Start() => UpdateSliderColor();

    public void UpdateSliderColor()
    {
        if(image != null)
            image.color = Color.Lerp(colorA, colorB, slider.value);
    }
}
