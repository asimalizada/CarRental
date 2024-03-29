﻿using Core.Entities;
using Core.Entities.Abstract;

namespace Entities.ComplexTypes
{
    public class CarDetails : IDto
    {
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
