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

    float shieldTime = 0f, tripleTime = 0f, turboTime = 0f;
    float startTime = 0f;
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
        //ManagePowerUpsUI();
        StartCoroutine(PowerUPTimer());
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

    void ManagePowerUpsUI()
    {

        if (player.shieldActive)
        {
            shieldTime += Time.deltaTime;
            var percent = shieldTime / maxPowerUpTime;
            shieldPU.fillAmount = Mathf.Lerp(1, 0, percent);
        }
        else
        {
            startTime = 0f;
        }
        if (player.turboActive)
        {
            turboTime += Time.deltaTime;
            var percent = turboTime / maxPowerUpTime;
            turboPU.fillAmount = Mathf.Lerp(1, 0, percent);
        }
        else
        {
            startTime = 0f;
        }
        if (player.tripleShootActive)
        {
            tripleTime += Time.deltaTime;
            var percent = tripleTime / maxPowerUpTime;
            tripleShootPU.fillAmount = Mathf.Lerp(1, 0, percent);
        }
        else
        {
            startTime = 0f;
        }
    }

    IEnumerator PowerUPTimer()
    {

        if (player.shieldActive)
        {
            ManagePowerUpsUI();
            yield return new WaitForSeconds(maxPowerUpTime);
            shieldTime = 0;
        }
        if (player.turboActive)
        {
            ManagePowerUpsUI();
            yield return new WaitForSeconds(maxPowerUpTime);
            turboTime = 0;
        }
        if (player.tripleShootActive)
        {
            ManagePowerUpsUI();
            yield return new WaitForSeconds(maxPowerUpTime);
            tripleTime = 0;
        }
    }

}
