using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] ParticleSystem destructionEffect;
    private void OnTriggerEnter (Collider other) {
        if (other.tag == "CollectibleObject") {
            ParticleSystem explosionEffect = Instantiate(destructionEffect) as ParticleSystem;

            explosionEffect.transform.position = other.transform.position;
            explosionEffect.Play();
            Destroy(explosionEffect, explosionEffect.main.duration);
            Destroy(other.gameObject);
        }
    }
}
