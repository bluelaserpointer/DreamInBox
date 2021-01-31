using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float m_Speed = 12f;
    public AudioSource m_MovementAudio;

    private string m_HorizontalMovementAxisName;
    private string m_VerticalMovementAxisName;
    private Rigidbody m_Rigidbody;
    public float m_HorizontalMovementInputValue;
    public float m_VerticalMovementInputValue;
    private Vector3 movementDirection;
    public float m_RaycastRange = 50f;
    public float jumpSpeed = 5f;
    private GameObject lastHitWall;
    public GroundCheck groundCheck;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;
        m_HorizontalMovementInputValue = 0f;
        m_VerticalMovementInputValue = 0f;
    }


    private void OnDisable()
    {
        m_Rigidbody.isKinematic = true;
    }


    private void Start()
    {
        m_HorizontalMovementAxisName = "Vertical";
        m_VerticalMovementAxisName = "Horizontal";
    }

    private void Update()
    {
        // Store the player's input and make sure the audio for the movement is playing.

        m_HorizontalMovementInputValue = Input.GetAxis(m_HorizontalMovementAxisName);
        m_VerticalMovementInputValue = Input.GetAxis(m_VerticalMovementAxisName);

        MovementAudio();

        //transform
        if (Input.GetButton("Transform") && Player.transforms.Count > 1)
        {
            Player.NextTransform();
            //TODO: SE
        }
        Jump();


    }


    private void MovementAudio()
    {
        // Play the correct audio clip based on whether or not the player is moving and what audio is currently playing.

        // Checks if the player is moving
        if (!CheckMovement() || MainRooms.IsRotating())
        {
            m_MovementAudio.Stop();
        }
        else
        {
            if (!m_MovementAudio.isPlaying)
            {
                m_MovementAudio.Play();
            }

        }
    }


    private void FixedUpdate()
    {
        // Move and turn the player.

        Move();
        Turn();
        Raycast();

        // CheckInteraction();

    }


    private void Move()
    {
        // Adjust the position of the player based on the player's input.
        if (CheckMovement() && !MainRooms.IsRotating())
        {
            movementDirection = m_Rigidbody.position + (Vector3.forward * m_HorizontalMovementInputValue + Vector3.right * m_VerticalMovementInputValue) * m_Speed * Time.deltaTime;

            m_Rigidbody.MovePosition(movementDirection);
        }



    }


    private void Turn()
    {
        if (CheckMovement() && !MainRooms.IsRotating())
        {
            transform.LookAt(movementDirection);
        }
    }

    private void Raycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, m_RaycastRange))
        {
            GameObject hitObject = hit.transform.gameObject;
            MainRoomsWall mainRoomsWall = hitObject.GetComponent<MainRoomsWall>();
            if (mainRoomsWall != null)
            {
                if (lastHitWall == null)
                {
                    lastHitWall = hit.transform.gameObject;
                    lastHitWall.GetComponent<MainRoomsWall>().hit = true;
                }

                if (hit.transform.gameObject != lastHitWall)
                {
                    lastHitWall.GetComponent<MainRoomsWall>().hit = false;
                    lastHitWall = hit.transform.gameObject;
                    lastHitWall.GetComponent<MainRoomsWall>().hit = true;
                }
            }

        }
    }



    private bool CheckMovement()
    {
        if (Mathf.Abs(m_HorizontalMovementInputValue) > 0.0f || Mathf.Abs(m_VerticalMovementInputValue) > 0.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckInteraction()
    {
        return Input.GetButton("Interaction");
    }
    public void Transport(TransportSpot transportSpot)
    {
        Debug.Log("Transporting to scene " + transportSpot.gotoScene);
        Player.lastScene = SceneManager.GetActiveScene().name;
        transportSpot.Transport();
    }
    public void OnCollisionStay(Collision collision)
    {
        OnTriggerStay(collision.collider);
    }

    public void OnTriggerStay(Collider collider)
    {
        Debug.Log(collider.gameObject.name);
        VolumeModification(collider);

        //transport
        TransportSpot transportSpot = collider.GetComponent<TransportSpot>();
        if (transportSpot != null && transportSpot.gotoScene != null && transportSpot.gotoScene.Length > 0)
        {
            // lastCollider = collision.collider;
            // Debug.Log("Colliding with TransportHole");
            if (!transportSpot.needInteraction || CheckInteraction())
            {
                Transport(transportSpot);
            }
        }
        //transformItem
        TransformItem item = collider.GetComponent<TransformItem>();
        if (item != null)
        {
            Player.transforms.Add(item.type);
            item.gameObject.SetActive(false);
            //TODO: item get notify(UI & SE)
        }






    }

    private void Jump()
    {
        //jump TODO: prevent flying
        Debug.Log(groundCheck.isGrounded);
        if (Input.GetButton("Jump") && groundCheck.isGrounded)
        {
            m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x, 0);//施加y方向速度，x方向维持原速
            // m_Rigidbody.AddForce(new Vector2(m_Rigidbody.velocity.x, 30f));
            m_Rigidbody.velocity = m_Rigidbody.velocity + new Vector3(0f, jumpSpeed);
        }
    }

    private void VolumeModification(Collider collider)
    {
        if (CheckInteraction())
        {
            if (collider.tag == "VolumeUp")
            {
                Debug.Log("Increased Volume");
                GameSettings.IncreaseVolume();
            }
            if (collider.tag == "VolumeUp")
            {
                Debug.Log("Decreased Volume");
                GameSettings.DecreaseVolume();
            }
        }
    }
}
