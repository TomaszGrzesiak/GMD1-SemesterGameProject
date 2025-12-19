# Milestone 1 – Core


First-level grid…
…with indestructible tiles and floor + Minimum 5 destructible tiles.
This part has taken a while… Hours to find proper assets. But once it was done, thanks services mentioned in the “sources” in Readme.md, it was manageable. 2D sprites for gym theme are not really popular. But this challenge only added to satisfaction once the assets have been secured! That’s an interesting twist for a feature software engineer.
Drawing the tile map and adding collisions was relatively smooth work, thanks to tutorials at the Unity learning platform.
One player with a simple sprite without animation.
Done very quickly, once the assets where present.
Player can move around the level.
Input system based on tutorial “2D Adventure Game” at Unity learning platform. A fairly straightforward work.
However, I decided to make the movement strictly adhering to the grid, such that the player only walks from a tile center to another tile center, so that they cannot go diagonally or stop in between tiles. There were a couple of tutorials in the Internet, but none that actually worked. It took me roughly 3-4 hours to figure out that it’s better to stick to the simple solutions of an Input system, learned at the mentioned tutorial.
Player can place a weight + Weight slams after 4 seconds.
Now the fun begins.
```csharp

private void TryPlaceWeight()
{
    Vector3Int cell = referenceTileMap.WorldToCell(rigidbody2d.position);
    Vector3 worldCenter = referenceTileMap.GetCellCenterWorld(cell);

    Collider2D hit = Physics2D.OverlapCircle(worldCenter, 0.2f, weightBlockingMask);
    if (hit != null) return;

    var w = Instantiate(weightPrefab, worldCenter, Quaternion.identity)
        .GetComponent<Weight>();

    w.Init(wallsTilemap, destructibleTilemap, blastRange);
}

```

The code shows 1 function of finding a center of a cell, checking if somehow the player isn’t trying to place a dumbbell in an illegal tile, and then instantiating the dumbbell with all the necessary parameters.
Now by this moment I decided to animate the dumbbell, despite it was supposed to be done in the Milestone 2. It looked so much better. But it took 1-2 hours to prepare sprites for animation, and then to set the animation itself.

This needed roughly 20 sprites and to set Sample rate to a much lower value than default, such that the animation covers exactly 4 seconds. Later in the Milestone 3 it would be recommended to split animation into parts and arrange them in the Animator tool with events and parameters such that the animation can last any time from 2 to 6 seconds or more depending on the game settings.
Slam breaks the destructible tiles.
```csharp
Slam (explosion) was a fairly simple class, attached to the explosion objects (showing animation of explosion).
public class Explosion : MonoBehaviour
{
    [SerializeField] private float life = 0.25f;

    private void Start() => Destroy(gameObject, life);
    }

```

But the main logic, again has been covered in the Weight.cs class.
## Just to give an overview, here’s how the coroutine starts
```csharp
private void Start()
{
    StartCoroutine(FuseRoutine());
}

private IEnumerator FuseRoutine()
{
    yield return new WaitForSeconds(fuseSeconds); // Suspends the coroutine execution for the given amount of seconds using scaled time.
    Explode();
    Destroy(gameObject);
}

```

Later, three methods: Explode, ExplodeLine and ExplodeCell are responsible to detect  collided destructible layer tiles and detroy them. They take into account possible higher range of the dumbbell shockwave explosion, such that in the feature development it’d be possible to introduce more power-ups, extending the firepower of the player(s).
Collectable power-ups
At this stage, I introduced only two: Whey Protein and Creatine. They don’t change anything yet in the player’s firepower, since it’s the first Milestone. A Pickup.cs class detects the player collison, destroying it’s object and adding the pickup collectables to the player counter in the GameState.cs singleton class, a store for these and some other publicly available fields.
Collecting both creatine and whey leads to a win.
Once the player has collected both power-ups, they can go and search for an “Exit” door.  The Exit door detetects on collision the player, checks whether they collected all the powerups. If not, a message is being displayed “Locked”. Otherwise, the game is happy to announce “Congrats! You won”!
Game exits to the main menu.
At this point the implementation includes only the message and restarting the state of the game to the beginning. There is no main menu yet. Hopefully in the Milestone 2 it will be available.

## Next milestone to implement
Sounds Effects,
Main menu
A quick introduction to objectives of the game.
## The last milestone
Adding 2 more levels
Adding a multiplayer mode
Adding enemies with AI.
