using System;
using System.Text;

namespace ManagementCinemaBookings
{
    public static class HelperMethodsBase64Formatting
    {       
        public static string ConvertToBase64String(this string original)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(original);
            return Convert.ToBase64String(bytes);
        }

        public static string ConvertFromBase64String(this string base64)
        {
            return Encoding.ASCII.GetString(Convert.FromBase64String(base64));
        }        
    }    
}