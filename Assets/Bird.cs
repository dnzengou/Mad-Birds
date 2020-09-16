using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{ // setting up the bird's initial position
    Vector3 _initialPosition;  // Access modifier Vector3 with _initialPosition only accessible by this private class
    
    private void Awake()
    {
        _initialPosition = transform.position; 
    }

    private void Update()
    { // IF position of y >goes beyond 10, then
        if (transform.position.y > 10)
        {
            string currentScenceName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScenceName);
        }
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;        
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        // Beware of GetyComponent method, slow and not great for complex games; for simple ones as here is OK though
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * 600); // 100 accelerates the speed of bird's lauch
        GetComponent<Rigidbody2D>().gravityScale = 1; // gravity allows the bird to fall and rebound on earth afer launch. 
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}
