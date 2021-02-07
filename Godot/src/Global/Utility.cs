namespace Global
{
  using Enums;
  using Godot;
  using System.Collections.Generic;
  using System;
  using Newtonsoft.Json;

  public class Utility
  {
    public static Vector2 Vector2FromDirection(DirectionEnum direction)
    {
      switch(direction)
      {
        case DirectionEnum.None: return new Vector2(0, 0);
        case DirectionEnum.North: return new Vector2(0, -1);
        case DirectionEnum.South: return new Vector2(0, 1);
        case DirectionEnum.East: return new Vector2(1, 0);
        case DirectionEnum.West: return new Vector2(-1, 0);
        case DirectionEnum.NorthWest: return new Vector2(-1, -1);
        case DirectionEnum.NorthEast: return new Vector2(1, -1);
        case DirectionEnum.SouthWest: return new Vector2(-1, 1);
        case DirectionEnum.SouthEast: return new Vector2(1, 1);
        default: return new Vector2(0, 0);
      }
    }

    public static DirectionEnum DirectionFromVector2(Vector2 direction)
    {
      float x = direction.x;
      float y = direction.y;
      if(x == 0 && y == 0)
      {
        return DirectionEnum.None;
      }
      if(y > 0)
      {
        if(x < 0)
        {
          return DirectionEnum.SouthWest;
        }
        else if (x > 0)
        {
          return DirectionEnum.SouthEast;
        }
        else
        {
          return DirectionEnum.South;
        }
      }
      else if(y < 0)
      {
        if(x < 0)
        {
          return DirectionEnum.NorthWest;
        }
        else if (x > 0)
        {
          return DirectionEnum.NorthEast;
        }
        else
        {
          return DirectionEnum.North;
        }
      }
      else
      {
        if(x < 0)
        {
          return DirectionEnum.West;
        }
        else if (x > 0)
        {
          return DirectionEnum.East;
        }
        else
        {
          return DirectionEnum.None;
        }
      }
    }

    public static object RayCast(Vector2 start, Vector2 end, List<object> ignored, World2D world)
    {
      Godot.Collections.Array array = new Godot.Collections.Array();
      foreach(object obj in ignored)
      {
        array.Add(obj);
      }

      Physics2DDirectSpaceState spaceState = world.DirectSpaceState;
      var result = spaceState.IntersectRay(start, end, array);
      object ret = null;
      try
      {
        ret = result["collider"];
      }
      catch(Exception e)
      {
        // FIXME: Godot.Collections.Dictionary.ContainsKey is currently broken in this version of godot. Try it out later.
      }
      return ret;
    }

    public static void Dump(string message, object obj){
      GD.Print(message + ToJson(obj));
    }

    // newtonsoft Wrapper
    public static string ToJson(object obj){
      return JsonConvert.SerializeObject(obj, Formatting.Indented);
    }

    public static T FromJson<T>(string json){
      return JsonConvert.DeserializeObject<T>(json);
    }

    }
}
