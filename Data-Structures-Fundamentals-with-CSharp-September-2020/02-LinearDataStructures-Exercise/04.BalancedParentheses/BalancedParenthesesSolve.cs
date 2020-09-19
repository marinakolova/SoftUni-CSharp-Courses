namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if (string.IsNullOrEmpty(parentheses) 
                || parentheses.Length % 2 == 1 )
            {
                return false;
            }

            Stack<char> openBrackets = new Stack<char>(parentheses.Length / 2);

            foreach (char currentBracket in parentheses)
            {
                char expectedCharacter = default;

                switch (currentBracket)
                {
                    case ')':
                        expectedCharacter = '(';
                        break;
                    
                    case ']':
                        expectedCharacter = '[';
                        break;
                    
                    case '}':
                        expectedCharacter = '{';
                        break;
                    
                    default:
                        openBrackets.Push(currentBracket);
                        break;
                }

                if (expectedCharacter != default
                    && openBrackets.Pop() != expectedCharacter)
                {
                    return false;
                }
            }

            return openBrackets.Count == 0;
        }
    }
}
