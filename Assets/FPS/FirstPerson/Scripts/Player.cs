using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speedZ;
    [SerializeField] private float speedX;

    private float directionZ;
    private float directionX;

    public void Move(float directionZ, float directionX)
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speedZ * directionZ);
        transform.Translate(Vector3.right * Time.deltaTime * speedX * directionX);
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            directionZ = Input.GetAxis("Vertical");
            directionX = Input.GetAxis("Horizontal");
            Move(directionZ, directionX);
        }
        
    }

}
