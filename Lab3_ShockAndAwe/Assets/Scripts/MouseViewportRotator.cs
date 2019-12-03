using System.Collections.Generic;
using UnityEngine;

public class MouseViewportRotator : MonoBehaviour
{
    private const int MAX_HIT_TARGETS = 8;

    public static MouseViewportRotator Instance { get; private set; }

    [ColorUsage(false, true)][SerializeField] private Color targetHitColor = Color.white;

    private Vector3 leftTopCorner = Vector3.zero;
    private Vector3 rightTopCorner = Vector3.zero;
    private Vector3 leftBottomCorner = Vector3.zero;
    private Vector3 rightBottomCorner = Vector3.zero;

    [SerializeField] private List<GameObject> hitTargets = new List<GameObject>();
    private int count = 0;
    private RaycastHit hitInfo;

    public Vector3 MouseOrientation { get; private set; } = Vector3.zero;

    private void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(gameObject);
        Instance = this;
    }

    private void Start()
    {
        Camera cam = Camera.main;
        Vector3[] frustumCorners = new Vector3[4];
        Camera.main.CalculateFrustumCorners(new Rect(0, 0, 1, 1), cam.farClipPlane, Camera.MonoOrStereoscopicEye.Mono, frustumCorners);
        leftBottomCorner = frustumCorners[0];
        leftTopCorner = frustumCorners[1];
        rightTopCorner = frustumCorners[2];
        rightBottomCorner = frustumCorners[3];
    }

    void Update()
    {
        var x = Utils.Mathf.Map(Input.mousePosition.x, 0, Screen.width, 0, 1);
        var y = Utils.Mathf.Map(Input.mousePosition.y, 0, Screen.height, 0, 1);

        var lerpTop = Vector3.Lerp(leftTopCorner, rightTopCorner, x);
        var lerpBottom = Vector3.Lerp(leftBottomCorner, rightBottomCorner, x);
        var lerpLeft = Vector3.Lerp(leftBottomCorner, leftTopCorner, y);
        var lerpRight = Vector3.Lerp(rightBottomCorner, rightTopCorner, y);
        MouseOrientation = lerpTop + lerpBottom + lerpLeft + lerpRight;
        Debug.DrawRay(transform.position, MouseOrientation);

        if (Input.GetMouseButtonUp(1))
        {
            foreach(var target in hitTargets)
            {
                target?.GetComponent<IPooledObject>()?.OnObjectHide();
            }
            count = 0;
            hitTargets.Clear();
        } 

        if(count > MAX_HIT_TARGETS - 1) return;
        if(!Input.GetMouseButton(1)) return;

        if(Physics.Raycast(new Ray(transform.position, MouseOrientation), out hitInfo, 200.0f))
        {
            if(hitInfo.transform.tag == "Target")
            {
                var target = hitInfo.transform.gameObject;
                target.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", targetHitColor);
                hitTargets.Add(target);
                count++;
            }
        }
    }
}
