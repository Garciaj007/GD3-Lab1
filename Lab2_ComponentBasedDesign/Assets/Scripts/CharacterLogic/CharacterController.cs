using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public static float ClickMinRadius = 2.0f;

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
        if (GameManager.Instance.CurrentSelected != gameObject) return;
        if ((mousePos.XY() - gameObject.transform.position.XY()).magnitude < ClickMinRadius) return;
        anim.GetBehaviour<CharacterMoveStateBehaviour>().NewPosition = mousePos;
        anim.SetBool("Moving", true);
    }
}
