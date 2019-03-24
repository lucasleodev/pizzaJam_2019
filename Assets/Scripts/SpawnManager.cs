using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject shield, tripleShoot, turbo;
    public GameObject smallWall, mediumWall, largeWall;
    public bool isGameOver = false;
    private int posX, posY;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartSpawn(bool condition)
    {
        StartCoroutine(SpawEnemy(condition));
        StartCoroutine(SpawnPowerUp(condition));
        StartCoroutine(SpawnWalls(condition));
    }

    IEnumerator SpawEnemy(bool isGameOver)
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(Random.Range(3f, 6f));
            posX = Random.Range(-9, 9);
            posY = Random.Range(-9, 9);
            Instantiate(enemy, new Vector3(posX, 3, posY), Quaternion.identity);
        }
    }

    IEnumerator SpawnPowerUp(bool isGameOver)
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(Random.Range(6f, 24f));
            posX = Random.Range(-9, 9);
            posY = Random.Range(-9, 9);
            int option = (int)Random.Range(0f, 2f);
            switch (option)
            {
                case 0:
                    Instantiate(tripleShoot, new Vector3(posX, 3, posY), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(shield, new Vector3(posX, 3, posY), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(turbo, new Vector3(posX, 3, posY), Quaternion.identity);
                    break;
            }
        }
    }

    IEnumerator SpawnWalls(bool isGameOver)
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(Random.Range(5f, 15f));
            posX = Random.Range(-7, 7);
            posY = Random.Range(-7, 7);
            int option = (int)Random.Range(0f, 2f);
            int rotate = Random.Range(0, 1);
            switch (option)
            {
                case 0:
                    if (rotate == 0)
                    {
                        Instantiate(smallWall, new Vector3(posX, -1.5f, posY), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(smallWall, new Vector3(posX, -1.5f, posY), Quaternion.Euler(0f,90f,0f));
                    }
                    break;
                case 1:
                    if (rotate == 0)
                    {
                        Instantiate(mediumWall, new Vector3(posX, -1.5f, posY), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(mediumWall, new Vector3(posX, -1.5f, posY), Quaternion.Euler(0f, 90f, 0f));
                    }
                    break;
                case 2:
                    if (rotate == 0)
                    {
                        Instantiate(largeWall, new Vector3(posX, -1.5f, posY), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(largeWall, new Vector3(posX, -1.5f, posY), Quaternion.Euler(0f, 90f, 0f));
                    }
                    break;
            }
        }
    }

}
