using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    Vector3 direction = Vector3.back;  // Küplerden çýkan ray olduðu için geriye doðru yaptýk.
    RaycastHit hit;
    bool isStack =false;      // Herhangi bir bug olmamasý ve birden fazla eklememesi için bu kodu yazdýk.

    [SerializeField] private CharacterStackController stackController;

    void Start()
    {
        stackController = GameObject.FindAnyObjectByType<CharacterStackController>();
    }


    void FixedUpdate()
    {
        SetCubeRaycast();
    }

    public void SetCubeRaycast() 
    {
        if (Physics.Raycast(transform.position, direction,out hit, 1.0f))
        {
            if(!isStack)
            {
                isStack = true;
                stackController.LastAddedCubes(gameObject);
                SetDirection();
            }

            // Obstacle cubeler için yazýlan koþullar
            if (hit.transform.name == "ObstacleCube")
            {
                stackController.DecreaseBlock(gameObject);
            }

        }

    }

    /// <summary>
    /// Küp toplandýktan sonra ýþýnýn yönünü deðiþtirerek çarpma durumunda kullanýlabilir hale getirdik.
    /// </summary>
    public void SetDirection()
    {
        direction = Vector3.forward;
    }


}
