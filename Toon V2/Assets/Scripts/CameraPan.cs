using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class CameraPan : MonoBehaviour
{
    [Header("Button attributes")]
    [SerializeField] private SpriteState _state;
    [SerializeField] private Button button;
    [SerializeField] private Sprite[] buttonSprites;
    [SerializeField] private Image targetButton;
    public bool start = true;
    public bool startRotate = false;
    [Header("Camera components")]
    public Camera cam;
    Vector3 direction = new Vector3(1, 0, 0);
    Vector3 right = new Vector3(0, 1, 0);
    public float rGoal = 0f;
    public float rotationGoal = 80f;
    public int fovGoal = 80;
    public float angle = 10f;
    
    

    private float currentXRotation;
    private float currentZRotation;
    private Vector3 currentRotation;
    
    
    
    private void Start()
    {
        currentXRotation = cam.transform.localEulerAngles.x;
        currentZRotation = cam.transform.localEulerAngles.z;

    }
    // Update is called once per frame
    void Update()
    {
        
        
        //RotateCam();


        // Pans the camera down to cooking view
       if (start == false && cam.transform.localEulerAngles.x <= rotationGoal)
        {
            cam.transform.position += new Vector3(0, 0.5f * (Time.deltaTime * 1.5f), 0);
            cam.transform.Rotate(direction, angle * (Time.deltaTime * 1.5f));
            targetButton.sprite = buttonSprites[1];
        }

        // Pans the camera up to customer view
        if (start == true && cam.transform.localEulerAngles.x > rGoal)
        {
            cam.transform.position -= new Vector3(0, 0.5f * (Time.deltaTime * 1.5f), 0);
            cam.transform.Rotate((direction * -1), angle * (Time.deltaTime * 1.5f));
            targetButton.sprite = buttonSprites[0];
        }
        
        
    }
    //Method utilised by button to start the pan
    public void StartPan()
    {
        if (start == true)
        { 
            start = false;
            //Change button sprite on click
            targetButton.sprite = buttonSprites[1];
        }
        else
        {
            start = true;
            //Change button sprite on click
            targetButton.sprite = buttonSprites[0];
            
        }
    }
    public void RotateCam()
    {
        
       
        if (cam.transform.localRotation.eulerAngles.y >= 270f)
        {
            startRotate = false;
            return;
        }
        if(startRotate == true)
        {

            cam.transform.Rotate(right, angle * (Time.deltaTime) * 2f);
            cam.transform.rotation = Quaternion.Euler(currentXRotation, cam.transform.rotation.eulerAngles.y, currentZRotation);

        }
        
    }
    public void StartRotate()
    {
        Debug.Log("ss");
        startRotate = true;
    }
    
    
}
