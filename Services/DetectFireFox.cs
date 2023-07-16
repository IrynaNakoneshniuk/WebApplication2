namespace WebApplication2.Services
{
    public class DetectFireFox : IDetectBrowseService
    {
        private int _counter;

        public string DetectBrowse(string browseName, bool hasFavicon)
        {
            if (browseName.Equals("FireFox"))
            {
                this._counter++;

                if (hasFavicon && this._counter > 1)
                {
                    this._counter--;
                }
            }
            return $"FireFox: {this._counter}";
        }

       
    }
}
