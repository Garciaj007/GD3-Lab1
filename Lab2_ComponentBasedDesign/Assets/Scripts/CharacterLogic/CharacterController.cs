using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    private Animator anim = null;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        player.NewPositionClick += HandleNewPositionClick;
    }

    private void OnDestroy()
    {
        player.NewPositionClick -= HandleNewPositionClick;
    }

    void HandleNewPositionClick (Vector3 mousePos)
    {
        if (GameManager.Instance.CurrentSelected == gameObject)
        {
            anim.GetBehaviour<CharacterMoveStateBehaviour>().NewPosition = mousePos;
            anim.SetBool("Moving", true);
        }
    }
}
