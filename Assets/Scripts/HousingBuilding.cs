using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousingBuilding : Building
{
    public float _avHappiness; // The average happiness of workers
    public int _amountOfWorkers = 0;
    public float _i;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        addWorker(15);
        addWorker(15);
       //New instructions can be called after the base's.
       _i = Time.time+calcSpawnTime();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
       //New instructions can be called after the base's.
        if (Time.time > _i)
        {
            _i += calcSpawnTime();
            addWorker(0);
        }
    }

    private float calcHapiness() { // val between 0 and 1
        float happySum = 0;
        foreach (Worker worker in _workers)
        {
            happySum += worker._happiness;
        }
        return happySum / _workers.Count;
    }

    private void addWorker(int age)
    {
        if (_amountOfWorkers <= 10)
        {
            Worker worker = new Worker();
            worker._age = age;
            WorkerAssignedToBuilding(worker);
            _amountOfWorkers += 1;
        }
    }

    private float calcSpawnTime()
    {
        return ((2-calcHapiness())*30);
    }

}
