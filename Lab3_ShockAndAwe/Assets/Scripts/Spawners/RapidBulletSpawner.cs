using UnityEngine;

public class RapidBulletSpawner : AObjectSpawner
{
    public float rateOfFire;
    private Utils.Timer bulletTimer;

    private void Start()
    {
        bulletTimer = new Utils.Timer(rateOfFire);
        bulletTimer.TimerFinished += Spawn;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
            bulletTimer.Start();

        if(Input.GetMouseButtonUp(0))
            bulletTimer.Stop();
        
        if(Input.GetMouseButton(0))
            bulletTimer.Update();
    }

    protected override void Spawn()
    {
        var pos = Input.mousePosition;
        pos.z = 1;
        pos = Camera.main.ScreenToWorldPoint(pos);
        //var rand = Random.insideUnitCircle;
        //var pos = new Vector3(rand.x, rand.y, 0.0f);
        objectPool.SpawnFromPool("RapidBullet", pos, Quaternion.identity);
    }
}
