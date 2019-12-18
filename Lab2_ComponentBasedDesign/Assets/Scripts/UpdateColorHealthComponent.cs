using UnityEngine;

public class UpdateColorHealthComponent : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr = null;
    [SerializeField] private Color colorA = Color.white;
    [SerializeField] private Color colorB = Color.white;

    private void Start() => UpdateColorOverLife();
    private void Update() => UpdateColorOverLife();
    public void UpdateColorOverLife()
    {
        if(sr == null) return;
        sr.color = Color.Lerp(colorA, colorB, GetComponent<HealthComponent>().GetHealthPercent());
    }
}
