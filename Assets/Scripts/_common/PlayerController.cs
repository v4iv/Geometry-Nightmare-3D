using UnityEngine;
using System.Collections;
[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour 
{
	public float speed;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float tilt;
	private float nextFire;

	void Update()
	{
		//if (Input.GetButton ("Fire1") && Time.time > nextFire) 
		//{
		//	nextFire = Time.time + fireRate;
		//	Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		//}
		for (int i = 0; i < Input.touchCount; ++i) 
		{
			if (Input.GetTouch (i).phase == TouchPhase.Began && Time.time > nextFire) 
			{
				nextFire = Time.time + fireRate;
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			}
		}
	}
	void FixedUpdate()
	{
		//float moveHorizontal = Input.GetAxis ("Horizontal");
		//float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (Input.acceleration.x, 0.0f, 0.0f);
		transform.Translate(movement);
		//rigidbody.velocity = movement * speed;

		GetComponent<Rigidbody>().position = new Vector3 
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
				0.0f,
				Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
			);
		//rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x*-tilt);
	}
}
