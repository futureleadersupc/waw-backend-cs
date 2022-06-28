using WAW.API.Chat.Domain.Models;
using WAW.API.Shared.Domain.Model;

namespace WAW.API.Auth.Domain.Models;

public class User : BaseModel {
  public string FullName { get; set; } = string.Empty;
  public string PreferredName { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string? Location { get; set; }
  public int ProfileViews { get; set; }
  public string? Biography { get; set; }
  public string? About { get; set; }
  public DateTime Birthdate { get; set; }

  // Relationships
  public long CoverId { get; set; }
  public ExternalImage? Cover { get; set; }

  public long PictureId { get; set; }
  public ExternalImage? Picture { get; set; }

  public IList<ChatRoom> ChatRooms { get; set; } = new List<ChatRoom>();
}
