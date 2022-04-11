using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class synthesis : MonoBehaviour
{
    public int LV;
    public bool down = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Fruit")
            AudioControl.Instance.PlayAudio(AudioControl.Instance.audioClips[1]);
        if (move.Instance.nowFruit != this.gameObject && collision.gameObject.tag == "Fruit")
        {
            //GameObject f1 = move.Instance.nowFruit;
            if (this.LV == collision.gameObject.GetComponent<synthesis>().LV)
            {
                if (this.gameObject.GetInstanceID() > collision.gameObject.GetInstanceID())
                {
                    GameObject newFruit = Instantiate(move.Instance.fruits[this.LV]);
                    newFruit.transform.position = this.gameObject.transform.position;
                    print("boom!");

                    UIscript.Instance.Score += 2 * LV;
                    AudioControl.Instance.PlayAudio(AudioControl.Instance.audioClips[0]);

                    Destroy(this.gameObject);
                    Destroy(collision.gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (move.Instance.nowFruit != this.gameObject && collision.gameObject.name == "line")
        {
            if (down)
            {
                print("game over.");
                SceneManager.LoadScene("SampleScene");
            }

            down = true;
        }
    }
}
