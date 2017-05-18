using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public LayerMask wallLayer;
    public GameObject spawnPoint;
    public AudioClip boost;

    private float moveSpeed;
    private bool speedBoost = false;
    private Vector3 move;
    private RaycastHit hit;

    // Use this for initialization
    void Start () {
        moveSpeed = 4f;
        transform.position = spawnPoint.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        MovementInput();
        Movability();
        WrapAround();
	}

    void MovementInput()
    {
        //movement vectors
         if (Input.GetKey(KeyCode.W))
         {
            move =  new Vector3(0, 0, 1);
         }
         else if (Input.GetKey(KeyCode.A))
         {
             move = new Vector3(-1, 0, 0);
         }
         else if (Input.GetKey(KeyCode.S))
         {
             move = new Vector3(0, 0, -1);
         }  
         else if (Input.GetKey(KeyCode.D))
         {
             move = new Vector3(1, 0, 0);
         }

        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.LookRotation(move.normalized); //face direction moving in
    }

    void Movability()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, 1f, wallLayer)) //stop moving when hitting a wall
            moveSpeed = 0; 
        else
        {
            if (speedBoost == true) //if speed boost aquired
                moveSpeed = 8f;
            else                   //if no speed boost and not hitting a wall move at normal speed
                moveSpeed = 4f;
        }    
    }

    void WrapAround()
    {
        if(transform.position.x < -49.5f)
        {
            transform.position = new Vector3(-22, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > -22f)
        {
            transform.position = new Vector3(-49, transform.position.y, transform.position.z);
        }
    }

    IEnumerator BoostSpeed()
    {
        yield return new WaitForSeconds(2.5f);
        speedBoost = false;
    }

   /* public PathfindingNode GetCurrenTile()
    {
        RaycastHit hit = new RaycastHit();
        bool check = Physics.Raycast(transform.position, -Vector3.up, out hit);
        Debug.Log(check);
        if(check)
        {
            return hit.transform.GetComponent<PathfindingNode>();
        }
        return null;
    }*/

    void OnCollisionEnter(Collision collider)
    {
        GameObject obj = collider.gameObject;
        if(obj.tag == "SpeedBoost")
        {
            speedBoost = true;
            StartCoroutine(BoostSpeed());
            AudioSource.PlayClipAtPoint(boost, transform.position);
            Destroy(obj);
        }
    }
}
