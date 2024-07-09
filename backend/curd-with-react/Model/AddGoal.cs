namespace curd_with_react.Model
{
    public class AddGoal
    {
        public int id {  get; set; }    
        public string title { get; set; }
        public string description { get; set; } 

        public AddGoal()
        {
            if(title == null)
            {
                title = "";
            }
            if (description == null)
            {
                description = "";
            }
        }
    }
}