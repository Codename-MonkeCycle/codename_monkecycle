using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    [SerializeField] private Vector2 originalLocalPointerPosition;
    [SerializeField] private Vector3 originalPanelLocalPosition;
     private Vector3 originalScale;
    private int currentState = 0;
    [SerializeField] private Quaternion originalRotation;
    [SerializeField] private Vector3 originalPosition;
    [SerializeField] private float selectScale = 1.1f;
    [SerializeField] private Vector2 cardPlay;
    [SerializeField] private Vector3 playPosition = new Vector3(0,160,0);   
    [SerializeField] private GameObject glowEffect;
    [SerializeField] private GameObject playArrow;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        originalScale = rectTransform.localScale;
        originalPosition = rectTransform.localPosition;
        originalRotation = rectTransform.localRotation;
    }
    private void Start()
    {
        originalScale = rectTransform.localScale;
        originalPosition = rectTransform.localPosition;
        originalRotation = rectTransform.localRotation;
    }
    void Update()
    {
        switch (currentState)
        {
            case 1:
                HandleHoverState();
                break;
            case 2:
                HandleDragState();
                if(!Input.GetMouseButton(0)) //check button is released
                {
                    TransitionToSTate0();
                }
                break;
            case 3:
                HandlePlayState();
                if (!Input.GetMouseButton(0)) //check button is released
                {
                    TransitionToSTate0();
                }
                break;
        }
    }

    private void TransitionToSTate0()
    {
        currentState = 0;
        rectTransform.localScale = originalScale;
        rectTransform.localPosition = originalPosition;
        rectTransform.localRotation = originalRotation;
        glowEffect.SetActive(false);
        playArrow.SetActive(false);
        //Debug.Log("Entered state 0");// debugger
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (currentState == 0)
        {            
            currentState = 1;
            //Debug.Log("state 1"); // debugger
        }
    }
    private void HandlePlayState()
    {
        rectTransform.localPosition = playPosition;
        rectTransform.localRotation = Quaternion.identity;
        
        if (Input.mousePosition.y < cardPlay.y) 
        {
            currentState = 2;
            playArrow.SetActive(false);
            //Debug.Log("state 2"); // debugger
        }
    }

    private void HandleDragState()
    {       
        rectTransform.localRotation = Quaternion.identity;//set the cards rotation to 0
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(currentState == 1) 
        {           
            TransitionToSTate0();
        }
    }
    private void HandleHoverState()
    {
        glowEffect.SetActive(true);
        rectTransform.localScale = originalScale * selectScale;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (currentState == 2)
        {
            Vector2 localPointerPosition;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out localPointerPosition))
            {
                rectTransform.position = Input.mousePosition;
                if (rectTransform.localPosition.y > cardPlay.y)
                { 
                    currentState = 3;
                    playArrow.SetActive(true);
                    rectTransform.localPosition = playPosition;
                    //Debug.Log("state 3"); // debugger
                }
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (currentState == 1)
        {
            currentState = 2;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(),eventData.position,eventData.pressEventCamera, out originalLocalPointerPosition);
            originalPanelLocalPosition = rectTransform.localPosition;
            //Debug.Log("state 2"); // debugger
        }
    }

}
