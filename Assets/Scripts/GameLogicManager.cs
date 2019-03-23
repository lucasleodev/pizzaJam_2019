using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogicManager : MonoBehaviour
{


    public Text scoreUI;
    public int score = 0;

    public Text armorUI;

    public Image armor;

    public bool isGameOver = false;

    public SpawnManager spawn;

    public PlayerMovement player;

    public Image tripleShootPU, turboPU, shieldPU, tripleBG, turboBG, shieldBG;

    public ParticleSystem explosion;

    float shieldTime = 0f, tripleTime = 0f, turboTime = 0f;
    float maxPowerUpTime = 15f;

    // Start is called before the first frame update
    void Start()
    {
        spawn.StartSpawn(isGameOver);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateArmor();
        UpdateScore();
    }

    public void AddScore()
    {
        score += 100;
    }

    void UpdateArmor()
    {
        armor.fillAmount = player.ReturnArmorValue() / 100;
        armorUI.text = player.ReturnArmorValue() + "%";
    }

    void UpdateScore()
    {
        scoreUI.text = score.ToString();
    }

    void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0f;
        }
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.B))
        {
            Time.timeScale = 1f;
        }
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.M))
        {

        }
    }

    public void MakeExplode(Transform pos)
    {
        Instantiate(explosion, pos.position, Quaternion.identity);
        explosion.Play();
    }
}
