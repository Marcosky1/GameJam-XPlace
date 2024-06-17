using System.Collections.Generic;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerController : MonoBehaviour
{
    //MOVEMENT
    [SerializeField] private float Speed;
    private Vector3 MovementDirection;
    private Rigidbody rigidBody;

    //CARRY  MECHANIC
    [SerializeField] private Transform TakerAxis;
    [SerializeField] private Transform Taker;
    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;


    [SerializeField] private int LuggageCapacity;
    [SerializeField] private Transform[] Luggage;
    private bool IsCarriyng;
    [SerializeField] private float RemoveImpulse;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        Luggage = new Transform[LuggageCapacity];
        IsCarriyng = false;
    }
    void FixedUpdate()
    {
        rigidBody.velocity = new Vector3((MovementDirection.normalized * Speed).x, rigidBody.velocity.y, (MovementDirection.normalized * Speed).z);

        if (IsCarriyng)
        {
            SetLuggageBehaviour();
        }
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        MovementDirection = context.ReadValue<Vector3>();
        if (MovementDirection != Vector3.zero)
        {
            TakerAxis.rotation = Quaternion.LookRotation(transform.TransformDirection(-MovementDirection));
        }
    }
    public void OnDecarry(InputAction.CallbackContext context)
    {
        RemoveLuggage();
    }
    public void OnCarry(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (Physics.Raycast(transform.position - new Vector3(0f, 1f, 0f), transform.TransformDirection(MovementDirection.normalized), out hit, 1.65f, layerMask))
            {
                Debug.DrawRay(transform.position - new Vector3(0f, 1f, 0f), transform.TransformDirection(MovementDirection.normalized) * hit.distance, Color.yellow);
                if(hit.transform.tag == "Luggage")
                {
                    AddBaggage(hit.transform);
                }
            }
            else
            {
                Debug.DrawRay(transform.position - new Vector3(0f, 1f, 0f), transform.TransformDirection(MovementDirection.normalized) * 1.65f, Color.white);
            }
        }
    }
    public void ModifyCapacity(int newCapacity)
    {
        Transform[] tmp = Luggage;
        Luggage = new Transform[newCapacity];
        for (int i = 0; i < Luggage.Length; i++)
        {
            try
            {
                Luggage[i] = tmp[i];
            }
            catch (System.IndexOutOfRangeException)
            {

            }
        }
    }
    public void AddBaggage(Transform victim)
    {
        IsCarriyng = true;
        int Iter = 0;
        for(int i = 0; i < Luggage.Length; i++)
        {
            if (Luggage[i] == null)
            {
                Iter++;
            }
            if(Iter == 1)
            {
                Luggage[i] = victim;
                victim.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                victim.rotation = Quaternion.identity;
            }
        }
    }
    public void SetLuggageBehaviour()
    {
        for (int i = 0; i < Luggage.Length; i++)
        {
            if(Luggage[i] != null)
            {
                Luggage[i].position = new Vector3(Taker.position.x, Taker.position.y + (i * 1.5f), Taker.position.z);
                if(MovementDirection != Vector3.zero)
                {
                    Luggage[i].rotation = Quaternion.LookRotation(MovementDirection);
                }
            }
        }
    }
    public void RemoveLuggage()
    {
        IsCarriyng = false;
        for(int i = 0; i < Luggage.Length; i++)
        {
            if(Luggage[i] != null)
            {
                Luggage[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                Luggage[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                Luggage[i].GetComponent<Rigidbody>().AddForce(((Taker.position - transform.position) + new Vector3(0, 1.75f, 0)).normalized * RemoveImpulse, ForceMode.Impulse);
                Luggage[i] = null;
            }
        }
    }
}