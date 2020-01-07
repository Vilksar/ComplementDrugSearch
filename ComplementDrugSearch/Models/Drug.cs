namespace ComplementDrugSearch.Models
{
    /// <summary>
    /// Represents a drug.
    /// </summary>
    public class Drug
    {
        /// <summary>
        /// Represents the name of the drug.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents the target protein of the drug.
        /// </summary>
        public Protein Protein { get; set; }

        /// <summary>
        /// Represents the direction of the protein when the drug is applied.
        /// </summary>
        public int Direction { get; set; }

        /// <summary>
        /// Initializes a new default instance of the class.
        /// </summary>
        public Drug()
        {
            // Assign the default value for each property.
            Name = null;
            Protein = null;
            Direction = 0;
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="name">The name of the drug.</param>
        /// <param name="protein">The target protein of the drug.</param>
        /// <param name="direction">The direction of the protein when the drug is applied.</param>
        public Drug(string name, Protein protein, int direction)
        {
            // Assign the value for each property.
            Name = name;
            Protein = protein;
            Direction = direction == -1 || direction == 0 || direction == 1 ? direction : 0;
        }
    }
}
