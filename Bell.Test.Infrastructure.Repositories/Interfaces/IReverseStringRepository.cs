namespace Bell.Test.Infrastructure.Repositories.Interfaces
{
    public interface IReverseStringRepository
    {
        Task<ReverseString.Domain.ReverseString> RetrieveShortestStringRawSql();
        Task<ReverseString.Domain.ReverseString> RetrieveShortestStringReversedRawSql();
        Task<ReverseString.Domain.ReverseString> RetrieveShortestString();
        Task<ReverseString.Domain.ReverseString> RetrieveShortestStringReversed();

        Task<ReverseString.Domain.ReverseString> SaveReversedString(ReverseString.Domain.ReverseString reversedString);
    }
}
