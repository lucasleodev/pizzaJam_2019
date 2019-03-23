using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogicManager : MonoBehaviour
{
    //public GameObject turbo;
    //public GameObject tripleShot;

    public Text scoreUI;
    public int score;

    public bool isGameOver = false;

    public SpawnManager spawn;

    /*
    public GameObject tripleShoot;
    public GameObject turbo;
    public GameObject shield;
    */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //spawn.StartSpawn(isGameOver);
    }

}
