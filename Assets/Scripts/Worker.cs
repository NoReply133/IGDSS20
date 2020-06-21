using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    #region Manager References
    JobManager _jobManager; //Reference to the JobManager
    GameManager _gameManager;//Reference to the GameManager
    #endregion

    public float _age; // The age of this worker
    public float _happiness; // The happiness of this worker
    private float _timerAge;
    private float _timerFish;
    private float _timerClothes;
    private float _timerSchnapps;


    private float _consumesFish = 0.5f ; // period in seconds
    private float _consumesClothes = 5f ; // period in seconds
    private float _consumesSchnapps = 0.5f ; // period in seconds

    // Start is called before the first frame update
    void Start()
    {
        _age=0;
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime;
        _timerAge += delta;
        _timerFish += delta;
        _timerClothes += delta;
        _timerSchnapps += delta;

        if (_timerAge >= 15){
        _timerAge = 0.0f;
        _age+=1f;
        Age();
        };

        if (_timerFish >= _consumesFish){
        _timerFish = 0.0f;
         consum(GameManager.ResourceTypes.Fish);
        };


        if (_timerClothes >= _consumesClothes){
        _timerClothes = 0.0f;
         consum(GameManager.ResourceTypes.Clothes);
        };

        if (_timerSchnapps >= _consumesSchnapps){
        _timerSchnapps = 0.0f;
         consum(GameManager.ResourceTypes.Schnapps);
        };
    }


    private void Age()
    {
        //TODO: Implement a life cycle, where a Worker ages by 1 year every 15 real seconds.
        //When becoming of age, the worker enters the job market, and leaves it when retiring.
        //Eventually, the worker dies and leaves an empty space in his home. His Job occupation is also freed up.

        if (_age > 14)
        {
            BecomeOfAge();
        }

        if (_age > 64)
        {
            Retire();
        }

        if (_age > 100)
        {
            Die();
        }
    }


    public void BecomeOfAge()
    {
        _jobManager.RegisterWorker(this);
    }

    private void Retire()
    {
        _jobManager.RemoveWorker(this);
    }

    private void Die()
    {
        Destroy(this.gameObject, 1);
    }

    private void consum(GameManager.ResourceTypes res)
    {
        if (_gameManager.HasResourceInWarehoues(res)) 
        {
            _gameManager.RemoveResourceFromWarehouse(res, 1);
            happy(true);
        }
        else {
            happy(false);
        };
    }

    private void happy(bool mood)
    {
        if (mood) { _happiness += 1; } else { _happiness -= 1 ;};
        if (_happiness < 0) {_happiness = 0 ;};
        if (_happiness > 100) {_happiness = 100;}; 
    }
}
