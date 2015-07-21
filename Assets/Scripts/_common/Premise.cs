using UnityEngine;
using System.Collections;

public class Premise : MonoBehaviour
{
	void OnTriggerExit(Collider other)
	{
		Destroy (other.gameObject);
	}
}
