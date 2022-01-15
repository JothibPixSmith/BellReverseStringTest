using Bell.Test.Infrastructure.Repositories.Interfaces;
using Bell.Test.ReverseStringServices.Infrastructure;

namespace Bell.Test.ReverseStringServices
{
    public class ReverseStringService : IReverseStringService
    {
        private readonly IReverseStringRepository repository;

        public ReverseStringService(IReverseStringRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ReverseString.Domain.ReverseString> ReverseStringForLoop(ReverseString.Domain.ReverseString reverseString)
        {
            var charArray = new char[reverseString.Value.Length];
            for (int i = reverseString.Value.Length - 1; i >= 0; i--)
            {
                charArray[(reverseString.Value.Length - 1) - i] = reverseString.Value[i];
            }

            var newValue = this.CreateNewReversedStringObjet(new string(charArray));

            newValue = await this.repository.SaveReversedString(newValue);

            return newValue;
        }

        public async Task<ReverseString.Domain.ReverseString> ReverseStringLinq(ReverseString.Domain.ReverseString reverseString)
        {
            var newValue = this.CreateNewReversedStringObjet(new string(reverseString.Value.Reverse().ToArray()));

            newValue = await this.repository.SaveReversedString(newValue);

            return newValue;
        }

        public async Task<ReverseString.Domain.ReverseString> ReverseStringRecursive(ReverseString.Domain.ReverseString reverseString)
        {
            var charArray = new char[reverseString.Value.Length];

            var newValue = this.CreateNewReversedStringObjet(this.RecursiveReverse(reverseString.Value, charArray, reverseString.Value.Length - 1));

            newValue = await this.repository.SaveReversedString(newValue);

            return newValue;
        }

        private ReverseString.Domain.ReverseString CreateNewReversedStringObjet(string newValue)
        {
            return new ReverseString.Domain.ReverseString
            {
                Value = newValue
            };
        }

        private string RecursiveReverse(string valueToReverse, char[] charArray, int index)
        {
            charArray[(valueToReverse.Length - 1) - index] = valueToReverse[index];

            if (index == 0)
            {
                return new string(charArray);
            }

            --index;

            return RecursiveReverse(valueToReverse, charArray, index);
        }
    }
}
