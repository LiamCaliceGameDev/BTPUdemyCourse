using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;

    public void TakeDamage (int amount) {
        health -= amount;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
	
}
