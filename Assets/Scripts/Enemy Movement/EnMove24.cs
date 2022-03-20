using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnMove24 : MonoBehaviour
{
   private Vector2 pos1;
   private Vector2 pos2;
   public float speed = 1.0f;
   
   void Start()
   {
       pos1 = transform.position;
       pos2 = new Vector2(39, 0);
   }
   void Update() 
   {
       transform.position = Vector2.Lerp (pos1, pos2, Mathf.PingPong(Time.time*speed, 1.0f));
   }
}
