using System;
using Core.Entities.Abstract;

namespace Entities.ComplexTypes
{
    public class RentalDetails : IDto
    {
        public int RentalId { get; set; }
        public string FullName { get; set; }
        /// <summary>
        /// BrandName
        /// </summary>
        public string CarName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}
