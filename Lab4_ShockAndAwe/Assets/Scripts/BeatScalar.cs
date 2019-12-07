using UnityEngine;

public class BeatScalar : MonoBehaviour
{
    [SerializeField] private float scaleAmount = 0.5f;
    [SerializeField] private float duration = 10.0f;
    private bool animating = false;

    public static BeatScalar Instance { get; private set; }
    public float Scalar { get; private set; } = 1f;

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
            Scalar += scaleAmount;
            if (Scalar >= 1.3f)
            {
                Scalar = 1.3f;
                animating = false;
            }
        }
        else
        {
            Scalar -= scaleAmount / duration;
            if (Scalar <= 1f)
                Scalar = 1f;
        }
    }
}
