namespace ComplementDrugSearch.Models
{
    /// <summary>
    /// Represents a protein-protein interaction.
    /// </summary>
    public class Interaction
    {
        /// <summary>
        /// Represents the source protein of the interaction.
        /// </summary>
        public Protein SourceProtein { get; set; }

        /// <summary>
        /// Represents the target protein of the interaction.
        /// </summary>
        public Protein TargetProtein { get; set; }

        /// <summary>
        /// Represents the direction of the interaction.
        /// </summary>
        public int Direction { get; set; }

        /// <summary>
        /// Initializes a new default instance of the class.
        /// </summary>
        public Interaction()
        {
            // Assign the default value for each property.
            SourceProtein = null;
            TargetProtein = null;
            Direction = 0;
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="sourceProtein">The source protein of the interaction.</param>
        /// <param name="targetProtein">The target protein of the interaction.</param>
        /// <param name="direction">The direction of the interaction (-1, 0 or +1).</param>
        public Interaction(Protein sourceProtein, Protein targetProtein, int direction)
        {
            // Assign the value for each property.
            SourceProtein = sourceProtein;
            TargetProtein = targetProtein;
            Direction = direction == -1 || direction == 0 || direction == 1 ? direction : 0;
        }
    }
}
