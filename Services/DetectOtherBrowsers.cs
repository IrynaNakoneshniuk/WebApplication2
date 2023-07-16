namespace WebApplication2.Services
{
    public class DetectOtherBrowsers : IDetectBrowseService
    {
        private int _counter;

        public string DetectBrowse(string browseName, bool hasFavicon)
        {
            if (!browseName.Equals("Opera")&&!browseName.Equals("Chrome")
                && !browseName.Equals("FireFox"))
            {
                this._counter++;

                if (hasFavicon&& this._counter>1 && this._counter > 1)
                {
                    this._counter--;
                }
            }

            return $"Other: {this._counter}";
        }
    }
}
