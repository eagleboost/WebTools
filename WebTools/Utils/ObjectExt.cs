namespace WebTools.Utils;

public static class ObjectExt
{
  public static T CastTo<T>(this object obj)
  {
    return (T)obj;
  }
}