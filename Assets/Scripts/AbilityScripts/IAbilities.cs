using UnityEngine;

//TODO: Think about making an inhertable class that implements the IAbilites interface and that way the ability classes can have built in functions for shared logic
public interface IAbilities
{
    // Condition for performing the action
    bool actionCondition(GameObject player);

    // Action being performed
    void action(GameObject player);

    //Clean up for the action performed
    void actionCleanUp(GameObject player, bool strictCleanup);

    //Get color
    Color GetColor();

}