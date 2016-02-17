using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public Transform myTransform;

    public float projectileSpeed = 500.0f;

    public float lifeTime = 3.0f;

	// Use this for initialization
	void Start () {

        myTransform = this.transform;

        Destroy(this.gameObject, lifeTime);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
