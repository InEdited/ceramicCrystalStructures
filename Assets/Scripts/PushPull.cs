using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPull : MonoBehaviour {
	Animator anim;
	Animator anim1;
	Animator anim2;
	Animator anim3;
	Animator anim4; 
	public GameObject gobj;
	public GameObject gobj1;
	public GameObject gobj2;
	public GameObject gobj3;
	public GameObject gobj4;
	public static int state = 0;
    public Camera cameraTriagonal, cameraTetragonal, cameraOctahedral, cameraCubic;
    public float fieldOfView;
    private bool changeCamera;
    private float changeVelocity;

    private void Update()
    {
        /*if (changeCamera)
        {
            cameraTriagonal.fieldOfView = Mathf.SmoothDamp(60,fieldOfView,ref changeVelocity,1);
            cameraCubic.fieldOfView = Mathf.SmoothDamp(60, fieldOfView, ref changeVelocity, 1);
            cameraOctahedral.fieldOfView = Mathf.SmoothDamp(60, fieldOfView, ref changeVelocity, 1);
            cameraTetragonal.fieldOfView = Mathf.SmoothDamp(60, fieldOfView, ref changeVelocity, 1);
        }
        else
        {
            cameraTriagonal.fieldOfView = Mathf.SmoothDamp(fieldOfView, 60, ref changeVelocity, 1);
            cameraCubic.fieldOfView = Mathf.SmoothDamp(fieldOfView, 60, ref changeVelocity, 1);
            cameraOctahedral.fieldOfView = Mathf.SmoothDamp(fieldOfView, 60, ref changeVelocity, 1);
            cameraTetragonal.fieldOfView = Mathf.SmoothDamp(fieldOfView, 60, ref changeVelocity, 1);
        }*/
    }

    public void changeSpaces()
	{
		anim   = gobj.GetComponent<Animator>();
		anim1 = gobj1.GetComponent<Animator>();
		anim2 = gobj2.GetComponent<Animator>();
		anim3 = gobj3.GetComponent<Animator>();
		anim4 = gobj4.GetComponent<Animator>();
		
		if(state == 0)
		{
			state = 1;
			anim.Play("Push");
			anim1.Play("Push");
			anim2.Play("Push");
			anim3.Play("Push");
			anim4.Play("Push");
            cameraTriagonal.fieldOfView = fieldOfView;
            cameraCubic.fieldOfView = fieldOfView;
            cameraOctahedral.fieldOfView = fieldOfView;
            cameraTetragonal.fieldOfView = fieldOfView;
        }
		else
		{
			state = 0;
			anim.Play("Pull");
			anim1.Play("Pull");
			anim2.Play("Pull");
			anim3.Play("Pull");
			anim4.Play("Pull");

            cameraTriagonal.fieldOfView = 60;
            cameraCubic.fieldOfView = 60;
            cameraOctahedral.fieldOfView = 60;
            cameraTetragonal.fieldOfView = 60;
        }
    }
}
