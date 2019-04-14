using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Processes mouse button inputs
/// </summary>
public class MouseButtonProcessor : MonoBehaviour
{
    [SerializeField]
    GameObject prefabExplosion;
    [SerializeField]
    GameObject prefabTeddyBear;

    // first frame input support
    bool spawnInputOnPreviousFrame = false;
	bool explodeInputOnPreviousFrame = false;

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
        // spawn teddy bear as appropriate
        if (Input.GetAxis("SpawnTeddyBear") > 0)
        {
            if(!spawnInputOnPreviousFrame)
            {
                // spawn teddy bear
                Instantiate(prefabTeddyBear, DetermineWorldPosition(), Quaternion.identity);
                spawnInputOnPreviousFrame = true;
            }
        }
        else
        {
            spawnInputOnPreviousFrame = false;
        }

        // explode teddy bear as appropriate
		
	}

    Vector3 DetermineWorldPosition()
    {
        //Get Mouse Position
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;

        //Convert Mouse Position to desired character position
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //Return new position
        return newPosition;
    }
}
