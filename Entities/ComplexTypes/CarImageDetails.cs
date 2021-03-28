using Core.Entities.Abstract;

namespace Entities.ComplexTypes
{
    public class CarImageDetails : IDto  /// Database object
    {
        public int Id { get; set; }
        public string CarName { get; set; }  
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
