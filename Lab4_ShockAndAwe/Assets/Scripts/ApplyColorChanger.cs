using UnityEngine;
using UnityEngine.UI;

public class ApplyColorChanger : MonoBehaviour
{
    public enum ColorType { Dark, Light, Accent }
    public enum ObjectType { Sprite, Text, Camera, Image }

    [SerializeField] private ColorType colorType = ColorType.Dark;
    [SerializeField] private ObjectType objectType = ObjectType.Sprite;

    private SpriteRenderer sp = null;
    private Text text = null;
    private Camera cam = null;
    private Image image = null;

    private void Start()
    {
        switch (objectType)
        {
            case ObjectType.Sprite: sp = GetComponent<SpriteRenderer>();
                break;
            case ObjectType.Text: text = GetComponent<Text>();
                break;
            case ObjectType.Image: image = GetComponent<Image>();
                break;
            case ObjectType.Camera: cam = Camera.main;
                break;
            default: sp = GetComponent<SpriteRenderer>();
                break;
        }
    }

    private void Update()
    {
        if (sp != null) sp.color = GetColor();
        else if (text != null) text.color = GetColor();
        else if (image != null) image.color = GetColor();
        else if (cam != null) cam.backgroundColor = GetColor();
    }

    private Color GetColor()
    {
        switch (colorType)
        {
            case ColorType.Dark:
                return ColorChanger.Instance.DarkColor;
            case ColorType.Light:
                return ColorChanger.Instance.LightColor;
            case ColorType.Accent:
                return ColorChanger.Instance.Accent;
            default:
                return ColorChanger.Instance.LightColor;
        }
    }
}
