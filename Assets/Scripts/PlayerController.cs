using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float tSpeed;
    private Rigidbody playerRB;
    private GameObject focalPoint;
    private Color[] colors = {Color.red, Color.blue, Color.cyan, Color.grey, Color.magenta};
    private MeshRenderer pMRenderer;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = this.GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        pMRenderer = this.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * tSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * forwardInput * tSpeed * Time.deltaTime);
        //playerRB.AddForce(Vector3.right * horizontalInput * speed);
        //playerRB.AddForce(Vector3.forward * forwardInput * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with Enemy" + otherObject.name);
            
            if (otherObject.transform.position.z < -11 || otherObject.transform.position.z > 11
                || otherObject.transform.position.x < -9
                || otherObject.transform.position.x > 9)
            {
                otherObject.GetComponent<NavMeshAgent>().enabled = false;
                GameManager.kills++;
                GameManager.gameManager.UpdateKills();

                pMRenderer.material.SetColor("_Color", colors[Random.Range(0, colors.Length)]);
                this.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            }

            float speed = 20.0f;
            Rigidbody enemyRB = otherObject.GetComponent<Rigidbody>();
            enemyRB.AddForce(Vector3.forward * speed);
        }
    }
}
