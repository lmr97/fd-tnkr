using System.Text.Json.Serialization;

namespace SlctdChecklist.Models
{
    public class ShiftTask
    {
        public int Id { get; set; }
        public required string ShortName { get; set; }
        public string? Description { get; set; }

        // Attribute solves a reference loop. 
        // Not normally good practice, because it will cause 
        // the field to be null even without a reference. 
        [JsonIgnore] 
        public List<Segment> ParentSegments { get; } = [];
    }

    // pegged to a ShiftTask within a Segment (which by definition belongs 
    // to strictly one Checklist), making it belong to exclusively one Checklist,
    // as well as one ChecklistSubmission. 
    public class CompletionRecord : ShiftTask
    {
        // public int Id { get; set; }
        // public int ShiftTaskId { get; set; }
        // public required ShiftTask ShiftTask { get; set; }
        // public int SegmentId { get; set; }
        // public required Segment Segment { get; set; }
        // public int SubmissionId { get; set; }
        // public required ChecklistSubmission ParentSubmission { get; set; }
        public bool Done { get; set; } = false;
    }
}