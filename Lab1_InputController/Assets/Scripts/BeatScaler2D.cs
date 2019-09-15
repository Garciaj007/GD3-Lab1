using UnityEngine;

public class BeatScaler2D : MonoBehaviour
{
    [SerializeField] private float scaleAmount = 0.5f;
    [SerializeField] private float duration = 10.0f;
    private bool animating = false;

    public static BeatScaler2D Instance { get; private set; }
    public float Scale { get; private set; } = 1f;

    private void Start()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }

    void Update()
    {
        if (BeatSequencer.Instance.Active && BeatSequencer.Instance.BeatFull)
            animating = true;

        Animate();
    }

    private void Animate()
    {
        if (animating)
        {
            Scale += scaleAmount;
            if (Scale >= 1.3f)
            {
                Scale = 1.3f;
                animating = false;
            }
        }
        else
        {
            Scale -= scaleAmount / duration;
            if (Scale <= 1f)
                Scale = 1f;
        }
    }
}
