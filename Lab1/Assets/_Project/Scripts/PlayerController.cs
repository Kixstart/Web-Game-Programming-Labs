using UnityEngine;

namespace platformer397
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputReader input;
    
    private void Start()
        {
            Debug.Log("[Start]");
            input.EnablePlayerActions();
        }
        private void OnEnable()
        {
            input.Move += GetMovement;

        }
        private void OnDisable()
        {
            Debug.Log("[OnDisable]");
        }
       private void GetMovement(Vector2 move)
        {
            Debug.Log("Input Working " + move);    
        }
    }
    }

    
