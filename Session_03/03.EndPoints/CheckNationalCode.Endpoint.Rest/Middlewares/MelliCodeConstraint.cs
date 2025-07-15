namespace CheckNationalCode.Endpoint.Rest.Middlewares
{
    public class MelliCodeConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext
                        , IRouter? route
                        , string routeKey
                        , RouteValueDictionary values
                        , RouteDirection routeDirection)
        {
            if (!values.TryGetValue(routeKey, out var value) || value == null)
                return false;

            string melliCode = value.ToString();
            if (!melliCode.All(char.IsDigit)) return false;
            if (melliCode.Length <= 9 && melliCode.Length >= 12) return false;
            int sum = 0;
            if (melliCode.Length == 10)
            {
                for (int i = 0; i < 9; i++)
                {
                    sum = sum + (melliCode[i] - '0') * (10 - i);
                }
                sum = sum % 11;
                int checkDigit = melliCode[9] - '0';
                return (sum < 2 && checkDigit == sum) || (sum >= 2 && checkDigit == (11 - sum));
            }
            else
            {
                sum = sum + (melliCode[0] + melliCode[9] + 2) * 29;
                sum = sum + (melliCode[1] + melliCode[9] + 2) * 27;
                sum = sum + (melliCode[2] + melliCode[9] + 2) * 23;
                sum = sum + (melliCode[3] + melliCode[9] + 2) * 19;
                sum = sum + (melliCode[4] + melliCode[9] + 2) * 17;
                sum = sum + (melliCode[5] + melliCode[9] + 2) * 29;
                sum = sum + (melliCode[6] + melliCode[9] + 2) * 27;
                sum = sum + (melliCode[7] + melliCode[9] + 2) * 23;
                sum = sum + (melliCode[8] + melliCode[9] + 2) * 19;
                sum = sum + (melliCode[9] + melliCode[9] + 2) * 17;

                int rem = sum - ((sum / 11) * 11);
                string srem = rem.ToString();
                if (rem.ToString().Length == 2)
                {
                    if (srem[1].ToString() == melliCode[10].ToString())
                        return true;
                }
                else if (rem.ToString().Length == 1 && rem.ToString() == melliCode[10].ToString())
                    return true;
            }
            return false;
        }
    }
}
