using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiming : MonoBehaviour
{
    Vector2 mousePos;
    float RfireRate =0;
    [SerializeField] float fireRate,range;
    [SerializeField] LayerMask enemyLayer;

    void aim()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Vector2.SignedAngle(Vector2.right, mousePos - new Vector2(transform.position.x, transform.position.y));
        if (angle > -140f && angle < -90f)
            angle = -140f;
        else if (angle > -90f && angle < -35f)
            angle = -35f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    // the shooting with raycast
    void shoot()
    {
        RfireRate = fireRate;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePos - new Vector2(transform.position.x, transform.position.y), range,enemyLayer);
        if (hit.collider != null)
        {
            Debug.Log("you hit enemy");
        }
        else
            Debug.Log("you hit nothing");
    }

    void Update()
    {
        aim();
        if (Input.GetMouseButtonDown(0) && RfireRate <= 0)
            shoot();
        else
            RfireRate -= Time.deltaTime;
    }
}
