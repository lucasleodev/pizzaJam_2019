using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip explode;
    public GameObject playerPosition;
    public float enemySpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.Find("Player");
        audio = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        if (playerPosition)
        {
            transform.LookAt(playerPosition.transform.position);
            transform.position += transform.forward * enemySpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "InvisibleWall")
        {
            audio.PlayOneShot(explode, 0.7f);
            Destroy(this.gameObject);
        }
    }
}
