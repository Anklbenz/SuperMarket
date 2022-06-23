using System;
using Enums;

public interface IPut
{
    ProductType Type{ get; }
    bool CanPut {get;}
    void Put(Product product);
}