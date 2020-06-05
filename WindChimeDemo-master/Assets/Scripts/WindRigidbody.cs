using UnityEngine;

public class WindRigidbody : MonoBehaviour
{
    public float WindStrengthMin = 0;
    public float WindStrengthMax = 5;
    private float windStrength;
    private float radius = 1234567;
    [SerializeField]
    private Transform windPosition;
    [SerializeField]
    private Transform windRotation;

	private void Update()
	{
		if (windPosition != null && windRotation != null)
		{
			windStrength = Random.Range(WindStrengthMin, WindStrengthMax);
			windRotation.rotation = transform.rotation;

			var hitColliders = Physics.OverlapSphere(windPosition.transform.position, radius);
			for (int i = 0; i < hitColliders.Length; i++)
			{
				if (hitColliders[i].GetComponent<Rigidbody>() != null)
				{
					RaycastHit hit;
					var rayDirection = hitColliders[i].GetComponent<Rigidbody>().gameObject.transform.position - windPosition.transform.position;
					if (Physics.Raycast(windPosition.transform.position, rayDirection, out hit)) //there was ',hit, 100' is from an old test.
					{
						if (hit.transform.GetComponent<Rigidbody>())
						{
							//AddExplosionForce(512, transform.position, radius, 3.0); //More garbage from old tests . . . 

							/*
							if (hitColliders[i].GetComponent.<Ball>().inWindZone) {
								hitColliders[i].GetComponent.<Ball>().BlowMe(indTransformPosition.transform.forward * windStrength);
							}
							*/

							hitColliders[i].GetComponent<Rigidbody>().AddForce(windPosition.transform.forward * windStrength, ForceMode.Acceleration);
                            Debug.DrawLine (windPosition.transform.position, hit.point, Color.cyan);

							//there was '32' instead of windStrength / / just a note for myself.
						}
					}
				}
			}
		}
	}
}