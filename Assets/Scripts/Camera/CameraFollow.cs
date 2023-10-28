using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform character;
        [SerializeField] private Vector3 newPosition;

        [SerializeField] private Vector3 offset;
        [SerializeField] private float lerpValue;


        void Start()
        {
            offset = transform.position - character.position;  // Karakter ve camera arasýndaki mesafe
        }

        private void LateUpdate()
        {
            SetCameraFollow();
        }

        private void SetCameraFollow()
        {
            newPosition = Vector3.Lerp(transform.position, new Vector3(0f, character.position.y, character.position.z) + offset , lerpValue * Time.deltaTime);
            transform.position = newPosition;
        }

    }

