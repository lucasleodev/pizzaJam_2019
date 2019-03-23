using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //THE DOOM - Domination OffTerrain OnTheGo Maquinary, AKA Heavy Dog

    public float _normalSpeed = 3f;
    public new AudioSource audio;
    public AudioClip shootSound, explodeSound;
    public GameObject bullet;
    public GameObject singleShot,leftTriple,centerTriple,rigthTriple;
    public GameObject shieldField;
    public float playerArmor = 100;
    public bool shieldActive = false;
    public bool turboActive = false;
    public bool tripleShootActive = false;
    bool canShoot = true;


    GameLogicManager manager;

    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.FindGameObjectWithTag("Manager").GetComponent<AudioSource>();
        shieldField.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TankMovement();
        Shoot();
        DestroyTank();
    }

    void GetPowerUps(string name)
    {
        switch (name)
        {
            case "Shield(Clone)":
                if (!shieldActive)
                {
                    StartCoroutine(TurnOnShield());
                }
                break;
            case "Turbo(Clone)":
                if (!turboActive)
                {
                    StartCoroutine(TurnOnTurbo());
                }
                break;
            case "TripleShoot(Clone)":
                if (!tripleShootActive)
                {
                    StartCoroutine(TurnOnTripleShoot());
                }
                break;
        }
    }

    void TankMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //move the tank
        if (Input.GetKey(KeyCode.RightControl))
        {
            transform.Translate(transform.right * horizontal * Time.deltaTime * _normalSpeed);
            transform.Translate(transform.forward * vertical * Time.deltaTime * _normalSpeed);
        }

        Vector3 newPos = new Vector3(horizontal, 0.0f, vertical);
        transform.LookAt(newPos + transform.position);
        transform.Translate(newPos * _normalSpeed * Time.deltaTime, Space.World);
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(canShoot)
            {
                StartCoroutine(ShootCooldown());
            }
        }
    }

    public float ReturnArmorValue()
    {
        return playerArmor;
    }

    public void DestroyTank()
    {
        if (playerArmor == 0)
        {
            audio.PlayOneShot(explodeSound);
            Destroy(this.gameObject);
        }
    }

    IEnumerator ShootCooldown()
    {
        while (canShoot)
        {
            audio.PlayOneShot(shootSound, 0.45f);
            if (!tripleShootActive)
            {
                Instantiate(bullet, singleShot.transform.position, singleShot.transform.rotation);
            }
            else
            {
                Instantiate(bullet, leftTriple.transform.position, leftTriple.transform.rotation);
                Instantiate(bullet, centerTriple.transform.position, centerTriple.transform.rotation);
                Instantiate(bullet, rigthTriple.transform.position, rigthTriple.transform.rotation);
            }
            canShoot = false;
            yield return new WaitForSeconds(2f);
            canShoot = true;
        }
    }

    IEnumerator TurnOnTripleShoot()
    {
        tripleShootActive = true;
        while (tripleShootActive)
        {
            yield return new WaitForSeconds(15f);
            tripleShootActive = false;
        }
    }

    IEnumerator TurnOnTurbo()
    {
        turboActive = true;
        while (turboActive)
        {
            _normalSpeed *= 2f;
            yield return new WaitForSeconds(15f);
            _normalSpeed = 3f;
            turboActive = false;
        }
    }

    IEnumerator TurnOnShield()
    {
        shieldActive = true;
        while (shieldActive)
        {
            shieldField.SetActive(true);
            yield return new WaitForSeconds(15f);
            shieldField.SetActive(false);
            shieldActive = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            if (!shieldActive)
            {
                playerArmor -= 10;
                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }

        if (collision.transform.tag == "Powerup")
        {
            Debug.Log(collision.transform.name);
            GetPowerUps(collision.transform.name);
            Destroy(collision.gameObject);
        }
    }

}
