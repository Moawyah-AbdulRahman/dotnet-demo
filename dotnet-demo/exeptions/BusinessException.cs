namespace dotnet_demo.exeptions;

[Serializable]
public class BusinessException : Exception
{
    public ErrorCode ErrorCode { get; }
    public string Massage { get; }

    public BusinessException(string massage, ErrorCode errorCode) : base(massage)
    {
        Massage = massage;
        ErrorCode = errorCode;
    }

}
