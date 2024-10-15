namespace Phader.Debug;
public static class Exceptions
{
    public class SceneKeyNotFoundException(string s) : Exception($"Key {s} was not found in SceneManager! Make sure it was added to the config");
}
