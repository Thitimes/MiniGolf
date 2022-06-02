using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BallController : MonoBehaviour
{
    public float maxPower;
    public float changeAngleSpeed;
    public float lineLength;
    public Slider powerSlider;
    public TextMeshProUGUI puttsCount;
    public float minHoleTime;
    public Transform startPos;

    private int putts;
    private Rigidbody ball;
    private LineRenderer line;
    private float angle;
    private float powerUpTime;
    private float power;
    private float holeTime;
    private Vector3 lastPosition;
    private void Awake()
    {
        ball = GetComponent<Rigidbody>();
        ball.maxAngularVelocity = 1000;
        line = GetComponent<LineRenderer>();
        putts = 0;
        holeTime = 0;
    }
    private void Update()
    {
        
        if(ball.velocity.magnitude < 0.01f)
        {
            getInput();
        }
        else
        {
            line.enabled = false;
        }
        
    }

    private void getInput()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            changeAngle(-1);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            changeAngle(1);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            PowerUp();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            putt();

        }

        updateLineRenderer();
    }
    private void changeAngle(int direction)
    {
        angle += changeAngleSpeed * Time.deltaTime * direction;
    }
    private void updateLineRenderer()
    {
        if (holeTime == 0)
        {
            line.enabled = true;
        }
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position + Quaternion.Euler(0, angle, 0) * Vector3.forward * lineLength);
    }
    private void putt()
    {
        lastPosition = transform.position;
        ball.AddForce(Quaternion.Euler(0, angle, 0) * Vector3.forward * maxPower * power , ForceMode.Impulse);
        power = 0;
        powerSlider.value = 0;
        powerUpTime = 0;
        updatePuttsCount();
    }
    private void PowerUp()
    {
        powerUpTime += Time.deltaTime;
        power = Mathf.PingPong(powerUpTime, 1);
        powerSlider.value = power;
    }
    private void updatePuttsCount()
    {
        putts++;
        puttsCount.text = putts.ToString();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "hole")
        {
            CountHoleTime();
        }
    }

    private void CountHoleTime()
    {
        holeTime += minHoleTime;
        if(holeTime >= minHoleTime)
        {
            Debug.Log("In the Hole It Only took me " + putts + "putts to get it in");
            //player has finish, move on to the next player
            holeTime = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "hole")
        {
            LeftHole();
        }
    }

    private void LeftHole()
    {
        holeTime = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "ground")
        {
            transform.position = lastPosition;
            ball.velocity = Vector3.zero;
            ball.angularVelocity = Vector3.zero;
        }
    }
    public void SetUpBall(Color color)
    {
        transform.position = startPos.position;
        angle = startPos.rotation.eulerAngles.y;
        ball.velocity = Vector3.zero;
        ball.angularVelocity = Vector3.zero;

        GetComponent<MeshRenderer>().material.SetColor("_Color", color);
        line.material.SetColor("_Color", color);
        line.enabled = true;
        putts = 0;
        puttsCount.text = "0";
    }
}
