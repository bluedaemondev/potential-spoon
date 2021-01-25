using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootOnClick : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform shootOrigin;

    public float bulletCd = 0.8f; // va bajando relativo a la cantidad de balas? podria ser una mecanica a ver

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Shoot()
    {
        var spawned = Instantiate(bulletPrefab, shootOrigin.position, Quaternion.identity);
        //spawned.GetComponent<Bullet>().Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
