using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetColorFromColorChanger : MonoBehaviour
{
    public enum ColorType { Dark, Light, Accent }

    [SerializeField] private ColorType colorType = ColorType.Dark;

    private SpriteRenderer sp;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    private void OnWillRenderObject()
    {
        switch (colorType)
        {
            case ColorType.Dark: sp.color = ColorChanger.Instance.DarkColor;
                break;
            case ColorType.Light: sp.color = ColorChanger.Instance.LightColor;
                break;
            case ColorType.Accent: sp.color = ColorChanger.Instance.Accent;
                break;
            default: sp.color = ColorChanger.Instance.LightColor;
                break;
        }
    }
}
