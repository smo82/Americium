/// <summary>
/// This structure is used for passing the data from a Word object
/// </summary>
public struct WordData
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WordData" /> struct.
    /// </summary>
    /// <param name="originalWord">The Word object that the current struct represents</param>
    public WordData(Word originalWord) : this()
    {
        this.HiddenWord = originalWord.GetHiddenWord;
    }

    /// <summary>
    /// Gets the hidden word
    /// </summary>
    public string HiddenWord { get; private set; }
}