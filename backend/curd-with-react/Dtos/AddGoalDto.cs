namespace curd_with_react.Dtos
{
    public class AddGoalDto
    {
        public string title {  get; set; }  
        public string description { get; set; }

        public AddGoalDto()
        {
            if (title == null)
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
