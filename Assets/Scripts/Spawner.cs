using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class Spawner : MonoBehaviour
{
	public GameObject catPrefab;
	public float createHeight;
	private MaterialPropertyBlock _props;

	void Start()
	{
    	_props = new MaterialPropertyBlock();
	}

	void CreateCat(Vector3 position)
	{
	    Instantiate(catPrefab, position, Quaternion.identity);
	}

	void Update()
	{
		if (Input.touchCount > 0 )
		{
			var touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began)
			{
				var screenPosition = Camera.main.ScreenToViewportPoint(touch.position);

				ARPoint point = new ARPoint {
					x = screenPosition.x,
					y = screenPosition.y
			    };

				List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface().HitTest (point, 
				ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent);
                
			    if (hitResults.Count > 0)
                {
				    foreach (var hitResult in hitResults)
                    {
				        Vector3 position = UnityARMatrixOps.GetPosition (hitResult.worldTransform);
				        CreateCat (new Vector3 (position.x, position.y + createHeight, position.z));
				        break;
				    }
				}
			}
		}
	}
}