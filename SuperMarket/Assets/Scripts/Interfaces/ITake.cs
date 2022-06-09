using System;
using Enums;

public interface ITake
{
   public event Action ProductPushedEvent;
   ProductType Type{ get; }
   bool CanTake{ get; }
   void Take (Product product) ;
}