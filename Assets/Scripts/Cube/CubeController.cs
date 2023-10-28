using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    Vector3 direction = Vector3.back;  // K�plerden ��kan ray oldu�u i�in geriye do�ru yapt�k.
    RaycastHit hit;
    bool isStack =false;      // Herhangi bir bug olmamas� ve birden fazla eklememesi i�in bu kodu yazd�k.

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

            // Obstacle cubeler i�in yaz�lan ko�ullar
            if (hit.transform.name == "ObstacleCube")
            {
                stackController.DecreaseBlock(gameObject);
            }

        }

    }

    /// <summary>
    /// K�p topland�ktan sonra ���n�n y�n�n� de�i�tirerek �arpma durumunda kullan�labilir hale getirdik.
    /// </summary>
    public void SetDirection()
    {
        direction = Vector3.forward;
    }


}
