using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeSurfer.Character
{

    public class CharacterInputController : MonoBehaviour
    {
        [SerializeField] float horizontalValue;

        public float HorizontalValue
        {
            get { return horizontalValue; }
        }

        void Update()
        {
            CharacterHorizontalInput();
        }

        public void CharacterHorizontalInput()
        {
            if (Input.GetMouseButton(0))
            {
                horizontalValue = Input.GetAxis("Mouse X");
            }
            else
            {
                horizontalValue = 0;
            }
        }


    }

}