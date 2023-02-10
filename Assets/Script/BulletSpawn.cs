using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject bullet;
    [SerializeField] BulletComponent b;
    private float maxPower = 700f;
    private float minPower = 2f;
    public float maxChargeDur = 5f;
    public float currentChargeDur = 0f;
    public bool isCharging = false;
    public bool isRelease = true;
   
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && isRelease)
        {
            currentChargeDur = 0f;
            isCharging = true;
            isRelease = false;
        }
        else if(isCharging && Input.GetButtonUp("Fire1") || currentChargeDur >= maxChargeDur) 
        {
            float power = Mathf.Lerp(minPower, maxPower, currentChargeDur / maxChargeDur);
            fireInTheHole(power);
            Reset();
        }
        
        if (isCharging)
        {
            currentChargeDur += Time.deltaTime;
            
        }

        if (!isRelease)
        {
            isRelease = Input.GetButtonUp("Fire1");
        }

      

    }
    
    private void fireInTheHole(float power)
    {
        b.force = power;
        Instantiate(bullet, transform.position, transform.rotation);

        //ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f, 0, power));
        //bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * power, ForceMode.Impulse);

    }

    private void Reset()
    {
        currentChargeDur = 0f;
        isCharging = false;
    }
}
