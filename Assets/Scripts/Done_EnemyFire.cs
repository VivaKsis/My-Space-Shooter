using UnityEngine;
using System.Collections;

public class Done_EnemyFire : MonoBehaviour
{
	public GameObject shot;
    public GameObject explosion;
    public Transform shotSpawn;
	public float fireRate;
	public float delay;

	public void Fire ()
	{
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		GetComponent<AudioSource>().Play();
	}

	public void DestroyOnExit ()
    {
		Destroy(gameObject);
    }

}
