public struct ModelMsg
{
    public string Id;
    public string FirstName;
    public string MsgText;
    public string UpdateId;

    public static string ToString (ModelMsg model)
    {
        return $"{model.Id} {model.FirstName} {model.MsgText} {model.UpdateId}";
    }
}