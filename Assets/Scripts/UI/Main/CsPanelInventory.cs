using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CsPanelInventory : MonoBehaviour
{
    Button mCancel;

    private void Awake()
    {
        mCancel = transform.Find("Cancel").GetComponent<Button>();
        mCancel.onClick.AddListener(RemoteControl);
    }

    private void Update()
    {

    }

    public void RemoteControl()
    {
        if (this.gameObject.active)
            this.gameObject.SetActive(false);
        else
            this.gameObject.SetActive(true);
    }
}
