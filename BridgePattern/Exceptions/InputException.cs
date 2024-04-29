namespace BridgePattern.Exeptions;

public sealed class InputDataException : ExceptionBase
{
    public InputDataException(string message) : base(message)
    {

    }

    public override ExceptionKind Kind => ExceptionKind.Error;
}

