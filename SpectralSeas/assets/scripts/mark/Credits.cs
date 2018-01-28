using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {


    private float offset;
    public float speed = 29.0f;
    public GUIStyle style;
    public Rect viewArea;

    private void Start()
    {
        this.offset = this.viewArea.height;
    }

    private void Update()
    {
        this.offset -= Time.deltaTime * this.speed;
    }

    private void OnGUI()
    {
        GUI.BeginGroup(this.viewArea);

        var position = new Rect(0, this.offset, this.viewArea.width, this.viewArea.height);
        var text = @"
Lead Producer
Mihir Dhanani

Lead Designer
James Hollingsworth


Lead Developer
Mark Vargas

Developers
Sydney Whitehurst
Kevin Vasquez

Lead Artist
Parker (Kobi) Troiani   

Artists
Adam Lobdell
Thomas Castle

Lead Writer
Dean Willhoft

Lead Audio
Emi Arnold
        ";

        style.normal.textColor = Color.white;
        style.fontSize = 32;
        GUI.Label(position, text, this.style);

        GUI.EndGroup();
    }
}
