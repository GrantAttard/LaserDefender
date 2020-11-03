using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float padding = 0.5f;


    float xMin;
    float xMax;

    float yMin;
    float yMax;
    /*
     * In Unity we will be using two methods: Built-in and User-Defined.
     * the unity compiler knows when to execute built-in methods at specific times
     * during game execution
     * Since C# is case sensitive, it is important that we define these Built-in methods with the proper
     * name and proper case
     * 
     * User Defined methods are methods which we create to properly organise our code and avoid from having
     * chunks of code in one place. Since Unity doesn't know about these methods we need to remember to
     * call these methods where they are required.
     */

    // Start is called before the first frame update
    void Start() // A common built-in method
    /* Here we have a method definition for the Start method so that the compiler will know what to execute
     * once it is called.
     * A method definition is made up of the access modifier, return type, method name brackets to include
     * parameters and curly brackets to hold the different statements.
     */
    {
        //print("The Start built-in method has been called!");
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        //print("The Update built-in method is being called!");
        Move();
    }

    void Move() //method definition
    {
        /*format of calling a method with a return 
         * variableToStoreReturn = methodCall();
         * 
         * format to call a method which has not been defined in our class
         * ClassName.MethodName();
         *
         */
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime; // any method which returns a value should be assigned to a variable so that the value is stored and not lost,.
        /*deltaTime is a property which returns the time taken for the previous frame to execute
         * *Since different devices have different frame rates, to make the game frame Independant, we are
         * multiplying the distance generated ( depending on the amount of frames) with the frame duration
         * *and thus, cancelling out the frame rate value.
         /*The GetAxis() method will search from the axis passed as async parameter, and will check what user controls are set e.g. arrow keys and keyboard keys. If the user, presses on any of these 
        keys a value to represent the movement/control is returned.

        /* to change a setting/property for our object, from the code , we need t o use the format
        * object.component.property
 
        * 
        */

        //calculating the new x coordinate by fetching the current x and adding/deducting the value of deltaX\


        var newXPos = Mathf.Clamp(transform.position.x + deltaX * movementSpeed, xMin, xMax);

        transform.position = new Vector3(newXPos, transform.position.y, transform.position.z);

        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime;

        var newYPos = Mathf.Clamp(transform.position.y + deltaY * movementSpeed, yMin, yMax);

        transform.position = new Vector3(newXPos, newYPos, transform.position.z);

    }
    void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;

        /*
         *  ViewportToWorldPoint looks at the current view of the camera and sets the boundaries 
         *  between 0 and 1 at runtime. Thus if we change the camera size, the new boundaries are recalculated
         *  with the same values of min 0 and max 1.
         *  Currently they have specified values and if we use these we need to change the meverytime the
         *  camera is changed.
         */
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

}
