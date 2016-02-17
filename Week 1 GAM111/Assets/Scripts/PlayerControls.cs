using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    private Transform myTransform;

    private Vector3 playerPosition;

    private float movementSpeed = 100.0f;

    GameManager gameManager;

    //Laser Weapon Variables
    public GameObject laser;
    public GameObject[] muzzles;
    public float laserFireRate = 0.05f;
    private float laserFireTime;


	// Use this for initialization
	void Start () {
        myTransform = this.transform;

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {

        movement();

	    checkBoundary();

        fireLasers();
	}

    private void fireLasers(){

        if(Input.GetMouseButton(0) && Time.time > laserFireTime){

            for(int i = 0; i < muzzles.Length; i++){
                Instantiate(laser, muzzles[i].transform.position, muzzles[i].transform.rotation);
            }

            laserFireTime = Time.time + laserFireRate;

        }
    }

    private void checkBoundary() {

        playerPosition = myTransform.position;

        //Horizontal Boundary check
        if (playerPosition.x <= -gameManager.xBoundary)
        {
            playerPosition.x = -gameManager.xBoundary;
        }
        else if(playerPosition.x >= gameManager.xBoundary)
        {
            playerPosition.x = gameManager.xBoundary;
        }

        //Vertical Boundary check
        if (playerPosition.z <= -gameManager.zBoundary)
        {
            playerPosition.z = -gameManager.zBoundary;
        }
        else if (playerPosition.z >= gameManager.zBoundary)
        {
            playerPosition.z = gameManager.zBoundary;
        }

        myTransform.position = playerPosition;
    }

    private void movement() {
        playerPosition = myTransform.position;

        //Movement Left and right
        if (Input.GetKey("a"))
        {
            playerPosition.x = playerPosition.x - movementSpeed * Time.deltaTime;
        }

        else if (Input.GetKey("d"))
        {
            playerPosition.x = playerPosition.x + movementSpeed * Time.deltaTime;
        }

        //Movement up and down
        if (Input.GetKey("s"))
        {
            playerPosition.z = playerPosition.z - movementSpeed * Time.deltaTime;
        }

        else if (Input.GetKey("w"))
        {
            playerPosition.z = playerPosition.z + movementSpeed * Time.deltaTime;
        }

        myTransform.position = playerPosition;
    }
}
