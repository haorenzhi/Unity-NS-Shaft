using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip scoresound;
    private AudioSource source;
    private Rigidbody2D rigidBody;
    private Vector2 leftvelocity;
    private Vector2 rightvelocity;
    private Vector2 zero;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        leftvelocity = new Vector2(-10, -12);
        rightvelocity = new Vector2(10, -12);
        zero = new Vector2(0, -12);
        rigidBody.velocity = zero;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rigidBody.velocity = zero;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.velocity = leftvelocity;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.velocity = rightvelocity;
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ResetScene();
        }
        if (IsTouchedScreen(gameObject)){
            Time.timeScale = 0;
            Termination.showText();
        }
        if (ScoreKeeper.score == 100)
        {
            Time.timeScale = 0;
            Termination.winText();
        }

    }
    private void FixedUpdate()
    {

    }
    private void ResetScene()
    {
        Record.GetRecord();
        ScoreKeeper.ClearScore();
        var curtime = Time.time;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Orb")
        {
            Time.timeScale = 0;
            Termination.showText();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Pedal")
        {
            ScoreKeeper.AddToScore(1);
            source.PlayOneShot(scoresound);
        }
    }

    bool IsTouchedScreen(GameObject obj)
    {
        var position = Camera.main.WorldToScreenPoint(obj.transform.position);
        return position.y < 0 ||  position.y > Screen.height || position.x < 0 || position.x > Screen.width;
    }

}
