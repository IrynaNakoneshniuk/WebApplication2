using System.Web;
namespace WebApplication2.Services
{
    public class DetectChrome:IDetectBrowseService
    {
        private int _counter;

        public string DetectBrowse(string browseName, bool hasFavicon)
        {
            if (browseName.Equals("Chrome"))
            {

                this._counter++;

                if (hasFavicon && this._counter > 1)
                {
                    this._counter--;
                }
            }

            return $"Chrome:{this._counter}";
        }
    }
}
