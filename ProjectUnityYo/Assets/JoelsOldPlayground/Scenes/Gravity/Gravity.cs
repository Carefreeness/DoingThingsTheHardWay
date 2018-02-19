using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    public static List<Gravity> gravityComp = new List<Gravity>();
    public static bool useGravity = true; 
    public float mass = 0.001f;
    private const float GConstant = 0.0667408f;

    private float combinedMass;
    private Vector3 force = new Vector3();

	// Use this for initialization
	void Start ()
    {
        gameObject.GetComponent<Rigidbody>().mass = mass;
        gameObject.GetComponent<Rigidbody>().drag = 0;
        gameObject.GetComponent<Rigidbody>().angularDrag = 0;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gravityComp.Add(this);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (useGravity)
        {
            foreach (var item in gravityComp)
            {
                if (item == this || item == null)
                    continue;
                CalculationsBruh(item.mass, item.transform, item);
            }
        }
	}

    private void OnDestroy()
    {
        gravityComp.Remove(this);
    }

    void CalculationsBruh(float otherMass, Transform otherPosition, Gravity gravityCheck)
    {
        if (gravityCheck == null)
            return;
        combinedMass = mass * otherMass;
        if (gravityCheck == null)
            return;
        Vector3 direction = otherPosition.position - transform.position;
        if (gravityCheck == null)
            return;
        float distanceR = Vector3.Distance(otherPosition.position, transform.position);

        float distanceSquared = Mathf.Pow(distanceR, 2);

        float pullingForce;

        pullingForce = GConstant*(combinedMass / distanceSquared);

        force = pullingForce * direction;

        Vector3 force2 = force;

        gameObject.GetComponent<Rigidbody>().AddForce(force2, ForceMode.Force);
    }

}
