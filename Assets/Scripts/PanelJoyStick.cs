﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelJoyStick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField]
    float mMaxDistance = 30f;

    bool mPullstick;
    
    RectTransform mCenterTransform;
    RectTransform mStickTransform;

    private void Awake()
    {
        mCenterTransform = transform.Find("jCenter").GetComponent<RectTransform>();
        mStickTransform = transform.Find("jStick").GetComponent<RectTransform>();

        mPullstick = false;
    }

    private void Update()
    {
        if (mPullstick)
        {
            Vector2 direction;
            GetStickInputInfo(out direction);
            OnEventStickInput(direction);
        }
    }

    private void OnEventStickInput(Vector2 direction)
    {
        UIEventToInGame.Instance.OnEventStickMove(direction);
    }

    private void GetStickInputInfo(out Vector2 direction)
    {
        Vector3 directionVec3 = mStickTransform.position - mCenterTransform.position;
        direction = new Vector2(directionVec3.x, directionVec3.y);
    }

    Vector3 GetInputDirection(bool bNormalize = true)
    {
        Vector3 direction = mStickTransform.position - mCenterTransform.position;
        return bNormalize ? direction.normalized : direction;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        mPullstick = true;
        UpdateStick(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateStick(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        mPullstick = false;
        ResetStickpos();

        UIEventToInGame.Instance.OnEventStickUp();
    }

    private void UpdateStick(PointerEventData eventData = null)
    {
        if (eventData != null)
        {
            mStickTransform.position = eventData.position;
        }

        Vector3 direction = GetInputDirection(false);
        float distance = direction.magnitude;
        direction = direction.normalized;

        if (distance > mMaxDistance)
        {
            mStickTransform.position = mCenterTransform.position + direction * mMaxDistance;
        }
    }
    
    private void ResetStickpos()
    {
        mStickTransform.position = mCenterTransform.position;
        //Vector3 temp = new Vector3(0, 0, 0);
        //mStickTransform.position = temp;
    }
}
