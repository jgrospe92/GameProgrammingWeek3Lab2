using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{

    public float force = 2f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
    }

    private void Update()
    {
        DestroyBullet();
    }

    void DestroyBullet()
    {
        Destroy(gameObject, 5);
    }


}
