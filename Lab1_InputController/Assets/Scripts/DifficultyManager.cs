using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance { get; private set; }

    [Range(0.0005f, 0f)]
    [SerializeField] private float difficultyIncrement = 0.1f;
    [SerializeField] private float difficulty = 0f;
    public float Difficulty { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        Difficulty = 1f;
        GameManager.resetGameDelegate += Reset;
    }

    // Update is called once per frame
    private void Update()
    {
        Difficulty += difficultyIncrement;
        difficulty = Difficulty;
    }

    public void Reset()
    {
        Difficulty = 1f;
    }
}
