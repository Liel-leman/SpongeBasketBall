using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour {
    public Texture2D InitTexture;
    public Texture2D highlightTexture;
    public Texture2D pressedTexture;
    public CursorMode curMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public bool highlight = false;
    // Use this for initialization
    void Start () {
        Cursor.SetCursor(InitTexture, hotSpot, curMode);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(pressedTexture, hotSpot, curMode);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(InitTexture, hotSpot, curMode);
        }

    }
    
}
