using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private GameObject currentSelected = null;

    public static GameManager Instance { get; set; }
    public GameObject CurrentSelected { get => currentSelected; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        Instance = this;
    }

    private void Start() {
        EntityClickController.OnCharacterClick += ChangeCurrentSelected;
    }

    private void ChangeCurrentSelected(GameObject gameObject_) {
        currentSelected = gameObject_;
    }
}
