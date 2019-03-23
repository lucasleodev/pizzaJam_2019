using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogicManager : MonoBehaviour
{


    public Text scoreUI;
    public int score;

    public Image armor;

    public bool isGameOver = false;

    public SpawnManager spawn;

    public PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        spawn.StartSpawn(isGameOver);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore()
    {
        score += 100;
    }

    void UpdateArmor()
    {
        armor.fillAmount = player.ReturnArmorValue()/100;
    }

}
