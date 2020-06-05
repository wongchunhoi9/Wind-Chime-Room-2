using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindChimePlayB : MonoBehaviour {

	AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    void OnCollisionEnter(Collision collision)
    {
        //foreach (ContactPoint contact in collision.contacts)
        //{
        //    Debug.DrawRay(contact.point, contact.normal, Color.white);
        //}

        if (collision.relativeVelocity.magnitude > 0.1)
        {
            audioSource.volume = collision.relativeVelocity.magnitude / 5;
            audioSource.Play();
        }
                
    }
}
