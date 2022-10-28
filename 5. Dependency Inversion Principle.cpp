/*
Rule: High-level modules shouldn't depend on low-level modules. 
      Dependencies between them should be based on abstraction not specific type.



Incorrect implementation:
      Player class below has one relevant method, interactWith(). 
      This method calls the toggleOpen() method of the Door class.
*/
class Player
{
public:
    Player() {}
    
    void interactWith( Door *door )
    {
        if( door )
        {
            door->toggleOpen();
        }
    }
};

class Door
{
public:
    Door() {}
    void toggleOpen() 
    {
        m_open = !m_open;
        if( m_open )
        {
            std::cout << "Door is open" << std::endl;
        }
        else
        {
            std::cout << "Door is closed" << std::endl;
        }
    }
private:
    bool m_open = false;
};


// If the player wants to interact with other objects in the game we'll need to write a separate method for every new object.
// Correct implementation: 
//      The Player class will now only need to know the InteractiveObject interface.

class InteractiveObject
{
public:
    virtual void interact() = 0;
    virtual ~InteractiveObject() = default;
};

class Player
{
public:
    Player() {}
    
    void interactWith( InteractiveObject *obj )
    {
        if( obj )
        {
            obj->interact();
        }
    }
};

class Door : public InteractiveObject
{
public:
    Door() {}
    void interact() override
    {
        m_open = !m_open;
        if (m_open)
        {
            std::cout << "Door is open" << std::endl;
        }
        else
        {
            std::cout << "Door is closed" << std::endl;
        }
    }
private:
    bool m_open = false;
};


// Same problem with templates:

class Player
{
public:
    Player() {}
    
    template <typename InteractiveObject>
    void interactWith( InteractiveObject *obj )
    {
        if( obj )
        {
            obj->interact();
        }
    }
};

class Door
{
public:
    Door() {}
    void interact()
    {
        m_open = !m_open;
        if( m_open )
        {
            std::cout << "Door is open" << std::endl;
        }
        else
        {
            std::cout << "Door is closed" << std::endl;
        }
    }
private:
    bool m_open = false;
};
