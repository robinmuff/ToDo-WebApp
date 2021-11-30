using System.Reflection.Emit;
namespace ToDo_WebApp.Class
{
    public class Task
    {
        public Task() {
            id = -1;
            title = "";
            description = "";
            status = "";
        }
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string status { get; set; }
    }
}
