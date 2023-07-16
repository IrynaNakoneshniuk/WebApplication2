namespace WebApplication2.Services
{
    public class DetectOpera : IDetectBrowseService
    {
        private int _counter;

        public string DetectBrowse(string browseName, bool hasFavicon )
        {
            if (browseName.Equals("Opera"))
            {
                this._counter++;

                if(hasFavicon && this._counter > 1)
                {
                    this._counter--;
                }
            }

            return $"Opera: {this._counter}";   
        }
    }
}
