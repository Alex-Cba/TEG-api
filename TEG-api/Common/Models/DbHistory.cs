using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEG_api.Common.Models
{
    /// <summary>
    /// History of deletes & sensible data
    /// </summary>
    [Table("DbHistories")]
    public class DbHistory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string TableName { get; set; }
        public string RecordId { get; set; }
        public string? Action { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string Details { get; set; }
    }
}
