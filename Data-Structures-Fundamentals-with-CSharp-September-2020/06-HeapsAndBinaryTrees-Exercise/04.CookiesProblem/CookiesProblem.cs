using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int k, int[] cookies)
        {
            OrderedBag<int> orderedCookies = new OrderedBag<int>();
            
            foreach (var cookie in cookies)
            {
                orderedCookies.Add(cookie);
            }

            int operations = 0;
            int currentCookie = orderedCookies.GetFirst();

            while (currentCookie < k)
            {
                if (orderedCookies.Count <= 1)
                {
                    return -1;
                }
                else
                { 
                    currentCookie = orderedCookies.RemoveFirst() + (2 * orderedCookies.RemoveFirst());
                    orderedCookies.Add(currentCookie);
                    operations++;
                    currentCookie = orderedCookies.GetFirst();
                }
            }

            return operations;
        }
    }
}
