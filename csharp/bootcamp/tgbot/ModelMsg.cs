public struct ModelMsg
{
    public string Id;
    public string FirstName;
    public string MsgText;
    public string UpdateId;

    public override string ToString()
    {
        return $"{Id} {FirstName} {MsgText} {UpdateId}";
    }
}