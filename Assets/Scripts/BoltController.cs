using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltController : MonoBehaviour
{
    public int damage;

    public bool destructable;

    public AudioSource fireSound;

    private void Start()
    {
        if (fireSound != null)
        {
            fireSound.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        TakeDamage d = other.GetComponent<TakeDamage>();
        if (d != null)
        {
            d.Damage(damage);
            if (destructable)
            {
                Destroy(gameObject);
            }
        }
    }
}
