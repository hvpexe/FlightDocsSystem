namespace FlightDocsSystem.Helpers
{
    public class Utils
    {
        private static string GetFirstChar(string text)
        {
            var letters = text.Split(" ");
            string result = string.Concat(letters.Select(x => x[0])).ToUpper();
            return result;
        }

        public static string TwoPointToRoute(string loading, string unloading)
        {
            return GetFirstChar(loading.Trim()) + " - " + GetFirstChar(unloading.Trim());
        }
    }
}
