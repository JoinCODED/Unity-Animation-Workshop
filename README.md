# Unity-Animation-Workshop

1. Start a new project. Name it `Animation Workshop`. 
2. Add a quad. Rename it to `Terrain`.
3. Download the cyborg prefab from the `Asset Store` [here](https://assetstore.unity.com/packages/3d/characters/cyborg-character-112661). 
4. Show the cyborg base model in the `Models` folder. Drag and drop him on top of `Terrain`.
5. When playing the game, the body falls through the terrain. That is because it does not have a collider!
6. Add a capsule collider to the `cyborg` model. 
7. Add a rigid body to the `cyborg` model.
8. Attach a new script to the  model. Name it `Player Controller.`
Add the following to the script:
```
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space")){
            rb.AddForce(transform.forward*10000);
        }        
    }


9. Play the game.  When clicking space, the player moves, but there is no animations. 
10. Show the `Animations` folder. This prefab with a bunch of animations. But how to use? 
11. The cyborg has an animator. But it needs an `Animator Controller`. 
12. In the project, right click and add a `Animator Controller`. Name it `Player Animations`. 
13. This will show a menu to create a state machine.
14. Drag and drop the `_cyborg_idle` onto the grid. 
15. Drag and drop the  `_cyborg_walk` animation onto the grid.
16. Right click `idle` and create a transition. Drag the arrow to `Walking`.
17. Click on the arrow. Show that on the right, it expects a "condition".
18. To add a condition, we need to create a Parameter. Choose the parameter to be of type "Bool". Name it `isWalking`.
19. Now, while the transition arrow is highlighted, choose `isWalking`, and choose the value of it to be true. This means that when the character walks, set the value of to be true. Uncheck "Has Exit Time".
20. Back in the Hierarchy, click on the `cyborg` model, drag and drop the `Player Animations` into the `Controller` field of the `Animator` component.
21. Back in the `Player Controller` Script: 
```
    public Animator anim;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space")){
            anim.SetBool("isWalking", true);
            rb.AddForce(transform.forward*10000);
        }        
    }
```
22. Play the game now. The player now walks, but it happens indefinitely. Back in the `Player Animations` Animator controller, we need to add a transition back to walking. 
23. Right click on the `walk` rectangle, then drag the transition back to idle.
24. While the arrow is highlighted, add the condition to the right to be `isWalking` and the value of it to be `false`. 
25. Back in the script, adjust the if condition:
```
      if(Input.GetKey("space")){
            anim.SetBool("isWalking", true);
            rb.AddForce(transform.forward*10000);
        } else {
            anim.SetBool("isWalking", false);
        }
```
26. Everything now should work as expected.
27. Add a new animation `_cyborg_run` animation onto the grid. Make the transitions back and forth between `walk` and `run`.
28. Add a new `Bool` parameter, `isRunning`.
29. Set the conditions between walking and running to be `isRunning` to `true`. Uncheck has exit time. 
30. Set the conditions between running and walking to be `isRunning` to `false`.  Uncheck has exit time. 
31. Back in the script: 
```
    void Update()
    {
        if(Input.GetKey("space")){
            anim.SetBool("isWalking", true);
            anim.SetBool("isRunning", true);
            rb.AddForce(transform.forward*10000);
        } else {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }

    }
```


