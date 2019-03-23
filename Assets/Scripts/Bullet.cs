using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShootBullet();
    }

    public void ShootBullet()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed, Space.Self);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Destroyed by: " + collision.transform.tag);
        Destroy(this.gameObject);
    }
}
