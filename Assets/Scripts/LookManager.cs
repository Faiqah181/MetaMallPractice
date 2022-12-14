using UnityEngine;

public class LookManager : MonoBehaviour {

	public GameObject ViewPoint;
	public float distance = 0.1f;
	public GameObject lastLooked;

	void Update() {
		if (lastLooked) {
			lastLooked.SendMessage("NotLookingAt", SendMessageOptions.DontRequireReceiver);
			lastLooked = null;
		}

		GameObject closest = null;
		float closestDistance = Mathf.Infinity;
		
		Collider[] colliders = Physics.OverlapSphere(ViewPoint.transform.position, distance);
		foreach (Collider collider in colliders) {
			float distance = Vector3.Distance(ViewPoint.transform.position, collider.gameObject.transform.position);
			if (distance < closestDistance) {
				closestDistance = distance;
				closest = collider.gameObject;
			}
		}

		if (!closest.CompareTag("Player")) {
			closest.SendMessage("LookingAt", SendMessageOptions.DontRequireReceiver);
			lastLooked = closest;
		}

		//Ray gazeRay = new(ViewPoint.transform.position, ViewPoint.transform.rotation * Vector3.forward);
		//if (Physics.Raycast(gazeRay, out RaycastHit hit, Mathf.Infinity)) {
		//	hit.transform.SendMessage("GazingUpon", SendMessageOptions.DontRequireReceiver);
		//	lastGazed = hit.transform.gameObject;
		//}

		//if (Vector3.Dot(transform.forward, ))
	}
}
