using Platformer397;
using UnityEngine;

namespace Platformer397
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        

        [SerializeField] private InputReader input;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Vector3 movement;

        [SerializeField] private float moveSpeed = 200f;
        [SerializeField] private float rotationSpeed = 200f;

        [SerializeField] private Transform mainCam;

        private void Start()
        {
            Debug.Log("[Start]");
            input.EnablePlayerActions();
        }

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;
            mainCam = Camera.main.transform;
        }

        private void OnEnable()
        {
            Debug.Log("[OnEnable]");
            input.Move += GetMovement;
        }

        private void OnDisable()
        {
            Debug.Log("[OnDisable]");
            input.Move -= GetMovement;
        }

        private void OnDestroy()
        {
            Debug.Log("[OnDestroy]");
        }

        private void FixedUpdate()
        {
            UpdateMovement();
        }

        private void HandleMovement(Vector3 adjustedMovement){ 
            var velocity = adjustedMovement * moveSpeed * Time.fixedDeltaTime;
            rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
        }

        private void HandleRotation(Vector3 adjustedMovement)
        { 
            var targetRotation = Quaternion.LookRotation(adjustedMovement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        }

        private void UpdateMovement(){
            var adjustedDirection = Quaternion.AngleAxis(mainCam.eulerAngles.y, Vector3.up) * movement;
            if (adjustedDirection.magnitude > 0){
                //handle rotation and movement
                HandleRotation(adjustedDirection);
                HandleMovement(adjustedDirection);
            }
            else {
                //do not change rotation or movement but apply rigidbody y movement for gravity
                rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
            }
        }

        private void GetMovement(Vector2 move)
        {
            movement.x = move.x;
            movement.z = move.y;
            
        }
    }
}
