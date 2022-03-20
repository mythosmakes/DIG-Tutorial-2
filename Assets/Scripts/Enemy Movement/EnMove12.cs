using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnMove12 : MonoBehaviour
{
   private Vector2 pos1;
   private Vector2 pos2;
   public float speed = 1.0f;
   
   void Start()
   {
       pos1 = transform.position;
       pos2 = new Vector2(3, 0.5f);
   }
   void Update() 
   {
       transform.position = Vector2.Lerp (pos1, pos2, Mathf.PingPong(Time.time*speed, 1.0f));
   }
}
