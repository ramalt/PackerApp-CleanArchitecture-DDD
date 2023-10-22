namespace PackerApp.Shared.Abstractions.Exceptions;

public abstract class PackerAppException : Exception
{
    protected PackerAppException(string msg) : base(msg)
    {
        
    }    
}
