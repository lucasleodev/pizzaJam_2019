using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }


}
