public interface IGive
{
    int Count{ get; }
    
    bool CanGive{ get; }
    Product Give();
}