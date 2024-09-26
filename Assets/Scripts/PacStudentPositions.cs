using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentPositions : MonoBehaviour
{
    [SerializeField]
    private GameObject item; // <-- assign PacStudent as the item in Unity

    private Animator animator; // <-- need this to change the animator controller state stuff 

    public AudioClip pacStudentMovement; // <-- adding for PacStudent movement audio 

    private AudioSource audioSource; // <-- need an audiosource to play the movement audio clip

    private Tweener tweener;

    private Vector3[] positions = new Vector3[] {
        new Vector3(-6.5f, 10.5f, 0.0f), // <-- bottom right corner
        new Vector3(-11.5f, 10.5f, 0.0f), // <-- bottom left corner
        new Vector3(-11.5f, 14.5f, 0.0f), // <-- top left corner
        new Vector3(-6.5f, 14.5f, 0.0f), // <-- top right corner || putting here instead of first because PacStudent is already here at the start
    };

    private float duration = 3.0f; // <-- 3 second duration to keep a consistent speed

    private int nextPos = 0; // <-- keep track of which position it should move to next
    
    // Start is called before the first frame update
    void Start()
    {
        animator = item.GetComponent<Animator>(); // <-- getting animator from item (PacStudent) for state stuff, not tweening stuff 
        audioSource = item.GetComponent<AudioSource>(); // <-- getting audioSource from item (PacStudent) for movement audio stuff, not tweening stuff
        tweener = GetComponent<Tweener>();
        StartCoroutine(PositionCycle());
    }

    private IEnumerator PositionCycle() { // <-- using this because I want to use a while loop which is bad to put in Update() or something
        while (true) {
            Vector3 endPos = positions[nextPos]; //
            Vector3 startPos = item.transform.position; // <-- getting starting position
            tweener.AddTween(item.transform, startPos, endPos, duration);
            
            //animator.SetBool("moving", true);
            
            if (endPos == positions[0]) {
                animator.Play("Walking_Down"); // <-- was going to set transition parameters but thats more complicated and I gave up and did this instead 
            }
            else if (endPos == positions[1]) {
                animator.Play("Walking_Left");
            }
            else if (endPos == positions[2]) {
                animator.Play("Walking_Up");
            }
            else {
                animator.Play("Walking_Right");
            }

            audioSource.loop = true; // <-- telling it to loop the movement audio
            audioSource.Play(); // <-- start playing the audio

            nextPos = (nextPos + 1) % positions.Length; // <-- need to % by the length because I don't want the number to go past 3 - it'll do 4 % 4 = 0 and go to the first pos
            yield return new WaitForSeconds(duration); // <-- making it wait till the movement is finished (3 seconds)
            
            // v transition back to idle state
            //animator.SetBool("moving", false); <-- i wanted to add this but it makes the animation change back to idle too soon which is a no no and future me can worry about that for the actual game
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
