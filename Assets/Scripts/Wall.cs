using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveWall());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MoveWall()
    {
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        //transform.Translate(transform.up * Time.deltaTime * 5f);
        yield return new WaitForSeconds(5f);
        transform.position = new Vector3(transform.position.x, -1.5f, transform.position.z);
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
