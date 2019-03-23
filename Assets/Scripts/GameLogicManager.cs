using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogicManager : MonoBehaviour
{


    public Text scoreUI;
    public int score;

    public bool isGameOver = false;

    public SpawnManager spawn;

    // Start is called before the first frame update
    void Start()
    {
        spawn.StartSpawn(isGameOver);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
