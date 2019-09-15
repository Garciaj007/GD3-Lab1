using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public static ColorChanger Instance { get; private set; }
    public Color DarkColor { get; private set; } 
    public Color LightColor { get; private set; }
    public Color Accent { get; private set; }

    [Range(1000f, 50f)]
    [SerializeField] private float slope = 100f;

    private float mainHue = 0f;
    private float accentHue = 0.4f;

    private void Awake()
    {
        if (Instance != null & Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        mainHue += BeatScaler2D.Instance.Scale / slope;
        accentHue += BeatScaler2D.Instance.Scale / slope;
        mainHue %= 1f;
        accentHue %= 1f;

        DarkColor = Color.HSVToRGB(mainHue, 0.8f, 0.2f);
        LightColor = Color.HSVToRGB(mainHue, 0.8f, 0.8f);
        Accent = Color.HSVToRGB(accentHue, 1f, 0.8f);
    }
}
