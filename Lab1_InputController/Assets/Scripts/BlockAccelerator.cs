using UnityEngine;
public class BlockAccelerator : MonoBehaviour
{
    [Range(0f, 10f)] 
    [SerializeField] private float acceleration = 1f;
    [SerializeField] private float increment = 0f;

    public float Accelerator
    {
        get
        {
            return increment;
        }
        set
        {
            acceleration = value;
        }
    }

    private void Update()
    {
        increment += Time.deltaTime * acceleration * DifficultyManager.Instance.Difficulty;
    }
}
