using UnityEngine;
using System.Collections;
using TMPro;

public class RearWheelDrive : MonoBehaviour {

	private WheelCollider[] wheels;

	public float maxAngle = 30;
	public float maxTorque = 300;
	public float maxVel = 200;
	public GameObject wheelShape;
    [SerializeField]
    private TextMeshProUGUI[] rpm;
    [SerializeField]
    private TextMeshProUGUI[] torques;



    public float velocidad;
	// here we find all the WheelColliders down in the hierarchy
	public void Start()
	{
       
        velocidad = 0;
		wheels = GetComponentsInChildren<WheelCollider>();

		for (int i = 0; i < wheels.Length; ++i) 
		{
			var wheel = wheels [i];

			// create wheel shapes only when needed
			if (wheelShape != null)
			{
				var ws = GameObject.Instantiate (wheelShape);
				ws.transform.parent = wheel.transform;
			}
		}
       
    }


    // this is a really simple approach to updating wheels
    // here we simulate a rear wheel drive car and assume that the car is perfectly symmetric at local zero
    // this helps us to figure our which wheels are front ones and which are rear
    public void FixedUpdate()
	{
		float angle = maxAngle * Input.GetAxis("Horizontal");
		float torque = maxTorque * Input.GetAxis("Vertical");
        // 


        int i = 0;

        foreach (WheelCollider wheel in wheels)
		{


            velocidad = ((( Mathf.PI * (wheel.radius * 2)) * wheel.rpm * 60 )/ 1000/3);

            rpm[i].SetText(Mathf.Round(wheel.rpm).ToString());
            torques[i].SetText(Mathf.Round(velocidad).ToString());

            WheelFrictionCurve sf = wheel.sidewaysFriction;
            WheelFrictionCurve ff = wheel.forwardFriction;


			if (Input.GetKey(KeyCode.X))
			{
				maxAngle = 45;
			}else{
				maxAngle = 30;
			}
			
			// a simple car where front wheels steer while rear ones drive
			if (wheel.transform.localPosition.z > 0)
				wheel.steerAngle = angle;

			

			if(Input.GetKey(KeyCode.C) || Input.GetAxis("Vertical") == 0 )
			{
			
					wheel.motorTorque = 0;
					wheel.brakeTorque = 16000;

                ff.stiffness = 4f;
                sf.stiffness = 4f;
                wheel.forwardFriction = ff;
                wheel.sidewaysFriction = sf;

                
            }else{
                ff.stiffness = 1.5f;
                sf.stiffness = 2.8f;
                wheel.forwardFriction = ff;
                wheel.sidewaysFriction = sf;
                //print("acelerando");
                wheel.brakeTorque = 0;

                if (wheel.motorTorque > maxTorque)
                {
                    wheel.motorTorque = maxTorque;
                }
                else
                {
                    wheel.motorTorque = torque;
                }


            }

            i++;
			// update visual wheels if any
			if (wheelShape) 
			{
				Quaternion q;
				Vector3 p;
				wheel.GetWorldPose (out p, out q);

				// assume that the only child of the wheelcollider is the wheel shape
				Transform shapeTransform = wheel.transform.GetChild (0);
				shapeTransform.position = p;
				shapeTransform.rotation = q;
			}

		}
	}
}
