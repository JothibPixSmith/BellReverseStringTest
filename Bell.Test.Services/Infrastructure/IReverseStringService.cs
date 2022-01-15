namespace Bell.Test.ReverseStringServices.Infrastructure
{
    public interface IReverseStringService
    {
        Task<ReverseString.Domain.ReverseString> ReverseStringForLoop(ReverseString.Domain.ReverseString reverseString);

        Task<ReverseString.Domain.ReverseString> ReverseStringRecursive(ReverseString.Domain.ReverseString reverseString);

        Task<ReverseString.Domain.ReverseString> ReverseStringLinq(ReverseString.Domain.ReverseString reverseString);
    }
}
