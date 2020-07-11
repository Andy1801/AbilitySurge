using UnityEngine;

interface IAbilites
{
    // Condition for performing the action
    bool actionCondition(GameObject player);

    // Action being performing 
    void action(GameObject player);

    //Clean up for the action performed
    void actionCleanUp(GameObject player);
}