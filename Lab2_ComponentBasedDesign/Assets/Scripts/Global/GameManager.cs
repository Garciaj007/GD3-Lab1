using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    public delegate void OnCharacterClickDelegate(GameObject gameObject_);
    public static event OnCharacterClickDelegate OnCharacterClick;

    [SerializeField] private GameObject currentSelected = null;

    public static GameManager Instance { get; set; }
    public List<PlayerController> Players { get; set; } = new List<PlayerController>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        Instance = this;
    }

    private void Start()
    {
        OnCharacterClick += ChangeCurrentSelected;
    }

    public GameObject CurrentSelected => currentSelected;
    public void DispatchEntity(GameObject entity) => OnCharacterClick?.Invoke(entity);
    public void Move() => currentSelected?.GetComponent<EntityComponent>().Move();

    public void Defend()
    {
        currentSelected?.GetComponent<EntityComponent>().Defend();
        currentSelected?.GetComponent<Animator>().SetBool("Moving", false);
        currentSelected = null;
    }
    private void ChangeCurrentSelected(GameObject gameObject_)
    {
        currentSelected = gameObject_;

        UIManager.Instance.DisableButtons();
        if (!currentSelected.GetComponent<EntityComponent>().IsLocked)
            UIManager.Instance.EnableButtons();
    }
}
