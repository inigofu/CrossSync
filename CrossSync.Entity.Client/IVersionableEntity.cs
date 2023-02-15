using CrossSync.Entity.Abstractions;

namespace CrossSync.Entity
{
  /// <summary>
  /// Versionable entity client side interface
  /// </summary>
  public interface IVersionableEntity : IIdentifiable
  {
    /// <summary>
    /// Gets the entity version.
    /// This property should not be modified by clients application
    /// </summary>
    string Version { get; set; }
        /// <summary>
        /// Gets if the entity is trackable.
        /// Usefull fore child entity which are not need to be tracked
        /// </summary>
         bool IsTrackable { get; set; }
    }
}
