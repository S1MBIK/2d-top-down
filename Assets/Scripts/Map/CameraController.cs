    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Cinemachine;

    public class CameraController : Singleton<CameraController>
    {
        private CinemachineVirtualCamera cinemachineVirtualCamera;

        private new void Awake()
        {
            base.Awake();
            cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        }

        private void Start()
        {
            SetPlayerCameraFollow();
        }

        public void SetPlayerCameraFollow()
        {
            if (cinemachineVirtualCamera == null)
            {
                cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
            }

            if (cinemachineVirtualCamera != null && PlayerController.Instance != null)
            {
                cinemachineVirtualCamera.Follow = PlayerController.Instance.transform;
            }
        }

        private void OnEnable()
        {
            SetPlayerCameraFollow();
        }
    }
