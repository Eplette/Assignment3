using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    private Tween activeTween;

    public void AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration) {
        if (activeTween == null) {
            activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
        }
    }

    // Update is called once per frame
    void Update()
    {
      if (activeTween != null)
        {
            float startT = Time.time - activeTween.StartTime;
            float fraction = startT / activeTween.Duration;
            // v convert it to cubic easing-in interpolation
            float cubic = fraction * fraction * fraction; // <-- meant to make it look better or something 

            // v making it a Vector3 so it can be used in the if statements and not right now 
            Vector3 newPosition = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, cubic);

            // v If the activeTween.Target is further than 0.1f units away from the activeTween.EndPos
            if (Vector3.Distance(activeTween.Target.position, activeTween.EndPos) > 0.1f)
            {
                activeTween.Target.position = newPosition;
            }
            else // aka if the activeTween.Target is less than or equal to 0.1f units away from activeTween.EndPos,
            {
                activeTween.Target.position = activeTween.EndPos;
                activeTween = null; 
            }
        }  
    }
}
