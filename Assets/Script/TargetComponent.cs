using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetComponent : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            GameManager.Instance.IncrementScore();
            gameObject.SetActive(false);
            transform.parent.gameObject.GetComponent<Renderer>().material.color = Color.red;
            Invoke("ReActivate", 5);
            
        }
    }

    
    private void ReActivate()
    {
        gameObject.SetActive(true);
        transform.parent.gameObject.GetComponent<Renderer>().material.color = Color.green;
    }
  
}
