using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    //IN CLASS CCNY MW SPRING 2024
    //GLOBAL VARIABLES
    private bool isDragging = false;
    private Vector3 offset;






    // Start is called before the first frame updatE
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    //DRAG
    private void OnMouseDown()
    {
        //Debug.Log("mouse down");
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
        //Debug.Log("isDragging =" + isDragging);
        
    }

    private void OnMouseUp()
    {
        //Debug.Log("mouse up");
        isDragging = false;
        //Debug.Log("isDragging =" + isDragging);

    }


}
