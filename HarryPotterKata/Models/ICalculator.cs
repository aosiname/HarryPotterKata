using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotterKata.Models
{
    public interface ICalculator
    {
        decimal CalculateTotalPrice(Basket basket);
        decimal CalculateSubTotal(Basket basket);
        decimal CalculateDiscount(Basket basket);
    }
}
