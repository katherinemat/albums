using System.Collections.Generic;

namespace AlbumCollection.Objects
{
  public class Album
  {
    private string _name;
    private int _id;
    private static List<Album> _instances = new List<Album> {};

    public Album(string albumName)
    {
      _name = albumName;
      _instances.Add(this);
      _id = _instances.Count;
    }
    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Album> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Album Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
