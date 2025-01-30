using UnityEditor.Compilation;
using UnityEngine;
using Unity.Cinemachine;

public class CameraManager : MonoBehaviour
{
    //References to the CinemachineVirtualCamera and the Transform of our player
    [SerializeField] private CinemachineCamera freeLookCam;
    /*[SerializeField]*/ private Transform player;
    //In Awake lock the mouse into the game view in unity and turn the cursor off
    private void Awake()
    {
        //player ??= GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null) { player = GameObject.FindGameObjectWithTag("Player").transform; }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // On enable associate the transform of player into the target of the Cinemachine camera
    private void OnEnable()
    {
        freeLookCam.Target.TrackingTarget = player;
    }


}
