using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float Speed = 30;
    public GameObject BulletPrefab;
    Vector3 MousePos;
    public Transform FirePoint;
    public float offSet = -90;
    float lookAngle;
    bool shot = false;
    GameObject shoot;
    public GameObject bullet1,bullet2,bullet3;
    // Start is called before the first frame update
    void Start()
    
    {
        shoot = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
        lookAngle = Mathf.Atan2(MousePos.y, MousePos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0,lookAngle+offSet);
        if (Input.GetButton("Fire1")&& !shot)
        {
            StartCoroutine(Shoot());

        }

    }


    IEnumerator Shoot()
    {
       

        shot = true;
        PlayerStats.sound("attack");
        if (shoot.GetComponent<Player>().PlayerDamge == 1)
        {
            
            Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
            
        }
        else if (shoot.GetComponent<Player>().PlayerDamge == 2 )
        {
            Instantiate(bullet1, FirePoint.position, FirePoint.rotation);
        }

        else if (shoot.GetComponent<Player>().PlayerDamge == 3 )
        {
            Instantiate(bullet2, FirePoint.position, FirePoint.rotation);
        }

        else if (shoot.GetComponent<Player>().PlayerDamge == 4)
        {
            Instantiate(bullet3, FirePoint.position, FirePoint.rotation);
        }
        yield return new WaitForSeconds(.15f);
        shot = false;
    }


}

