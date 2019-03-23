using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public bool isGameOver = false;
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
            yield return new WaitForSeconds(5f);
            Instantiate(enemy, new Vector3(7, 1, 7), Quaternion.identity);
        }
    }

    IEnumerator SpawnPowerUp()
    {
        yield return new WaitForSeconds(Random.Range(9, 35) * Time.deltaTime);

    }
}
