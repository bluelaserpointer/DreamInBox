using System.Collections.Generic;

public static class Player
{
    public static string lastScene;
    public static TransformType transformType;
    public static List<TransformType> transforms = new List<TransformType>();
    public static List<TransformType> completelyUsedTransforms = new List<TransformType>();
    static Player()
    {
        transforms.Add(transformType = TransformType.Normal);
    }
    public static void NextTransform()
    {
        transformType = transforms[(transforms.IndexOf(transformType) + 1) % transforms.Count];
    }

}
