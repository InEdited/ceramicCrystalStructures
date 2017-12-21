using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBet: MonoBehaviour
{
	GameObject go;
	LineRenderer lr;
	public GameObject go2;
	void Start () 
	{
		go = new GameObject();
		lr = go.AddComponent<LineRenderer>();
	}
	void Update () 
	{
		lr.widthMultiplier = 0.05f;
		lr.material = new Material(Shader.Find("Sprites/Default"));
		lr.SetColors(Color.black,Color.black);
		lr.SetPosition(0, gameObject.transform.position);
		lr.SetPosition(1, go2.transform.position);
	}
}
