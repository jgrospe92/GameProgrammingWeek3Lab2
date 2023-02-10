using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Rigidbody m_rigidBody;
    public GameObject respawnPoint;
    public float m_velocity = 10f;
    public float m_mouseSensitivy = 2f;
    public float m_jumpVelocity = 10f;
    private Vector2 turn;
    // Start is called before the first frame update
    void Start()
    {
        
        m_rigidBody = GetComponent<Rigidbody>();
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        turn.x = Input.GetAxis("Mouse X");
        turn.y = Input.GetAxis("Mouse Y");
        Vector3 movement = ((v *transform.forward *m_velocity + h * transform.right * m_velocity)); 
        m_rigidBody.velocity = new Vector3(movement.x, m_rigidBody.velocity.y, movement.z);
        transform.Rotate(0, turn.x* m_mouseSensitivy, 0, Space.Self);

        if (Input.GetKeyDown(KeyCode.R))
        {
            RespawnPlayer();
        }

    }

    public void RespawnPlayer()
    {
        transform.position = respawnPoint.transform.position;
    }
}
