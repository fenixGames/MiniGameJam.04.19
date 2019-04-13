using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverHighlight : MonoBehaviour
{
    private NoodleNPC noodle;
    

    [SerializeField]
    private float growOnMouseOverInPercent;

    private Vector3 normalScale, grownScale;



    private void Awake()
    {
        noodle = GetComponent<NoodleNPC>();
        normalScale = transform.localScale;
        growOnMouseOverInPercent /=100;
        growOnMouseOverInPercent += 1;
        grownScale = new Vector3(normalScale.x * growOnMouseOverInPercent, 
                normalScale.y * growOnMouseOverInPercent,1);
    }

    private void OnMouseEnter()
    {
        if (!noodle.isExausted)
            transform.localScale = grownScale;

    }

    private void OnMouseExit()
    {
        if (!noodle.isExausted)
            transform.localScale = normalScale;
    }



}
