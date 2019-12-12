using System;
using System.Collections.Generic;
using System.Text;

namespace ComplementDrugSearch.Models
{
    /// <summary>
    /// Represents a protein.
    /// </summary>
    public class Protein
    {
        /// <summary>
        /// Represents the protein index within the network.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Represents the protein name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents the disease essential status of the protein..
        /// </summary>
        public bool IsDiseaseEssential { get; set; }

        /// <summary>
        /// Represents the healthy essential status of the protein..
        /// </summary>
        public bool IsHealthyEssential { get; set; }

        /// <summary>
        /// Initializes a new default instance of the class.
        /// </summary>
        public Protein()
        {
            // Assign the default value for each property.
            Index = 0;
            Name = null;
            IsDiseaseEssential = false;
            IsHealthyEssential = false;
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="name">The name of the protein.</param>
        /// <param name="isDiseaseEssential">The disease essential status of the protein.</param>
        /// <param name="isHealthyEssential">The healthy essential status of the protein.</param>
        public Protein(int index, string name, bool isDiseaseEssential, bool isHealthyEssential)
        {
            // Assign the value for each property.
            Index = index;
            Name = name;
            IsDiseaseEssential = isDiseaseEssential;
            IsHealthyEssential = isHealthyEssential;
        }
    }
}
