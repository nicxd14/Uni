using UnityEngine;
using System.Collections;

public class Laser : Projectile {

	// Update is called once per frame
	void Update () {

        //Movement
        myTransform.position += Time.deltaTime * projectileSpeed * myTransform.forward;
	}

    void OnTriggerEnter (Collider Object){

        if (otherObject.tag == "Enemy")
        {
            Destroy (otherObject.gameObject);
            Destroy (this.gameObject);
        }
    }
}
