using System.Collections.Generic;
using UnityEngine;

public class HitScanBulletSpawner : AObjectSpawner
{
    private const int MAX_HIT_TARGETS = 8;

    [ColorUsage(false, true)]
    [SerializeField] private Color targetHitColor = Color.white;
    [SerializeField] private float maxRaycastDistance = 200.0f;
    [SerializeField] private List<GameObject> hitTargets = new List<GameObject>();

    private int count = 0;
    private RaycastHit hitInfo;

    private void Update()
    {
        //if (Input.GetMouseButtonUp(1))
        //{
        //    Spawn();
        //    count = 0;
        //    hitTargets.Clear();
        //}
        
        if (BeatSequencer.Instance.BeatFull)
        {
            Spawn();
            count = 0;
            hitTargets.Clear();
        } 

        if(count > MAX_HIT_TARGETS - 1) return;
        if(!Input.GetMouseButton(1)) return;

        if(Physics.Raycast(MouseViewportRotator.Instance.MouseOrientationRay, out hitInfo, maxRaycastDistance))
        {
            if(hitInfo.transform.CompareTag("Target") && !hitTargets.Contains(hitInfo.transform.gameObject))
            {
                var target = hitInfo.transform.gameObject;
                target.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", targetHitColor);
                hitTargets.Add(target);
                count++;
            }
        }
    }

    protected override void Spawn()
    {
        foreach(var target in hitTargets)
        {
            var rand = Random.insideUnitSphere.normalized;
            var pos = new Vector3(rand.x, rand.y, 0.0f);
            var obj = objectPool.SpawnFromPool("HitscanBullet", pos,
                Quaternion.LookRotation(MouseViewportRotator.Instance.MouseOrientationRay.direction, Vector3.up));
            obj.GetComponent<HitscanBulletPooledObjectBehaviour>().Target = target;
        }
    }
}
