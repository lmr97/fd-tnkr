using System.Text.Json.Serialization;

namespace SlctdChecklist.Models 
{
    public enum Shift { AM, PM, Audit }

    public class Checklist
    {
        public int Id { get; set; }
        public int Version { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Shift Shift { get; set; }
        public List<Segment> Segments { get; } = [];
    }

    public class ChecklistSubmission : Checklist
    {
        public required string Employee { get; set; }
        public DateOnly Date { get; set; }
    }
}