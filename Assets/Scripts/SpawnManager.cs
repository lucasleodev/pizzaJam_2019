using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
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
    }

    IEnumerator SpawEnemy(bool isGameOver)
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(Random.Range(5f,12f));
            posX = Random.Range(-7, 7);
            posY = Random.Range(-7, 7);
            Instantiate(enemy, new Vector3(posX, 1, posY), Quaternion.identity);
        }
    }

    IEnumerator SpawnPowerUp()
    {
        yield return new WaitForSeconds(Random.Range(9, 35) * Time.deltaTime);

    }

    void RandomEnemyPos()
    {
        posX = Random.Range(-7, 7);
        posY = Random.Range(-7, 7);
    }
}
