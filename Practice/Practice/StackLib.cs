using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class StackLib
    {
        int LongestValidParentsis(string s)
        {
            Stack<int> stack = new Stack<int>();
            int maxLength = Int32.MinValue;
            for(int i=0; i < s.Length; i++)
            {
                if(s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    if(stack.Count > 0)
                    {
                        stack.Pop();
                    }

                    if (stack.Count > 0)
                    {
                        int j = stack.Peek();
                        maxLength = Math.Max(maxLength, i - j);
                    }
                    else
                    {
                        stack.Push(i);
                    }

                }
            }

            return maxLength;
        }
    }
}


















//Given a string containing just the characters '(' and ')', find the length of the longest valid(well-formed) parentheses substring.
//For "(()", the longest valid parentheses substring is "()", which has length = 2.
//Another example is ")()())", where the longest valid parentheses substring is "()()", which has length = 4