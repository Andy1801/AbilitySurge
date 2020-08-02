# **Ability Surge**

Created for _GMTK GameJam 2020_ with the theme "Out Of Control", **Ability Surge** is a game where you play a corrupted robot that has to survive the onslaught of forces 
trying to shut you down. Abilities will rotate quickly and you must learn how to utilize them to your advantage to win. The game is still a work in progress, but you can take a look at some of the assets below as well as the progress made so far. We
([@EShoukry](https://github.com/EShoukry) and [@Andy1801](https://github.com/Andy1801)) do not have much experience with art, so much of the animations, effects, and
level design are not complete yet since we are learning as we create them. 

![AbilitySwapMenuGif](https://user-images.githubusercontent.com/35610424/89108119-0231d780-d404-11ea-8dbf-396ce48a73f7.gif)

### Our interface that all the abilities inherit is shown below:

```C#
public interface IAbilities
{
    // Condition for performing the action
    bool actionCondition(GameObject player);

    // Action being performed
    void action(GameObject player);

    //Clean up for the action performed
    void actionCleanUp(GameObject player, bool strictCleanup);

}
```
The action condition has specific checks for each ability that, while the checks are true, will enable the actual action to be taken. 
For instance, for Double Jump, we have a check for the player pressing down the jump button 'W' as well as a check on a boolean value if they can jump at that moment.
If so, we set jumping to true, and return jumping. Since jumping is true, the action() method executes it's code, and we are in a "jumping state."
```C#
if (Input.GetKeyDown(KeyCode.W) && !grounded.getIsGrounded() && canJump)
        {
            jumping = true;
            canJump = false;
            return jumping;
        }
        else if (grounded.getIsGrounded())
        {
            canJump = true;
        }
        return jumping;
```
This is used for all the abilities in order to be able to switch our states at will depending on the criteria the player has to meet. 

### Abilities that we would like to include in the game: 
- [x] Glide 
<img src="https://user-images.githubusercontent.com/35610424/89109078-ffd37b80-d40b-11ea-9d0a-b1c0dc3c213b.gif" width="400">

- [x] Tiny
<img src="https://user-images.githubusercontent.com/35610424/89109076-fea24e80-d40b-11ea-8406-3aaa7e2e7f84.gif" width="400">

- [x] Dash
<img src="https://user-images.githubusercontent.com/35610424/89109071-f3e7b980-d40b-11ea-9cc8-a3e43563471b.gif" width="400">

- [x] Double Jump
<img src="https://user-images.githubusercontent.com/35610424/89109073-fba75e00-d40b-11ea-8c9a-e39110a6aea6.gif" width="400">

- [ ] Teleport
- [ ] Force Punch
- [ ] Shield

