using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// WIP
//Edge Swipe
//Show or Hide Side Panel


public class SidePanel : MonoBehaviour 
{

    public enum SwipeDirection {Left, Right }

    public float xHidePosition;
    public float xShowPosition;
    public SwipeDirection direction = SwipeDirection.Left;
    public bool isShown = false;

    public float edgeMargin = 0.1f;

    public Canvas canvas;
    public RectTransform thisPanel;
    public RectTransform elements;


    private void Start() {
        Vector2 newPosition;

        if (isShown) {
            newPosition = new Vector2(xShowPosition, thisPanel.anchoredPosition.y);
        } else {
            newPosition = new Vector2(xHidePosition, thisPanel.anchoredPosition.y);
        }
        thisPanel.anchoredPosition = newPosition;
    }


    private void Update() {

        if (isShown) {
            Vector2 newPosition = new Vector2(xShowPosition, thisPanel.anchoredPosition.y);
            thisPanel.anchoredPosition = Vector2.Lerp(thisPanel.anchoredPosition, newPosition, 0.2f);
        }
        else {
            Vector2 newPosition = new Vector2(xHidePosition, thisPanel.anchoredPosition.y);
            thisPanel.anchoredPosition = Vector2.Lerp(thisPanel.anchoredPosition, newPosition, 0.2f);
        }

        if (Input.touchCount > 0) {
        
            Touch touch = Input.GetTouch(0);

            ShowHidePanel(touch);

            if (isShown) {
                ScrollPanel(touch);
            }

        } else {
            if (isShown) {
                ResetPosition();
            }
        }
    }

    private void ShowHidePanel(Touch touch) {
        Vector2 touchDelta = touch.deltaPosition;
        float swipeLength = touchDelta.magnitude;

        Vector2 firstTouch = touch.position;
        float screenWidth = Screen.width;

        if (direction == SwipeDirection.Left) {
            if (firstTouch.x / screenWidth > edgeMargin) {
                return;
            }
        } else {
            if (firstTouch.x / screenWidth < edgeMargin) {
                return;
            }
        }

        if (swipeLength < 3) return;



        if (touchDelta.x > 0) {
            if (direction == SwipeDirection.Left) {
                isShown = true;
            } else {
                isShown = false;
            }
        }
        else if (touchDelta.x < 0) {
            if (direction == SwipeDirection.Left) {
                isShown = false;
            } else {
                isShown = true;
            }
        }

        
    }

    private void ScrollPanel(Touch touch) {
        Vector2 touchDelta = touch.deltaPosition;
        elements.anchoredPosition += new Vector2(0, touchDelta.y);
    }

    private void ResetPosition() {
        elements.anchoredPosition = Vector2.Lerp(elements.anchoredPosition, Vector2.zero, 0.2f);
    }

}
