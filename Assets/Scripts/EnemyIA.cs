using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    public GameObject playerPosition;
    public float enemySpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        transform.LookAt(playerPosition.transform.position);
        transform.position += transform.forward * enemySpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "InvisibleWall")
        {
            Destroy(this.gameObject);
        }
    }
}
