using Platformer397;
using UnityEngine;

namespace Platformer397
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

        private void GetMovement(Vector2 move)
        {
            Debug.Log("[Input working]" + move);
        }
    }
}
