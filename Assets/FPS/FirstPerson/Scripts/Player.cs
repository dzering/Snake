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
        RotationToMousePosiniton();

        if (Input.anyKey)
        {
            directionZ = Input.GetAxis("Vertical");
            directionX = Input.GetAxis("Horizontal");
            Move(directionZ, directionX);

        }

    }

    private void RotationToMousePosiniton()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - objectPos.x;
        mousePos.z = mousePos.z - objectPos.z;

        float angle = Mathf.Atan2(mousePos.x, mousePos.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(angle, 0, 0));



    }
}
