using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeSurfer.Character
{
    public class CharacterMovementController : MonoBehaviour
    {
        [SerializeField] private CharacterInputController CharacterInputController;

        [SerializeField] private float forwardMovementSpeed;
        [SerializeField] private float horizontalMovementSpeed;

        [SerializeField] private float horizontalMovementLimit;
        
        [SerializeField] private float newPositionX;

        private void FixedUpdate()
        {
            SetHeroForwardMovement();
            SetHeroHorizontalMovement();
        }

        /// <summary>
        /// Karakterin düz koþmasýný saðlayacak kodu yazdýk.
        /// </summary>
        public void SetHeroForwardMovement()
        {
            transform.Translate(Vector3.down * forwardMovementSpeed * Time.fixedDeltaTime);
        }

        public void SetHeroHorizontalMovement()
        {
            newPositionX = transform.position.x + CharacterInputController.HorizontalValue * horizontalMovementSpeed * Time.fixedDeltaTime;
            newPositionX = Mathf.Clamp(newPositionX, -horizontalMovementLimit, horizontalMovementLimit);
            transform.position = new Vector3(newPositionX,transform.position.y, transform.position.z);
        }


    }
}