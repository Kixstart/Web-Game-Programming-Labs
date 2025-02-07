using Unity.Cinemachine;
using UnityEngine;

namespace platformer397
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private CinemachineCamera freeLoocCam;
        [SerializeField] private Transform player;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (player == null) { return; }
                player = GameObject.FindGameObjectWithTag("Player").transform;
            
               
        }
        private void OnEnable()
        {
            freeLoocCam.Target.TrackingTarget = player;
        }
    }
    }

