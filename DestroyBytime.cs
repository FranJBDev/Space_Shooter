using UnityEngine;
using System.Collections;

public class DestroyBytime : MonoBehaviour {
	public float lifeTime;
	void Start(){
		Destroy (gameObject,lifeTime);
	}
}
