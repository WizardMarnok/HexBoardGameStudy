using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// the class holding the GameBoard of these Hextilees can store a MaxQRS[] value to define the limit of actual tiles
// most of these functions will need to know the MaxQRS; should each element of this class hold a reference to its owning GameBoard?


// CLASS handles placed Hextile entities on a GameBoard.
// Type of Hextile and other details are defined elsewhere and recorded here.
// in this way a Hextile may gain or lose properties.

public class Hextile : MonoBehaviour 
{
    // handles indivivual Hextiles by qrs reference; 
    // additional data may relate to these by coord

    public GameObject HextileTileModel;
    public GameObject GameBoard;
    public int[] coords;
    public float size = 1.0f;

    private static Vector3[] direction_vectors = new []{
        new Vector3(1, 0, -1),
        new Vector3(1, -1, 0),
        new Vector3(0, -1, 1),
        new Vector3(-1, 0, 1),
        new Vector3(-1, 1, 0),
        new Vector3(0, 1, -1)
    };

    // qrs relates to position on a certain GameBoard.
    // A game may contain multiple GameBoard objects, active or inactive;
    // cannot find Hextile by coords alone, need GameBoard structure for this to make sense.

    // constructor
    public Hextile(int q, int r, GameObject board, GameObject obj)
    {

        // create logic and mapping

        //coords - calculate s from q&r
        coords = new int[3] {q, r, -q-r};
            // LATER might add y value for elevated Hextilees

        // gameboard - the group of Hextilees this Hextile belongs to.
        GameBoard = board;         

        // Create physicality

        // calculate x,z engine coords from q,r,s true coords
        // (y value can be used directly once implemented)

        float x = size * (1.5f * q);
        float z = size * (Mathf.Sqrt(3)/2 * q  +  Mathf.Sqrt(3) * r);

        GameObject newHextile = Instantiate(obj, new Vector3(x, 1.0f, z), Quaternion.identity);


    }

    public Vector2 get_grid_coords()
    {
        // find the wordlspace coordinates to place the hextile
        float x = size * (1.5f * coords[0]);
        float z = size * (Mathf.Sqrt(3) / 2 * coords[0]  +  Mathf.Sqrt(3) * coords[1]);
        return new Vector2(x, z);
    }


    public bool Equals(Hextile other)
    {
        // Equality would mean, the two Hextilees are the same Hextile on same gameboard. 

        if (other.GameBoard != GameBoard)
            return false;

        return ( (coords[0] == other.coords[0]) && (coords[1] == other.coords[1]) );
    }

    public List<Hextile> GetRawDistance (int range)
    {
        // returns all Hextile in a "crow-fly" distance with no consideration of move costs, visibility, etc

        List<Hextile> Hextilees = new List<Hextile>();


        return Hextilees;

    }

    public Dictionary<Hextile, float> GetMovementRange (float MovementSpeed, string MovementProfile, List<Hextile> RevealedFogOfWar)
    {
        // Returns all Hextilees selected unit can move to from this Hextile, and the float movement cost to move there

        // MAY ALSO NEED TO RETURN COST as at that Hextile
        // MAY ALSO NEED TO RETURN  additional info; do I get wet/damaged/on fire?

        // MovementProfile contains costs to move through terrain types for the selected unit;
        // will probably NOT be a string in final implementation (a Dictionary based on terrain types / features? A whole class to allow multiple variable features?)

        // MovementProfile will need to include other game entities; placed obstables, players, npcs, spell effects(fire, smoke, etc)

        Dictionary<Hextile, float> Hextiles = new Dictionary<Hextile,float>();




        return Hextiles;

    }

    public List<Hextile> GetLOS (float SensoryRange, string SensoryProfile, List<Hextile> RevealedFogOfWar = null)
    {
        // as for MovementRange, Profile will almost certainly NOT be a String

        // (If you need a generic LOS Sensory profile that's fine, but there's no such thing as "default")

        // MAY NEED BOOL Dictionary - for VISIBLE / DETECTABLE vs SHOOTABLE - glass walls, etc
        // In these cases different Profiles might be used when shooting/casting/etc compared to determining Fog Of War effects

        // Need rule for "no Hextile" - if nothing is defined is that free visible, or never visible... or are all off-grid unDictionaryped Hextilees "foggy"

        // BE CAREFUL with zero-cost; need to know if there are any Defined Hextilees in a direction so we don;t try to calculate to
        // infinity across undefined Hextilees just in case there's a Hextile beyond
        // PERHAPS the class holding the GameBoard of these Hextilees can store a MaxQRS[] value to define the limit of actual tiles

        // RevealedFogOfWar no used here...? As this would be used to determine FOW rather than other way around?
        // May end up using it anyway, with a boolean (null or set). 
        // Can see some gameplay cases where revealing FOW is used differently than 

        List<Hextile> Hextiles = new List<Hextile>();


        return Hextiles;

    }


    public int GetRawDistanceTo(Hextile otherHextile)
    {
        // returns raw crowfly distance to another Hextile on the grid

        int RawDistance = 0;



        return RawDistance;

    }



}
