using System.Text.Json.Serialization;

namespace SlctdChecklist.Models
{
    public class Segment
    {
        public int Id { get; set; }
        public TimeOnly StartBy { get; set; }
        public TimeOnly DueBy { get; set; }
        public List<ShiftTask> TasksToDo { get; } = [];

        // parent checklist info
        public int ChecklistId { get; set; }
        // Attribute solves a reference loop. 
        // Not normally good practice, because it will cause 
        // the field to be null even without a reference. 
        [JsonIgnore]
        public Checklist Checklist { get; set; } = null!;
    }
}